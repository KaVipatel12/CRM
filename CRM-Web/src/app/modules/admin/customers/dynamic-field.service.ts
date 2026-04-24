import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { Observable } from 'rxjs';
import { DynamicFieldMaster, DynamicFieldValue, UpsertDynamicFieldValue } from './customer.types';

@Injectable({ providedIn: 'root' })
export class DynamicFieldService {
    private _httpClient = inject(HttpClient);
    private _baseApiUrl = inject(API_BASE_URL);

    /**
     * Get all active dynamic field definitions
     */
    getMasters(): Observable<DynamicFieldMaster[]> {
        return this._httpClient.get<DynamicFieldMaster[]>(`${this._baseApiUrl}/api/DynamicFieldMasters`);
    }

    /**
     * Get dynamic field values for a specific customer
     */
    getValuesByCustomer(customerId: number): Observable<DynamicFieldValue[]> {
        return this._httpClient.get<DynamicFieldValue[]>(`${this._baseApiUrl}/api/DynamicFieldValues/${customerId}`);
    }

    /**
     * Save/Update dynamic field values for a customer
     */
    upsertValues(customerId: number, values: UpsertDynamicFieldValue[]): Observable<any> {
        return this._httpClient.post(`${this._baseApiUrl}/api/DynamicFieldValues/${customerId}`, values);
    }

    /**
     * Add a new dynamic field master
     */
    addMaster(master: Partial<DynamicFieldMaster>): Observable<DynamicFieldMaster> {
        return this._httpClient.post<DynamicFieldMaster>(`${this._baseApiUrl}/api/DynamicFieldMasters`, master);
    }

    /**
     * Update an existing dynamic field master
     */
    updateMaster(id: number, master: Partial<DynamicFieldMaster>): Observable<any> {
        return this._httpClient.put(`${this._baseApiUrl}/api/DynamicFieldMasters/${id}`, master);
    }

    /**
     * Delete a dynamic field master
     */
    deleteMaster(id: number): Observable<any> {
        return this._httpClient.delete(`${this._baseApiUrl}/api/DynamicFieldMasters/${id}`);
    }
}
