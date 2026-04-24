import { Component, Inject, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatDividerModule } from '@angular/material/divider';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { CustomerService } from '../../customer.service';
import { Branch } from '../../customer.types';
import { FuseConfirmationService } from '@fuse/services/confirmation';

@Component({
    selector: 'branch-manager-dialog',
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        MatButtonModule,
        MatDialogModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatDividerModule,
        MatSnackBarModule
    ],
    template: `
        <div class="flex flex-col max-w-160 min-w-120 overflow-hidden">
            <!-- Header -->
            <div class="flex items-center justify-between px-6 py-4 bg-primary text-on-primary">
                <div class="text-lg font-semibold">Manage Business Branches</div>
                <button mat-icon-button (click)="close()" [disabled]="isSaving">
                    <mat-icon class="text-current" [svgIcon]="'heroicons_outline:x-mark'"></mat-icon>
                </button>
            </div>

            <div class="p-6">
                <!-- Add New Branch -->
                <div class="flex items-center gap-4 mb-8">
                    <mat-form-field class="fuse-mat-no-subscript flex-auto">
                        <mat-label>New Branch Name</mat-label>
                        <input matInput [(ngModel)]="newBranchName" placeholder="e.g. Sydney Office" (keyup.enter)="addBranch()">
                    </mat-form-field>
                    <button mat-flat-button color="primary" class="h-12 rounded-xl px-6 flex-shrink-0" (click)="addBranch()" [disabled]="!newBranchName || isSaving">
                        <mat-icon class="icon-size-5 mr-2" [svgIcon]="'heroicons_solid:plus'"></mat-icon>
                        Add Branch
                    </button>
                </div>

                <mat-divider class="mb-6"></mat-divider>

                <!-- Branch List -->
                <div class="space-y-3 max-h-80 overflow-y-auto pr-2">
                    <div *ngFor="let branch of branches" class="flex items-center justify-between p-3 bg-gray-50 dark:bg-gray-800 rounded-xl border border-divider">
                        <div class="flex flex-col">
                            <span class="font-semibold text-sm">{{ branch.branchName }}</span>
                        </div>
                        <div class="flex items-center gap-1">
                            <button mat-icon-button class="text-rose-500 w-8 h-8" (click)="deleteBranch(branch)" [disabled]="isSaving">
                                <mat-icon class="icon-size-4" [svgIcon]="'heroicons_solid:trash'"></mat-icon>
                            </button>
                        </div>
                    </div>
                    <div *ngIf="branches.length === 0" class="py-12 text-center text-secondary italic text-sm">
                        No branches defined for this business yet.
                    </div>
                </div>
            </div>

            <!-- Footer -->
            <div class="flex items-center justify-end px-6 py-4 bg-gray-50 dark:bg-gray-900 border-t">
                <button mat-button (click)="close()" [disabled]="isSaving">Close</button>
            </div>
        </div>
    `
})
export class BranchManagerDialogComponent implements OnInit {
    private _customerService = inject(CustomerService);
    private _snackBar = inject(MatSnackBar);
    private _fuseConfirmationService = inject(FuseConfirmationService);

    branches: Branch[] = [];
    newBranchName: string = '';
    isSaving: boolean = false;

    constructor(
        public dialogRef: MatDialogRef<BranchManagerDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: { customerId: number, localBranches?: Branch[] }
    ) {}

    ngOnInit(): void {
        if (this.data.customerId) {
            this.loadBranches();
        } else if (this.data.localBranches) {
            this.branches = [...this.data.localBranches];
        }
    }

    loadBranches(): void {
        this._customerService.getBranches(this.data.customerId).subscribe(res => {
            this.branches = res;
        });
    }

    addBranch(): void {
        if (!this.newBranchName) return;

        if (!this.data.customerId) {
            // Local mode
            const newLocalBranch: Branch = {
                id: Math.floor(Math.random() * -1000000), // Small negative random ID
                customerId: 0,
                branchName: this.newBranchName
            };
            this.branches.push(newLocalBranch);
            this.newBranchName = '';
            return;
        }

        this.isSaving = true;
        const branch: Partial<Branch> = {
            customerId: this.data.customerId,
            branchName: this.newBranchName
        };

        this._customerService.createBranch(branch).subscribe({
            next: () => {
                this._snackBar.open('Branch added successfully', 'OK', { duration: 2000 });
                this.newBranchName = '';
                this.isSaving = false;
                this.loadBranches();
            },
            error: () => {
                this.isSaving = false;
                this._snackBar.open('Failed to add branch', 'ERROR', { duration: 3000 });
            }
        });
    }

    deleteBranch(branch: Branch): void {
        this._fuseConfirmationService.open({
            title: 'Delete Branch',
            message: 'Are you sure you want to delete this branch? Any addresses linked to this branch will become unlinked.',
            actions: {
                confirm: { label: 'Delete', color: 'warn' }
            }
        }).afterClosed().subscribe(result => {
            if (result === 'confirmed') {
                if (!this.data.customerId) {
                    // Local mode
                    this.branches = this.branches.filter(b => b.id !== branch.id);
                    return;
                }

                this.isSaving = true;
                this._customerService.deleteBranch(branch.id).subscribe({
                    next: () => {
                        this._snackBar.open('Branch deleted', 'OK', { duration: 2000 });
                        this.isSaving = false;
                        this.loadBranches();
                    },
                    error: () => {
                        this.isSaving = false;
                        this._snackBar.open('Failed to delete branch', 'ERROR', { duration: 3000 });
                    }
                });
            }
        });
    }

    close(): void {
        this.dialogRef.close(this.branches); // Always return the current list
    }
}
