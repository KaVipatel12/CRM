import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { toCamelCase } from 'app/core/utils/case-utils';
import { Observable, map } from 'rxjs';
import { Customer, CustomerListFilter, CustomerPagedResponse, CustomerStatistics } from './customer.types';

@Injectable({ providedIn: 'root' })
export class CustomerService {
    private _httpClient = inject(HttpClient);
    private _baseApiUrl = inject(API_BASE_URL);
    private _baseUrl = `${this._baseApiUrl}/api/Customers`;

    /**
     * Get customers with filters and pagination
     */
    getCustomers(filter: CustomerListFilter): Observable<CustomerPagedResponse> {
        let params = new HttpParams();
        
        if (filter.searchString) params = params.set('SearchString', filter.searchString);
        if (filter.contactType) params = params.set('ContactType', filter.contactType.toString());
        if (filter.varifiedType) params = params.set('VarifiedType', filter.varifiedType);
        if (filter.includeInactive !== undefined) params = params.set('IncludeInactive', filter.includeInactive.toString());
        if (filter.includeArchived !== undefined) params = params.set('IncludeArchived', filter.includeArchived.toString());
        if (filter.includeExcluded !== undefined) params = params.set('IncludeExcluded', filter.includeExcluded.toString());
        
        params = params.set('CurrentPage', filter.currentPage.toString());
        params = params.set('PageSize', filter.pageSize.toString());
        
        if (filter.orderBy) params = params.set('OrderBy', filter.orderBy);

        return this._httpClient.get<CustomerPagedResponse>(this._baseUrl, { params });
    }

    /**
     * Get customer statistics for dashboard metrics
     */
    getStatistics(): Observable<CustomerStatistics> {
        return this._httpClient.get<CustomerStatistics>(`${this._baseUrl}/statistics`);
    }

    /**
     * Get single customer details
     */
    getCustomerById(id: number): Observable<any> {
        return this._httpClient.get<any>(`${this._baseUrl}/${id}`).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Create customer
     */
    createCustomer(customer: any): Observable<number> {
        return this._httpClient.post<number>(this._baseUrl, customer);
    }

    /**
     * Update customer
     */
    updateCustomer(id: number, customer: any): Observable<void> {
        return this._httpClient.put<void>(`${this._baseUrl}/${id}`, customer);
    }

    /**
     * Get increment code by customer type
     */
    getIncrementCode(clientType: number): Observable<number> {
        return this._httpClient.get<number>(`${this._baseUrl}/GetIncrementCodeByType?contactType=${clientType}`);
    }

    /**
     * Check if code is duplicated
     */
    checkDuplicateCode(code: string): Observable<boolean> {
        return this._httpClient.get<boolean>(`${this._baseUrl}/CheckDuplicateCode/${code}`);
    }

    /**
     * Delete customer
     */
    deleteCustomer(id: number): Observable<void> {
        return this._httpClient.delete<void>(`${this._baseUrl}/${id}`);
    }

    /**
     * File Upload History
     */
    getUploadHistory(): Observable<any[]> {
        return this._httpClient.get<any[]>(`${this._baseApiUrl}/api/FileUpload/history`).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Upload Bulk File
     */
    uploadFile(file: File): Observable<any> {
        const formData = new FormData();
        formData.append('file', file);
        return this._httpClient.post<any>(`${this._baseApiUrl}/api/FileUpload/upload`, formData);
    }

    /**
     * Trigger bulk processing
     */
    processFile(id: number): Observable<any> {
        return this._httpClient.post<any>(`${this._baseApiUrl}/api/FileUpload/process/${id}`, {});
    }

    /**
     * Verify Customer
     */
    verifyCustomer(id: number): Observable<boolean> {
        return this._httpClient.post<boolean>(`${this._baseUrl}/${id}/verify`, {});
    }

    /**
     * Change Customer Type Migration
     */
    changeCustomerType(id: number, newClientType: number): Observable<boolean> {
        return this._httpClient.post<boolean>(`${this._baseUrl}/${id}/change-type`, { newClientType });
    }

    /**
     * Service Portfolio Methods
     */
    getServiceMasters(): Observable<any[]> {
        return this._httpClient.get<any[]>(`${this._baseUrl}/services/masters`);
    }

    getCustomerServices(customerId: number): Observable<any[]> {
        return this._httpClient.get<any[]>(`${this._baseUrl}/${customerId}/services`);
    }

    upsertCustomerService(service: any): Observable<any> {
        return this._httpClient.post<any>(`${this._baseUrl}/services`, service);
    }

    deleteCustomerService(id: number): Observable<any> {
        return this._httpClient.delete<any>(`${this._baseUrl}/services/${id}`);
    }

    /**
     * Checklist Methods
     */
    getChecklist(customerId: number): Observable<any[]> {
        return this._httpClient.get<any[]>(`${this._baseApiUrl}/api/Checklist/${customerId}`).pipe(
            map(data => toCamelCase(data))
        );
    }

    toggleChecklistStatus(customerId: number, checklistMasterId: number, isCompleted: boolean, notes: string = null): Observable<any> {
        return this._httpClient.post<any>(`${this._baseApiUrl}/api/Checklist/toggle`, {
            customerId,
            checklistMasterId,
            isCompleted,
            notes
        });
    }
    /**
     * Branch Methods
     */
    getBranches(customerId: number): Observable<any[]> {
        return this._httpClient.get<any[]>(`${this._baseApiUrl}/api/Branch/customer/${customerId}`);
    }

    createBranch(branch: any): Observable<any> {
        return this._httpClient.post<any>(`${this._baseApiUrl}/api/Branch`, branch);
    }

    updateBranch(id: number, branch: any): Observable<void> {
        return this._httpClient.put<void>(`${this._baseApiUrl}/api/Branch/${id}`, branch);
    }

    deleteBranch(id: number): Observable<void> {
        return this._httpClient.delete<void>(`${this._baseApiUrl}/api/Branch/${id}`);
    }
}
