import { CommonModule } from '@angular/common';
import { Component, Input, OnInit, inject } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { CustomerService } from '../../customer.service';
import { CustomerServicePortfolio } from '../../customer.types';
import { ServiceDialogComponent } from './service-dialog/service-dialog.component';

@Component({
    selector: 'app-service-portfolio',
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatIconModule,
        MatTableModule,
        MatDialogModule,
        MatTooltipModule
    ],
    templateUrl: './service-portfolio.component.html'
})
export class ServicePortfolioComponent implements OnInit {
    @Input() customerId: number;
    
    private _customerService = inject(CustomerService);
    private _matDialog = inject(MatDialog);
    private _fuseConfirmationService = inject(FuseConfirmationService);

    services: CustomerServicePortfolio[] = [];
    displayedColumns: string[] = ['serviceName', 'amount', 'unit', 'lastEdit', 'actions'];

    ngOnInit(): void {
        this.loadServices();
    }

    loadServices(): void {
        if (!this.customerId) return;
        this._customerService.getCustomerServices(this.customerId).subscribe((data) => {
            this.services = data;
        });
    }

    getUnitLabel(unit: string): string {
        switch (unit) {
            case 'y': return 'Yearly';
            case 'q': return 'Quarterly';
            case 'm': return 'Monthly';
            case 'w': return 'Weekly';
            case 'd': return 'Daily';
            default: return unit;
        }
    }

    openServiceDialog(service?: CustomerServicePortfolio): void {
        const dialogRef = this._matDialog.open(ServiceDialogComponent, {
            data: {
                customerId: this.customerId,
                service: service
            },
            width: '500px'
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result) {
                this.loadServices();
            }
        });
    }

    deleteService(id: number): void {
        const dialogRef = this._fuseConfirmationService.open({
            title: 'Delete Service',
            message: 'Are you sure you want to remove this service from the customer portfolio?',
            actions: {
                confirm: {
                    label: 'Delete',
                    color: 'warn'
                }
            }
        });

        dialogRef.afterClosed().subscribe((result) => {
            if (result === 'confirmed') {
                this._customerService.deleteCustomerService(id).subscribe(() => {
                    this.loadServices();
                });
            }
        });
    }
}
