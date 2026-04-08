import { Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatRadioModule } from '@angular/material/radio';
import { CommonModule } from '@angular/common';

@Component({
    selector     : 'job-dialog',
    templateUrl  : './job-dialog.component.html',
    encapsulation: ViewEncapsulation.None,
    standalone   : true,
    imports      : [
        CommonModule,
        MatDialogModule,
        MatIconModule,
        MatButtonModule,
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatDatepickerModule,
        MatRadioModule
    ]
})
export class JobDialogComponent implements OnInit
{
    jobForm: FormGroup;
    jobTypes: any[] = [];
    staff: any[] = [];
    jobStatusMasters: any[] = [];
    customers: any[] = [];
    isGlobalCall: boolean = false;
    isAdmin: boolean = false;
    isEditMode: boolean = false;

    priorityLevels = [
        { id: 0, name: 'Low' },
        { id: 1, name: 'Medium' },
        { id: 2, name: 'High' },
        { id: 3, name: 'Overdue' }
    ];

    periods = [
        { id: 1, name: 'General / One-off' },
        { id: 2, name: 'Daily' },
        { id: 3, name: 'Weekly' },
        { id: 4, name: 'Fortnightly' },
        { id: 5, name: 'Monthly' },
        { id: 6, name: 'Quarterly' },
        { id: 7, name: 'Yearly' }
    ];

    dueDateBasisOptions = ['Days', 'Weeks', 'Months'];

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: any,
        public matDialogRef: MatDialogRef<JobDialogComponent>,
        private _formBuilder: FormBuilder
    )
    {
        this.jobTypes = data.jobTypes || [];
        this.staff = data.staff || [];
        this.jobStatusMasters = data.jobStatusMasters || [];
        this.customers = data.customers || [];
        this.isGlobalCall = data.isGlobalCall || false;
        this.isAdmin = data.isAdmin || false;
        this.isEditMode = !!data.job;
    }

    ngOnInit(): void
    {
        // Create the form
        this.jobForm = this._formBuilder.group({
            customerId  : [this.data.customerId || (this.data.job ? this.data.job.customerId : null), this.isGlobalCall ? Validators.required : null],
            jobTypeId   : [this.data.job ? this.data.job.jobTypeId : null, Validators.required],
            caption     : [this.data.job ? this.data.job.caption : 'General', Validators.required],
            description : [this.data.job ? this.data.job.description : ''],
            priority    : [this.data.job ? this.data.job.priority : 1, Validators.required],
            currentStage: [this.data.job ? this.data.job.currentStage : 1],
            startDate   : [this.data.job ? new Date(this.data.job.startDate) : new Date()],
            targetEndDate: [this.data.job && this.data.job.targetEndDate ? new Date(this.data.job.targetEndDate) : null],
            deadline    : [this.data.job && this.data.job.deadline ? new Date(this.data.job.deadline) : null],
            dueDateDays : [this.data.job ? this.data.job.dueDateDays : 0],
            dueDateBasis: [this.data.job ? this.data.job.dueDateBasis : 'Days'], 
            ownerId     : [this.data.job ? this.data.job.ownerId : (this.data.currentUserId || null)],
            responsibleId: [this.data.job ? this.data.job.responsibleId : null],
            isRecurring : [this.data.job ? this.data.job.isRecurring : false],
            period      : [this.data.job ? this.data.job.period : 1],
            tasks       : this._formBuilder.array([])
        });

        // Lock fields in edit mode
        if (this.isEditMode) {
            this.jobForm.get('customerId').disable();
            this.jobForm.get('isRecurring').disable();
            this.jobForm.get('startDate').disable();
        }

        // If edit mode and has tasks, patch them
        if (this.isEditMode && this.data.job.tasks) {
            this.data.job.tasks.forEach(t => {
                this.tasksArray.push(this._formBuilder.group({
                    id: [t.id],
                    description: [t.description, Validators.required],
                    isCompleted: [t.isCompleted],
                    sequence: [t.sequence]
                }));
            });
        }
    }

    /**
     * Handle category change (Single vs Recurring)
     */
    onCategoryChange(isRecurring: boolean): void
    {
        if (isRecurring)
        {
            this.jobForm.get('period').setValue(3); // Default to Weekly for recurring
            this.tasksArray.clear(); // Clear tasks for recurring jobs
        }
        else
        {
            this.jobForm.get('period').setValue(1); // Reset to General
        }
    }

    newTaskText: string = '';

    get tasksArray(): any
    {
        return this.jobForm.get('tasks');
    }

    addTask(): void
    {
        if (this.newTaskText && this.newTaskText.trim() !== '')
        {
            this.tasksArray.push(this._formBuilder.group({
                description: [this.newTaskText.trim(), Validators.required],
                isCompleted: [false],
                sequence: [this.tasksArray.length + 1]
            }));
            this.newTaskText = '';
        }
    }

    removeTask(index: number): void
    {
        this.tasksArray.removeAt(index);
    }

    save(): void
    {
        if (this.jobForm.invalid)
        {
            return;
        }

        // Get value including disabled fields (like customerId)
        const result = this.jobForm.getRawValue();
        this.matDialogRef.close(result);
    }

    close(): void
    {
        this.matDialogRef.close();
    }
}
