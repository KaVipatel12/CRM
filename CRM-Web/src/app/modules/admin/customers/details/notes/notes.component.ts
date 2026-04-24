import { CommonModule } from '@angular/common';
import { Component, Input, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatDividerModule } from '@angular/material/divider';
import { CustomerNoteService } from '../../customer-note.service';
import { CreateCustomerNote, CustomerNote } from '../../customer.types';
import { Subject, takeUntil } from 'rxjs';

@Component({
    selector: 'customer-notes',
    templateUrl: './notes.component.html',
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatDividerModule
    ]
})
export class NotesComponent implements OnInit {
    @Input() customerId: number;

    private _customerNoteService = inject(CustomerNoteService);
    private _formBuilder = inject(FormBuilder);

    noteForm: FormGroup;
    notes: CustomerNote[] = [];
    isLoading: boolean = true;
    isSaving: boolean = false;

    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor() {
        this.noteForm = this._formBuilder.group({
            noteText: ['', [Validators.required]]
        });
    }

    ngOnInit(): void {
        if (this.customerId) {
            this.loadNotes();
        } else {
            this.isLoading = false;
        }
    }

    loadNotes(): void {
        this.isLoading = true;
        this._customerNoteService.getNotesByCustomer(this.customerId).subscribe(notes => {
            this.notes = notes;
            this.isLoading = false;
        });
    }

    addNote(): void {
        if (this.noteForm.invalid || this.isSaving) return;

        this.isSaving = true;
        const newNote: CreateCustomerNote = {
            customerId: this.customerId,
            noteText: this.noteForm.get('noteText').value,
            isPinned: false
        };

        this._customerNoteService.addNote(newNote).subscribe({
            next: (savedNote) => {
                this.notes.unshift(savedNote);
                this.noteForm.reset();
                this.isSaving = false;
            },
            error: () => {
                this.isSaving = false;
            }
        });
    }

    deleteNote(id: number): void {
        this._customerNoteService.deleteNote(id).subscribe(() => {
            this.notes = this.notes.filter(n => n.id !== id);
        });
    }

    togglePin(note: CustomerNote): void {
        const updatedNote = { ...note, isPinned: !note.isPinned };
        this._customerNoteService.updateNote(updatedNote).subscribe(() => {
            note.isPinned = !note.isPinned;
            // Re-sort notes
            this.notes.sort((a, b) => (b.isPinned ? 1 : 0) - (a.isPinned ? 1 : 0));
        });
    }

    formatDate(date: any): string {
        return new Date(date).toLocaleString();
    }
}
