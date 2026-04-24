import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@Component({
    selector: 'temporary-assignment-dialog',
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatDialogModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatDatepickerModule,
        MatNativeDateModule
    ],
    templateUrl: './temporary-assignment-dialog.component.html'
})
export class TemporaryAssignmentDialogComponent {
    form: FormGroup;
    staffList: any[] = [];
    jobCount: number = 0;
    minDate: Date = new Date(); // Can only assign to future dates

    constructor(
        private _formBuilder: FormBuilder,
        public dialogRef: MatDialogRef<TemporaryAssignmentDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: { staffList: any[], jobCount: number }
    ) {
        this.staffList = data.staffList;
        this.jobCount = data.jobCount;
        
        // Default tomorrow
        const tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1);

        this.form = this._formBuilder.group({
            staffId: ['', Validators.required],
            untilDate: [tomorrow, Validators.required],
            note: ['', Validators.required]
        });
    }

    submit(): void {
        if (this.form.invalid) return;
        this.dialogRef.close(this.form.value);
    }
}
