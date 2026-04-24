import { CommonModule } from '@angular/common';
import { Component, Input, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { CustomerRelationshipService } from '../../customer-relationship.service';
import { CustomerService } from '../../customer.service';
import { CreateCustomerRelationship, CustomerRelationship, Lookup } from '../../customer.types';
import { Subject, debounceTime, distinctUntilChanged, filter, switchMap, takeUntil } from 'rxjs';

@Component({
    selector: 'customer-relationships',
    templateUrl: './relationships.component.html',
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatSelectModule,
        MatDatepickerModule,
        MatTooltipModule,
        MatAutocompleteModule
    ]
})
export class RelationshipsComponent implements OnInit {
    @Input() customerId: number;

    private _relationshipService = inject(CustomerRelationshipService);
    private _customerService = inject(CustomerService);
    private _formBuilder = inject(FormBuilder);

    relationshipForm: FormGroup;
    relationships: CustomerRelationship[] = [];
    relationshipTypes: Lookup[] = [];
    filteredCustomers: any[] = [];
    
    isLoading: boolean = true;
    isSaving: boolean = false;
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor() {
        this.relationshipForm = this._formBuilder.group({
            targetCustomerId: [null, [Validators.required]],
            targetCustomerName: ['', [Validators.required]],
            relationshipTypeId: [null, [Validators.required]],
            startDate: [null],
            endDate: [null],
            noOfShare: [null],
            note: ['']
        });
    }

    ngOnInit(): void {
        this.relationshipTypes = [];
        this.loadLookups();
        this.setupCustomerSearch();
        
        // Date Validation Logic
        this.relationshipForm.get('startDate').valueChanges
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(start => {
                const end = this.relationshipForm.get('endDate').value;
                if (start && end && start > end) {
                    this.relationshipForm.get('endDate').setValue(null);
                }
            });

        if (this.customerId) {
            this.loadRelationships();
        } else {
            this.isLoading = false;
        }
    }

    loadLookups(): void {
        this._relationshipService.getRelationshipTypes().subscribe(types => {
            this.relationshipTypes = types;
        });
    }

    loadRelationships(): void {
        this.isLoading = true;
        this._relationshipService.getRelationshipsByCustomer(this.customerId).subscribe(data => {
            this.relationships = data;
            this.isLoading = false;
        });
    }

    setupCustomerSearch(): void {
        this.relationshipForm.get('targetCustomerName').valueChanges
            .pipe(
                takeUntil(this._unsubscribeAll),
                debounceTime(300),
                distinctUntilChanged(),
                switchMap(query => {
                    // Allow search only if query > 2 OR if it's explicitly cleared/initial
                    const searchQuery = typeof query === 'string' ? query : '';
                    if (searchQuery.length > 2 || searchQuery === '') {
                        return this._customerService.getCustomers({
                            searchString: searchQuery,
                            currentPage: 1,
                            pageSize: 15
                        });
                    }
                    return [];
                })
            )
            .subscribe(response => {
                if (response && response.items) {
                    this.filteredCustomers = response.items.filter(c => c.id !== this.customerId);
                }
            });
    }

    triggerSearch(): void {
        const query = this.relationshipForm.get('targetCustomerName').value || '';
        this._customerService.getCustomers({
            searchString: typeof query === 'string' ? query : '',
            currentPage: 1,
            pageSize: 15
        }).subscribe(response => {
            this.filteredCustomers = response.items.filter(c => c.id !== this.customerId);
        });
    }

    onCustomerSelected(event: any): void {
        const customer = event.option.value;
        this.relationshipForm.patchValue({
            targetCustomerId: customer.id,
            targetCustomerName: customer.name
        });
    }

    addRelationship(): void {
        if (this.relationshipForm.invalid || this.isSaving) return;

        const formData = this.relationshipForm.value;
        const newRel: CreateCustomerRelationship = {
            sourceCustomerId: this.customerId || 0,
            targetCustomerId: formData.targetCustomerId,
            relationshipTypeId: formData.relationshipTypeId,
            startDate: formData.startDate,
            endDate: formData.endDate,
            noOfShare: formData.noOfShare,
            note: formData.note
        };

        if (!this.customerId) {
            // Local addition for new customer
            const typeName = this.relationshipTypes.find(t => t.id === formData.relationshipTypeId)?.name || '';
            const pendingRel: CustomerRelationship = {
                id: -(this.relationships.length + 1), // Temporary ID
                ...newRel,
                relationshipTypeName: typeName,
                targetCustomerName: formData.targetCustomerName
            } as any;

            this.relationships.push(pendingRel);
            this.relationshipForm.reset();
            return;
        }

        this.isSaving = true;
        this._relationshipService.addRelationship(newRel).subscribe({
            next: (saved) => {
                this.relationships.push(saved);
                this.relationshipForm.reset();
                this.isSaving = false;
            },
            error: () => {
                this.isSaving = false;
            }
        });
    }

    /**
     * Get values for parent detail save
     */
    getValues(): CreateCustomerRelationship[] {
        // Return only relationships that don't have a positive ID (meaning they are new)
        // Or if in edit mode, it doesn't matter for this bulk save approach
        return this.relationships
            .filter(r => r.id <= 0)
            .map(r => ({
                sourceCustomerId: this.customerId || 0,
                targetCustomerId: r.targetCustomerId,
                relationshipTypeId: r.relationshipTypeId,
                startDate: r.startDate,
                endDate: r.endDate,
                noOfShare: r.noOfShare,
                note: r.note
            }));
    }

    deleteRelationship(id: number): void {
        this._relationshipService.deleteRelationship(id).subscribe(() => {
            this.relationships = this.relationships.filter(r => r.id !== id);
        });
    }

    formatDate(date: any): string {
        if (!date) return '-';
        return new Date(date).toLocaleDateString();
    }

    isExpired(endDate: any): boolean {
        if (!endDate) return false;
        
        try {
            const today = new Date();
            today.setHours(0, 0, 0, 0);
            
            const expiryDate = new Date(endDate);
            // Handle invalid dates
            if (isNaN(expiryDate.getTime())) return false;
            
            expiryDate.setHours(0, 0, 0, 0);
            
            return expiryDate.getTime() < today.getTime();
        } catch (e) {
            return false;
        }
    }
}
