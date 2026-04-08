import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild, ViewEncapsulation, inject } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { Customer, CustomerListFilter } from '../customer.types';
import { CustomerService } from '../customer.service';
import { LookupService } from '../lookup.service';
import { debounceTime, Subject, takeUntil, map } from 'rxjs';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { UserService } from 'app/core/user/user.service';
import { User } from 'app/core/user/user.types';
import { RouterLink } from '@angular/router';

@Component({
    selector     : 'customers-list',
    templateUrl  : './list.component.html',
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    standalone   : true,
    imports      : [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatCheckboxModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatMenuModule,
        MatPaginatorModule,
        MatSelectModule,
        MatTableModule,
        MatSnackBarModule,
        MatTooltipModule,
        MatProgressBarModule,
        RouterLink
    ]
})
export class ListComponent implements OnInit, OnDestroy {
    @ViewChild(MatPaginator) private _paginator: MatPaginator;

    private _customerService = inject(CustomerService);
    private _lookupService = inject(LookupService);
    private _userService = inject(UserService);
    private _fuseConfirmationService = inject(FuseConfirmationService);
    private _snackBar = inject(MatSnackBar);

    customers: Customer[] = [];
    dataSource: MatTableDataSource<Customer> = new MatTableDataSource();
    displayedColumns: string[] = ['code', 'name', 'type', 'email', 'status', 'action'];
    
    filters: CustomerListFilter = {
        currentPage: 1,
        pageSize: 10,
        searchString: '',
        includeInactive: false,
        varifiedType: 'all',
        contactType: 0,
        includeArchived: false,
        includeExcluded: false
    };
    
    contactTypes: any[] = [];
    customerTypes: any[] = [];
    isLoading: boolean = false;
    isChecker: boolean = false;
    stats: any = {
        total: 0,
        verified: 0,
        unverified: 0,
        active: 0,
        inactive: 0
    };
    
    totalCount: number = 0;
    searchInputControl: FormControl = new FormControl();
    private _changeDetectorRef = inject(ChangeDetectorRef);
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    /**
     * Constructor
     */
    constructor() {}

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    ngOnInit(): void {
        this.loadLookups();
        this.loadStatistics();
        this.loadCustomers();
        
        // Check if user is a checker
        this._userService.user$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((user: User) => {
                this.isChecker = user.isChecker || user.isSuperAdmin;
            });

        // Setup search throttling
        this.searchInputControl.valueChanges.pipe(
            debounceTime(400),
            takeUntil(this._unsubscribeAll)
        ).subscribe(searchString => {
            this.filters.searchString = searchString;
            this.filters.currentPage = 1;
            this.loadCustomers();
        });
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    loadLookups(): void {
        this._lookupService.getLookups()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(lookups => {
                this.contactTypes = lookups.contactTypes;
                this.customerTypes = lookups.customerTypes;
                this._changeDetectorRef.markForCheck();
            });
    }

    loadCustomers(): void {
        this.isLoading = true;
        this._changeDetectorRef.markForCheck();
        
        this._customerService.getCustomers(this.filters)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe({
                next: (response) => {
                    this.customers = response.items;
                    this.totalCount = response.totalCount;
                    this.dataSource.data = response.items;
                    this.isLoading = false;
                    this._changeDetectorRef.markForCheck();
                },
                error: () => {
                    this.isLoading = false;
                    this._changeDetectorRef.markForCheck();
                }
            });
    }

    loadStatistics(): void {
        this._customerService.getStatistics()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(stats => {
                this.stats = stats;
                this._changeDetectorRef.markForCheck();
            });
    }

    onPageChange(event: any): void {
        this.filters.currentPage = event.pageIndex + 1;
        this.filters.pageSize = event.pageSize;
        this.loadCustomers();
    }

    onFilterChange(): void {
        this.filters.currentPage = 1;
        this.loadCustomers();
    }



    getCustomerTypeLabel(typeId: number): string {
        if (!this.customerTypes?.length) return '';
        const type = this.customerTypes.find(t => t.id === typeId);
        return type ? type.customerTypeNM : 'Other';
    }

    deleteCustomer(id: number): void {
        const dialogRef = this._fuseConfirmationService.open({
            title  : 'Delete Contact',
            message: 'Are you sure you want to delete this contact? This action cannot be undone.',
            icon   : {
                show: true,
                name: 'heroicons_outline:exclamation-triangle',
                color: 'warn',
            },
            actions: {
                confirm: {
                    show : true,
                    label: 'Delete',
                    color: 'warn',
                },
                cancel : {
                    show : true,
                    label: 'Cancel',
                },
            },
            dismissible: true,
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result === 'confirmed') {
                this.isLoading = true;
                this._customerService.deleteCustomer(id).subscribe({
                    next: () => {
                        this._snackBar.open('Contact deleted successfully.', 'Close', {
                            duration          : 3000,
                            horizontalPosition: 'right',
                            verticalPosition  : 'top',
                            panelClass        : ['bg-green-600', 'text-white']
                        });
                        this.loadCustomers();
                    },
                    error: (err) => {
                        this.isLoading = false;
                        let errorMessage = 'Failed to delete contact.';
                        
                        if (err.status === 403) {
                            errorMessage = 'Access Denied: Only Administrators can delete contacts.';
                        }
                        
                        this._snackBar.open(errorMessage, 'Close', {
                            duration          : 4000,
                            horizontalPosition: 'right',
                            verticalPosition  : 'top',
                            panelClass        : ['bg-red-600', 'text-white']
                        });
                    }
                });
            }
        });
    }

    verifyCustomer(customer: Customer): void {
        const dialogRef = this._fuseConfirmationService.open({
            title  : 'Verify Customer',
            message: `Are you sure you want to verify <b>${customer.name}</b>?`,
            icon   : {
                show: true,
                name: 'heroicons_outline:check-badge',
                color: 'success',
            },
            actions: {
                confirm: {
                    show : true,
                    label: 'Verify',
                    color: 'primary',
                },
                cancel : {
                    show : true,
                    label: 'Cancel',
                },
            },
            dismissible: true,
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result === 'confirmed') {
                this._customerService.verifyCustomer(customer.id).subscribe({
                    next: () => {
                        this._snackBar.open('Customer verified successfully.', 'Close', {
                            duration          : 3000,
                            horizontalPosition: 'right',
                            verticalPosition  : 'top',
                            panelClass        : ['bg-green-600', 'text-white']
                        });
                        this.loadCustomers();
                    },
                    error: () => {
                        this._snackBar.open('Failed to verify customer.', 'Close', {
                            duration          : 4000,
                            horizontalPosition: 'right',
                            verticalPosition  : 'top',
                            panelClass        : ['bg-red-600', 'text-white']
                        });
                    }
                });
            }
        });
    }
}
