import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewEncapsulation, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

import { MatSelectModule } from '@angular/material/select';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { SelectionModel } from '@angular/cdk/collections';
import { MatMenuModule } from '@angular/material/menu';
import { MatDividerModule } from '@angular/material/divider';
import { Subject, debounceTime, takeUntil, concatMap, from, finalize } from 'rxjs';
import { UserService } from 'app/core/user/user.service';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { Job, JobFilter, JobStatistics } from '../job.types';
import { JobService } from '../job.service';
import { JobPreviewDialogComponent } from '../job-preview-dialog/job-preview-dialog.component';
import { JobDialogComponent } from '../../customers/details/job-dialog/job-dialog.component';
import { TemporaryAssignmentDialogComponent } from './temporary-assignment-dialog.component';
import { Input, OnChanges, SimpleChanges } from '@angular/core';

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
        MatSelectModule,
        MatPaginatorModule,
        MatTableModule,
        MatTooltipModule,
        MatCheckboxModule,
        MatMenuModule,
        MatDividerModule,
        MatProgressBarModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatDialogModule,
        MatSortModule
    ]
})
export class JobsListComponent implements OnInit, OnChanges, OnDestroy {
    @Input() dashboardMode: boolean = false;
    @Input() externalFilter: Partial<JobFilter> | null = null;


    jobs: Job[] = [];
    totalCount: number = 0;
    isLoading: boolean = false;
    
    // Lookups
    jobTypes: any[] = [];
    statusMasters: any[] = [];
    filteredStatusMasters: any[] = [];
    jobTypeStatusMappings: any[] = [];
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
        responsibleId: undefined,
        isInternal: false,
        isActive: true,
        orderBy: 'deadline',
        orderDirection: 'desc'
    };

    searchInputControl: FormControl = new FormControl();
    selectedJobId: number | null = null;
    currentUserId: number | null = null;
    isGlobalAdmin: boolean = false;
    
    
    // Selection
    selection = new SelectionModel<Job>(true, []);

    // Displayed columns
    displayedColumns: string[] = ['select', 'customerCode', 'customer', 'jobType', 'caption', 'priority', 'status', 'period', 'assignDate', 'deadline', 'daysLeft', 'responsible', 'owner', 'actions'];

    private _changeDetectorRef = inject(ChangeDetectorRef);
    private _matDialog = inject(MatDialog);
    private _jobService = inject(JobService);
    private _userService = inject(UserService);
    private _fuseConfirmationService = inject(FuseConfirmationService);
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor() {}

    ngOnInit(): void {
        // Load lookups
        this._jobService.getLookups().subscribe((lookups) => {
            if (lookups) {
                this.jobTypes = lookups.jobTypes || [];
                this.statusMasters = lookups.jobStatusMasters || [];
                this.jobTypeStatusMappings = lookups.jobTypeStatusMappings || [];
                this.staff = lookups.staff || [];
                this.customers = lookups.customers || [];
                this.updateFilteredStatuses();
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
        if (!this.dashboardMode) {
            this.loadStats();
        }
    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes['externalFilter'] && this.externalFilter) {
            this.filter = { ...this.filter, ...this.externalFilter };
            this.loadJobs();
        }
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
                this.selection.clear();
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
     * Whether the number of selected elements matches the total number of rows.
     */
    isAllSelected(): boolean {
        const numSelected = this.selection.selected.length;
        const numRows = this.jobs.length;
        return numSelected === numRows;
    }

    /**
     * Selects all rows if they are not all selected; otherwise clear selection.
     */
    toggleAllRows(): void {
        this.isAllSelected() ?
            this.selection.clear() :
            this.jobs.forEach(row => this.selection.select(row));
    }

    /**
     * Bulk update status for selected jobs
     */
    bulkUpdateStatus(statusId: number): void {
        const selectedIds = this.selection.selected.map(j => j.id);
        if (!selectedIds.length) return;

        this.isLoading = true;
        this._jobService.bulkUpdateStatus(selectedIds, statusId)
            .pipe(finalize(() => this.isLoading = false))
            .subscribe(() => {
                this.selection.clear();
                this.loadJobs();
                this.loadStats();
            });
    }

    /**
     * Open dialog to temporarily assign selected jobs
     */
    openTemporaryAssignmentDialog(): void {
        const selectedIds = this.selection.selected.map(j => j.id);
        if (!selectedIds.length) return;

        const dialogRef = this._matDialog.open(TemporaryAssignmentDialogComponent, {
            width: '450px',
            data: { staffList: this.staff, jobCount: selectedIds.length }
        });

        dialogRef.afterClosed().pipe(takeUntil(this._unsubscribeAll)).subscribe(result => {
            if (result) {
                // Ensure date is ISO string formatting appropriately before sending
                const payload = {
                    jobIds: selectedIds,
                    staffId: result.staffId,
                    untilDate: result.untilDate.toISOString(),
                    note: result.note
                };

                this.isLoading = true;
                this._jobService.bulkTemporaryAssign(payload)
                    .pipe(finalize(() => this.isLoading = false))
                    .subscribe(() => {
                        this.selection.clear();
                        this.loadJobs();
                    });
            }
        });
    }

    /**
     * Export jobs to Excel
     */
    exportToExcel(): void {
        this.isLoading = true;
        this._jobService.exportJobs(this.filter)
            .pipe(finalize(() => this.isLoading = false))
            .subscribe((blob) => {
                const url = window.URL.createObjectURL(blob);
                const link = document.createElement('a');
                link.href = url;
                link.download = `JobsReport_${new Date().getTime()}.xlsx`;
                link.click();
                window.URL.revokeObjectURL(url);
            });
    }

    /**
     * Handle filter change
     */
    onFilterChange(): void {
        this.filter.pageNumber = 1;
        this.updateFilteredStatuses();
        this.loadJobs();
    }

    /**
     * Handle sort change
     */
    onSortChange(sort: any): void {
        this.filter.orderBy = sort.active;
        this.filter.orderDirection = sort.direction || 'desc';
        this.filter.pageNumber = 1;
        this.loadJobs();
    }

    /**
     * Update the list of selectable statuses based on selected job type
     */
    updateFilteredStatuses(): void {
        this.filteredStatusMasters = this._jobService.getFilteredStatuses(
            this.filter.jobTypeId,
            this.statusMasters,
            this.jobTypeStatusMappings
        );
        
        // If current status filter is not in the filtered list, reset it
        if (this.filter.statusId && !this.filteredStatusMasters.find(s => s.id === this.filter.statusId)) {
            this.filter.statusId = undefined;
        }
    }

    /**
     * Open job preview dialog (read-only)
     */
    openJobDetails(job: Job): void {
        this.selectedJobId = job.id;
        
        const dialogRef = this._matDialog.open(JobPreviewDialogComponent, {
            data: {
                jobId: job.id,
                statusMasters: this.statusMasters,
                jobTypeStatusMappings: this.jobTypeStatusMappings,
                staff: this.staff,
                isAdmin: this.isGlobalAdmin
            },
            width: '1400px',
            maxWidth: '96vw',
            height: '92vh',
            maxHeight: '92vh',
            panelClass: 'job-preview-dialog-panel'
        });

        dialogRef.afterClosed().subscribe((result) => {
            this.selectedJobId = null;
            
            // If admin clicked 'Edit', open the Edit dialog
            if (result === 'edit') {
                this.openEditJobDialog(job);
            }
            
            this.loadJobs();
            this.loadStats();
            this._changeDetectorRef.markForCheck();
        });
    }



    /**
     * Close job details
     */
    closeJobDetails(): void {
        this.selectedJobId = null;
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
                jobTypeStatusMappings: this.jobTypeStatusMappings,
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

    /**
     * Archive a single job (Soft Delete)
     */
    archiveJob(job: Job): void {
        const dialogRef = this._fuseConfirmationService.open({
            title: 'Archive Job',
            message: `Are you sure you want to archive this job: "${job.caption}"?<br><br>It will be hidden from the dashboard but kept in the database for audit.`,
            icon: {
                show: true,
                name: 'heroicons_outline:trash',
                color: 'error'
            },
            actions: {
                confirm: {
                    show: true,
                    label: 'Archive',
                    color: 'warn'
                },
                cancel: {
                    show: true,
                    label: 'Cancel'
                }
            },
            dismissible: true
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result === 'confirmed') {
                this.isLoading = true;
                this._jobService.deleteJob(job.id)
                    .pipe(finalize(() => this.isLoading = false))
                    .subscribe(() => {
                        this.loadJobs();
                        this.loadStats();
                    });
            }
        });
    }

    /**
     * Archive multiple selected jobs (Bulk Action)
     */
    bulkArchive(): void {
        const selectedIds = this.selection.selected.map(j => j.id);
        if (!selectedIds.length) return;

        const dialogRef = this._fuseConfirmationService.open({
            title: 'Bulk Archive',
            message: `Are you sure you want to archive <b>${selectedIds.length}</b> selected jobs?`,
            icon: {
                show: true,
                name: 'heroicons_outline:trash',
                color: 'error'
            },
            actions: {
                confirm: {
                    show: true,
                    label: 'Archive All',
                    color: 'warn'
                },
                cancel: {
                    show: true,
                    label: 'Cancel'
                }
            },
            dismissible: true
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result === 'confirmed') {
                this.isLoading = true;
                this._jobService.bulkArchiveJobs(selectedIds)
                    .pipe(finalize(() => this.isLoading = false))
                    .subscribe(() => {
                        this.selection.clear();
                        this.loadJobs();
                        this.loadStats();
                    });
            }
        });
    }
}
