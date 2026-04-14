import { ChangeDetectionStrategy, Component, ViewEncapsulation, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { StickyNotesDialogComponent } from '../../../modules/admin/dashboard/sticky-notes/sticky-notes-dialog.component';

@Component({
    selector: 'notes-header',
    template: `
        <button
            mat-icon-button
            (click)="openNotes()"
            [matTooltip]="'Sticky Notes'">
            <mat-icon [svgIcon]="'heroicons_outline:document-text'"></mat-icon>
        </button>
    `,
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    standalone: true,
    imports: [
        MatButtonModule,
        MatIconModule,
        MatTooltipModule
    ]
})
export class StickyNotesHeaderComponent {
    private _matDialog = inject(MatDialog);

    openNotes(): void {
        this._matDialog.open(StickyNotesDialogComponent, {
            width: '640px',
            maxHeight: '85vh',
            panelClass: 'sticky-notes-dialog'
        });
    }
}
