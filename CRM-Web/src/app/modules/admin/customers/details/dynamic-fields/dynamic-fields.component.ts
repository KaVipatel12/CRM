import { CommonModule } from '@angular/common';
import { Component, Input, OnInit, OnChanges, SimpleChanges, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { DynamicFieldService } from '../../dynamic-field.service';
import { DynamicFieldMaster, DynamicFieldValue, UpsertDynamicFieldValue } from '../../customer.types';
import { Subject, takeUntil } from 'rxjs';

@Component({
    selector: 'dynamic-fields',
    templateUrl: './dynamic-fields.component.html',
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatCheckboxModule,
        MatDatepickerModule,
        MatSelectModule,
        MatButtonModule,
        MatIconModule
    ]
})
export class DynamicFieldsComponent implements OnInit, OnChanges {
    @Input() customerId: number;
    @Input() customerTypeId: number;

    private _dynamicFieldService = inject(DynamicFieldService);
    private _formBuilder = inject(FormBuilder);

    dynamicForm: FormGroup;
    fields: DynamicFieldMaster[] = [];
    categories: { name: string, fields: DynamicFieldMaster[] }[] = [];
    isLoading: boolean = true;
    isSaving: boolean = false;

    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor() {
        this.dynamicForm = this._formBuilder.group({});
    }

    ngOnInit(): void {
        this.loadFieldsAndValues();
    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes['customerTypeId'] && !changes['customerTypeId'].firstChange) {
            this.loadFieldsAndValues();
        }
    }

    /**
     * Load field definitions and their values for the customer
     */
    loadFieldsAndValues(): void {
        this.isLoading = true;

        // 1. Get all master fields
        this._dynamicFieldService.getMasters().subscribe(masters => {
            // Filter fields based on customerTypeId if it exists
            this.fields = masters.filter(field => {
                // If no type restriction, show for all
                if (!field.displayTypeIds || field.displayTypeIds.trim() === '') {
                    return true;
                }

                // If we don't have a type yet (e.g. adding new customer), show all? 
                // Actually, if a field is restricted to specific types, and we haven't selected one, we probably shouldn't show it.
                // But usually, the user selects the type first.
                if (!this.customerTypeId) {
                    return false; 
                }

                const allowedTypes = field.displayTypeIds.split(',').map(id => parseInt(id.trim()));
                return allowedTypes.includes(this.customerTypeId);
            });

            // Group fields by category
            const categoryMap = new Map<string, DynamicFieldMaster[]>();
            this.fields.forEach(field => {
                const cat = field.category || 'General';
                if (!categoryMap.has(cat)) {
                    categoryMap.set(cat, []);
                }
                categoryMap.get(cat).push(field);
            });

            this.categories = Array.from(categoryMap.entries()).map(([name, fields]) => ({
                name,
                fields: fields.sort((a, b) => a.sortOrder - b.sortOrder)
            }));

            // 2. Build form controls
            // Clear existing controls first if any (in case of type change)
            Object.keys(this.dynamicForm.controls).forEach(key => {
                this.dynamicForm.removeControl(key);
            });

            this.fields.forEach(field => {
                this.dynamicForm.addControl(
                    field.id.toString(),
                    this._formBuilder.control(field.defaultValue || '')
                );
            });

            // 3. If edit mode, load existing values
            if (this.customerId && this.customerId > 0) {
                this._dynamicFieldService.getValuesByCustomer(this.customerId).subscribe(values => {
                    const patchObj = {};
                    values.forEach(v => {
                        // Only patch if the field is actually in the filtered list
                        if (this.dynamicForm.contains(v.fieldId.toString())) {
                            patchObj[v.fieldId.toString()] = v.fieldValue;
                        }
                    });
                    this.dynamicForm.patchValue(patchObj, { emitEvent: false });
                    this.isLoading = false;
                });
            } else {
                this.isLoading = false;
            }
        });
    }

    /**
     * Parse JSON options string
     */
    parseOptions(options: string): string[] {
        try {
            return options ? JSON.parse(options) : [];
        } catch (e) {
            return [];
        }
    }

    /**
     * Get values for saving
     */
    getFormValues(): UpsertDynamicFieldValue[] {
        const results: UpsertDynamicFieldValue[] = [];
        const formValue = this.dynamicForm.getRawValue();

        Object.keys(formValue).forEach(key => {
            const val = formValue[key];
            results.push({
                fieldId: parseInt(key),
                fieldValue: val !== null && val !== undefined ? val.toString() : null
            });
        });

        return results;
    }

    /**
     * Save values to the database
     */
    save(): void {
        if (!this.customerId) return;

        this.isSaving = true;
        const values = this.getFormValues();
        this._dynamicFieldService.upsertValues(this.customerId, values).subscribe({
            next: () => {
                this.isSaving = false;
                console.log('Dynamic fields saved successfully');
            },
            error: (err) => {
                this.isSaving = false;
                console.error('Error saving dynamic fields', err);
            }
        });
    }
}
