import { CommonModule } from '@angular/common';
import { Component, Inject, Input, OnInit, ViewEncapsulation, inject } from '@angular/core';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { FSNote, FSNoteMaster, FSNoteService } from './fs-notes.service';
import { Subject, takeUntil } from 'rxjs';
import { UserService } from 'app/core/user/user.service';
import { FuseConfirmationService } from '@fuse/services/confirmation';


@Component({
    selector: 'fs-notes',
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatIconModule,
        MatDialogModule,
        MatSnackBarModule,
        MatProgressSpinnerModule
    ],
    templateUrl: './fs-notes.component.html'
})
export class FSNotesComponent implements OnInit {
    @Input() customerId: number;
    
    private _fsNoteService = inject(FSNoteService);
    private _userService = inject(UserService);
    private _dialog = inject(MatDialog);
    private _snackBar = inject(MatSnackBar);
    private _fuseConfirmationService = inject(FuseConfirmationService);
    
    isLoading: boolean = false;
    isAdmin: boolean = false;
    masterTypes: FSNoteMaster[] = [];
    notes: FSNote[] = [];
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    ngOnInit(): void {
        this._userService.user$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((user) => {
                this.isAdmin = !!(user?.isAdmin || user?.isChecker || user?.isSuperAdmin);
            });
        this.loadNotes();
    }

    loadNotes(): void {
        if (!this.customerId) return;
        
        this.isLoading = true;
        this._fsNoteService.getNotesForCustomer(this.customerId)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe({
                next: (res) => {
                    this.masterTypes = res.masterTypes;
                    this.notes = res.notes;
                    this.isLoading = false;
                },
                error: () => {
                    this.isLoading = false;
                    this._snackBar.open('Error loading notes', 'Close', { duration: 3000 });
                }
            });
    }

    openAddNoteDialog(note?: FSNote): void {
        const dialogRef = this._dialog.open(FSNoteDialogComponent, {
            width: '520px',
            maxWidth: '95vw',
            panelClass: 'fs-note-dialog-panel',
            data: {
                customerId: this.customerId,
                masterTypes: this.masterTypes,
                note: note
            }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result) {
                this.loadNotes();
            }
        });
    }

    deleteNote(id: number): void {
        const confirmation = this._fuseConfirmationService.open({
            title: 'Delete Note',
            message: 'Are you sure you want to delete this financial note? This action cannot be undone.',
            actions: {
                confirm: {
                    label: 'Delete',
                    color: 'warn'
                }
            }
        });

        confirmation.afterClosed().subscribe((result) => {
            if (result === 'confirmed') {
                this._fsNoteService.deleteNote(id).subscribe(() => {
                    this._snackBar.open('Note deleted successfully', 'Close', { duration: 2000 });
                    this.loadNotes();
                });
            }
        });
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }
}

// --- Dialog Component ---
@Component({
    selector: 'fs-note-dialog',
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatButtonModule,
        MatIconModule,
        MatDialogModule
    ],
    template: `
        <div class="flex flex-col overflow-hidden">
            <div class="flex items-center justify-between py-4 pr-3 pl-6 border-b bg-gray-50 dark:bg-transparent">
                <div class="text-lg font-medium">{{ data.note ? 'Edit' : 'Add' }} Notes Detail</div>
                <button mat-icon-button (click)="onCancel()" [tabIndex]="-1">
                    <mat-icon class="icon-size-5" [svgIcon]="'heroicons_outline:x-mark'"></mat-icon>
                </button>
            </div>

            <div class="p-8">
                <form [formGroup]="noteForm" class="flex flex-col">
                    <mat-form-field class="w-full" appearance="outline">
                        <mat-label>Note Type</mat-label>
                        <mat-select formControlName="fsNoteMasterId">
                            <mat-option *ngFor="let type of data.masterTypes" [value]="type.id">
                                {{ type.noteType }}
                            </mat-option>
                        </mat-select>
                        <mat-error *ngIf="noteForm.get('fsNoteMasterId').hasError('required')">
                            Note type is required
                        </mat-error>
                    </mat-form-field>

                    <mat-form-field class="w-full mt-4" appearance="outline">
                        <mat-label>Note</mat-label>
                        <textarea matInput formControlName="noteContent" rows="5" placeholder="Enter financial note details..."></textarea>
                        <mat-error *ngIf="noteForm.get('noteContent').hasError('required')">
                            Note content is required
                        </mat-error>
                    </mat-form-field>

                    @if (data.note) {
                        <div class="px-6 py-3 bg-gray-50 dark:bg-black/20 border-t border-divider flex flex-col sm:flex-row sm:items-center justify-between gap-2">
                            <div class="flex flex-col gap-1">
                                <div class="flex items-center text-[10px] font-medium text-secondary/60 uppercase tracking-wider">
                                    <mat-icon class="icon-size-3 mr-1" [svgIcon]="'heroicons_solid:pencil'"></mat-icon>
                                    <span>Made by {{ data.note.createdByUserName || 'System' }}</span>
                                    <span class="mx-1">•</span>
                                    <span>{{ data.note.createdDateTime | date: 'MMM dd, yyyy HH:mm' }}</span>
                                </div>
                                @if (data.note.updateDateTime !== data.note.createdDateTime) {
                                    <div class="flex items-center text-[10px] font-bold text-primary/80 uppercase tracking-wider">
                                        <mat-icon class="icon-size-3 mr-1" [svgIcon]="'heroicons_solid:arrow-path'"></mat-icon>
                                        <span>Updated by {{ data.note.updatedByUserName || 'System' }}</span>
                                        <span class="mx-1">•</span>
                                        <span>{{ data.note.updateDateTime | date: 'MMM dd, yyyy HH:mm' }}</span>
                                    </div>
                                }
                            </div>
                        </div>
                    }
                </form>
            </div>

            <div class="flex items-center justify-end px-8 py-4 border-t bg-gray-50 dark:bg-transparent">
                <button mat-button (click)="onCancel()">Cancel</button>
                <button class="ml-2" mat-flat-button color="primary" [disabled]="noteForm.invalid" (click)="onSave()">
                    {{ data.note ? 'Update' : 'Save' }}
                </button>
            </div>
        </div>
    `,
    styles: [`
        :host {
            display: block;
            overflow: hidden;
        }
        .mat-mdc-form-field.mat-focused .mdc-notched-outline__leading,
        .mat-mdc-form-field.mat-focused .mdc-notched-outline__notch,
        .mat-mdc-form-field.mat-focused .mdc-notched-outline__trailing {
            border-color: #cbd5e1 !important;
            border-width: 1px !important;
        }
        .mat-mdc-form-field.mat-focused .mat-mdc-floating-label {
            color: #64748b !important;
        }
        .mat-mdc-form-field.mat-focused .mat-mdc-select-arrow {
            color: #64748b !important;
        }
        textarea {
            resize: none;
            outline: none !important;
        }
    `],
    encapsulation: ViewEncapsulation.None
})
export class FSNoteDialogComponent implements OnInit {
    noteForm: FormGroup;
    private _fb = inject(FormBuilder);
    private _fsNoteService = inject(FSNoteService);

    constructor(
        public dialogRef: MatDialogRef<FSNoteDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any
    ) {}

    ngOnInit(): void {
        this.noteForm = this._fb.group({
            fsNoteMasterId: [this.data.note?.fsNoteMasterId || '', Validators.required],
            noteContent: [this.data.note?.noteContent || '', Validators.required]
        });
    }

    onCancel(): void {
        this.dialogRef.close();
    }

    onSave(): void {
        if (this.noteForm.invalid) return;

        const noteData = {
            customerId: this.data.customerId,
            ...this.noteForm.value
        };

        const request = this.data.note 
            ? this._fsNoteService.updateNote(this.data.note.id, noteData)
            : this._fsNoteService.createNote(noteData);

        request.subscribe(() => {
            this.dialogRef.close(true);
        });
    }
}
