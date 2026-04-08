import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild, ViewEncapsulation, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatDrawer, MatSidenavModule } from '@angular/material/sidenav';
import { MatSelectModule } from '@angular/material/select';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { Subject, debounceTime, takeUntil } from 'rxjs';
import { Job, JobFilter } from '../job.types';
import { JobService } from '../job.service';
import { JobDetailsComponent } from '../../customers/details/job-details/job-details.component';

@Component({
    selector: 'jobs-list',
    templateUrl: './list.component.html',
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatSidenavModule,
        MatSelectModule,
        MatPaginatorModule,
        MatTableModule,
        MatTooltipModule,
        MatProgressBarModule,
        JobDetailsComponent
    ]
})
export class JobsListComponent implements OnInit, OnDestroy {
    @ViewChild('drawer') drawer: MatDrawer;

    jobs: Job[] = [];
    totalCount: number = 0;
    isLoading: boolean = false;
    
    // Lookups
    jobTypes: any[] = [];
    statusMasters: any[] = [];
    staff: any[] = [];
    
    // Filters
    filter: JobFilter = {
        pageNumber: 1,
        pageSize: 10,
        searchString: '',
        statusId: undefined,
        priority: undefined,
        jobTypeId: undefined,
        ownerId: undefined
    };

    searchInputControl: FormControl = new FormControl();
    selectedJobId: number | null = null;
    
    // Displayed columns
    displayedColumns: string[] = ['customer', 'jobType', 'caption', 'priority', 'status', 'deadline', 'owner'];

    private _changeDetectorRef = inject(ChangeDetectorRef);
    private _jobService = inject(JobService);
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor() {}

    ngOnInit(): void {
        // Load lookups
        this._jobService.getLookups().subscribe((lookups) => {
            this.jobTypes = lookups.jobTypes;
            this.statusMasters = lookups.jobStatusMasters;
            this.staff = lookups.staff;
            this._changeDetectorRef.markForCheck();
        });

        // Search input debounce
        this.searchInputControl.valueChanges
            .pipe(
                debounceTime(500),
                takeUntil(this._unsubscribeAll)
            )
            .subscribe((value) => {
                this.filter.searchString = value;
                this.filter.pageNumber = 1;
                this.loadJobs();
            });

        // Load initial data
        this.loadJobs();
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }

    /**
     * Load jobs from backend
     */
    loadJobs(): void {
        this.isLoading = true;
        this._changeDetectorRef.markForCheck();

        this._jobService.getJobs(this.filter)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((response) => {
                this.jobs = response.items;
                this.totalCount = response.totalCount;
                this.isLoading = false;
                this._changeDetectorRef.markForCheck();
            });
    }

    /**
     * Handle pagination change
     */
    onPageChange(event: any): void {
        this.filter.pageNumber = event.pageIndex + 1;
        this.filter.pageSize = event.pageSize;
        this.loadJobs();
    }

    /**
     * Handle filter change
     */
    onFilterChange(): void {
        this.filter.pageNumber = 1;
        this.loadJobs();
    }

    /**
     * Open job details drawer
     */
    openJobDetails(job: Job): void {
        this.selectedJobId = job.id;
        this.drawer.open();
        this._changeDetectorRef.markForCheck();
    }

    /**
     * Close job details drawer
     */
    closeJobDetails(): void {
        this.selectedJobId = null;
        this.drawer.close();
        this._changeDetectorRef.markForCheck();
    }

    /**
     * Refresh after job update
     */
    onJobUpdated(): void {
        this.loadJobs();
    }
}
