import { AsyncPipe, NgIf } from '@angular/common';
import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { StickyNotesDialogComponent } from '../../../modules/admin/dashboard/sticky-notes/sticky-notes-dialog.component';
import { StickyNoteService } from '../../../modules/admin/dashboard/sticky-notes/sticky-note.service';
import { map } from 'rxjs';

@Component({
    selector: 'notes-header',
    template: `
        <button
            class="relative"
            mat-icon-button
            (click)="openNotes()"
            [matTooltip]="'Sticky Notes'">
            <mat-icon [svgIcon]="'heroicons_outline:pencil-square'"></mat-icon>
            <ng-container *ngIf="(notesCount$ | async) as count">
                <span
                    class="absolute top-0 right-0 flex items-center justify-center min-w-4 h-4 px-1 rounded-full bg-primary text-on-primary text-[10px] font-bold ring-2 ring-card"
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
export class StickyNotesHeaderComponent implements OnInit {
    private _matDialog = inject(MatDialog);
    private _stickyNoteService = inject(StickyNoteService);

    notesCount$ = this._stickyNoteService.notes$.pipe(
        map(notes => notes.length)
    );

    ngOnInit(): void {
        this._stickyNoteService.getNotes().subscribe();
    }

    openNotes(): void {
        this._matDialog.open(StickyNotesDialogComponent, {
            width: '640px',
            maxHeight: '85vh',
            panelClass: 'sticky-notes-dialog'
        });
    }
}
