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
import { RouterLink } from '@angular/router';
import { Customer, CustomerListFilter } from '../customer.types';
import { CustomerService } from '../customer.service';
import { LookupService } from '../lookup.service';
import { debounceTime, Subject, takeUntil } from 'rxjs';

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
        includeInactive: false
    };
    
    contactTypes: any[] = [];

    isLoading: boolean = false;
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor(
        private _customerService: CustomerService,
        private _lookupService: LookupService
    ) {}

    ngOnInit(): void {
        this.loadLookups();
        this.loadCustomers();
    }

    loadLookups(): void {
        this._lookupService.getLookups()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(lookups => {
                this.contactTypes = lookups.contactTypes;
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

    onSearch(event: any): void {
        this.filters.searchString = event.target.value;
        this.filters.currentPage = 1;
        this.loadCustomers();
    }

    onFilterChange(): void {
        this.filters.currentPage = 1;
        this.loadCustomers();
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }
}
