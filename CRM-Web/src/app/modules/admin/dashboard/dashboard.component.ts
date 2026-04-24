import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewEncapsulation, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTableModule } from '@angular/material/table';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { RouterModule } from '@angular/router';
import { NgApexchartsModule } from 'ng-apexcharts';
import { Subject, delay, takeUntil } from 'rxjs';
import { JobService } from '../jobs/job.service';
import { JobStatistics } from '../jobs/job.types';
import { UserService } from 'app/core/user/user.service';
import { BirthdayService, UpcomingBirthday } from '../reports/birthday.service';
import { BirthdayDialogComponent } from '../reports/birthday-dialog/birthday-dialog.component';
import { JobsListComponent } from '../jobs/list/list.component';
import { JobFilter } from '../jobs/job.types';
import { TodoService } from './todo.service';

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html',
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    standalone: true,
    imports: [
        CommonModule,
        MatIconModule,
        MatButtonModule,
        MatTooltipModule,
        MatTableModule,
        MatSlideToggleModule,
        MatDialogModule,
        RouterModule,
        NgApexchartsModule,
        JobsListComponent
    ]
})
export class DashboardComponent implements OnInit, OnDestroy {
    stats: JobStatistics | null = null;
    selectedCategory: string = 'myJobs';
    currentUserId: number | null = null;
    isAdmin: boolean = false;
    isGlobalView: boolean = false;
    personalTodoCount: number = 0;
    birthdayCount: number = 0;
    upcomingBirthdays: UpcomingBirthday[] = [];
    
    // Filter to pass down to JobsList
    jobsFilter: Partial<JobFilter> = {};
    
    // Chart options
    chartByStage: any = {};
    chartByType: any = {};

    private _changeDetectorRef = inject(ChangeDetectorRef);
    private _jobService = inject(JobService);
    private _todoService = inject(TodoService);
    private _userService = inject(UserService);
    private _birthdayService = inject(BirthdayService);
    private _dialog = inject(MatDialog);
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor() {}

    ngOnInit(): void {
        // Get user info and then load stats/jobs
        this._userService.user$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((user) => {
                if (user) {
                    this.currentUserId = Number(user.id);
                    this.isAdmin = user.isAdmin ?? false;
                    this.updateJobsFilter();
                    this.loadStats();
                    this.loadPersonalTodoCount();
                    this.loadBirthdays();
                }
            });
    }

    loadBirthdays(): void {
        this._birthdayService.getUpcomingBirthdays().subscribe((birthdays) => {
            this.upcomingBirthdays = birthdays;
            this.birthdayCount = birthdays.length;
            this._changeDetectorRef.markForCheck();
        });
    }

    openBirthdayDialog(): void {
        this._dialog.open(BirthdayDialogComponent, {
            width: '600px',
            maxWidth: '95vw'
        });
    }

    loadPersonalTodoCount(): void {
        this._todoService.getTodos().subscribe(todos => {
            this.personalTodoCount = todos.filter(t => !t.isCompleted).length;
            this._changeDetectorRef.markForCheck();
        });
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }

    /**
     * Toggle between My Jobs and Global View
     */
    onGlobalViewChange(event: any): void {
        this.isGlobalView = event.checked;
        this.updateJobsFilter();
        this.loadStats();
    }

    /**
     * Update filter object for the jobs-list child component
     */
    updateJobsFilter(): void {
        this.jobsFilter = {
            responsibleId: this.selectedCategory === 'myJobs' ? (this.isGlobalView ? undefined : this.currentUserId) : undefined,
            createdUserId: this.selectedCategory === 'createdByMe' ? this.currentUserId : undefined,
            ownerId: this.selectedCategory === 'ownedByMe' ? this.currentUserId : undefined,
            isActive: true
        };
        this._changeDetectorRef.markForCheck();
    }

    /**
     * Set active category and update filters
     */
    setCategory(category: string): void {
        this.selectedCategory = category;
        this.updateJobsFilter();
    }

    /**
     * Load dashboard statistics
     */
    loadStats(): void {
        this._jobService.getStatistics(this.isGlobalView)
            .pipe(
                delay(0),
                takeUntil(this._unsubscribeAll)
            )
            .subscribe((stats) => {
                this.stats = stats;
                this.prepareCharts(stats);
                this._changeDetectorRef.markForCheck();
            });
    }

    /**
     * Prepare ApexCharts options based on statistics
     */
    prepareCharts(stats: JobStatistics): void {
        // Chart 1: Jobs by Stage (Donut)
        this.chartByStage = {
            series: stats.jobsByStage.map(x => x.value),
            chart: {
                height: 300,
                type: 'donut',
                fontFamily: 'inherit',
                animations: { enabled: true }
            },
            labels: stats.jobsByStage.map(x => x.label),
            colors: ['#6366f1', '#f43f5e', '#f59e0b', '#10b981', '#64748b', '#06b6d4'],
            legend: {
                position: 'bottom',
                fontFamily: 'inherit'
            },
            plotOptions: {
                pie: {
                    donut: {
                        size: '70%',
                        labels: {
                            show: true,
                            total: {
                                show: true,
                                label: 'Total',
                                formatter: () => stats.totalActive.toString()
                            }
                        }
                    }
                }
            },
            stroke: { show: false }
        };

        // Chart 2: Jobs by Type (Pie)
        this.chartByType = {
            series: stats.jobsByType.map(x => x.value),
            chart: {
                height: 300,
                type: 'pie',
                fontFamily: 'inherit',
                animations: { enabled: true }
            },
            labels: stats.jobsByType.map(x => x.label),
            colors: ['#8b5cf6', '#ec4899', '#f97316', '#3b82f6', '#14b8a6'],
            legend: {
                position: 'bottom',
                fontFamily: 'inherit'
            },
            stroke: { show: false }
        };
    }
}
