import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer, CustomerListFilter } from './customer.types';

@Injectable({ providedIn: 'root' })
export class CustomerService {
    private _httpClient = inject(HttpClient);
    private _baseUrl = 'api/Customers';

    /**
     * Get customers with filters and pagination
     */
    getCustomers(filter: CustomerListFilter): Observable<Customer[]> {
        let params = new HttpParams();
        
        if (filter.searchString) params = params.set('SearchString', filter.searchString);
        if (filter.contactType) params = params.set('ContactType', filter.contactType.toString());
        if (filter.includeInactive !== undefined) params = params.set('IncludeInactive', filter.includeInactive.toString());
        
        params = params.set('CurrentPage', filter.currentPage.toString());
        params = params.set('PageSize', filter.pageSize.toString());
        
        if (filter.orderBy) params = params.set('OrderBy', filter.orderBy);

        return this._httpClient.get<Customer[]>(this._baseUrl, { params });
    }

    /**
     * Get single customer details
     */
    getCustomerById(id: number): Observable<any> {
        return this._httpClient.get<any>(`${this._baseUrl}/${id}`);
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
}
