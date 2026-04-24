import { Component, Inject, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogModule, MatDialog } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { Router } from '@angular/router';
import { CustomerService } from '../customer.service';

@Component({
    selector: 'customer-preview-dialog',
    templateUrl: './customer-preview-dialog.component.html',
    standalone: true,
    imports: [
        CommonModule,
        MatDialogModule,
        MatButtonModule,
        MatIconModule,
        MatDividerModule,
        MatTooltipModule,
        MatProgressSpinnerModule
    ]
})
export class CustomerPreviewDialogComponent implements OnInit {
    customer: any = null;
    isLoading = true;

    private _router = inject(Router);
    private _customerService = inject(CustomerService);

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: { customerId: number },
        public dialogRef: MatDialogRef<CustomerPreviewDialogComponent>
    ) {}

    ngOnInit(): void {
        this._customerService.getCustomerById(this.data.customerId).subscribe({
            next: (c) => {
                this.customer = c;
                this.isLoading = false;
            },
            error: () => {
                this.isLoading = false;
            }
        });
    }

    private _matDialog = inject(MatDialog);

    goToFullProfile(): void {
        const id = this.data.customerId;
        this._matDialog.closeAll();
        // Using absolute path and ensuring ID is appended correctly
        this._router.navigateByUrl(`/customers/${id}`);
    }

    close(): void {
        this.dialogRef.close();
    }
}
