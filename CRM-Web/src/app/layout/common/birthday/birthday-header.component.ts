import { AsyncPipe, NgIf } from '@angular/common';
import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { map } from 'rxjs';
import { BirthdayService } from '../../../modules/admin/reports/birthday.service';
import { BirthdayDialogComponent } from '../../../modules/admin/reports/birthday-dialog/birthday-dialog.component';

@Component({
    selector: 'birthday-header',
    template: `
        <button
            class="relative"
            mat-icon-button
            (click)="openBirthday()"
            [matTooltip]="'Upcoming Birthdays'">
            <mat-icon [svgIcon]="'heroicons_outline:cake'"></mat-icon>
            <ng-container *ngIf="(birthdayCount$ | async) as count">
                <span
                    class="absolute top-0 right-0 flex items-center justify-center min-w-4 h-4 px-1 rounded-full bg-rose-500 text-white text-[10px] font-bold ring-2 ring-card animate-pulse"
                    *ngIf="count > 0">
                    {{count}}
                </span>
            </ng-container>
        </button>
    `,
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    standalone: true,
    imports: [
        AsyncPipe,
        NgIf,
        MatButtonModule,
        MatIconModule,
        MatTooltipModule
    ]
})
export class BirthdayHeaderComponent implements OnInit {
    private _matDialog = inject(MatDialog);
    private _birthdayService = inject(BirthdayService);

    birthdayCount$ = this._birthdayService.birthdays$.pipe(
        map(birthdays => birthdays ? birthdays.length : 0)
    );

    ngOnInit(): void {
        this._birthdayService.getUpcomingBirthdays().subscribe();
    }

    openBirthday(): void {
        this._matDialog.open(BirthdayDialogComponent, {
            width: '600px',
            maxWidth: '95vw'
        });
    }
}
