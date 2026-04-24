import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewEncapsulation, inject } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { FormControl } from '@angular/forms';
import { Observable, map, startWith, finalize } from 'rxjs';
import { MatSelectModule } from '@angular/material/select';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterLink } from '@angular/router';
import { ReportsService, FSNotesReportFilter } from '../reports.service';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from 'app/app.config';
import { MatChipsModule } from '@angular/material/chips';

@Component({
    selector: 'report-notes-for-fs',
    templateUrl: './notes-for-fs.component.html',
    encapsulation: ViewEncapsulation.None,
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatCheckboxModule,
        MatDividerModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatMenuModule,
        MatSelectModule,
        MatTooltipModule,
        MatAutocompleteModule,
        MatChipsModule,
        RouterLink,
        MatProgressSpinnerModule
    ]
})
export class NotesForFSComponent implements OnInit {
    private _reportsService = inject(ReportsService);
    private _httpClient = inject(HttpClient);
    private _baseApiUrl = inject(API_BASE_URL);

    // Lookups
    contactTypes: any[] = [];
    customerTypes: any[] = [];
    staff: any[] = [];
    partners: string[] = [];
    allPartners: any[] = [];
    fsNoteMasters: any[] = [];
    allCustomers: any[] = [];

    // Search/Autocomplete
    partnerControl = new FormControl('');
    staffControl = new FormControl('');
    customerControl = new FormControl('');
    
    filteredPartners: Observable<string[]>;
    filteredStaff: Observable<any[]>;
    filteredCustomers: Observable<any[]>;

    selectedCustomers: any[] = [];

    // Filters
    filters: FSNotesReportFilter = {
        contactType: undefined,
        partner: undefined,
        partnerId: undefined,
        staffInCharge: undefined,
        clientType: undefined,
        isActive: true,
        isArchived: false,
        isExcluded: false,
        selectedNoteTypeIds: [],
        selectedCustomerIds: [],
        orderBy: 'Name',
        orderDirection: 'ASC',
        exportFormat: 'csv'
    };

    isLoading: boolean = false;
    isGenerating: boolean = false;

    ngOnInit(): void {
        this.loadLookups();

        // Setup Autocomplete Filtering
        this.filteredPartners = this.partnerControl.valueChanges.pipe(
            startWith(''),
            map(value => this._filterPartners(value || ''))
        );

        this.filteredStaff = this.staffControl.valueChanges.pipe(
            startWith(''),
            map(value => this._filterStaff(value || ''))
        );

        this.filteredCustomers = this.customerControl.valueChanges.pipe(
            startWith(''),
            map(value => this._filterCustomers(value || ''))
        );

        // Sync control values
        this.partnerControl.valueChanges.subscribe(val => {
            if (!val) {
                this.filters.partner = undefined;
                this.filters.partnerId = undefined;
            }
        });

        this.staffControl.valueChanges.subscribe(val => {
            if (!val) this.filters.staffInCharge = undefined;
        });
    }

    onPartnerSelected(event: any): void {
        const val = event.option.value;
        if (!val) {
            this.filters.partnerId = undefined;
            this.filters.partner = undefined;
            return;
        }
        const found = this.allPartners.find(p => p.name === val);
        this.filters.partnerId = found ? found.id : undefined;
        this.filters.partner = val;
    }

    onStaffSelected(event: any): void {
        const val = event.option.value;
        if (!val) {
            this.filters.staffInCharge = undefined;
            return;
        }
        const found = this.staff.find(s => `${s.firstName} ${s.lastName}` === val);
        this.filters.staffInCharge = found ? found.id : undefined;
    }

    onCustomerSelected(event: any): void {
        const customer = event.option.value;
        if (customer && !this.selectedCustomers.find(c => c.id === customer.id)) {
            this.selectedCustomers.push(customer);
            this.filters.selectedCustomerIds.push(customer.id);
        }
        this.customerControl.setValue('');
    }

    removeCustomer(customerId: number): void {
        this.selectedCustomers = this.selectedCustomers.filter(c => c.id !== customerId);
        this.filters.selectedCustomerIds = this.filters.selectedCustomerIds.filter(id => id !== customerId);
    }

    private _filterPartners(value: string): string[] {
        const filterValue = value.toLowerCase();
        return this.partners.filter(p => p.toLowerCase().includes(filterValue));
    }

    private _filterStaff(value: string): any[] {
        const filterValue = value.toLowerCase();
        return this.staff.filter(s => 
            `${s.firstName} ${s.lastName}`.toLowerCase().includes(filterValue)
        );
    }

    private _filterCustomers(value: any): any[] {
        if (typeof value !== 'string') return [];
        const filterValue = value.toLowerCase();
        return this.allCustomers.filter(c => 
            c.name.toLowerCase().includes(filterValue) || 
            (c.code && c.code.toLowerCase().includes(filterValue))
        ).slice(0, 50); // Limit results for performance
    }

    loadLookups(): void {
        this.isLoading = true;
        this._httpClient.get(`${this._baseApiUrl}/api/lookups`).pipe(finalize(() => this.isLoading = false)).subscribe((res: any) => {
            this.contactTypes = res.contactTypes;
            this.customerTypes = res.customerTypes;
            this.staff = res.staff;
            this.fsNoteMasters = res.fsNoteMasters;
            
            this.allCustomers = res.customers;
            this.allPartners = res.customers; // Assuming partners are also in the customers list
            this.partners = res.customers.map(c => c.name).sort();

            this.partnerControl.setValue('');
            this.staffControl.setValue('');
            this.customerControl.setValue('');
        });
    }

    resetFilters(): void {
        this.filters = {
            contactType: undefined,
            partner: undefined,
            partnerId: undefined,
            staffInCharge: undefined,
            clientType: undefined,
            isActive: true,
            isArchived: false,
            isExcluded: false,
            selectedNoteTypeIds: [],
            selectedCustomerIds: [],
            orderBy: 'Name',
            orderDirection: 'ASC',
            exportFormat: 'csv'
        };

        this.selectedCustomers = [];
        this.partnerControl.setValue('');
        this.staffControl.setValue('');
        this.customerControl.setValue('');
    }

    generateReport(): void {
        this.isGenerating = true;
        this._reportsService.exportFSNotes(this.filters)
            .pipe(finalize(() => this.isGenerating = false))
            .subscribe((blob) => {
                const url = window.URL.createObjectURL(blob);
                const a = document.createElement('a');
                a.href = url;
                a.download = `FS_Notes_${new Date().getTime()}.${this.filters.exportFormat}`;
                document.body.appendChild(a);
                a.click();
                window.URL.revokeObjectURL(url);
                document.body.removeChild(a);
            });
    }
}
