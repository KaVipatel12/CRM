import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit, ViewEncapsulation, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { CdkDragDrop, DragDropModule, moveItemInArray } from '@angular/cdk/drag-drop';
import { Subject, takeUntil, Observable } from 'rxjs';
import { StickyNoteEditorComponent } from './editor/sticky-note-editor.component';
import { StickyNoteService, UserNote } from './sticky-note.service';

@Component({
    selector: 'sticky-notes-dialog',
    templateUrl: './sticky-notes-dialog.component.html',
    encapsulation: ViewEncapsulation.None,
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatDialogModule,
        MatDividerModule,
        MatIconModule,
        MatTooltipModule,
        DragDropModule
    ]
})
export class StickyNotesDialogComponent implements OnInit, OnDestroy {
    private _stickyNoteService = inject(StickyNoteService);
    private _matDialog = inject(MatDialog);
    private _dialogRef = inject(MatDialogRef<StickyNotesDialogComponent>);

    private _unsubscribeAll: Subject<any> = new Subject<any>();
    
    notes: UserNote[] = [];

    ngOnInit(): void {
        this._stickyNoteService.notes$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((notes) => {
                this.notes = notes;
            });
            
        this._stickyNoteService.getNotes().subscribe();
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }

    onDrop(event: CdkDragDrop<UserNote[]>): void {
        if (event.previousIndex === event.currentIndex) {
            return;
        }

        // Move the item visually in the array immediately
        moveItemInArray(this.notes, event.previousIndex, event.currentIndex);

        // Map the new display order based on the new array positions
        const updates = this.notes.map((note, index) => ({
            id: note.id,
            displayOrder: index
        }));

        this._stickyNoteService.updateOrder(updates).subscribe();
    }

    addNote(): void {
        const dialogRef = this._matDialog.open(StickyNoteEditorComponent, {
            width: '600px',
            maxWidth: '100vw',
            data: { note: null }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result) {
                this._stickyNoteService.createNote(result).subscribe();
            }
        });
    }

    editNote(note: UserNote): void {
        const dialogRef = this._matDialog.open(StickyNoteEditorComponent, {
            width: '600px',
            maxWidth: '100vw',
            data: { note }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result) {
                this._stickyNoteService.updateNote(result.id, result).subscribe();
            }
        });
    }

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

    deleteNote(id: number, event: Event): void {
        event.stopPropagation();
        this._stickyNoteService.deleteNote(id).subscribe();
    }

    convertToTodo(id: number, event: Event): void {
        event.stopPropagation();
        this._stickyNoteService.convertToTodo(id).subscribe();
    }

    close(): void {
        this._dialogRef.close();
    }

    getNoteColorClass(index: number): string {
        const bgColors = [
            'bg-amber-100 dark:bg-amber-900/30',
            'bg-emerald-100 dark:bg-emerald-900/30',
            'bg-sky-100 dark:bg-sky-900/30',
            'bg-rose-100 dark:bg-rose-900/30',
            'bg-purple-100 dark:bg-purple-900/30'
        ];
        return bgColors[index % bgColors.length];
    }
}
