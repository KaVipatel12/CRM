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
import { MatDividerModule } from '@angular/material/divider';
import { CommonModule } from '@angular/common';
import { SearchableSelectComponent } from 'app/shared/components/searchable-select/searchable-select.component';

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
        MatRadioModule,
        MatDividerModule,
        SearchableSelectComponent
    ]
})
export class JobDialogComponent implements OnInit
{
    jobForm: FormGroup;
    jobTypes: any[] = [];
    staff: any[] = [];
    jobStatusMasters: any[] = [];
    allStatusMasters: any[] = [];
    jobTypeStatusMappings: any[] = [];
    filteredStatuses: any[] = [];
    customers: any[] = [];
    isGlobalCall: boolean = false;
    isAdmin: boolean = false;
    isEditMode: boolean = false;
    isMultiMode: boolean = false;
    isInternal: boolean = false;
    isRecurring: boolean = false;

    priorityLevels = [
        { id: 0, name: 'Low' },
        { id: 1, name: 'Medium' },
        { id: 2, name: 'High' },
        { id: 3, name: 'Overdue' }
    ];

    recurringModes = [
        { id: 'Weekly', name: 'Weekly' },
        { id: 'Fortnightly', name: 'Fortnightly' },
        { id: 'Monthly', name: 'Monthly' },
        { id: 'Quarterly', name: 'Quarterly' },
        { id: 'Yearly', name: 'Yearly' }
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
        this.allStatusMasters = data.jobStatusMasters || [];
        this.jobTypeStatusMappings = data.jobTypeStatusMappings || [];
        this.customers = data.customers || [];
        this.isGlobalCall = data.isGlobalCall || false;
        this.isAdmin = data.isAdmin || false;
        this.isEditMode = !!data.job;
        this.isMultiMode = data.isMultiMode || false;
        this.isInternal = this.isMultiMode ? false : (data.isInternal || (data.job?.isInternal) || false);
        this.isRecurring = data.job?.isRecurring || false;
    }

    ngOnInit(): void
    {
        // Create the form
        this.jobForm = this._formBuilder.group({
            customerId  : [this.data.customerId || (this.data.job ? this.data.job.customerId : null), (this.isGlobalCall && !this.isMultiMode) ? Validators.required : null],
            customerIds : [this.isMultiMode ? [] : null, (this.isGlobalCall && this.isMultiMode) ? Validators.required : null],
            jobTypeId   : [this.data.job ? this.data.job.jobTypeId : null, Validators.required],
            caption     : [this.data.job ? this.data.job.caption : 'General', Validators.required],
            description : [this.data.job ? this.data.job.description : ''],
            priority    : [this.data.job ? this.data.job.priority : 1, Validators.required],
            currentStage: [this.data.job ? this.data.job.currentStage : 1],
            startDate   : [this.data.job ? new Date(this.data.job.startDate) : new Date()],
            targetEndDate: [this.data.job && this.data.job.targetEndDate ? new Date(this.data.job.targetEndDate) : null],
            deadline    : [this.data.job && this.data.job.deadline ? new Date(this.data.job.deadline) : null],
            dueDateDays : [this.data.job ? this.data.job.dueDateDays : 0, [Validators.min(0)]],
            dueDateBasis: [this.data.job ? this.data.job.dueDateBasis : 'Days'],             ownerId     : [this.data.job ? this.data.job.ownerId : (this.data.currentUserId || null)],
            responsibleId: [this.data.job ? this.data.job.responsibleId : null],
            isRecurring : [this.data.job ? this.data.job.isRecurring : false],
            recurringMode: [this.data.job ? this.data.job.recurringMode : 'Monthly'],
            isInternal  : [this.isInternal],
            period      : [this.data.job ? this.data.job.period : 1],
            tasks       : this._formBuilder.array([])
        });

        // Watch for Start Date changes to validate dependent dates
        this.jobForm.get('startDate').valueChanges.subscribe((startDate) => {
            if (startDate) {
                const start = new Date(startDate);
                const deadline = this.jobForm.get('deadline').value;
                const targetEndDate = this.jobForm.get('targetEndDate').value;
                
                if (deadline && new Date(deadline) < start) {
                    this.jobForm.get('deadline').setValue(null);
                }
                if (targetEndDate && new Date(targetEndDate) < start) {
                    this.jobForm.get('targetEndDate').setValue(null);
                }
            }
        });

        // Filter statuses initially
        this._filterStatuses(this.jobForm.get('jobTypeId').value);

        // Watch for job type changes
        this.jobForm.get('jobTypeId').valueChanges.subscribe((typeId) => {
            this._filterStatuses(typeId);
            // Optional: reset stage if current one is not in the new list
            const currentStage = this.jobForm.get('currentStage').value;
            if (currentStage && !this.filteredStatuses.find(s => s.id === currentStage)) {
                this.jobForm.get('currentStage').setValue(this.filteredStatuses[0]?.id || null);
            }
        });

        // Set customerId validator based on mode
        this._updateCustomerValidator();

        // Lock fields in edit mode
        if (this.isEditMode) {
            this.jobForm.get('customerId').disable();
            this.jobForm.get('jobTypeId').disable();
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

        // Map staff names for searchable select
        this.staff = this.staff.map(s => ({
            ...s,
            name: `${s.firstName} ${s.lastName}`
        }));
    }

    /**
     * Handle category change (Single vs Recurring)
     */
    onCategoryChange(isRecurring: boolean): void
    {
        this.isRecurring = isRecurring;
        this.jobForm.get('isRecurring').setValue(isRecurring);
        if (isRecurring)
        {
            this.jobForm.get('period').setValue(1); // New recurring jobs always start at Period 1
            this.tasksArray.clear(); // Clear tasks for recurring jobs
        }
        else
        {
            this.jobForm.get('period').setValue(1); // Reset to General
        }
    }

    /**
     * Toggle Internal mode
     */
    toggleInternal(isInternal: boolean): void
    {
        this.isInternal = isInternal;
        this.jobForm.get('isInternal').setValue(isInternal);
        this._updateCustomerValidator();
    }

    private _updateCustomerValidator(): void
    {
        const customerIdControl = this.jobForm.get('customerId');
        if (this.isInternal || this.isMultiMode || !this.isGlobalCall)
        {
            customerIdControl.clearValidators();
        }
        else
        {
            customerIdControl.setValidators(Validators.required);
        }
        customerIdControl.updateValueAndValidity();
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

    /**
     * Select/Deselect all customers
     */
    toggleAllCustomers(all: boolean): void
    {
        if (all)
        {
            this.jobForm.get('customerIds').setValue(this.customers.map(c => c.id));
        }
        else
        {
            this.jobForm.get('customerIds').setValue([]);
        }
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

    private _filterStatuses(jobTypeId: any): void
    {
        if (!jobTypeId) {
            this.filteredStatuses = [...this.allStatusMasters];
            return;
        }

        const id = Number(jobTypeId);
        const allowedStatusIds = this.jobTypeStatusMappings
            .filter(m => Number(m.jobTypeId) === id)
            .sort((a, b) => (a.displayOrder || 0) - (b.displayOrder || 0))
            .map(m => m.jobStatusMasterId);

        if (allowedStatusIds.length > 0) {
            this.filteredStatuses = this.allStatusMasters.filter(s => allowedStatusIds.includes(s.id));
        } else {
            // Fallback to all statuses if no mapping exists
            this.filteredStatuses = [...this.allStatusMasters];
        }
    }
}
