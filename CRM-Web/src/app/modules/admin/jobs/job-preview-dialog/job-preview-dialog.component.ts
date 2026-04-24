import { Component, Inject, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule, ReactiveFormsModule, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { JobService } from '../job.service';
import { Job, JobTask, JobComment } from '../job.types';
import { UserService } from 'app/core/user/user.service';
import { CustomerPreviewDialogComponent } from '../../customers/customer-preview-dialog/customer-preview-dialog.component';

@Component({
    selector: 'job-preview-dialog',
    templateUrl: './job-preview-dialog.component.html',
    standalone: true,
    imports: [
        CommonModule,
        MatDialogModule,
        MatButtonModule,
        MatIconModule,
        MatDividerModule,
        MatTooltipModule,
        MatProgressSpinnerModule,
        MatSelectModule,
        MatFormFieldModule,
        MatInputModule,
        MatCheckboxModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class JobPreviewDialogComponent implements OnInit {
    job: Job | null = null;
    isLoading = true;
    isAdmin = false;
    currentUserId: number | null = null;
    staff: any[] = [];
    statusMasters: any[] = [];
    jobTypeStatusMappings: any[] = [];
    filteredStatuses: any[] = [];

    commentForm: FormGroup;
    taskForm: FormGroup;

    private _jobService = inject(JobService);
    private _userService = inject(UserService);
    private _matDialog = inject(MatDialog);
    private _fb = inject(FormBuilder);

    recurringHistory: Job[] = [];
    activeJobId: number;

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {
            jobId: number;
            statusMasters: any[];
            jobTypeStatusMappings: any[];
            staff: any[];
            isAdmin: boolean;
        },
        public dialogRef: MatDialogRef<JobPreviewDialogComponent>
    ) {
        this.activeJobId = data.jobId;
        this.isAdmin = data.isAdmin || false;
        this.staff = data.staff || [];
        this.statusMasters = data.statusMasters || [];
        this.jobTypeStatusMappings = data.jobTypeStatusMappings || [];

        this.commentForm = this._fb.group({ comment: ['', Validators.required] });
        this.taskForm = this._fb.group({ task: ['', Validators.required] });
    }

    ngOnInit(): void {
        this._userService.user$.subscribe(user => {
            if (user) this.currentUserId = Number(user.id);
        });

        this.loadJob(this.activeJobId);
    }

    loadJob(jobId: number): void {
        this.isLoading = true;
        this.activeJobId = jobId;
        this._jobService.getJob(jobId).subscribe({
            next: (job) => {
                this.job = job;
                this.mapStaffNames();
                this.updateFilteredStatuses();
                
                // If recurring, fetch history
                if (this.job.isRecurring) {
                    this._jobService.getRecurringHistory(jobId).subscribe(history => {
                        this.recurringHistory = history;
                    });
                } else {
                    this.recurringHistory = [];
                }

                this.isLoading = false;
            },
            error: () => {
                this.isLoading = false;
            }
        });
    }

    switchJob(jobId: number): void {
        if (jobId === this.activeJobId) return;
        this.loadJob(jobId);
    }

    private mapStaffNames(): void {
        if (!this.job || !this.staff.length) return;
        if (this.job.ownerId) {
            const s = this.staff.find(x => x.id === this.job.ownerId);
            this.job.staffName = s ? `${s.firstName} ${s.lastName ?? ''}`.trim() : 'Unassigned';
        }
        if (this.job.responsibleId) {
            const s = this.staff.find(x => x.id === this.job.responsibleId);
            this.job.responsibleName = s ? `${s.firstName} ${s.lastName ?? ''}`.trim() : 'Unassigned';
        }
    }

    updateFilteredStatuses(): void {
        if (!this.job) return;
        this.filteredStatuses = this._jobService.getFilteredStatuses(
            this.job.jobTypeId,
            this.statusMasters,
            this.jobTypeStatusMappings
        );
    }

    get priorityLabel(): string {
        if (!this.job) return '';
        switch (this.job.priority) {
            case 0: return 'Low';
            case 1: return 'Medium';
            case 2: return 'High';
            case 3: return 'Urgent';
            default: return 'Unknown';
        }
    }

    get priorityClass(): string {
        if (!this.job) return '';
        switch (this.job.priority) {
            case 0: return 'bg-gray-100 text-gray-600';
            case 1: return 'bg-blue-100 text-blue-700';
            case 2: return 'bg-amber-100 text-amber-700';
            case 3: return 'bg-rose-100 text-rose-700';
            default: return 'bg-gray-100 text-gray-600';
        }
    }

    get completedTasks(): number {
        return this.job?.tasks?.filter(t => t.isCompleted).length || 0;
    }

    get totalTasks(): number {
        return this.job?.tasks?.length || 0;
    }

    // --- Interactive Actions ---

    updateStatus(newStatusId: number): void {
        if (!this.job) return;
        const updated = { ...this.job, currentStage: newStatusId };
        this._jobService.updateJob(this.job.id, updated).subscribe(() => {
            this.loadJob(this.activeJobId);
        });
    }

    toggleTask(task: JobTask): void {
        this._jobService.toggleTask(task.id).subscribe(() => {
            task.isCompleted = !task.isCompleted;
        });
    }

    addTask(): void {
        if (this.taskForm.invalid || !this.job) return;
        const desc = this.taskForm.get('task')?.value;
        this._jobService.addTask(this.job.id, desc).subscribe((newTask) => {
            if (!this.job!.tasks) this.job!.tasks = [];
            this.job!.tasks.push(newTask);
            this.taskForm.reset();
        });
    }

    deleteTask(taskId: number): void {
        this._jobService.deleteTask(taskId).subscribe(() => {
            if (this.job?.tasks) {
                this.job.tasks = this.job.tasks.filter(t => t.id !== taskId);
            }
        });
    }

    addComment(): void {
        if (this.commentForm.invalid || !this.job) return;
        const text = this.commentForm.get('comment')?.value;
        this._jobService.addComment(this.job.id, text).subscribe((newComment) => {
            if (!this.job!.comments) this.job!.comments = [];
            this.job!.comments.unshift(newComment);
            this.commentForm.reset();
        });
    }

    deleteComment(commentId: number): void {
        this._jobService.deleteComment(commentId).subscribe(() => {
            if (this.job?.comments) {
                this.job.comments = this.job.comments.filter(c => c.id !== commentId);
            }
        });
    }

    canDeleteComment(comment: any): boolean {
        return this.isAdmin || comment.userId === this.currentUserId;
    }

    openCustomerPreview(): void {
        if (!this.job?.customerId) return;
        this._matDialog.open(CustomerPreviewDialogComponent, {
            data: { customerId: this.job.customerId },
            width: '550px',
            maxHeight: '90vh'
        });
    }

    openEditDialog(): void {
        if (!this.job) return;
        this.dialogRef.close('edit');
    }

    close(): void {
        this.dialogRef.close();
    }
}
