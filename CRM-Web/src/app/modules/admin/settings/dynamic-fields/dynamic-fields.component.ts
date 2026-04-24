import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { DynamicFieldService } from 'app/modules/admin/customers/dynamic-field.service';
import { DynamicFieldMaster } from 'app/modules/admin/customers/customer.types';
import { DynamicFieldDialogComponent } from './dialog/dynamic-field-dialog.component';
import { finalize } from 'rxjs';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

import { UserService } from 'app/core/user/user.service';

@Component({
    selector: 'dynamic-fields-admin',
    standalone: true,
    templateUrl: './dynamic-fields.component.html',
    imports: [
        CommonModule,
        MatButtonModule,
        MatDialogModule,
        MatIconModule,
        MatProgressSpinnerModule,
        MatTableModule,
        RouterLink,
        MatSnackBarModule
    ]
})
export class DynamicFieldsAdminComponent implements OnInit {
    private _dynamicFieldService = inject(DynamicFieldService);
    private _dialog = inject(MatDialog);
    private _fuseConfirmationService = inject(FuseConfirmationService);
    private _snackBar = inject(MatSnackBar);
    private _userService = inject(UserService);

    fields: DynamicFieldMaster[] = [];
    isLoading = false;
    displayedColumns: string[] = ['displayName', 'fieldType', 'actions'];
    isReadOnly = false;

    ngOnInit(): void {
        // In the legacy system, anyone could add/edit dynamic fields.
        // We are matching that behavior here.
        this.isReadOnly = false;
        
        this.loadFields();
    }

    loadFields(): void {
        this.isLoading = true;
        this._dynamicFieldService.getMasters()
            .pipe(finalize(() => this.isLoading = false))
            .subscribe({
                next: (data) => {
                    this.fields = data;
                },
                error: (err) => {
                    this._snackBar.open('Failed to load fields', 'Close', { duration: 3000 });
                }
            });
    }

    openDialog(field?: DynamicFieldMaster): void {
        const dialogRef = this._dialog.open(DynamicFieldDialogComponent, {
            width: '560px',
            maxWidth: '90vw',
            autoFocus: false,
            panelClass: 'dynamic-field-dialog-panel',
            data: { field: field }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result) {
                if (field && field.id) {
                    // Update
                    this.isLoading = true;
                    this._dynamicFieldService.updateMaster(field.id, result).subscribe({
                        next: () => {
                            this._snackBar.open('Field updated', 'OK', { duration: 2000 });
                            this.loadFields();
                        },
                        error: () => {
                            this.isLoading = false;
                            this._snackBar.open('Failed to update field', 'Close', { duration: 3000 });
                        }
                    });
                } else {
                    // Add
                    this.isLoading = true;
                    this._dynamicFieldService.addMaster(result).subscribe({
                        next: () => {
                            this._snackBar.open('Field added', 'OK', { duration: 2000 });
                            this.loadFields();
                        },
                        error: () => {
                            this.isLoading = false;
                            this._snackBar.open('Failed to add field', 'Close', { duration: 3000 });
                        }
                    });
                }
            }
        });
    }

    deleteField(field: DynamicFieldMaster): void {
        const confirmation = this._fuseConfirmationService.open({
            title: 'Delete Dynamic Field',
            message: `Are you sure you want to delete the field "${field.displayName}"? This action cannot be undone.`,
            icon: { show: true, name: 'heroicons_outline:exclamation-triangle', color: 'warn' },
            actions: {
                confirm: { show: true, label: 'Remove', color: 'warn' },
                cancel: { show: true, label: 'Cancel' }
            }
        });

        confirmation.afterClosed().subscribe((result) => {
            if (result === 'confirmed') {
                this.isLoading = true;
                this._dynamicFieldService.deleteMaster(field.id).subscribe({
                    next: () => {
                        this._snackBar.open('Field deleted', 'OK', { duration: 2000 });
                        this.loadFields();
                    },
                    error: () => {
                        this.isLoading = false;
                        this._snackBar.open('Failed to delete field', 'Close', { duration: 3000 });
                    }
                });
            }
        });
    }
}
