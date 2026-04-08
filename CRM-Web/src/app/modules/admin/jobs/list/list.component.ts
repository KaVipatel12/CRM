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
import { MatDialog } from '@angular/material/dialog';
import { Subject, debounceTime, takeUntil, concatMap, from, finalize } from 'rxjs';
import { UserService } from 'app/core/user/user.service';
import { Job, JobFilter, JobStatistics } from '../job.types';
import { JobService } from '../job.service';
import { JobDetailsComponent } from '../../customers/details/job-details/job-details.component';
import { JobDialogComponent } from '../../customers/details/job-dialog/job-dialog.component';

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
    customers: any[] = [];
    stats: JobStatistics | null = null;
    
    // Filters
    filter: JobFilter = {
        pageNumber: 1,
        pageSize: 10,
        searchString: '',
        statusId: undefined,
        priority: undefined,
        jobTypeId: undefined,
        ownerId: undefined,
        isInternal: false
    };

    searchInputControl: FormControl = new FormControl();
    selectedJobId: number | null = null;
    currentUserId: number | null = null;
    isGlobalAdmin: boolean = false;
    
    // Displayed columns
    displayedColumns: string[] = ['customer', 'jobType', 'caption', 'priority', 'status', 'deadline', 'responsible', 'owner', 'actions'];

    private _changeDetectorRef = inject(ChangeDetectorRef);
    private _matDialog = inject(MatDialog);
    private _jobService = inject(JobService);
    private _userService = inject(UserService);
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor() {}

    ngOnInit(): void {
        // Load lookups
        this._jobService.getLookups().subscribe((lookups) => {
            if (lookups) {
                this.jobTypes = lookups.jobTypes || [];
                this.statusMasters = lookups.jobStatusMasters || [];
                this.staff = lookups.staff || [];
                this.customers = lookups.customers || [];
            }
            this.mapStaffNamesToJobs();
            this._changeDetectorRef.markForCheck();
        });

        // Determine user role and ID
        this._userService.user$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((user) => {
                if (user) {
                    this.isGlobalAdmin = user.isAdmin || user.isChecker || user.isSuperAdmin;
                    this.currentUserId = Number(user.id);
                    if (!this.isGlobalAdmin) {
                        this.displayedColumns = this.displayedColumns.filter(c => c !== 'owner');
                    }
                }
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
        this.loadStats();
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
                this.mapStaffNamesToJobs();
                this.isLoading = false;
                this._changeDetectorRef.markForCheck();
            });
    }

    /**
     * Load dashboard statistics
     */
    loadStats(): void {
        this._jobService.getStatistics()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((stats) => {
                this.stats = stats;
                this._changeDetectorRef.markForCheck();
            });
    }

    /**
     * Helper to map staff names client-side since API returns OwnerId
     */
    private mapStaffNamesToJobs(): void {
        if (!this.staff.length || !this.jobs.length) return;
        
        this.jobs.forEach(job => {
            if (job.ownerId) {
                const s = this.staff.find(x => x.id === job.ownerId);
                job.staffName = s ? `${s.firstName} ${s.lastName ?? ''}`.trim() : 'Unknown';
            }
            if (job.responsibleId) {
                const s = this.staff.find(x => x.id === job.responsibleId);
                job.responsibleName = s ? `${s.firstName} ${s.lastName ?? ''}`.trim() : 'Unassigned';
            } else {
                job.responsibleName = 'Unassigned';
            }
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
     * Check if deadline is overdue
     */
    isOverdue(dateStr: string | null | undefined): boolean {
        if (!dateStr) return false;
        return new Date(dateStr) < new Date();
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
        this.loadStats();
    }

    /**
     * Quick close a job
     */
    quickClose(job: Job): void {
        this._jobService.closeJob(job.id).subscribe(() => {
            this.loadJobs();
            this.loadStats();
        });
    }

    /**
     * Open Job Create Dialog
     */
    openAddJobDialog(): void {
        const dialogRef = this._matDialog.open(JobDialogComponent, {
            panelClass: 'mail-compose-dialog',
            width: '720px',
            maxHeight: '85vh',
            data: {
                isGlobalCall: true,
                jobTypes: this.jobTypes,
                staff: this.staff,
                jobStatusMasters: this.statusMasters,
                customers: this.customers,
                currentUserId: this.currentUserId,
                isAdmin: this.isGlobalAdmin
            }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result) {
                this._jobService.createJob(result).subscribe({
                    next: () => {
                        this.loadJobs();
                        this.loadStats();
                    },
                    error: (err) => {
                        console.error('Error creating job', err);
                    }
                });
            }
        });
    }

    /**
     * Open Add Multi Job Dialog
     */
    openAddMultiJobDialog(): void {
        const dialogRef = this._matDialog.open(JobDialogComponent, {
            panelClass: 'mail-compose-dialog',
            width: '720px',
            maxHeight: '85vh',
            data: {
                jobTypes: this.jobTypes,
                staff: this.staff,
                jobStatusMasters: this.statusMasters,
                customers: this.customers,
                isGlobalCall: true,
                isMultiMode: true,
                isAdmin: this.isGlobalAdmin,
                currentUserId: this.currentUserId
            }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result && result.customerIds && result.customerIds.length > 0) {
                this.isLoading = true;
                this._changeDetectorRef.markForCheck();

                const { customerIds, ...jobTemplate } = result;

                // Create jobs sequentially for each customer
                from(customerIds).pipe(
                    concatMap((cid: number) => {
                        const jobData = { ...jobTemplate, customerId: cid };
                        return this._jobService.createJob(jobData);
                    }),
                    finalize(() => {
                        this.isLoading = false;
                        this.loadJobs();
                        this.loadStats();
                        this._changeDetectorRef.markForCheck();
                    })
                ).subscribe({
                    next: () => {
                        // Success for individual job
                    },
                    error: (err) => {
                        console.error('Error in batch creation', err);
                    }
                });
            }
        });
    }

    /**
     * Open Job Edit Dialog
     */
    openEditJobDialog(job: Job): void {
        const dialogRef = this._matDialog.open(JobDialogComponent, {
            panelClass: 'mail-compose-dialog',
            width: '720px',
            maxHeight: '85vh',
            data: {
                job: job,
                isGlobalCall: true,
                jobTypes: this.jobTypes,
                staff: this.staff,
                jobStatusMasters: this.statusMasters,
                customers: this.customers,
                currentUserId: this.currentUserId,
                isAdmin: this.isGlobalAdmin
            }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result) {
                this._jobService.updateJob(job.id, result).subscribe({
                    next: () => {
                        this.loadJobs();
                        this.loadStats();
                    },
                    error: (err) => {
                        console.error('Error updating job', err);
                    }
                });
            }
        });
    }

    /**
     * Open Add Schedule Job Dialog
     */
    openAddScheduleJobDialog(): void {
        const dialogRef = this._matDialog.open(JobDialogComponent, {
            panelClass: 'mail-compose-dialog',
            width: '720px',
            maxHeight: '85vh',
            data: {
                isGlobalCall: true,
                isInternal: true,
                jobTypes: this.jobTypes,
                staff: this.staff,
                jobStatusMasters: this.statusMasters,
                customers: this.customers,
                currentUserId: this.currentUserId,
                isAdmin: this.isGlobalAdmin
            }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result) {
                // Ensure isInternal is set
                result.isInternal = true;
                result.customerId = null;

                this._jobService.createJob(result).subscribe({
                    next: () => {
                        this.loadJobs();
                        this.loadStats();
                    },
                    error: (err) => {
                        console.error('Error creating internal job', err);
                    }
                });
            }
        });
    }

    /**
     * Open List of Schedule Jobs Dialog
     * For now, we reuse the filter logic by toggling isInternal
     */
    viewScheduleJobs(): void {
        this.filter.isInternal = true;
        this.filter.pageNumber = 1;
        this.loadJobs();
    }

    /**
     * Reset to Client Jobs
     */
    viewClientJobs(): void {
        this.filter.isInternal = false;
        this.filter.pageNumber = 1;
        this.loadJobs();
    }
}
