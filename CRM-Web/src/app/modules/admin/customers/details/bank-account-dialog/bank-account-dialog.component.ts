import { Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';

@Component({
    selector     : 'bank-account-dialog',
    templateUrl  : './bank-account-dialog.component.html',
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
        MatInputModule
    ]
})
export class BankAccountDialogComponent implements OnInit
{
    bankAccountForm: FormGroup;

    /**
     * Constructor
     */
    constructor(
        @Inject(MAT_DIALOG_DATA) public data: any,
        public matDialogRef: MatDialogRef<BankAccountDialogComponent>,
        private _formBuilder: FormBuilder
    )
    {
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
        // Create the form
        this.bankAccountForm = this._formBuilder.group({
            id           : [this.data?.account?.id || 0],
            accountName  : [this.data?.account?.accountName || '', Validators.required],
            bankName     : [this.data?.account?.bankName || '', Validators.required],
            bsb          : [this.data?.account?.bsb || ''],
            accountNumber: [this.data?.account?.accountNumber || '', Validators.required]
        });
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Save and close
     */
    save(): void
    {
        if (this.bankAccountForm.invalid)
        {
            return;
        }

        this.matDialogRef.close(this.bankAccountForm.value);
    }

    /**
     * Close the dialog
     */
    close(): void
    {
        this.matDialogRef.close();
    }
}
