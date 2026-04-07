import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, OnDestroy, OnInit, Output, ViewEncapsulation, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { Job, JobTask, JobComment } from '../../../jobs/job.types';
import { JobService } from '../../../jobs/job.service';
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

@Component({
    selector       : 'job-details',
    templateUrl    : './job-details.component.html',
    encapsulation  : ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    standalone     : true,
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
    @Output() closed = new EventEmitter<void>();
    @Output() jobUpdated = new EventEmitter<void>();

    job: Job;
    commentForm: FormGroup;
    taskForm: FormGroup;
    isLoading: boolean = true;

    private _changeDetectorRef = inject(ChangeDetectorRef);
    private _formBuilder = inject(FormBuilder);
    private _jobService = inject(JobService);
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
                this.isLoading = false;
                this._changeDetectorRef.markForCheck();
            });
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
     * Close the drawer
     */
    close(): void
    {
        this.closed.emit();
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
}
