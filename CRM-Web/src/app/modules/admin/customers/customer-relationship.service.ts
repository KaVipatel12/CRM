import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { Observable } from 'rxjs';
import { CreateCustomerRelationship, CustomerRelationship, Lookup } from './customer.types';

@Injectable({ providedIn: 'root' })
export class CustomerRelationshipService {
    private _httpClient = inject(HttpClient);
    private _baseApiUrl = inject(API_BASE_URL);
    private _baseUrl = `${this._baseApiUrl}/api/CustomerRelationships`;

    /**
     * Get relationships for a specific customer
     */
    getRelationshipsByCustomer(customerId: number): Observable<CustomerRelationship[]> {
        return this._httpClient.get<CustomerRelationship[]>(`${this._baseUrl}/${customerId}`);
    }

    /**
     * Get relationship types (lookups)
     */
    getRelationshipTypes(): Observable<Lookup[]> {
        return this._httpClient.get<Lookup[]>(`${this._baseUrl}/types`);
    }

    /**
     * Create a new relationship
     */
    addRelationship(relationship: CreateCustomerRelationship): Observable<CustomerRelationship> {
        return this._httpClient.post<CustomerRelationship>(this._baseUrl, relationship);
    }

    /**
     * Delete a relationship
     */
    deleteRelationship(id: number): Observable<void> {
        return this._httpClient.delete<void>(`${this._baseUrl}/${id}`);
    }
}
