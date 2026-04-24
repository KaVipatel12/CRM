import { CommonModule } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule, MatChipInputEvent } from '@angular/material/chips';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { DynamicFieldMaster } from 'app/modules/admin/customers/customer.types';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { SearchableSelectComponent } from 'app/shared/components/searchable-select/searchable-select.component';
import { LookupService } from 'app/modules/admin/customers/lookup.service';
import { map } from 'rxjs';

@Component({
    selector: 'dynamic-field-dialog',
    standalone: true,
    templateUrl: './dynamic-field-dialog.component.html',
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatDialogModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatSelectModule,
        MatChipsModule,
        SearchableSelectComponent
    ]
})
export class DynamicFieldDialogComponent implements OnInit {
    form: FormGroup;
    isEditMode = false;
    isSaving = false;
    optionsList: string[] = [];
    customerTypes: any[] = [];
    readonly separatorKeysCodes = [ENTER, COMMA] as const;

    constructor(
        public dialogRef: MatDialogRef<DynamicFieldDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: { field: DynamicFieldMaster },
        private _fb: FormBuilder,
        private _lookupService: LookupService
    ) {}

    ngOnInit(): void {
        this.isEditMode = !!this.data?.field;

        this.form = this._fb.group({
            fieldName: [this.data?.field?.fieldName || '', [Validators.required]],
            displayName: [this.data?.field?.displayName || '', [Validators.required]],
            fieldType: [this.data?.field?.fieldType || 'string', [Validators.required]],
            sortOrder: [this.data?.field?.sortOrder || 0],
            options: [this.data?.field?.options || null],
            displayTypeIds: [this.data?.field?.displayTypeIds ? this.data.field.displayTypeIds.split(',').map(Number) : []]
        });

        // Load customer types
        this._lookupService.getLookups().pipe(
            map(data => data.customerTypes)
        ).subscribe(types => {
            this.customerTypes = types;
            
            // Re-patch form value to ensure mat-select picks up the values once options are loaded
            if (this.data?.field?.displayTypeIds) {
                const ids = this.data.field.displayTypeIds.split(',').map(Number);
                this.form.get('displayTypeIds').setValue(ids);
            }
        });

        if (this.isEditMode && this.data.field.options) {
            try {
                this.optionsList = JSON.parse(this.data.field.options);
            } catch (e) {
                this.optionsList = [];
            }
        }
    }

    addOption(event: MatChipInputEvent): void {
        const value = (event.value || '').trim();
        this.addOptionManually(value);
        event.chipInput!.clear();
    }

    addOptionManually(value: string): void {
        const trimmedValue = (value || '').trim();
        if (trimmedValue && !this.optionsList.includes(trimmedValue)) {
            this.optionsList.push(trimmedValue);
        }
    }

    removeOption(option: string): void {
        const index = this.optionsList.indexOf(option);
        if (index >= 0) {
            this.optionsList.splice(index, 1);
        }
    }

    save(): void {
        if (this.form.invalid) return;

        this.isSaving = true;
        const value = this.form.getRawValue();
        
        if (value.fieldType === 'dropdown') {
            value.options = JSON.stringify(this.optionsList);
        } else {
            value.options = null;
        }

        // Convert array of IDs to comma separated string
        if (value.displayTypeIds && Array.isArray(value.displayTypeIds)) {
            value.displayTypeIds = value.displayTypeIds.join(',');
        } else {
            value.displayTypeIds = null;
        }

        // Simulating slight delay to show loading state if needed, but normally pass back immediately
        this.dialogRef.close(value);
    }

}
