import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { TodoService } from '../todo.service';

@Component({
    selector: 'todo-dialog',
    template: `
        <div class="flex flex-col max-w-160 min-w-80 md:min-w-120 overflow-hidden">
            <div class="flex items-center justify-between p-6 bg-primary text-on-primary">
                <div class="text-2xl font-bold tracking-tight">Add Personal To-Do</div>
                <button mat-icon-button (click)="close()" class="text-white">
                    <mat-icon [svgIcon]="'heroicons_outline:x-mark'"></mat-icon>
                </button>
            </div>

            <div class="p-8">
                <form [formGroup]="todoForm" (ngSubmit)="save()">
                    <mat-form-field class="fuse-mat-no-subscript w-full" [appearance]="'outline'">
                        <mat-label>What needs to be done?</mat-label>
                        <textarea matInput [formControlName]="'note'" [rows]="3" placeholder="Enter your reminder..."></textarea>
                    </mat-form-field>

                    <div class="flex items-center justify-end mt-8">
                        <button mat-button (click)="close()">Cancel</button>
                        <button class="ml-2" mat-flat-button color="primary" [disabled]="todoForm.invalid" (click)="save()">
                            Add Reminder
                        </button>
                    </div>
                </form>
            </div>
        </div>
    `,
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatDialogModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule
    ]
})
export class TodoDialogComponent {
    todoForm: UntypedFormGroup;

    private _dialogRef = inject(MatDialogRef<TodoDialogComponent>);
    private _todoService = inject(TodoService);
    private _formBuilder = inject(UntypedFormBuilder);

    constructor() {
        this.todoForm = this._formBuilder.group({
            note: ['', [Validators.required]]
        });
    }

    close(): void {
        this._dialogRef.close();
    }

    save(): void {
        if (this.todoForm.invalid) return;

        const note = this.todoForm.get('note')?.value;
        this._todoService.createTodo(note).subscribe(() => {
            this._dialogRef.close(true);
        });
    }
}
