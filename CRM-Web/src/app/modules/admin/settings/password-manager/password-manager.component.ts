import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, OnDestroy, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { fuseAnimations } from '@fuse/animations';
import { finalize } from 'rxjs';
import { PasswordManagerService } from './password-manager.service';
import { PasswordManager } from './password-manager.types';
import { MasterPasswordDialogComponent } from './master-password-dialog/master-password-dialog.component';
import { FuseConfirmationService } from '@fuse/services/confirmation';

@Component({
    selector: 'password-manager',
    standalone: true,
    templateUrl: './password-manager.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatDialogModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatMenuModule,
        MatProgressBarModule,
        MatSnackBarModule,
        MatTableModule,
        MatTooltipModule,
        RouterLink
    ]
})
export class PasswordManagerComponent implements OnInit, OnDestroy {
    private _fb = inject(FormBuilder);
    private _passwordService = inject(PasswordManagerService);
    private _snackBar = inject(MatSnackBar);
    private _dialog = inject(MatDialog);
    private _fuseConfirmationService = inject(FuseConfirmationService);

    passwords: PasswordManager[] = [];
    displayedColumns: string[] = ['title', 'userName', 'url', 'password', 'actions'];
    isLoading = false;
    searchInput: string = '';

    // For Add/Edit
    passwordForm: FormGroup;
    selectedPassword: PasswordManager | null = null;
    isFormOpen = false;
    isSaving = false;
    showPassword = false;
    cachedMasterPassword: string | null = null;
    private _autoLockTimer: any;
    private _inactivityTimeout = 5 * 60 * 1000; // 5 minutes

    ngOnInit(): void {
        this.passwordForm = this._fb.group({
            id: [0],
            title: ['', Validators.required],
            url: [''],
            userName: [''],
            password: ['', Validators.required],
            note: [''],
            masterPassword: ['', Validators.required]
        });

        this.loadPasswords();
    }

    ngOnDestroy(): void {
        if (this._autoLockTimer) {
            clearTimeout(this._autoLockTimer);
        }
    }

    loadPasswords(): void {
        this.isLoading = true;
        this._passwordService.getPasswords()
            .pipe(finalize(() => this.isLoading = false))
            .subscribe({
                next: (passwords) => {
                    this.passwords = passwords;
                },
                error: () => {
                    this._snackBar.open('Error loading passwords', 'Close', { duration: 3000 });
                }
            });
    }

    openAddForm(): void {
        this.resetAutoLockTimer();
        this.selectedPassword = null;
        this.passwordForm.reset({ id: 0 });
        this.isFormOpen = true;
    }

    openEditForm(password: PasswordManager): void {
        this.resetAutoLockTimer();
        const proceedWithEdit = (masterPassword: string) => {
            this.isLoading = true;
            this._passwordService.getPasswordDetails(password.id, masterPassword)
                .pipe(finalize(() => this.isLoading = false))
                .subscribe({
                    next: (details) => {
                        this.cachedMasterPassword = masterPassword;
                        this.selectedPassword = details;
                        this.passwordForm.patchValue({
                            ...details,
                            masterPassword: masterPassword
                        });
                        this.isFormOpen = true;
                    },
                    error: () => {
                        this.cachedMasterPassword = null;
                        this._snackBar.open('Invalid Master Password or Error loading details', 'Close', { duration: 3000 });
                    }
                });
        };

        if (this.cachedMasterPassword) {
            proceedWithEdit(this.cachedMasterPassword);
        } else {
            this._dialog.open(MasterPasswordDialogComponent, {
                data: {
                    title: 'Authorize Edit',
                    message: `Enter Master Password to edit "${password.title}"`
                }
            }).afterClosed().subscribe((masterPassword) => {
                if (masterPassword) proceedWithEdit(masterPassword);
            });
        }
    }

    closeForm(): void {
        this.isFormOpen = false;
        this.passwordForm.reset();
    }

    savePassword(): void {
        if (this.passwordForm.invalid) return;

        this.isSaving = true;
        const formValues = this.passwordForm.value;
        const request = {
            passwordData: {
                id: formValues.id,
                title: formValues.title,
                url: formValues.url,
                userName: formValues.userName,
                password: formValues.password,
                note: formValues.note
            },
            masterPassword: formValues.masterPassword
        };

        this._passwordService.savePassword(request)
            .pipe(finalize(() => this.isSaving = false))
            .subscribe({
                next: () => {
                    this._snackBar.open('Password saved successfully', 'OK', { duration: 3000 });
                    this.closeForm();
                    this.loadPasswords();
                },
                error: () => {
                    this._snackBar.open('Error saving password. Check Master Password.', 'Close', { duration: 3000 });
                }
            });
    }

    deletePassword(id: number): void {
        this.resetAutoLockTimer();
        const proceedWithDelete = (masterPassword: string) => {
            const confirmation = this._fuseConfirmationService.open({
                title: 'Delete Password',
                message: 'Are you sure you want to permanently delete this entry? This action cannot be undone!',
                actions: {
                    confirm: {
                        label: 'Delete',
                        color: 'warn'
                    }
                }
            });

            confirmation.afterClosed().subscribe((result) => {
                if (result === 'confirmed') {
                    this.isLoading = true;
                    this._passwordService.deletePassword(id, masterPassword)
                        .pipe(finalize(() => this.isLoading = false))
                        .subscribe({
                            next: () => {
                                this.cachedMasterPassword = masterPassword;
                                this._snackBar.open('Password deleted successfully', 'OK', { duration: 3000 });
                                this.loadPasswords();
                            },
                            error: () => {
                                this.cachedMasterPassword = null;
                                this._snackBar.open('Error deleting password. Check Master Password.', 'Close', { duration: 3000 });
                            }
                        });
                }
            });
        };

        if (this.cachedMasterPassword) {
            proceedWithDelete(this.cachedMasterPassword);
        } else {
            this._dialog.open(MasterPasswordDialogComponent, {
                data: {
                    title: 'Authorize Deletion',
                    message: 'Enter Master Password to permanently delete this entry.'
                }
            }).afterClosed().subscribe((masterPassword) => {
                if (masterPassword) proceedWithDelete(masterPassword);
            });
        }
    }

    revealPassword(password: PasswordManager): void {
        this.resetAutoLockTimer();
        // If already decrypted, just toggle visibility
        if (password.decryptedPassword) {
            password.isRevealed = !password.isRevealed;
            return;
        }

        const proceedWithReveal = (masterPassword: string) => {
            this.isLoading = true;
            this._passwordService.getPasswordDetails(password.id, masterPassword)
                .pipe(finalize(() => this.isLoading = false))
                .subscribe({
                    next: (details) => {
                        this.cachedMasterPassword = masterPassword; // Store in cache
                        password.decryptedPassword = details.password;
                        password.isRevealed = true;
                    },
                    error: () => {
                        this.cachedMasterPassword = null; // Clear cache on error
                        this._snackBar.open('Invalid Master Password', 'Close', { duration: 3000 });
                    }
                });
        };

        // Use cache if available
        if (this.cachedMasterPassword) {
            proceedWithReveal(this.cachedMasterPassword);
        } else {
            this._dialog.open(MasterPasswordDialogComponent, {
                data: {
                    title: 'Reveal Password',
                    message: `Enter Master Password to see the password for "${password.title}"`
                }
            }).afterClosed().subscribe((masterPassword) => {
                if (masterPassword) proceedWithReveal(masterPassword);
            });
        }
    }

    lockVault(): void {
        if (this._autoLockTimer) {
            clearTimeout(this._autoLockTimer);
        }
        this.cachedMasterPassword = null;
        // Also hide all passwords that were revealed in memory
        this.passwords.forEach(p => {
            p.isRevealed = false;
            p.decryptedPassword = undefined;
        });
        this._snackBar.open('Vault locked due to inactivity', 'OK', { duration: 2000 });
    }

    resetAutoLockTimer(): void {
        if (!this.cachedMasterPassword) return;

        if (this._autoLockTimer) {
            clearTimeout(this._autoLockTimer);
        }

        this._autoLockTimer = setTimeout(() => {
            this.lockVault();
        }, this._inactivityTimeout);
    }

    get filteredPasswords(): PasswordManager[] {
        if (!this.searchInput) return this.passwords;
        const search = this.searchInput.toLowerCase();
        return this.passwords.filter(p => 
            p.title.toLowerCase().includes(search) || 
            p.userName?.toLowerCase().includes(search) || 
            p.url?.toLowerCase().includes(search)
        );
    }
}
