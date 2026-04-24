import { Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CustomerService } from '../../customer.service';

@Component({
    selector: 'app-change-type-dialog',
    templateUrl: './change-type-dialog.component.html',
    encapsulation: ViewEncapsulation.None,
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatDialogModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatSelectModule
    ]
})
export class ChangeTypeDialogComponent implements OnInit {

    customer: any;
    customerTypes: any[];
    selectedNewType: number = null;
    isSaving: boolean = false;
    showConfirmation: boolean = false;

    // Data impact info
    fieldsLost: string[] = [];
    fieldsCarriedOver: string[] = [];
    fieldsGained: string[] = [];

    // Field definitions per type (Logic ported from old project)
    private typeFields: { [key: number]: string[] } = {
        1: ['First Name', 'Last Name', 'Date of Birth', 'Gender'],           // Individual
        2: ['Website', 'ACN Number'],                                         // Company
        3: ['First Name', 'Last Name', 'Date of Birth'],                      // Sole Proprietor
        4: [],                                                                 // SMSF
        5: [],                                                                 // Non-Trading
        6: ['Annual Accounts Month', 'Charge Interest', 'Filed by Firm'],      // Trust
        7: [],                                                                 // Partnership
    };

    constructor(
        public dialogRef: MatDialogRef<ChangeTypeDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private _customerService: CustomerService
    ) {
        this.customer = data.customer;
        this.customerTypes = data.customerTypes;
    }

    ngOnInit(): void {
    }

    getCurrentTypeName(): string {
        if (!this.customer || !this.customer.clientType) return 'Unknown';
        const t = this.customerTypes.find(x => x.id === this.customer.clientType);
        return t ? t.customerTypeNM : 'Unknown';
    }

    getAvailableTypes(): any[] {
        if (!this.customerTypes) return [];
        return this.customerTypes.filter(x => x.id !== this.customer.clientType);
    }

    getSelectedTypeName(): string {
        if (!this.selectedNewType) return '';
        const t = this.customerTypes.find(x => x.id === this.selectedNewType);
        return t ? t.customerTypeNM : '';
    }

    onTypeSelected(): void {
        if (!this.selectedNewType) {
            this.showConfirmation = false;
            return;
        }

        const oldType = this.customer.clientType;
        const newType = this.selectedNewType;

        const oldFields = this.typeFields[oldType] || [];
        const newFields = this.typeFields[newType] || [];

        // Compatible fields = fields present in BOTH old and new
        this.fieldsCarriedOver = oldFields.filter(f => newFields.includes(f));

        // Lost = old fields NOT in new type
        this.fieldsLost = oldFields.filter(f => !newFields.includes(f));

        // Gained = new fields NOT in old type
        this.fieldsGained = newFields.filter(f => !oldFields.includes(f));

        this.showConfirmation = true;
    }

    isCompatibleMigration(): boolean {
        return this.fieldsLost.length === 0;
    }

    save(): void {
        if (!this.selectedNewType) return;
        this.isSaving = true;
        this._customerService.changeCustomerType(this.customer.id, this.selectedNewType).subscribe({
            next: () => {
                this.isSaving = false;
                this.dialogRef.close({ success: true, newType: this.selectedNewType });
            },
            error: (err) => {
                this.isSaving = false;
                console.error("Migration error", err);
                this.dialogRef.close(false);
            }
        });
    }

    closeDialog(): void {
        this.dialogRef.close(false);
    }
}
