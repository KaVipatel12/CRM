import { ChangeDetectionStrategy, Component, inject, OnInit, ViewEncapsulation } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, UntypedFormControl } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { SearchableSelectComponent } from 'app/shared/components/searchable-select/searchable-select.component';
import { CustomerService } from 'app/modules/admin/customers/customer.service';
import { finalize } from 'rxjs/operators';

@Component({
    selector     : 'form-contact-picker',
    templateUrl  : './contact-picker.component.html',
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    standalone   : true,
    imports      : [CommonModule, FormsModule, ReactiveFormsModule, MatDialogModule, MatButtonModule, MatIconModule, MatFormFieldModule, MatInputModule, MatAutocompleteModule, SearchableSelectComponent]
})
export class FormContactPickerComponent implements OnInit
{
    private _matDialogRef = inject(MatDialogRef<FormContactPickerComponent>);
    private _customerService = inject(CustomerService);

    customers: any[] = [];
    selectedCustomerId: number | null = null;
    isLoading: boolean = false;

    /**
     * On init
     */
    ngOnInit(): void
    {
        // Load initial customers (same as Jobs list)
        this.isLoading = true;
        this._customerService.getCustomers({ pageSize: 100, currentPage: 1 }).subscribe(response => {
            this.customers = response.items;
            this.isLoading = false;
        });
    }

    /**
     * Select contact
     */
    onContactSelected(customerId: number): void
    {
        const contact = this.customers.find(c => c.id === customerId);
        if (contact) {
            this._matDialogRef.close({ contact });
        }
    }

    /**
     * Continue without contact (Blank Form)
     */
    continueBlank(): void
    {
        this._matDialogRef.close({ blank: true });
    }

    /**
     * Close dialog
     */
    close(): void
    {
        this._matDialogRef.close();
    }
}
