import { CommonModule } from '@angular/common';
import { Component, Input, OnChanges, SimpleChanges, inject, OnInit } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { CustomerService } from '../../customer.service';
import { CustomerServicePortfolio } from '../../customer.types';
import { JobService } from '../../../jobs/job.service';
import { Job } from '../../../jobs/job.types';
import { FSNote, FSNoteService } from '../fs-notes/fs-notes.service';

@Component({
    selector: 'customer-summary',
    standalone: true,
    imports: [CommonModule, MatIconModule, MatButtonModule, MatDividerModule],
    templateUrl: './summary.component.html'
})
export class SummaryComponent implements OnInit, OnChanges {
    @Input() customer: any;
    @Input() customerId: number;
    @Input() lastVarifiedDate: string;
    @Input() lastVarifiedUserName: string;

    private _customerService = inject(CustomerService);
    private _jobService = inject(JobService);
    private _fsNoteService = inject(FSNoteService);

    services: CustomerServicePortfolio[] = [];
    jobs: Job[] = [];
    fsNotes: FSNote[] = [];
    checklistItems: any[] = [];
    totalFees: number = 0;
    activeJobsCount: number = 0;
    currentYear: number = new Date().getFullYear();

    ngOnInit(): void {
        if (this.customerId) {
            this.loadSummaryData();
        }
    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes['customerId'] && this.customerId && !changes['customerId'].firstChange) {
            this.loadSummaryData();
        }
    }

    printSummary(): void {
        const printContent = document.getElementById('print-area');
        if (!printContent) return;

        const printWindow = window.open('', '_blank', 'width=900,height=700');
        if (!printWindow) return;

        printWindow.document.write(`
            <!DOCTYPE html>
            <html>
            <head>
                <title>Customer Report - ${this.customer?.name || 'CRM'}</title>
                <style>
                    @page { size: A4; margin: 12mm; }
                    * { box-sizing: border-box; margin: 0; padding: 0; }
                    body {
                        font-family: -apple-system, BlinkMacSystemFont, 'Inter', 'Segoe UI', Roboto, sans-serif;
                        color: #1e293b;
                        background: white;
                        padding: 0;
                        -webkit-print-color-adjust: exact !important;
                        print-color-adjust: exact !important;
                    }
                    .report-container { max-width: 100%; }
                    .section {
                        border: 1px solid #e2e8f0;
                        border-radius: 12px;
                        margin-bottom: 20px;
                        overflow: visible;
                        page-break-inside: avoid;
                    }
                    .section-header {
                        padding: 20px 28px;
                        border-bottom: 1px solid #e2e8f0;
                    }
                    .section-title {
                        font-size: 16px;
                        font-weight: 800;
                        text-transform: uppercase;
                        letter-spacing: 0.03em;
                        color: #4f46e5;
                    }
                    .section-subtitle {
                        font-size: 9px;
                        font-weight: 700;
                        text-transform: uppercase;
                        letter-spacing: 0.1em;
                        color: #94a3b8;
                        margin-top: 2px;
                    }
                    .section-body { padding: 20px 28px; }
                    .field-row {
                        display: flex;
                        flex-direction: column;
                        margin-bottom: 16px;
                    }
                    .field-label {
                        font-size: 9px;
                        font-weight: 700;
                        text-transform: uppercase;
                        letter-spacing: 0.1em;
                        color: #94a3b8;
                        margin-bottom: 3px;
                    }
                    .field-value {
                        font-size: 13px;
                        font-weight: 600;
                        color: #1e293b;
                    }
                    .grid-3 {
                        display: grid;
                        grid-template-columns: repeat(3, 1fr);
                        gap: 16px 32px;
                    }
                    .grid-2 {
                        display: grid;
                        grid-template-columns: repeat(2, 1fr);
                        gap: 20px;
                    }
                    .status-dot {
                        display: inline-block;
                        width: 8px; height: 8px;
                        border-radius: 50%;
                        margin-right: 6px;
                    }
                    .text-primary { color: #4f46e5; }
                    .text-emerald { color: #059669; }
                    .text-amber { color: #d97706; }
                    .text-secondary { color: #94a3b8; }
                    .font-bold { font-weight: 700; }
                    .font-extrabold { font-weight: 800; }
                    .text-sm { font-size: 13px; }
                    .text-xs { font-size: 11px; }
                    .text-2xl { font-size: 22px; }
                    .uppercase { text-transform: uppercase; }

                    /* TABLES */
                    table { width: 100%; border-collapse: collapse; }
                    th {
                        padding: 10px 20px;
                        font-size: 9px;
                        font-weight: 700;
                        text-transform: uppercase;
                        letter-spacing: 0.08em;
                        color: #64748b;
                        background: #f8fafc;
                        border-bottom: 1px solid #e2e8f0;
                        text-align: left;
                    }
                    td {
                        padding: 10px 20px;
                        font-size: 12px;
                        border-bottom: 1px solid #f1f5f9;
                    }
                    .text-right { text-align: right; }
                    .italic { font-style: italic; }
                    tfoot td {
                        font-weight: 700;
                        background: #f8fafc;
                        border-top: 2px solid #e2e8f0;
                    }
                    .badge {
                        display: inline-block;
                        font-size: 9px;
                        font-weight: 700;
                        padding: 2px 8px;
                        border-radius: 4px;
                        background: #dbeafe;
                        color: #1d4ed8;
                        text-transform: uppercase;
                        letter-spacing: 0.05em;
                    }
                    .info-row {
                        display: flex;
                        justify-content: space-between;
                        align-items: center;
                        padding: 10px 0;
                        border-bottom: 1px solid #f1f5f9;
                    }
                    .info-row:last-child { border-bottom: none; }
                    .footer {
                        margin-top: 30px;
                        padding-top: 12px;
                        border-top: 1px solid #e2e8f0;
                        text-align: center;
                        font-size: 9px;
                        color: #94a3b8;
                    }
                    .empty-state {
                        text-align: center;
                        padding: 30px;
                        color: #94a3b8;
                        font-style: italic;
                        font-size: 12px;
                    }
                </style>
            </head>
            <body>
                <div class="report-container">
                    ${this._buildClientSection()}
                    <div class="grid-2">
                        ${this._buildCommunicationSection()}
                        ${this._buildComplianceSection()}
                    </div>
                    ${this._buildChecklistSection()}
                    ${this._buildFSNotesSection()}
                    ${this._buildServicesTable()}
                    ${this._buildJobsTable()}
                    <div class="footer">
                        &copy; ${this.currentYear} SuperSmartPlans CRM Portfolio Report &middot; Confidential Document &middot; Generated on ${new Date().toLocaleDateString()}
                    </div>
                </div>
            </body>
            </html>
        `);
        printWindow.document.close();
        setTimeout(() => {
            printWindow.print();
            printWindow.close();
        }, 400);
    }

    private _buildClientSection(): string {
        const c = this.customer;
        return `
        <div class="section">
            <div class="section-header" style="display:flex;justify-content:space-between;align-items:flex-start;">
                <div>
                    <div class="section-title">Client Detail</div>
                    <div class="section-subtitle">Core Information & Identity</div>
                </div>
                <div style="text-align:right;">
                    <div class="section-subtitle">Client ID</div>
                    <div class="text-sm font-bold">#${c?.id || ''}</div>
                </div>
            </div>
            <div class="section-body">
                <div class="grid-3">
                    <div class="field-row"><span class="field-label">Full Legal Name</span><span class="field-value">${c?.name || '-'}</span></div>
                    <div class="field-row"><span class="field-label">System Code</span><span class="field-value">${c?.code || '-'}</span></div>
                    <div class="field-row"><span class="field-label">Trading Name</span><span class="field-value">${c?.tradingName || '-'}</span></div>
                    <div class="field-row"><span class="field-label">Registration (ABN)</span><span class="field-value">${c?.abnNumber || '-'}</span></div>
                    <div class="field-row"><span class="field-label">Tax File Number (TFN)</span><span class="field-value">${c?.tfnNumber || '-'}</span></div>
                    <div class="field-row"><span class="field-label">Account Status</span><span class="field-value"><span class="status-dot" style="background:${c?.isActive ? '#10b981' : '#ef4444'}"></span>${c?.isActive ? 'ACTIVE' : 'INACTIVE'}</span></div>
                </div>
            </div>
        </div>`;
    }

    private _buildCommunicationSection(): string {
        const ci = this.customer?.contactInfo;
        return `
        <div class="section">
            <div class="section-header">
                <div class="section-title">Communication</div>
                <div class="section-subtitle">Primary Contact Channels</div>
            </div>
            <div class="section-body">
                <div class="info-row"><span class="field-label">Contact Name</span><span class="text-sm font-bold">${ci?.contactName || '-'}</span></div>
                <div class="info-row"><span class="field-label">Mobile Phone</span><span class="text-sm font-bold">${ci?.cellPhone || '-'}</span></div>
                <div class="info-row"><span class="field-label">Email Address</span><span class="text-sm font-bold text-primary">${ci?.email || '-'}</span></div>
            </div>
        </div>`;
    }

    private _buildComplianceSection(): string {
        const verifiedHtml = this.lastVarifiedDate
            ? `<span class="text-sm font-bold">Validated on ${new Date(this.lastVarifiedDate).toLocaleDateString()}</span><br><span class="text-xs text-secondary">by ${this.lastVarifiedUserName}</span>`
            : `<span class="text-xs text-amber italic font-bold">Verification Awaiting Action</span>`;

        return `
        <div class="section">
            <div class="section-header">
                <div class="section-title">Compliance & Value</div>
                <div class="section-subtitle">Verification & Annual Estimates</div>
            </div>
            <div class="section-body">
                <div style="margin-bottom:16px;">
                    <div class="field-label">Verification Info</div>
                    ${verifiedHtml}
                </div>
                <div style="border-top:1px solid #e2e8f0;padding-top:16px;">
                    <div class="field-label">Estimated Annual Revenue</div>
                    <div class="text-2xl font-extrabold text-emerald">${this._formatCurrency(this.totalFees)}</div>
                </div>
            </div>
        </div>`;
    }

    private _buildServicesTable(): string {
        if (this.services.length === 0) {
            return `
            <div class="section">
                <div class="section-header">
                    <div class="section-title">Service Portfolio</div>
                    <div class="section-subtitle">Detailed Billing & Service Assignments</div>
                </div>
                <div class="empty-state">No active services defined in portfolio.</div>
            </div>`;
        }

        const rows = this.services.map(s => {
            const freq = s.unit === 'y' ? 'Yearly' : s.unit === 'q' ? 'Quarterly' : s.unit === 'm' ? 'Monthly' : 'Periodic';
            return `<tr>
                <td class="font-bold">${s.serviceName}</td>
                <td><span class="badge">${freq}</span></td>
                <td class="text-right font-bold">${this._formatCurrency(s.amount)}</td>
                <td class="text-secondary italic text-xs">${s.internalNotes || '-'}</td>
            </tr>`;
        }).join('');

        return `
        <div class="section">
            <div class="section-header">
                <div class="section-title">Service Portfolio</div>
                <div class="section-subtitle">Detailed Billing & Service Assignments</div>
            </div>
            <table>
                <thead><tr>
                    <th>Service Type</th><th>Frequency</th><th class="text-right">Fee (Excl. GST)</th><th>Internal Notes</th>
                </tr></thead>
                <tbody>${rows}</tbody>
                <tfoot><tr>
                    <td colspan="2" class="text-right" style="font-size:9px;text-transform:uppercase;letter-spacing:0.1em;color:#94a3b8;">Aggregate Annual Estimate</td>
                    <td class="text-right text-primary" style="font-size:16px;">${this._formatCurrency(this.totalFees)}</td>
                    <td></td>
                </tr></tfoot>
            </table>
        </div>`;
    }

    private _buildJobsTable(): string {
        if (this.jobs.length === 0) {
            return `
            <div class="section">
                <div class="section-header">
                    <div class="section-title">Recent Activity</div>
                    <div class="section-subtitle">Latest Jobs & Lifecycle Status</div>
                </div>
                <div class="empty-state">No recent job activity recorded for this contact.</div>
            </div>`;
        }

        const rows = this.jobs.map(j => {
            const color = j.statusColor || '#94a3b8';
            const date = j.assignDate ? new Date(j.assignDate).toLocaleDateString() : '-';
            return `<tr>
                <td class="font-bold">${j.caption || '-'}</td>
                <td>${date}</td>
                <td><span class="status-dot" style="background:${color}"></span><span class="uppercase font-bold" style="font-size:9px;letter-spacing:0.08em;color:${color}">${j.statusName || 'Pending'}</span></td>
            </tr>`;
        }).join('');

        return `
        <div class="section">
            <div class="section-header">
                <div class="section-title">Recent Activity</div>
                <div class="section-subtitle">Latest Jobs & Lifecycle Status</div>
            </div>
            <table>
                <thead><tr>
                    <th>Job Caption</th><th>Assign Date</th><th>Current Workflow Stage</th>
                </tr></thead>
                <tbody>${rows}</tbody>
            </table>
        </div>`;
    }

    private _formatCurrency(value: number): string {
        return new Intl.NumberFormat('en-AU', { style: 'currency', currency: 'AUD' }).format(value || 0);
    }

    private _buildFSNotesSection(): string {
        if (this.fsNotes.length === 0) return '';
        
        const notesHtml = this.fsNotes.map(n => `
            <div style="margin-bottom: 12px; padding-bottom: 12px; border-bottom: 1px solid #f1f5f9;">
                <div style="display:flex; justify-content:space-between; margin-bottom: 4px;">
                    <span class="badge" style="background:#4f46e5; color:white;">${n.noteType}</span>
                    <span style="font-size: 9px; color: #94a3b8;">${new Date(n.createdDateTime).toLocaleDateString()}</span>
                </div>
                <div style="font-size: 12px; line-height: 1.5;">${n.noteContent}</div>
                <div style="font-size: 8px; color: #94a3b8; margin-top: 4px; text-transform: uppercase;">
                    Made by ${n.createdByUserName || 'System'}
                </div>
            </div>
        `).join('');

        return `
        <div class="section">
            <div class="section-header">
                <div class="section-title">Financial Services Notes</div>
                <div class="section-subtitle">Compliance & Audit History</div>
            </div>
            <div class="section-body">
                ${notesHtml}
            </div>
        </div>`;
    }

    private _buildChecklistSection(): string {
        if (this.checklistItems.length === 0) return '';

        const itemsHtml = this.checklistItems.map(i => `
            <div class="info-row">
                <div style="display:flex; align-items:center;">
                    <div style="width:12px; height:12px; border:1px solid #cbd5e1; border-radius:2px; margin-right:8px; display:flex; align-items:center; justify-content:center;">
                        ${i.isCompleted ? '<div style="width:6px; height:6px; background:#4f46e5; border-radius:1px;"></div>' : ''}
                    </div>
                    <span style="font-size: 11px; ${i.isCompleted ? 'text-decoration: line-through; color: #94a3b8;' : 'font-weight:600;'}">${i.taskName}</span>
                </div>
                <div style="text-align:right;">
                    <span style="font-size: 8px; color: #94a3b8; text-transform: uppercase;">${i.isCompleted ? 'Done' : 'Pending'}</span>
                </div>
            </div>
        `).join('');

        return `
        <div class="section">
            <div class="section-header">
                <div class="section-title">Admin Checklist</div>
                <div class="section-subtitle">Internal Process Verification</div>
            </div>
            <div class="section-body">
                ${itemsHtml}
            </div>
        </div>`;
    }

    loadSummaryData(): void {
        // Load services to calculate fees
        this._customerService.getCustomerServices(this.customerId).subscribe(services => {
            this.services = services;
            this.calculateTotalFees();
        });

        // Load jobs
        this._jobService.getJobsByCustomerId(this.customerId).subscribe(jobs => {
            this.jobs = jobs;
            this.activeJobsCount = jobs.filter(j => j.currentStage !== 5).length; // Assuming 5 is 'Completed'
        });

        // Load FS Notes
        this._fsNoteService.getNotesForCustomer(this.customerId).subscribe(res => {
            this.fsNotes = res.notes;
        });

        // Load Admin Checklist
        this._customerService.getChecklist(this.customerId).subscribe(res => {
            this.checklistItems = res;
        });
    }

    calculateTotalFees(): void {
        this.totalFees = this.services.reduce((acc, curr) => {
            let amount = curr.amount || 0;
            // Normalize to yearly for the summary
            switch (curr.unit) {
                case 'm': amount *= 12; break;
                case 'q': amount *= 4; break;
                case 'w': amount *= 52; break;
                case 'd': amount *= 365; break;
            }
            return acc + amount;
        }, 0);
    }
}
