import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterLink } from '@angular/router';
import { CustomerService } from '../customer.service';
import { Subject, takeUntil } from 'rxjs';

@Component({
    selector     : 'customer-upload',
    templateUrl  : './upload.component.html',
    encapsulation: ViewEncapsulation.None,
    standalone   : true,
    imports      : [
        CommonModule,
        MatButtonModule,
        MatIconModule,
        MatTableModule,
        MatProgressBarModule,
        MatSnackBarModule,
        MatTooltipModule,
        RouterLink
    ]
})
export class UploadComponent implements OnInit {
    uploads: any[] = [];
    dataSource: MatTableDataSource<any> = new MatTableDataSource();
    displayedColumns: string[] = ['fileName', 'uploadDate', 'totalRecords', 'processed', 'failed', 'status', 'actions'];

    isLoading: boolean = false;
    isUploading: boolean = false;
    isProcessing: number | null = null; // Track which file is being processed
    selectedFile: File | null = null;
    dragOver: boolean = false;

    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor(
        private _customerService: CustomerService,
        private _snackBar: MatSnackBar
    ) {}

    ngOnInit(): void {
        this.loadHistory();
    }

    loadHistory(): void {
        this.isLoading = true;
        this._customerService.getUploadHistory()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe({
                next: (data) => {
                    this.uploads = data;
                    this.dataSource.data = data;
                    this.isLoading = false;
                },
                error: () => {
                    this.isLoading = false;
                    this._snackBar.open('Failed to load upload history.', 'Close', {
                        duration: 3000,
                        horizontalPosition: 'right',
                        verticalPosition: 'top',
                        panelClass: ['bg-red-600', 'text-white']
                    });
                }
            });
    }

    onFileSelected(event: any): void {
        const file = event.target.files[0];
        if (file) {
            this.selectedFile = file;
            this.uploadFile();
        }
    }

    onDragOver(event: DragEvent): void {
        event.preventDefault();
        event.stopPropagation();
        this.dragOver = true;
    }

    onDragLeave(event: DragEvent): void {
        event.preventDefault();
        event.stopPropagation();
        this.dragOver = false;
    }

    onDrop(event: DragEvent): void {
        event.preventDefault();
        event.stopPropagation();
        this.dragOver = false;
        const file = event.dataTransfer?.files[0];
        if (file) {
            this.selectedFile = file;
            this.uploadFile();
        }
    }

    uploadFile(): void {
        if (!this.selectedFile) return;

        this.isUploading = true;
        this._customerService.uploadFile(this.selectedFile)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe({
                next: () => {
                    this.isUploading = false;
                    this.selectedFile = null;
                    this._snackBar.open('File uploaded successfully! Click the process button to import records.', 'Close', {
                        duration: 5000,
                        horizontalPosition: 'right',
                        verticalPosition: 'top',
                        panelClass: ['bg-green-600', 'text-white']
                    });
                    this.loadHistory();
                },
                error: (err) => {
                    this.isUploading = false;
                    this._snackBar.open('Upload failed: ' + (err.error || 'Unknown error'), 'Close', {
                        duration: 4000,
                        horizontalPosition: 'right',
                        verticalPosition: 'top',
                        panelClass: ['bg-red-600', 'text-white']
                    });
                }
            });
    }

    processFile(id: number): void {
        this.isProcessing = id;
        this._customerService.processFile(id)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe({
                next: (result) => {
                    this.isProcessing = null;
                    const msg = result.recordFailed > 0
                        ? `Processed: ${result.recordProcessed} records. Failed: ${result.recordFailed} records.`
                        : `All ${result.recordProcessed} records imported successfully!`;
                    this._snackBar.open(msg, 'Close', {
                        duration: 5000,
                        horizontalPosition: 'right',
                        verticalPosition: 'top',
                        panelClass: [result.recordFailed > 0 ? 'bg-orange-600' : 'bg-green-600', 'text-white']
                    });
                    this.loadHistory();
                },
                error: (err) => {
                    this.isProcessing = null;
                    this._snackBar.open('Processing failed: ' + (err.error || 'Unknown error'), 'Close', {
                        duration: 4000,
                        horizontalPosition: 'right',
                        verticalPosition: 'top',
                        panelClass: ['bg-red-600', 'text-white']
                    });
                }
            });
    }

    getStatusLabel(processResult: number | null): string {
        if (processResult === null || processResult === undefined) return 'Pending';
        if (processResult === 0) return 'Pending';
        if (processResult === 1) return 'Success';
        return 'Errors';
    }

    getStatusClass(processResult: number | null): string {
        if (processResult === null || processResult === undefined || processResult === 0) return 'bg-amber-100 text-amber-800';
        if (processResult === 1) return 'bg-green-100 text-green-800';
        return 'bg-red-100 text-red-800';
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }
}
