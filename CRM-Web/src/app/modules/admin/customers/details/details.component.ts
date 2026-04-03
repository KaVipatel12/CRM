import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTabsModule } from '@angular/material/tabs';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FuseAlertComponent, FuseAlertType } from '@fuse/components/alert';
import { CustomerService } from '../customer.service';
import { LookupService } from '../lookup.service';
import { Subject, takeUntil } from 'rxjs';

@Component({
    selector     : 'customers-details',
    templateUrl  : './details.component.html',
    encapsulation: ViewEncapsulation.None,
    standalone   : true,
    imports      : [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatCheckboxModule,
        MatDatepickerModule,
        MatDividerModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatSelectModule,
        MatTabsModule,
        RouterLink,
        FuseAlertComponent
    ]
})
export class DetailsComponent implements OnInit {
    customerForm: FormGroup;
    editMode: boolean = false;
    customerId: number;
    isSaving: boolean = false;
    
    alert: { type: FuseAlertType; message: string } = {
        type   : 'success',
        message: ''
    };
    showAlert: boolean = false;
    
    // Lookups
    contactTypes: any[] = [];
    customerTypes: any[] = [];
    businessTypes: any[] = [];
    taxAgents: any[] = [];
    tradingStatuses: any[] = [];
    staff: any[] = [];

    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor(
        private _activatedRoute: ActivatedRoute,
        private _customerService: CustomerService,
        private _lookupService: LookupService,
        private _formBuilder: FormBuilder,
        private _router: Router
    ) {}

    ngOnInit(): void {
        // Initialize form
        this.customerForm = this._formBuilder.group({
            id: [0],
            name: ['', Validators.required],
            code: [''],
            clientType: [null, Validators.required],
            contactType: [null, Validators.required],
            tradingName: [''],
            abnNumber: ['', [Validators.pattern('^[0-9]{11}$')]],
            tfnNumber: [''],
            directorID: [''],
            businessType: [null],
            tradingStatus: [null],
            taxAgent: [null],
            staffInCharge: [null],
            postNewsLetter: [false],
            isActive: [true],
            groupName: [''],
            contactInfo: this._formBuilder.group({
                contactName: [''],
                email: ['', [Validators.email]],
                cellPhone: [''],
                workPhone: ['']
            }),
            individualInfo: this._formBuilder.group({
                firstName: [''],
                lastName: [''],
                dateOfBirth: [null],
                gender: [null]
            }),
            companyInfo: this._formBuilder.group({
                webSite: [''],
                acnNumber: ['', [Validators.pattern('^[0-9]{9}$')]]
            }),
            addresses: this._formBuilder.array([])
        });

        // Load lookups
        this.loadLookups();

        // Check if edit mode
        this._activatedRoute.params
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(params => {
                if (params['id'] && params['id'] !== 'new') {
                    this.editMode = true;
                    this.customerId = +params['id'];
                    this.loadCustomer(this.customerId);
                } else {
                    this.initDefaultAddresses();
                }
            });

        // Auto-generate code when Customer Type (clientType) changes
        this.customerForm.get('clientType').valueChanges
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(clientType => {
                if (!this.editMode && clientType) {
                    this.generateCode(clientType);
                } else if (!this.editMode && !clientType) {
                    this.customerForm.get('code').setValue('');
                }
            });
    }

    generateCode(clientType: number): void {
        this._customerService.getIncrementCode(clientType).subscribe(count => {
            const typePart = ("0" + clientType).slice(-2);
            const nextVal = count + 1;
            let valStr = nextVal.toString();
            if (nextVal < 10) valStr = "000" + nextVal;
            else if (nextVal < 100) valStr = "00" + nextVal;
            else if (nextVal < 1000) valStr = "0" + nextVal;
            
            const code = `SSP${typePart}${valStr}`;
            this.customerForm.get('code').setValue(code);
            this.customerForm.get('code').setErrors(null);
        });
    }

    clearCode(): void {
        this.customerForm.get('code').setValue('');
    }

    checkDuplicateCode(): void {
        let code = this.customerForm.get('code').value;
        if (!code) return;
        code = code.trim();
        
        this._customerService.checkDuplicateCode(code).subscribe(isDuplicate => {
            if (isDuplicate) {
                this.customerForm.get('code').setErrors({ duplicate: true });
                // Optional: show a toastr/alert here if MatSnackBar is available
            } else {
                this.customerForm.get('code').setErrors(null);
            }
        });
    }

    loadLookups(): void {
        this._lookupService.getLookups()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(lookups => {
                this.contactTypes = lookups.contactTypes;
                this.customerTypes = lookups.customerTypes;
                this.businessTypes = lookups.businessTypes;
                this.taxAgents = lookups.taxAgents;
                this.tradingStatuses = lookups.tradingStatuses;
                this.staff = lookups.staff;
            });
    }

    get addresses(): FormArray {
        return this.customerForm.get('addresses') as FormArray;
    }

    initDefaultAddresses(): void {
        this.addresses.clear();
        this.addAddressForType(null, 1); // Home 
        this.addAddressForType(null, 2); // Business
        this.addAddressForType(null, 3); // Postal
    }

    addAddressForType(address: any, defaultType: number): void {
        const addressForm = this._formBuilder.group({
            id: [address?.id || 0],
            type: [address?.type || defaultType],
            addressLine1: [address?.addressLine1 || ''],
            addressLine2: [address?.addressLine2 || ''],
            city: [address?.city || ''],
            state: [address?.state || ''],
            postalCode: [address?.postalCode || ''],
            country: [address?.country || 'Australia']
        });
        this.addresses.push(addressForm);
    }

    removeAddress(index: number): void {
        this.addresses.removeAt(index);
    }

    loadCustomer(id: number): void {
        this._customerService.getCustomerById(id).subscribe(customer => {
            this.customerForm.patchValue(customer);
            // Rebuild addresses array specifically for Home, Business, Postal
            this.addresses.clear();
            const home = customer.addresses?.find((a: any) => a.type === 1);
            const biz = customer.addresses?.find((a: any) => a.type === 2);
            const postal = customer.addresses?.find((a: any) => a.type === 3);
            
            this.addAddressForType(home, 1);
            this.addAddressForType(biz, 2);
            this.addAddressForType(postal, 3);
        });
    }

    isIndividual(): boolean {
        const typeId = this.customerForm.get('clientType').value;
        if (!typeId) return false;
        const type = this.customerTypes.find(t => t.id === typeId);
        return type?.customerTypeNM?.toLowerCase() === 'individual';
    }

    isSoleProprietor(): boolean {
        const typeId = this.customerForm.get('clientType').value;
        if (!typeId) return false;
        const type = this.customerTypes.find(t => t.id === typeId);
        return type?.customerTypeNM?.toLowerCase() === 'sole proprietor';
    }

    isTypeSelected(): boolean {
        return !!this.customerForm.get('clientType').value && !!this.customerForm.get('contactType').value;
    }

    save(): void {
        if (this.customerForm.invalid) return;

        this.showAlert = false;
        this.isSaving = true;
        const data = Object.assign({}, this.customerForm.value);
        
        // Filter out completely empty address blocks
        data.addresses = data.addresses.filter((a: any) => 
            a.addressLine1 || a.city || a.state || a.postalCode || (a.id && a.id > 0)
        );

        if (this.editMode) {
            this._customerService.updateCustomer(this.customerId, data).subscribe({
                next: () => {
                    this.alert = { type: 'success', message: 'Customer updated successfully' };
                    this.showAlert = true;
                    this.isSaving = false;
                    setTimeout(() => this._router.navigate(['../'], { relativeTo: this._activatedRoute }), 2000);
                },
                error: (err) => {
                    this.alert = { type: 'error', message: 'Failed to update customer' };
                    this.showAlert = true;
                    this.isSaving = false;
                }
            });
        } else {
            this._customerService.createCustomer(data).subscribe({
                next: () => {
                    this.alert = { type: 'success', message: 'Customer created successfully' };
                    this.showAlert = true;
                    this.isSaving = false;
                    setTimeout(() => this._router.navigate(['../'], { relativeTo: this._activatedRoute }), 2000);
                },
                error: (err) => {
                    this.alert = { type: 'error', message: 'Failed to create customer' };
                    this.showAlert = true;
                    this.isSaving = false;
                }
            });
        }
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }
}
