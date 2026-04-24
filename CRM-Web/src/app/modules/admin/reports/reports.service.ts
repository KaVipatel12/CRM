import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { Observable } from 'rxjs';

export interface ReportField {
    key: string;
    displayName: string;
    category: string;
    isDynamic: boolean;
    dynamicFieldId?: number;
}

export interface ClientDetailsReportFilter {
    contactType?: number;
    partner?: string;
    partnerId?: number;
    manager?: string;
    clientType?: number;
    group?: string;
    isActive?: boolean;
    isArchived?: boolean;
    isExcluded?: boolean;
    staffInCharge?: number;
    selectedCustomerIds?: number[];
    tradingStatus?: number;
    orderBy?: string;
    orderDirection?: string;
    selectedFieldKeys: string[];
    exportFormat: string;
}

export interface FSNotesReportFilter {
    contactType?: number;
    partner?: string;
    partnerId?: number;
    staffInCharge?: number;
    clientType?: number;
    isActive?: boolean;
    isArchived?: boolean;
    isExcluded?: boolean;
    selectedNoteTypeIds: number[];
    selectedCustomerIds?: number[];
    orderBy?: string;
    orderDirection?: string;
    exportFormat: string;
}

@Injectable({
    providedIn: 'root'
})
export class ReportsService {
    private _httpClient = inject(HttpClient);
    private _baseApiUrl = inject(API_BASE_URL);
    private _baseUrl = `${this._baseApiUrl}/api/reports`;

    /**
     * Get available fields for client details report
     */
    getAvailableFields(clientType?: number): Observable<ReportField[]> {
        let params = new HttpParams();
        if (clientType) {
            params = params.set('clientType', clientType.toString());
        }
        return this._httpClient.get<ReportField[]>(`${this._baseUrl}/client-details/fields`, { params });
    }

    /**
     * Export client details report
     */
    exportClientDetails(filter: ClientDetailsReportFilter): Observable<Blob> {
        return this._httpClient.post(`${this._baseUrl}/client-details/export`, filter, {
            responseType: 'blob'
        });
    }

    /**
     * Export FS Notes report
     */
    exportFSNotes(filter: FSNotesReportFilter): Observable<Blob> {
        return this._httpClient.post(`${this._baseUrl}/fs-notes/export`, filter, {
            responseType: 'blob'
        });
    }
}
