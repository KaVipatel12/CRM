import { ChangeDetectionStrategy, ChangeDetectorRef, Component, inject, OnInit, ViewEncapsulation } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';
import { fuseAnimations } from '@fuse/animations';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { FormsService, FormMaster } from 'app/modules/admin/forms/forms.service';
import { CustomerService } from 'app/modules/admin/customers/customer.service';
import { Subject, takeUntil } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { EmailComposeComponent } from 'app/shared/components/email-compose/email-compose.component';

@Component({
    selector     : 'form-view',
    templateUrl  : './view.component.html',
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    animations   : fuseAnimations,
    standalone   : true,
    imports      : [CommonModule, FormsModule, MatButtonModule, MatIconModule, MatTooltipModule]
})
export class FormViewComponent implements OnInit
{
    private _activatedRoute = inject(ActivatedRoute);
    private _formsService = inject(FormsService);
    private _customerService = inject(CustomerService);
    private _router = inject(Router);
    private _changeDetectorRef = inject(ChangeDetectorRef);
    private _snackBar = inject(MatSnackBar);
    private _dialog = inject(MatDialog);

    form: FormMaster;
    customerData: any;
    isLoading: boolean = true;
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    /**
     * On init
     */
    ngOnInit(): void
    {
        const slug = this._activatedRoute.snapshot.paramMap.get('slug');
        const customerId = this._activatedRoute.snapshot.queryParamMap.get('customerId');

        if (slug)
        {
            this._formsService.getFormBySlug(slug).subscribe((form) => {
                this.form = form;
                this._changeDetectorRef.markForCheck();
            });
        }

        if (customerId)
        {
            this._customerService.getCustomerById(Number(customerId)).subscribe((customer) => {
                this.customerData = customer;
                this.isLoading = false;
                this._changeDetectorRef.markForCheck();
            });
        }
        else
        {
            this.isLoading = false;
        }
    }

    /**
     * Navigate back to the previous context
     */
    goBack(): void
    {
        const customerId = this._activatedRoute.snapshot.queryParamMap.get('customerId');
        const from = this._activatedRoute.snapshot.queryParamMap.get('from');

        if (from === 'customer' && customerId)
        {
            this._router.navigate(['/customers', customerId]);
        }
        else
        {
            this._router.navigate(['/forms']);
        }
    }

    /**
     * Download the PDF from backend
     */
    download(): void
    {
        if (!this.form) return;

        this.isLoading = true;
        this._changeDetectorRef.markForCheck();

        const customerId = this.customerData ? this.customerData.id : 0;

        this._formsService.getFormPDF(this.form.slug, customerId).subscribe({
            next: (response) => {
                this.isLoading = false;
                if (response && response.base64PDF) {
                    const linkSource = `data:application/pdf;base64,${response.base64PDF}`;
                    const downloadLink = document.createElement("a");
                    const fileName = response.fileName || `${this.form.slug}_${customerId || 'blank'}.pdf`;
                    downloadLink.href = linkSource;
                    downloadLink.download = fileName;
                    downloadLink.click();
                    this._snackBar.open('PDF Generated successfully', 'OK', { duration: 3000 });
                } else {
                    this._snackBar.open('PDF Generation failed: No data returned from server', 'Error', { duration: 5000 });
                }
                this._changeDetectorRef.markForCheck();
            },
            error: (error) => {
                this.isLoading = false;
                const errorMessage = error?.error || 'Error generating PDF from backend legacy engine';
                this._snackBar.open(errorMessage, 'Error', { duration: 5000 });
                this._changeDetectorRef.markForCheck();
            }
        });
    }

    /**
     * Send the PDF via email
     */
    email(): void
    {
        if (!this.form) return;

        const customerId = this.customerData ? this.customerData.id : 0;
        
        // Define default body and subject
        const defaultSubject = `Form: ${this.form.name}`;
        const defaultBody = `<p>Dear ${this.customerData?.name || 'Client'},</p><p>Please find the attached ${this.form.name}.</p><br/><p>Thank you,</p><p>SSP CRM Team</p>`;
        const attachmentName = `${this.form.slug}_${customerId || 'blank'}.pdf`;

        // Open Dialog
        const dialogRef = this._dialog.open(EmailComposeComponent, {
            data: {
                toEmail: this.customerData?.contactInfo?.email || this.customerData?.email || '',
                subject: defaultSubject,
                body: defaultBody,
                attachmentName: attachmentName
            },
            panelClass: 'email-compose-dialog-panel'
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result) {
                this.isLoading = true;
                this._changeDetectorRef.markForCheck();

                const emailDetails = {
                    emailId: result.to,
                    subject: result.subject,
                    body: result.body
                };

                this._formsService.sendFormEmail(this.form.slug, customerId, emailDetails).subscribe({
                    next: (response) => {
                        this.isLoading = false;
                        this._snackBar.open('Email sent successfully', 'OK', { duration: 3000 });
                        this._changeDetectorRef.markForCheck();
                    },
                    error: () => {
                        this.isLoading = false;
                        this._snackBar.open('Error sending email', 'Error', { duration: 5000 });
                        this._changeDetectorRef.markForCheck();
                    }
                });
            }
        });
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void
    {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }
}
