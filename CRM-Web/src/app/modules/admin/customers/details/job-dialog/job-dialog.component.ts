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
    }

    ngOnInit(): void
    {
        // Create the form
        this.jobForm = this._formBuilder.group({
            customerId  : [this.data.customerId],
            jobTypeId   : [null, Validators.required],
            caption     : ['', Validators.required],
            description : [''],
            priority    : [1, Validators.required], // Default to Medium
            currentStage: [1], // Default to Not Yet In (or current status)
            startDate   : [new Date()],
            targetEndDate: [null],
            deadline    : [null], // We'll keep this if needed or repurpose for due date
            dueDateDays : [0],
            dueDateBasis: ['Days'], 
            ownerId     : [null], // Staff in charge (Owner)
            isRecurring : [false],
            period      : [1], // 1: General
            tasks       : this._formBuilder.array([]) // Inline To-Dos for single jobs
        });
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

        this.matDialogRef.close(this.jobForm.value);
    }

    close(): void
    {
        this.matDialogRef.close();
    }
}
