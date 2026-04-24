import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@Component({
    selector: 'master-password-dialog',
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
    ],
    template: `
        <div class="flex flex-col max-w-120 -m-6">
            <!-- Header -->
            <div class="flex items-center justify-between pl-8 pr-6 py-4 bg-primary text-on-primary">
                <div class="text-lg font-medium">{{data.title || 'Master Password Required'}}</div>
                <button mat-icon-button (click)="cancel()" [tabIndex]="-1">
                    <mat-icon class="text-current" [svgIcon]="'heroicons_outline:x-mark'"></mat-icon>
                </button>
            </div>

            <!-- Content -->
            <div class="p-8">
                <div class="flex flex-col">
                    <div class="text-secondary mb-4">
                        {{data.message || 'Please enter your master vault password to continue.'}}
                    </div>
                    
                    <form [formGroup]="passwordForm" (ngSubmit)="confirm()">
                        <mat-form-field class="w-full" [subscriptSizing]="'dynamic'">
                            <mat-label>Master Password</mat-label>
                            <input
                                matInput
                                [type]="'password'"
                                [formControlName]="'password'"
                                [placeholder]="'Enter password'"
                                autofocus>
                            <mat-icon
                                matPrefix
                                class="icon-size-5"
                                [svgIcon]="'heroicons_solid:key'"></mat-icon>
                        </mat-form-field>
                    </form>
                </div>
            </div>

            <!-- Actions -->
            <div class="flex items-center justify-end px-8 py-4 bg-gray-50 dark:bg-transparent border-t">
                <button mat-button (click)="cancel()">Cancel</button>
                <button
                    class="ml-2"
                    mat-flat-button
                    [color]="'primary'"
                    [disabled]="passwordForm.invalid"
                    (click)="confirm()">
                    Verify
                </button>
            </div>
        </div>
    `
})
export class MasterPasswordDialogComponent {
    private _dialogRef = inject(MatDialogRef<MasterPasswordDialogComponent>);
    public data = inject(MAT_DIALOG_DATA);
    private _fb = inject(FormBuilder);

    passwordForm: FormGroup = this._fb.group({
        password: ['', Validators.required]
    });

    cancel(): void {
        this._dialogRef.close();
    }

    confirm(): void {
        if (this.passwordForm.invalid) return;
        this._dialogRef.close(this.passwordForm.get('password')?.value);
    }
}
