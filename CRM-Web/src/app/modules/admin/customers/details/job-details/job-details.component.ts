import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, OnDestroy, OnInit, Output, ViewEncapsulation, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { Job, JobTask, JobComment } from '../../../jobs/job.types';
import { JobService } from '../../../jobs/job.service';
import { UserService } from 'app/core/user/user.service';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTabsModule } from '@angular/material/tabs';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDividerModule } from '@angular/material/divider';
import { MatTooltipModule } from '@angular/material/tooltip';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialog } from '@angular/material/dialog';
import { MatDialogModule } from '@angular/material/dialog';
import { CustomerPreviewDialogComponent } from '../../customer-preview-dialog/customer-preview-dialog.component';

@Component({
    selector       : 'job-details',
    templateUrl    : './job-details.component.html',
    encapsulation  : ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    standalone     : true,
    styles: [`
        .status-group-header .mat-mdc-optgroup-label {
            font-size: 10px !important;
            font-weight: 800 !important;
            text-transform: uppercase !important;
            letter-spacing: 0.05em !important;
            color: var(--fuse-text-secondary) !important;
            background-color: var(--fuse-bg-subtle) !important;
            min-height: 28px !important;
            line-height: 28px !important;
            margin-top: 4px !important;
        }
        .status-group-header .mat-mdc-option {
            min-height: 36px !important;
        }
    `],
    imports        : [
        CommonModule,
        MatButtonModule,
        MatIconModule,
        MatTabsModule,
        MatFormFieldModule,
        MatInputModule,
        MatCheckboxModule,
        MatDividerModule,
        MatTooltipModule,
        FormsModule,
        ReactiveFormsModule,
        MatSelectModule
    ]
})
export class JobDetailsComponent implements OnInit, OnDestroy
{
    @Input() jobId: number;
    @Input() statusMasters: any[] = [];
    @Input() jobTypeStatusMappings: any[] = [];
    @Output() closed = new EventEmitter<void>();
    @Output() jobUpdated = new EventEmitter<void>();
    
    statusGroups: { name: string, statuses: any[] }[] = [];

    private _statusPhases: { [key: number]: string } = {
        // Phase 1: Preparation
        1: 'Preparation', 2: 'Preparation', 13: 'Preparation', 15: 'Preparation', 19: 'Preparation', 
        20: 'Preparation', 24: 'Preparation', 25: 'Preparation', 37: 'Preparation', 38: 'Preparation', 
        46: 'Preparation', 48: 'Preparation', 51: 'Preparation',
        // Phase 2: Review & Checking
        3: 'Review & Checking', 4: 'Review & Checking', 14: 'Review & Checking', 16: 'Review & Checking', 
        17: 'Review & Checking', 18: 'Review & Checking', 22: 'Review & Checking', 
        30: 'Review & Checking', 47: 'Review & Checking',
        // Phase 3: Lodgement
        5: 'Lodgement', 6: 'Lodgement', 21: 'Lodgement', 28: 'Lodgement', 29: 'Lodgement', 
        40: 'Lodgement', 41: 'Lodgement',
        // Phase 4: Assessment & Processing
        7: 'Assessment & Processing', 44: 'Assessment & Processing',
        // Phase 5: Completion
        8: 'Completion', 11: 'Completion', 12: 'Completion', 23: 'Completion', 31: 'Completion', 
        32: 'Completion', 42: 'Completion', 43: 'Completion', 45: 'Completion', 
        49: 'Completion', 50: 'Completion',
        // Phase 6: Issues / On Hold
        9: 'Issues / On Hold', 10: 'Issues / On Hold', 26: 'Issues / On Hold', 27: 'Issues / On Hold', 
        33: 'Issues / On Hold', 34: 'Issues / On Hold', 35: 'Issues / On Hold', 36: 'Issues / On Hold', 
        39: 'Issues / On Hold'
    };

    job: Job;
    commentForm: FormGroup;
    taskForm: FormGroup;
    isLoading: boolean = true;
    currentUserId: number | null = null;
    isGlobalAdmin: boolean = false;
    
    recurringModes = [
        { id: 'Weekly', name: 'Weekly' },
        { id: 'Fortnightly', name: 'Fortnightly' },
        { id: 'Monthly', name: 'Monthly' },
        { id: 'Quarterly', name: 'Quarterly' },
        { id: 'Yearly', name: 'Yearly' }
    ];

    private _changeDetectorRef = inject(ChangeDetectorRef);
    private _formBuilder = inject(FormBuilder);
    private _jobService = inject(JobService);
    private _userService = inject(UserService);
    private _matDialogData = inject(MAT_DIALOG_DATA, { optional: true });
    private _matDialogRef = inject(MatDialogRef<JobDetailsComponent>, { optional: true });
    private _matDialog = inject(MatDialog);
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    /**
     * Constructor
     */
    constructor()
    {
        // Prepare forms
        this.commentForm = this._formBuilder.group({
            comment: ['', Validators.required]
        });

        this.taskForm = this._formBuilder.group({
            task: ['', Validators.required]
        });
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
        if (this._matDialogData) {
            this.jobId = this._matDialogData.jobId;
            this.statusMasters = this._matDialogData.statusMasters;
            this.jobTypeStatusMappings = this._matDialogData.jobTypeStatusMappings;
        }

        // Get current user
        this._userService.user$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((user) => {
                if (user) {
                    this.currentUserId = Number(user.id);
                    this.isGlobalAdmin = user.isSuperAdmin === true || user.isAdmin === true;
                }
            });

        if (this.jobId)
        {
            this.loadJob();
        }
    }



    /**
     * On destroy
     */
    ngOnDestroy(): void
    {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Get the current phase name for the job
     */
    get currentPhase(): string {
        if (!this.job) return 'Unknown';
        return this._statusPhases[this.job.currentStage] || 'Other';
    }

    /**
     * Get all phase names in order
     */
    get phases(): string[] {
        return [
            'Preparation', 
            'Review & Checking', 
            'Lodgement', 
            'Assessment & Processing', 
            'Completion'
        ];
    }

    /**
     * Get the index of the current phase (0-4)
     */
    get currentPhaseIndex(): number {
        const phase = this.currentPhase;
        const index = this.phases.indexOf(phase);
        // If it's "Issues" or "Other", we'll just return -1 or keep it as is
        return index;
    }

    /**
     * Load job details
     */
    loadJob(): void
    {
        this.isLoading = true;
        this._changeDetectorRef.markForCheck();
        
        this._jobService.getJob(this.jobId)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((job) => {
                this.job = job;
                this.updateFilteredStatuses();
                this.isLoading = false;
                this._changeDetectorRef.markForCheck();
            });
    }

    /**
     * Update the list of selectable statuses based on current job's type
     */
    updateFilteredStatuses(): void {
        if (!this.job) return;
        
        const filtered = this._jobService.getFilteredStatuses(
            this.job.jobTypeId,
            this.statusMasters,
            this.jobTypeStatusMappings
        );

        // Group the statuses by phase
        const groups: { [key: string]: any[] } = {};
        filtered.forEach(status => {
            const phase = this._statusPhases[status.id] || 'Other';
            if (!groups[phase]) {
                groups[phase] = [];
            }
            groups[phase].push(status);
        });

        // Convert to array of groups for the template
        const phaseOrder = [
            'Preparation', 
            'Review & Checking', 
            'Lodgement', 
            'Assessment & Processing', 
            'Completion', 
            'Issues / On Hold',
            'Other'
        ];

        this.statusGroups = phaseOrder
            .filter(phase => groups[phase] && groups[phase].length > 0)
            .map(phase => ({
                name: phase,
                statuses: groups[phase]
            }));
    }

    /**
     * Update job status
     */
    updateStatus(statusId: number): void
    {
        if (!this.job || this.job.currentStage === statusId) return;

        // Optimistic update
        const oldStage = this.job.currentStage;
        const oldStatusName = this.job.statusName;
        
        this.job.currentStage = statusId;
        const newStatus = this.statusMasters.find(s => s.id === statusId);
        this.job.statusName = newStatus ? newStatus.statusName : 'Unknown';
        
        this._jobService.updateJob(this.job.id, this.job)
            .subscribe({
                next: () => {
                    this.jobUpdated.emit();
                    this.loadJob(); // Reload to get updated history
                },
                error: () => {
                    // Rollback
                    this.job.currentStage = oldStage;
                    this.job.statusName = oldStatusName;
                    this._changeDetectorRef.markForCheck();
                }
            });
    }
    
    /**
     * Update recurring mode
     */
    updateRecurringMode(mode: string): void
    {
        if (!this.job || this.job.recurringMode === mode) return;

        this.job.recurringMode = mode;
        this._jobService.updateJob(this.job.id, this.job)
            .subscribe({
                next: () => {
                    this.jobUpdated.emit();
                    this.loadJob();
                },
                error: () => {
                    this.loadJob(); // Reset UI
                }
            });
    }



    /**
     * Toggle task status
     */
    toggleTask(task: JobTask): void
    {
        this._jobService.toggleTask(task.id)
            .subscribe(() => {
                task.isCompleted = !task.isCompleted;
                this._changeDetectorRef.markForCheck();
            });
    }

    /**
     * Add task
     */
    addTask(): void
    {
        if (this.taskForm.invalid) return;

        const description = this.taskForm.get('task').value;
        this._jobService.addTask(this.jobId, description)
            .subscribe((newTask) => {
                if (!this.job.tasks) this.job.tasks = [];
                this.job.tasks.push(newTask);
                this.taskForm.reset();
                this._changeDetectorRef.markForCheck();
            });
    }

    /**
     * Delete task
     */
    deleteTask(taskId: number): void
    {
        this._jobService.deleteTask(taskId)
            .subscribe(() => {
                this.job.tasks = this.job.tasks.filter(t => t.id !== taskId);
                this._changeDetectorRef.markForCheck();
            });
    }

    /**
     * Add comment
     */
    addComment(): void
    {
        if (this.commentForm.invalid) return;

        const text = this.commentForm.get('comment').value;
        this._jobService.addComment(this.jobId, text)
            .subscribe((newComment) => {
                if (!this.job.comments) this.job.comments = [];
                this.job.comments.unshift(newComment);
                this.commentForm.reset();
                this._changeDetectorRef.markForCheck();
            });
    }

    /**
     * Delete comment (only owner or admin)
     */
    deleteComment(commentId: number): void
    {
        this._jobService.deleteComment(commentId)
            .subscribe(() => {
                this.job.comments = this.job.comments.filter(c => c.id !== commentId);
                this._changeDetectorRef.markForCheck();
            });
    }

    /**
     * Check if the current user can delete a comment
     */
    canDeleteComment(comment: any): boolean {
        return this.isGlobalAdmin || comment.userId === this.currentUserId;
    }

    /**
     * Check if the current user can change the job status
     */
    canChangeStatus(): boolean {
        // Everyone can change status in the new "Open Edit" logic
        return true;
    }

    /**
     * Close the Job Details view (Drawer or Dialog)
     */
    close(): void {
        this.closed.emit();
        if (this._matDialogRef) {
            this._matDialogRef.close();
        }
    }

    /**
     * Open Customer Preview Dialog
     */
    goToCustomer(customerId: number): void {
        if (!customerId) return;
        
        this._matDialog.open(CustomerPreviewDialogComponent, {
            data: { customerId },
            width: '550px',
            maxHeight: '90vh',
            panelClass: 'customer-preview-dialog-panel'
        });
    }
}
