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
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatMenuModule } from '@angular/material/menu';
import { MatDividerModule } from '@angular/material/divider';
import { Subject, debounceTime, takeUntil } from 'rxjs';
import { UserService } from 'app/core/user/user.service';
import { CallsService } from '../calls.service';
import { CallLog, Purpose } from '../calls.types';
import { CallDialogComponent } from '../call-dialog/call-dialog.component';
import { CallCommentsDialogComponent } from '../call-comments-dialog/call-comments-dialog.component';

@Component({
    selector: 'calls-list',
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
        MatDialogModule
    ]
})
export class CallsListComponent implements OnInit, OnDestroy {
    private _changeDetectorRef = inject(ChangeDetectorRef);
    private _callsService = inject(CallsService);
    private _userService = inject(UserService);
    private _matDialog = inject(MatDialog);

    calls: CallLog[] = [];
    totalCount: number = 0;
    isLoading: boolean = false;
    
    // Lookups
    purposes: Purpose[] = [];
    staff: any[] = [];
    statusMasters: any[] = [];
    
    // Filters
    filter: any = {
        pageNumber: 1,
        pageSize: 10,
        searchString: '',
        receiverId: null,
        forWhomId: null,
        purposeId: null,
        statusId: null,
        fromDate: null,
        toDate: null,
        isClosed: false
    };

    searchInputControl: FormControl = new FormControl();
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    // Displayed columns
    displayedColumns: string[] = ['date', 'forWhom', 'callerInfo', 'purpose', 'receiver', 'status', 'remark', 'actions'];

    constructor() { }

    ngOnInit(): void {
        // Get current user and set default filter
        this._userService.user$.pipe(takeUntil(this._unsubscribeAll)).subscribe((user) => {
            if (user) {
                this.filter.forWhomId = parseInt(user.id);
                this._changeDetectorRef.markForCheck();
                this.getCalls();
            }
        });

        // Search input subscription
        this.searchInputControl.valueChanges
            .pipe(
                takeUntil(this._unsubscribeAll),
                debounceTime(300)
            )
            .subscribe((value) => {
                this.filter.searchString = value;
                this.filter.pageNumber = 1;
                this.getCalls();
            });

        // Load lookups
        this.loadLookups();
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }

    loadLookups(): void {
        this._callsService.getPurposes().subscribe((purposes) => {
            this.purposes = purposes;
            this._changeDetectorRef.markForCheck();
        });

        this._callsService.getUsers().subscribe((users) => {
            this.staff = users;
            this._changeDetectorRef.markForCheck();
        });

        // Status masters for calls (TypeID 26 in old system)
        this._callsService.getUsers(); // Placeholder, we should probably get status masters from a global lookup service
        // For now, I'll mock or wait for status list. The old system used StatusMaster with Category/Type.
    }

    getCalls(): void {
        this.isLoading = true;
        this._callsService.getCalls(this.filter)
            .subscribe((response) => {
                this.calls = response.items;
                this.totalCount = response.totalCount;
                this.isLoading = false;
                this._changeDetectorRef.markForCheck();
            });
    }

    onPageChange(event: any): void {
        this.filter.pageNumber = event.pageIndex + 1;
        this.filter.pageSize = event.pageSize;
        this.getCalls();
    }

    resetFilters(): void {
        this._userService.user$.pipe(takeUntil(this._unsubscribeAll)).subscribe((user) => {
            if (user) {
                this.filter = {
                    pageNumber: 1,
                    pageSize: 10,
                    searchString: '',
                    receiverId: null,
                    forWhomId: parseInt(user.id),
                    purposeId: null,
                    statusId: null,
                    fromDate: null,
                    toDate: null,
                    isClosed: false
                };
                this.searchInputControl.setValue('', { emitEvent: false });
                this.getCalls();
            }
        });
    }

    openAddCallDialog(): void {
        const dialogRef = this._matDialog.open(CallDialogComponent, {
            width: '800px',
            data: { call: null }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result) {
                this.getCalls();
            }
        });
    }

    openEditCallDialog(call: CallLog): void {
        const dialogRef = this._matDialog.open(CallDialogComponent, {
            width: '800px',
            data: { call }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result) {
                this.getCalls();
            }
        });
    }

    openCommentsDialog(call: CallLog): void {
        const dialogRef = this._matDialog.open(CallCommentsDialogComponent, {
            width: '600px',
            data: { callId: call.id, callName: call.name }
        });

        dialogRef.afterClosed().subscribe(() => {
            this.getCalls();
        });
    }

    closeCall(call: CallLog): void {
        this._callsService.closeCall(call.id).subscribe(() => {
            this.getCalls();
        });
    }

    toggleChecked(call: CallLog): void {
        // Implementation for toggleChecked if needed
    }
}
