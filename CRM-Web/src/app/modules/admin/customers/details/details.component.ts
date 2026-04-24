import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit, ViewChild, ViewEncapsulation, inject } from '@angular/core';
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
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTabsModule } from '@angular/material/tabs';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FuseAlertType } from '@fuse/components/alert';
import { CustomerService } from '../customer.service';
import { LookupService } from '../lookup.service';
import { UserService } from 'app/core/user/user.service';
import { User } from 'app/core/user/user.types';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { Observable, Subject, takeUntil } from 'rxjs';
import { JobService } from '../../jobs/job.service';
import { Job } from '../../jobs/job.types';
import { BankAccountDialogComponent } from './bank-account-dialog/bank-account-dialog.component';
import { ChangeTypeDialogComponent } from './change-type-dialog/change-type-dialog.component';
import { JobDialogComponent } from './job-dialog/job-dialog.component';

import { MatTableModule } from '@angular/material/table';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { JobPreviewDialogComponent } from '../../jobs/job-preview-dialog/job-preview-dialog.component';
import { DynamicFieldsComponent } from './dynamic-fields/dynamic-fields.component';
import { NotesComponent } from './notes/notes.component';
import { RelationshipsComponent } from './relationships/relationships.component';
import { ServicePortfolioComponent } from './services/service-portfolio.component';
import { SummaryComponent } from './summary/summary.component';
import { AdminChecklistComponent } from './admin-checklist/admin-checklist.component';
import { FSNotesComponent } from './fs-notes/fs-notes.component';
import { FormsGridComponent } from '../../forms/grid/grid.component';


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
        MatTooltipModule,
        MatDialogModule,
        MatTableModule,
        MatProgressBarModule,
        MatSidenavModule,
        RouterLink,
        DynamicFieldsComponent,
        NotesComponent,
        RelationshipsComponent,
        ServicePortfolioComponent,
        SummaryComponent,
        AdminChecklistComponent,
        FSNotesComponent,
        FormsGridComponent
    ]
})
export class DetailsComponent implements OnInit, OnDestroy {
    private _activatedRoute = inject(ActivatedRoute);
    private _customerService = inject(CustomerService);
    private _jobService = inject(JobService);
    private _lookupService = inject(LookupService);
    private _userService = inject(UserService);
    private _formBuilder = inject(FormBuilder);
    private _fuseConfirmationService = inject(FuseConfirmationService);
    private _router = inject(Router);
    private _snackBar = inject(MatSnackBar);
    private _matDialog = inject(MatDialog);

    customerForm: FormGroup;
    editMode: boolean = false;
    customerId: number;
    isSaving: boolean = false;
    branches: any[] = [];
    isLoadingBranches: boolean = false;

    @ViewChild(DynamicFieldsComponent) dynamicFieldsComponent: DynamicFieldsComponent;
    @ViewChild(RelationshipsComponent) relationshipsComponent: RelationshipsComponent;
    
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
    jobTypes: any[] = [];
    jobStatusMasters: any[] = [];
    jobTypeStatusMappings: any[] = [];
    
    // Jobs data
    jobs: Job[] = [];
    pendingJobs: any[] = [];
    isLoadingJobs: boolean = false;
    selectedJobId: number | null = null;
    
    // User info for role based interactions
    currentUser: User | null = null;
    isChecker: boolean = false;
    isAdmin: boolean = false;
    lastVarifiedDate: string | null = null;
    lastVarifiedUserName: string | null = null;

    private _unsubscribeAll: Subject<any> = new Subject<any>();

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

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
            businessType: [null],
            tradingStatus: [{ value: null, disabled: true }],
            taxAgent: [null],
            staffInCharge: [null],
            postNewsLetter: [false],
            isActive: [true],
            isArchived: [false],
            isExcluded: [false],
            annualFinancialStatements: [false],
            annualABNTaxReturn: [false],
            annualGSTClient: [false],
            annualNonGST: [false],
            basa: [false],
            basq: [false],
            prepareGroupCertificates: [false],
            lodgement: [false],
            financialStatement: [false],
            paygWeekly: [false],
            mailingName: [''],
            partner: [''],
            manager: [''],
            contactInfo: this._formBuilder.group({
                salutation: [''],
                contactName: [''],
                cellPhone: ['', [Validators.required]],
                workPhone: [''],
                email: ['', [Validators.email]],
                email2: ['', [Validators.email]]
            }),
            individualInfo: this._formBuilder.group({
                firstName: [''],
                lastName: [''],
                dateOfBirth: [null],
                gender: [null],
                directorID: [''],
                chargeInterest: [false],
                chargeMonthlyDisbursement: [false]
            }),
            companyInfo: this._formBuilder.group({
                webSite: [''],
                acnNumber: ['', [Validators.pattern('^[0-9]{9}$')]],
                annualAccountsMonth: [null]
            }),
            trustInfo: this._formBuilder.group({
                annualAccountsMonth: [null],
                chargeInterest: [false],
                chargeMonthlyDisbursement: [false],
                filedbyFirm: [false]
            }),
            solePropriterInfo: this._formBuilder.group({
                firstName: [''],
                lastName: [''],
                dateOfBirth: [null],
                directorID: [''],
                businessName: ['']
            }),
            addresses: this._formBuilder.array([]),
            bankAccounts: this._formBuilder.array([])
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
                    this.loadJobs(this.customerId);
                    // this.loadBranches(this.customerId);
                } else {
                    this.editMode = false;
                    this.initDefaultAddresses();
                }
            });
            
        // Get current user info
        this._userService.user$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((user: User) => {
                this.currentUser = user;
                this.isAdmin = user.isAdmin || user.isSuperAdmin;
                this.isChecker = user.isChecker;
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

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

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
                this.jobTypes = lookups.jobTypes;
                this.jobStatusMasters = lookups.jobStatusMasters;
                this.jobTypeStatusMappings = lookups.jobTypeStatusMappings;
            });
    }

    loadJobs(customerId: number): void {
        this.isLoadingJobs = true;
        this._jobService.getJobsByCustomerId(customerId)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(jobs => {
                this.jobs = jobs;
                this.isLoadingJobs = false;
            });
    }

    openAddJobDialog(): void {
        const dialogRef = this._matDialog.open(JobDialogComponent, {
            width: '640px',
            data: {
                customerId: this.customerId,
                jobTypes: this.jobTypes,
                staff: this.staff,
                jobStatusMasters: this.jobStatusMasters
            }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result)
            {
                if (this.editMode)
                {
                    this._jobService.createJob(result).subscribe({
                        next: () => {
                            this._snackBar.open('Job created successfully', 'OK', { duration: 3000, horizontalPosition: 'right', verticalPosition: 'top' });
                            this.loadJobs(this.customerId);
                        },
                        error: () => {
                            this._snackBar.open('Failed to create job', 'ERROR', { duration: 5000, horizontalPosition: 'right', verticalPosition: 'top' });
                        }
                    });
                }
                else
                {
                    // Add to pending jobs for new customer
                    this.pendingJobs.push(result);
                    this._snackBar.open('Job scheduled for creation', 'OK', { duration: 2000, horizontalPosition: 'right', verticalPosition: 'top' });
                }
            }
        });
    }

    removePendingJob(index: number): void {
        this.pendingJobs.splice(index, 1);
    }

    /**
     * Open job details dialog
     */
    openJobDetails(jobId: number): void {
        const dialogRef = this._matDialog.open(JobPreviewDialogComponent, {
            data: {
                jobId: jobId,
                statusMasters: this.jobStatusMasters,
                jobTypeStatusMappings: this.jobTypeStatusMappings,
                staff: this.staff,
                isAdmin: this.isAdmin
            },
            width: '1400px',
            maxWidth: '96vw',
            height: '92vh',
            maxHeight: '92vh',
            panelClass: 'job-preview-dialog-panel'
        });

        dialogRef.afterClosed().subscribe(() => {
            if (this.customerId) {
                this.loadJobs(this.customerId);
            }
        });
    }

    /**
     * Close job details drawer
     */
    closeJobDetails(): void {
        this.selectedJobId = null;
    }

    get addresses(): FormArray {
        return this.customerForm.get('addresses') as FormArray;
    }

    initDefaultAddresses(): void {
        this.addresses.clear();
        // For new customers, we can still provide the 3 defaults but they will be dynamic now
        this.addAddressForType({ type: 1 }); // Home 
        this.addAddressForType({ type: 2 }); // Business
        this.addAddressForType({ type: 3 }); // Postal
    }

    get bankAccounts(): FormArray {
        return this.customerForm.get('bankAccounts') as FormArray;
    }

    addBankAccount(): void {
        const dialogRef = this._matDialog.open(BankAccountDialogComponent, {
            width: '640px',
            data: {
                account: null
            }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result)
            {
                this._addBankAccountToForm(result);
                this.customerForm.markAsDirty();
            }
        });
    }

    editBankAccount(index: number): void {
        const account = this.bankAccounts.at(index).value;
        const dialogRef = this._matDialog.open(BankAccountDialogComponent, {
            width: '640px',
            data: {
                account: account
            }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result)
            {
                this.bankAccounts.at(index).patchValue(result);
                this.customerForm.markAsDirty();
            }
        });
    }

    private _addBankAccountToForm(account: any = null): void {
        this.bankAccounts.push(this._formBuilder.group({
            id: [account?.id || 0],
            accountName: [account?.accountName || '', Validators.required],
            bankName: [account?.bankName || '', Validators.required],
            bsb: [account?.bsb || ''],
            accountNumber: [account?.accountNumber || '', Validators.required]
        }));
    }

    removeBankAccount(index: number): void {
        this.bankAccounts.removeAt(index);
        this.customerForm.markAsDirty();
    }

    addAddressForType(address: any = null, defaultType: number = 1): void {
        const addressForm = this._formBuilder.group({
            id: [address?.id || 0],
            type: [address?.type || defaultType],
            addressLine1: [address?.addressLine1 || ''],
            addressLine2: [address?.addressLine2 || ''],
            city: [address?.city || ''],
            state: [address?.state || ''],
            postalCode: [address?.postalCode || ''],
            country: [address?.country || 'Australia'],
            branchId: [address?.branchId || null],
            branchName: [address?.branchName || '']
        });
        this.addresses.push(addressForm);
    }

    removeAddress(index: number): void {
        const address = this.addresses.at(index).value;
        if (address.id > 0) {
            this._fuseConfirmationService.open({
                title: 'Remove Address',
                message: 'Are you sure you want to remove this address? This will be saved when you update the customer.',
                actions: { confirm: { label: 'Remove', color: 'warn' } }
            }).afterClosed().subscribe(result => {
                if (result === 'confirmed') {
                    this.addresses.removeAt(index);
                    this.customerForm.markAsDirty();
                }
            });
        } else {
            this.addresses.removeAt(index);
        }
    }

    loadBranches(customerId: number): void {
        this.isLoadingBranches = true;
        this._customerService.getBranches(customerId).subscribe(branches => {
            this.branches = branches;
            this.isLoadingBranches = false;
        });
    }

    /* Branch Management Disabled
    openManageBranches(): void {
        const dialogRef = this._matDialog.open(BranchManagerDialogComponent, {
            width: '600px',
            data: { 
                customerId: this.customerId,
                localBranches: !this.editMode ? this.branches : [] 
            },
            disableClose: true
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result) {
                if (!this.editMode) {
                    this.branches = result;
                } else {
                    this.loadBranches(this.customerId);
                }
            }
        });
    }
    */

    loadCustomer(id: number): void {
        this._customerService.getCustomerById(id).subscribe(customer => {
            this.customerForm.patchValue(customer);
            // Disable customer type controls in edit mode to prevent accidental data corruption
            this.customerForm.get('clientType').disable();
            this.customerForm.get('contactType').disable();
            
            // Rebuild arrays
            this.addresses.clear();
            if (customer.addresses && customer.addresses.length > 0) {
                customer.addresses.forEach((addr: any) => {
                    this.addAddressForType(addr);
                });
            } else {
                this.initDefaultAddresses();
            }
            
            this.bankAccounts.clear();
            if (customer.bankAccounts && customer.bankAccounts.length > 0) {
                customer.bankAccounts.forEach((b: any) => this._addBankAccountToForm(b));
            }
            
            this.lastVarifiedDate = customer.lastVarifiedDate;
            this.lastVarifiedUserName = customer.lastVarifiedUserName;
            
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
        const nameControl = this.customerForm.get('name');
        const indFirstName = this.customerForm.get('individualInfo.firstName');
        const indLastName = this.customerForm.get('individualInfo.lastName');
        const spFirstName = this.customerForm.get('solePropriterInfo.firstName');
        const spLastName = this.customerForm.get('solePropriterInfo.lastName');

        nameControl.clearValidators();
        indFirstName.clearValidators();
        indLastName.clearValidators();
        spFirstName.clearValidators();
        spLastName.clearValidators();

        if (this.isIndividual()) {
            indFirstName.setValidators([Validators.required]);
            indLastName.setValidators([Validators.required]);
        } else if (this.isSoleProprietor()) {
            spFirstName.setValidators([Validators.required]);
            spLastName.setValidators([Validators.required]);
        } else {
            nameControl.setValidators([Validators.required]);
        }

        nameControl.updateValueAndValidity();
        indFirstName.updateValueAndValidity();
        indLastName.updateValueAndValidity();
        spFirstName.updateValueAndValidity();
        spLastName.updateValueAndValidity();
    }

    isTypeSelected(): boolean {
        return !!this.customerForm.get('clientType').value && !!this.customerForm.get('contactType').value;
    }

    showGender(): boolean {
        return this.customerForm.get('clientType').value === 1;
    }

    isTrust(): boolean {
        const typeId = this.customerForm?.get('clientType')?.value;
        if (!typeId) return false;
        const type = this.customerTypes.find(t => t.id === typeId);
        return type?.customerTypeNM?.toLowerCase() === 'trust';
    }

    showManager(): boolean {
        const ct = this.customerForm.get('clientType').value;
        return ct === 1 || ct === 4 || ct === 6 || ct === 7;
    }

    showPartner(): boolean {
        const contactType = this.customerForm.get('contactType').value;
        const clientType = this.customerForm.get('clientType').value;
        return !(contactType === 4 && clientType === 9);
    }

    showAdditionalInfo(): boolean {
        const contactType = this.customerForm.get('contactType').value;
        const clientType = this.customerForm.get('clientType').value;
        return !(contactType === 4 && clientType === 9);
    }

    showAdminTab(): boolean {
        const contactType = this.customerForm.get('contactType').value;
        const clientType = this.customerForm.get('clientType').value;
        return !((contactType === 4 && clientType === 9) || clientType === 1);
    }

    showFSNotesTab(): boolean {
        const clientType = this.customerForm.get('clientType').value;
        return clientType === 2; // Only for Company
    }


    showBusinessType(): boolean {
        const ct = this.customerForm.get('clientType').value;
        return ct === 2 || ct === 3 || ct === 4 || ct === 6;
    }

    showTradingStatus(): boolean {
        const ct = this.customerForm.get('clientType').value;
        return ct === 2 || ct === 3 || ct === 4 || ct === 5 || ct === 6;
    }

    save(): void {
        if (this.customerForm.invalid) return;

        this.showAlert = false;
        this.isSaving = true;
        
        if (this.isIndividual()) {
            const info = this.customerForm.get('individualInfo').value;
            this.customerForm.patchValue({ name: `${info.firstName || ''} ${info.lastName || ''}`.trim() }, { emitEvent: false });
        } else if (this.isSoleProprietor()) {
            const info = this.customerForm.get('solePropriterInfo').value;
            this.customerForm.patchValue({ name: `${info.firstName || ''} ${info.lastName || ''}`.trim() }, { emitEvent: false });
        }

        const data = Object.assign({}, this.customerForm.getRawValue());
        
        // --- Gather Nested Data for All-in-One Save ---
        if (this.dynamicFieldsComponent) {
            data.dynamicFieldValues = this.dynamicFieldsComponent.getFormValues();
        }
        if (this.relationshipsComponent) {
            data.relationships = this.relationshipsComponent.getValues();
        }
        // ----------------------------------------------

        data.addresses = data.addresses.filter((a: any) => 
            a.addressLine1 || a.city || a.state || a.postalCode || (a.id && a.id > 0)
        );

        const codeControl = this.customerForm.get('code');
        if (!this.editMode || codeControl.dirty) {
            this._customerService.checkDuplicateCode(data.code).subscribe(isDuplicate => {
                if (isDuplicate) {
                    this._snackBar.open('Duplicate Code!', 'ERROR', { duration: 5000 });
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
        /* Branch Mapping Disabled for New Customer
        if (!this.editMode && this.branches.length > 0) {
            data.branches = this.branches;
            
            if (data.addresses) {
                data.addresses.forEach(addr => {
                    if (!addr.branchId || isNaN(Number(addr.branchId))) {
                        addr.branchId = null;
                    }
                    
                    if (addr.branchId) {
                        const b = this.branches.find(br => br.id === addr.branchId);
                        if (b) addr.branchName = b.branchName;
                    }
                });
            }
        } else if (this.editMode && data.addresses) {
            data.addresses.forEach(addr => {
                if (!addr.branchId || isNaN(Number(addr.branchId))) {
                    addr.branchId = null;
                }
            });
        }
        */

        const request: Observable<any> = this.editMode 
            ? this._customerService.updateCustomer(this.customerId, data)
            : this._customerService.createCustomer(data);

        request.subscribe({
            next: (response: any) => {
                // If creating a new customer, response is the new ID (integer)
                // We handle both plain number and object cases for robustness
                const newCustomerId = (typeof response === 'number') ? response : (response?.id || response?.ID);
                
                if (!this.editMode && newCustomerId && this.pendingJobs.length > 0) {
                    this.pendingJobs.forEach(job => {
                        job.customerId = newCustomerId;
                        this._jobService.createJob(job).subscribe();
                    });
                }
                
                this._snackBar.open(`Contact ${this.editMode ? 'updated' : 'created'}`, 'OK', { duration: 3000 });
                this.isSaving = false;
                this._router.navigate(['../'], { relativeTo: this._activatedRoute });
            },
            error: () => {
                this._snackBar.open('Operation failed', 'ERROR', { duration: 5000 });
                this.isSaving = false;
            }
        });
    }

    verify(): void {
        if (!this.customerId) return;
        
        const dialogRef = this._fuseConfirmationService.open({
            title: 'Verify Contact',
            message: 'Are you sure?',
            icon: { show: true, name: 'heroicons_outline:check-badge', color: 'success' },
            actions: { confirm: { show: true, label: 'Verify', color: 'primary' }, cancel: { show: true, label: 'Cancel' } }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result === 'confirmed') {
                this._customerService.verifyCustomer(this.customerId).subscribe({
                    next: (success) => {
                        if (success) {
                            this._snackBar.open('Verified', 'OK', { duration: 3000 });
                            this.loadCustomer(this.customerId);
                        }
                    },
                    error: () => {
                        this._snackBar.open('Verification failed', 'ERROR', { duration: 5000 });
                    }
                });
            }
        });
    }

    changeCustomerType(): void {
        const dialogRef = this._matDialog.open(ChangeTypeDialogComponent, {
            width: '640px',
            data: {
                customer: this.customerForm.getRawValue(),
                customerTypes: this.customerTypes
            }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result && result.success) {
                this._snackBar.open('Type changed', 'OK', { duration: 3000 });
                this.loadCustomer(this.customerId);
            }
        });
    }

    toggleActive(): void {
        const ctrl = this.customerForm.get('isActive');
        ctrl.setValue(!ctrl.value);
        ctrl.markAsDirty();
    }

    toggleArchived(): void {
        const ctrl = this.customerForm.get('isArchived');
        ctrl.setValue(!ctrl.value);
        ctrl.markAsDirty();
    }

    toggleExcluded(): void {
        const ctrl = this.customerForm.get('isExcluded');
        ctrl.setValue(!ctrl.value);
        ctrl.markAsDirty();
    }
}
