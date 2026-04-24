import { Component, inject, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { QuillEditorComponent } from 'ngx-quill';
import { SearchableSelectComponent } from '../searchable-select/searchable-select.component';
import { CustomerService } from 'app/modules/admin/customers/customer.service';
import { finalize } from 'rxjs';

@Component({
    selector: 'app-email-compose',
    templateUrl: './email-compose.component.html',
    styleUrls: ['./email-compose.component.scss'],
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MatDialogModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
        MatIconModule,
        QuillEditorComponent,
        SearchableSelectComponent
    ],
    encapsulation: ViewEncapsulation.None
})
export class EmailComposeComponent implements OnInit {
    private _fb = inject(FormBuilder);
    private _customerService = inject(CustomerService);

    composeForm: FormGroup;
    customers: any[] = [];
    isLoadingCustomers = false;
    
    // Editor modules for Quill
    modules = {
        toolbar: [
            ['bold', 'italic', 'underline', 'strike'],
            [{ 'list': 'ordered'}, { 'list': 'bullet' }],
            [{ 'header': [1, 2, 3, false] }],
            [{ 'color': [] }, { 'background': [] }],
            ['clean']
        ]
    };

    constructor(
        public dialogRef: MatDialogRef<EmailComposeComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any
    ) {
        // Build the form with default values or passed data
        this.composeForm = this._fb.group({
            to: [data?.toEmail || '', Validators.required],
            subject: [data?.subject || 'Document Attached', Validators.required],
            body: [data?.body || '<p>Hi,</p><p>Please find the attached document.</p><br/><p>Best regards,<br/>SSP CRM Team</p>', Validators.required]
        });

        // If toEmail is provided, disable the field
        if (data?.toEmail) {
            this.composeForm.get('to').disable();
        }
    }

    ngOnInit(): void {
        // If no toEmail provided, load customer list for selection
        if (!this.data?.toEmail) {
            this.isLoadingCustomers = true;
            this._customerService.getCustomers({ pageSize: 1000, currentPage: 1, includeInactive: false })
                .pipe(finalize(() => this.isLoadingCustomers = false))
                .subscribe(response => {
                    // Map customers to have a consistent display name and filter out those without email
                    this.customers = response.items
                        .filter(c => !!c.email)
                        .map(c => ({
                            id: c.email, // We use email as the value
                            name: `${c.name} (${c.email})`
                        }));
                });
        }
    }

    send(): void {
        if (this.composeForm.valid) {
            // getRawValue gets disabled fields too, ensuring 'to' is included
            this.dialogRef.close(this.composeForm.getRawValue());
        }
    }

    close(): void {
        this.dialogRef.close();
    }
}
