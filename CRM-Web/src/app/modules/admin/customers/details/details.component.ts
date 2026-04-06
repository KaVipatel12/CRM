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
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
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
        MatSnackBarModule,
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
        private _router: Router,
        private _snackBar: MatSnackBar
    ) {}

    ngOnInit(): void {
        // Initialize form
        this.customerForm = this._formBuilder.group({
            id: [0],
            name: [''],
            code: ['', Validators.required],
            clientType: [null, Validators.required],
            contactType: [null, Validators.required],
            tradingName: [''],
            abnNumber: ['', [Validators.pattern('^[0-9]{11}$')]],
            tfnNumber: [''],
            directorID: [''],
            businessType: [null],
            tradingStatus: [{ value: null, disabled: true }],
            taxAgent: [null],
            staffInCharge: [null],
            postNewsLetter: [false],
            isActive: [true],
            groupName: [''],
            mailingName: [''],
            partner: [''],
            manager: [''],
            contactInfo: this._formBuilder.group({
                contactName: [''],
                email: ['', [Validators.email]],
                cellPhone: ['', [Validators.required]],
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

        // Dynamic validation based on clientType
        this.customerForm.get('clientType').valueChanges
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(() => {
                this._updateNameValidators();
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
            
            this._updateNameValidators();
        });
    }

    isIndividual(): boolean {
        const typeId = this.customerForm?.get('clientType')?.value;
        if (!typeId) return false;
        const type = this.customerTypes.find(t => t.id === typeId);
        return type?.customerTypeNM?.toLowerCase() === 'individual';
    }

    isSoleProprietor(): boolean {
        const typeId = this.customerForm?.get('clientType')?.value;
        if (!typeId) return false;
        const type = this.customerTypes.find(t => t.id === typeId);
        return type?.customerTypeNM?.toLowerCase() === 'sole proprietor';
    }

    isCompany(): boolean {
        const typeId = this.customerForm?.get('clientType')?.value;
        if (!typeId) return false;
        const type = this.customerTypes.find(t => t.id === typeId);
        return type?.customerTypeNM?.toLowerCase() === 'company';
    }

    getNameLabel(): string {
        return this.isCompany() ? 'Company Name' : 'Name';
    }

    private _updateNameValidators(): void {
        const clientType = this.customerForm.get('clientType').value;
        const nameControl = this.customerForm.get('name');
        const firstNameControl = this.customerForm.get('individualInfo.firstName');
        const lastNameControl = this.customerForm.get('individualInfo.lastName');

        // Clear all first
        nameControl.clearValidators();
        firstNameControl.clearValidators();
        lastNameControl.clearValidators();

        if (this.isIndividual() || this.isSoleProprietor()) {
            firstNameControl.setValidators([Validators.required]);
            lastNameControl.setValidators([Validators.required]);
        } else {
            nameControl.setValidators([Validators.required]);
        }

        nameControl.updateValueAndValidity();
        firstNameControl.updateValueAndValidity();
        lastNameControl.updateValueAndValidity();
    }

    isTypeSelected(): boolean {
        return !!this.customerForm.get('clientType').value && !!this.customerForm.get('contactType').value;
    }

    //   Gender only for Individual (customerType == 1)
    showGender(): boolean {
        return this.customerForm.get('clientType').value === 1;
    }

    //   DOB for Individual (1) and Sole Proprietor (3)
    showDateOfBirth(): boolean {
        const ct = this.customerForm.get('clientType').value;
        return ct === 1 || ct === 3;
    }

    //   Director ID for Individual (1) and Sole Proprietor (3)
    showDirectorID(): boolean {
        const ct = this.customerForm.get('clientType').value;
        return ct === 1 || ct === 3;
    }

    //   Manager for Individual(1), SMSF(4), Trust(6), Partnership(7)
    showManager(): boolean {
        const ct = this.customerForm.get('clientType').value;
        return ct === 1 || ct === 4 || ct === 6 || ct === 7;
    }

    //   Partner hidden only for Supplier(contactType=4) + Other(clientType=9)
    showPartner(): boolean {
        const contactType = this.customerForm.get('contactType').value;
        const clientType = this.customerForm.get('clientType').value;
        return !(contactType === 4 && clientType === 9);
    }

    //   Additional Info (Tax Agent) hidden for Supplier(4) + Other(9)
    showAdditionalInfo(): boolean {
        const contactType = this.customerForm.get('contactType').value;
        const clientType = this.customerForm.get('clientType').value;
        return !(contactType === 4 && clientType === 9);
    }

    //   Business Type for Company(2), SoleProp(3), SMSF(4), Trust(6)
    showBusinessType(): boolean {
        const ct = this.customerForm.get('clientType').value;
        return ct === 2 || ct === 3 || ct === 4 || ct === 6;
    }

    //   Trading Status for Company(2), SoleProp(3), SMSF(4), NonTrading(5), Trust(6)
    showTradingStatus(): boolean {
        const ct = this.customerForm.get('clientType').value;
        return ct === 2 || ct === 3 || ct === 4 || ct === 5 || ct === 6;
    }

    save(): void {
        if (this.customerForm.invalid) {
            console.error('Form is invalid. Errors:', this.getFormValidationErrors());
            return;
        }

        this.showAlert = false;
        this.isSaving = true;
        
        // Sync name field for Individuals/SoleProprietors if they used FirstName/LastName
        if (this.isIndividual() || this.isSoleProprietor()) {
            const info = this.customerForm.get('individualInfo').value;
            if (info.firstName || info.lastName) {
                this.customerForm.patchValue({
                    name: `${info.firstName || ''} ${info.lastName || ''}`.trim()
                }, { emitEvent: false });
            }
        }

        const data = Object.assign({}, this.customerForm.value);
        
        // Filter out completely empty address blocks
        data.addresses = data.addresses.filter((a: any) => 
            a.addressLine1 || a.city || a.state || a.postalCode || (a.id && a.id > 0)
        );

        // Check for duplicate code
        const codeControl = this.customerForm.get('code');
        if (!this.editMode || (this.editMode && codeControl.dirty)) {
            this._customerService.checkDuplicateCode(data.code).subscribe(isDuplicate => {
                if (isDuplicate) {
                    this._snackBar.open('Customer Code already exists. Please use a unique code.', 'ERROR', { duration: 5000, horizontalPosition: 'right', verticalPosition: 'top' });
                    this.isSaving = false;
                    return;
                }
                this._proceedToSave(data);
            });
        } else {
            this._proceedToSave(data);
        }
    }

    private _proceedToSave(data: any): void {
        if (this.editMode) {
            this._customerService.updateCustomer(this.customerId, data).subscribe({
                next: () => {
                    this._snackBar.open('Contact updated successfully', 'OK', { duration: 3000, horizontalPosition: 'right', verticalPosition: 'top' });
                    this.isSaving = false;
                    setTimeout(() => this._router.navigate(['../'], { relativeTo: this._activatedRoute }), 500);
                },
                error: (err) => {
                    this._snackBar.open('Failed to update contact', 'ERROR', { duration: 5000, horizontalPosition: 'right', verticalPosition: 'top' });
                    this.isSaving = false;
                    console.error('API Error:', err);
                }
            });
        } else {
            this._customerService.createCustomer(data).subscribe({
                next: () => {
                    this._snackBar.open('Contact created successfully', 'OK', { duration: 3000, horizontalPosition: 'right', verticalPosition: 'top' });
                    this.isSaving = false;
                    setTimeout(() => this._router.navigate(['../'], { relativeTo: this._activatedRoute }), 500);
                },
                error: (err) => {
                    this._snackBar.open('Failed to create contact', 'ERROR', { duration: 5000, horizontalPosition: 'right', verticalPosition: 'top' });
                    this.isSaving = false;
                    console.error('API Error:', err);
                }
            });
        }
    }

    getFormValidationErrors(): any {
        const errors = {};
        Object.keys(this.customerForm.controls).forEach(key => {
            const controlErrors = this.customerForm.get(key).errors;
            if (controlErrors != null) {
                errors[key] = controlErrors;
            }
        });
        
        // Check nested groups
        ['contactInfo', 'individualInfo', 'companyInfo'].forEach(group => {
            const groupCtrl = this.customerForm.get(group);
            if (groupCtrl instanceof FormGroup) {
                Object.keys(groupCtrl.controls).forEach(key => {
                    const controlErrors = groupCtrl.get(key).errors;
                    if (controlErrors != null) {
                        errors[`${group}.${key}`] = controlErrors;
                    }
                });
            }
        });

        return errors;
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }
}

