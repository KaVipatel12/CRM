import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';
import { Observable } from 'rxjs';
import { StickyNoteEditorComponent } from './editor/sticky-note-editor.component';
import { StickyNoteService, UserNote } from './sticky-note.service';

@Component({
    selector: 'sticky-notes',
    templateUrl: './sticky-notes.component.html',
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatDividerModule,
        MatIconModule,
        MatMenuModule,
        MatTooltipModule
    ]
})
export class StickyNotesComponent implements OnInit {
    private _stickyNoteService = inject(StickyNoteService);
    private _matDialog = inject(MatDialog);

    notes$: Observable<UserNote[]> = this._stickyNoteService.notes$;

    ngOnInit(): void {
        // Fetch notes on load
        this._stickyNoteService.getNotes().subscribe();
    }

    /**
     * Open form to create a new note
     */
    addNote(): void {
        const dialogRef = this._matDialog.open(StickyNoteEditorComponent, {
            width: '600px',
            maxWidth: '100vw',
            data: { note: null }
        });

        // Save note on dialog close if result exists
        dialogRef.afterClosed().subscribe((result) => {
            if (result) {
                this._stickyNoteService.createNote(result).subscribe();
            }
        });
    }

    /**
     * Open form to edit an existing note
     */
    editNote(note: UserNote): void {
        const dialogRef = this._matDialog.open(StickyNoteEditorComponent, {
            width: '600px',
            maxWidth: '100vw',
            data: { note }
        });

        // Update note on dialog close if result exists
        dialogRef.afterClosed().subscribe((result) => {
            if (result) {
                this._stickyNoteService.updateNote(result.id, result).subscribe();
            }
        });
    }

    /**
     * Toggle the pinned status of a note
     */
    togglePin(note: UserNote, event: Event): void {
        event.stopPropagation();
        this._stickyNoteService.updateNote(note.id, {
            id: note.id,
            title: note.title,
            content: note.content,
            isPinned: !note.isPinned,
            displayOrder: note.displayOrder
        }).subscribe();
    }

    /**
     * Delete a note
     */
    deleteNote(id: number, event: Event): void {
        event.stopPropagation();
        this._stickyNoteService.deleteNote(id).subscribe();
    }

    /**
     * Convert note to a Todo
     */
    convertToTodo(id: number, event: Event): void {
        event.stopPropagation();
        this._stickyNoteService.convertToTodo(id).subscribe();
    }
}
