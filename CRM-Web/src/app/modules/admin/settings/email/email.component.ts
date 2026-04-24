import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, ViewEncapsulation } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule, MatChipInputEvent } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { EmailSettingsService } from './email.service';
import { finalize } from 'rxjs';

import { UserService } from 'app/core/user/user.service';

@Component({
    selector: 'email-settings',
    standalone: true,
    templateUrl: './email.component.html',
    encapsulation: ViewEncapsulation.None,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatChipsModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatSnackBarModule,
        MatTooltipModule,
        RouterLink
    ]
})
export class EmailSettingsComponent implements OnInit {
    private _fb = inject(FormBuilder);
    private _smtpService = inject(EmailSettingsService);
    private _snackBar = inject(MatSnackBar);
    private _userService = inject(UserService);

    settingsForm: FormGroup;
    isLoading = false;
    isSaving = false;
    hidePassword = true;
    isReadOnly = false;
    
    // Chips configuration
    readonly separatorKeysCodes = [ENTER, COMMA] as const;
    ccEmails: string[] = [];

    ngOnInit(): void {
        this.settingsForm = this._fb.group({
            id: [0],
            providerName: ['', Validators.required],
            host: ['', Validators.required],
            port: [587, [Validators.required, Validators.min(1)]],
            username: ['', [Validators.required, Validators.email]],
            encryptedPassword: ['', Validators.required],
            fromEmail: ['', [Validators.required, Validators.email]],
            fromName: ['', Validators.required],
            isActive: [true]
        });

        this._userService.user$.subscribe(user => {
            this.isReadOnly = !(user?.isAdmin || user?.isSuperAdmin);
        });

        this.loadSettings();
    }

    loadSettings(): void {
        this.isLoading = true;
        this._smtpService.getSettings()
            .pipe(finalize(() => this.isLoading = false))
            .subscribe({
                next: (settings) => {
                    this.settingsForm.patchValue(settings);
                    if (settings.ccEmailsJson) {
                        try {
                            this.ccEmails = JSON.parse(settings.ccEmailsJson);
                        } catch (e) {
                            this.ccEmails = [];
                        }
                    }
                },
                error: (err) => {
                    this._snackBar.open('Error loading settings', 'Close', { duration: 3000 });
                }
            });
    }

    addCC(event: MatChipInputEvent): void {
        const value = (event.value || '').trim();
        // Add our email (simple regex for basic validation)
        if (value && /^\S+@\S+\.\S+$/.test(value)) {
            if (!this.ccEmails.includes(value)) {
                this.ccEmails.push(value);
            }
        }
        // Clear the input value
        event.chipInput!.clear();
    }

    addCCFromButton(inputElement: HTMLInputElement): void {
        const value = (inputElement.value || '').trim();
        if (value && /^\S+@\S+\.\S+$/.test(value)) {
            if (!this.ccEmails.includes(value)) {
                this.ccEmails.push(value);
                inputElement.value = '';
            }
        }
    }

    removeCC(email: string): void {
        const index = this.ccEmails.indexOf(email);
        if (index >= 0) {
            this.ccEmails.splice(index, 1);
        }
    }

    save(): void {
        if (this.settingsForm.invalid) return;

        this.isSaving = true;
        const formValues = this.settingsForm.getRawValue();
        
        // Prepare payload with CC list as JSON string
        const payload = {
            ...formValues,
            ccEmailsJson: JSON.stringify(this.ccEmails)
        };

        this._smtpService.saveSettings(payload)
            .pipe(finalize(() => this.isSaving = false))
            .subscribe({
                next: () => {
                    this._snackBar.open('Settings saved successfully', 'OK', { duration: 3000 });
                },
                error: (err) => {
                    this._snackBar.open('Error saving settings', 'Close', { duration: 3000 });
                }
            });
    }
}
