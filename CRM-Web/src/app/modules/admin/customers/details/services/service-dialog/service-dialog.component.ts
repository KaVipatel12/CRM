import { CommonModule } from '@angular/common';
import { Component, Inject, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CustomerService } from '../../../customer.service';

@Component({
    selector: 'app-service-dialog',
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatDialogModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatIconModule
    ],
    templateUrl: './service-dialog.component.html'
})
export class ServiceDialogComponent implements OnInit {
    private _fb = inject(FormBuilder);
    private _customerService = inject(CustomerService);
    
    serviceForm: FormGroup;
    masters: any[] = [];
    frequencies = [
        { value: 'y', label: 'Yearly' },
        { value: 'q', label: 'Quarterly' },
        { value: 'm', label: 'Monthly' },
        { value: 'w', label: 'Weekly' },
        { value: 'd', label: 'Daily' }
    ];

    constructor(
        public dialogRef: MatDialogRef<ServiceDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any
    ) {
        this.serviceForm = this._fb.group({
            id: [data.service?.id || 0],
            customerId: [data.customerId, Validators.required],
            serviceId: [data.service?.serviceId || null, Validators.required],
            amount: [data.service?.amount || null, [Validators.required, Validators.min(0)]],
            unit: [data.service?.unit || 'q', Validators.required],
            internalNotes: [data.service?.internalNotes || '']
        });
    }

    ngOnInit(): void {
        this._customerService.getServiceMasters().subscribe((data) => {
            this.masters = data;
        });
    }

    save(): void {
        if (this.serviceForm.invalid) return;

        this._customerService.upsertCustomerService(this.serviceForm.value).subscribe(() => {
            this.dialogRef.close(true);
        });
    }
}
