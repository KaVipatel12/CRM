import { CommonModule } from '@angular/common';
import { Component, Inject, ViewEncapsulation, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { QuillModule } from 'ngx-quill';
import { UserNote } from '../sticky-note.service';

@Component({
    selector: 'sticky-note-editor',
    templateUrl: './sticky-note-editor.component.html',
    encapsulation: ViewEncapsulation.None,
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatCheckboxModule,
        MatDialogModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        QuillModule
    ]
})
export class StickyNoteEditorComponent {
    noteForm: FormGroup;
    quillModules = {
        toolbar: [
            ['bold', 'italic', 'underline', 'strike'],
            [{ 'list': 'ordered' }, { 'list': 'bullet' }],
            [{ 'header': [1, 2, 3, false] }],
            ['link', 'clean']
        ]
    };

    constructor(
        public dialogRef: MatDialogRef<StickyNoteEditorComponent>,
        @Inject(MAT_DIALOG_DATA) public data: { note?: UserNote }
    ) {
        // Initialize form
        this.noteForm = new FormGroup({
            title: new FormControl(this.data.note?.title || ''),
            content: new FormControl(this.data.note?.content || '', [Validators.required]),
            isPinned: new FormControl(this.data.note?.isPinned || false),
            displayOrder: new FormControl(this.data.note?.displayOrder || 0)
        });
    }

    /**
     * Save note
     */
    save(): void {
        if (this.noteForm.invalid) {
            return;
        }

        this.dialogRef.close({
            ...this.noteForm.value,
            id: this.data.note?.id
        });
    }

    /**
     * Close dialog
     */
    close(): void {
        this.dialogRef.close();
    }
}
