import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { RouterLink } from '@angular/router';
import { Customer, CustomerListFilter } from '../customer.types';
import { CustomerService } from '../customer.service';
import { LookupService } from '../lookup.service';
import { debounceTime, Subject, takeUntil } from 'rxjs';
import { FuseConfirmationService } from '@fuse/services/confirmation';

@Component({
    selector     : 'customers-list',
    templateUrl  : './list.component.html',
    encapsulation: ViewEncapsulation.None,
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
        RouterLink
    ]
})
export class ListComponent implements OnInit {
    @ViewChild(MatPaginator) private _paginator: MatPaginator;

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
    private _searchSubject: Subject<string> = new Subject<string>();
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor(
        private _customerService: CustomerService,
        private _lookupService: LookupService,
        private _fuseConfirmationService: FuseConfirmationService,
        private _snackBar: MatSnackBar
    ) {}

    ngOnInit(): void {
        this.loadLookups();
        this.loadCustomers();
        
        // Setup search throttling
        this._searchSubject.pipe(
            debounceTime(400),
            takeUntil(this._unsubscribeAll)
        ).subscribe(searchString => {
            this.filters.searchString = searchString;
            this.filters.currentPage = 1;
            this.loadCustomers();
        });
    }

    loadLookups(): void {
        this._lookupService.getLookups()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(lookups => {
                this.contactTypes = lookups.contactTypes;
                this.customerTypes = lookups.customerTypes;
            });
    }

    loadCustomers(): void {
        this.isLoading = true;
        this._customerService.getCustomers(this.filters)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe({
                next: (data) => {
                    this.customers = data;
                    this.dataSource.data = data;
                    this.isLoading = false;
                },
                error: () => {
                    this.isLoading = false;
                    // Handle error
                }
            });
    }

    onFilterChange(): void {
        this.filters.currentPage = 1;
        this.loadCustomers();
    }

    onSearch(event: any): void {
        this._searchSubject.next(event.target.value);
    }

    getCustomerTypeLabel(typeId: number): string {
        if (!this.customerTypes?.length) return '';
        const type = this.customerTypes.find(t => t.id === typeId);
        return type ? type.customerTypeNM : 'Other';
    }

    deleteCustomer(id: number): void {
        const dialogRef = this._fuseConfirmationService.open({
            title: 'Delete Contact',
            message: 'Are you sure you want to delete this contact? This action cannot be undone.',
            icon: {
                show: true,
                name: 'heroicons_outline:exclamation-triangle',
                color: 'warn',
            },
            actions: {
                confirm: {
                    show: true,
                    label: 'Delete',
                    color: 'warn',
                },
                cancel: {
                    show: true,
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
                            duration: 3000,
                            horizontalPosition: 'right',
                            verticalPosition: 'top',
                            panelClass: ['bg-green-600', 'text-white']
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
                            duration: 4000,
                            horizontalPosition: 'right',
                            verticalPosition: 'top',
                            panelClass: ['bg-red-600', 'text-white']
                        });
                    }
                });
            }
        });
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }
}
