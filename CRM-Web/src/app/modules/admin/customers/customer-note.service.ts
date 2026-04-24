import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { Observable } from 'rxjs';
import { CreateCustomerNote, CustomerNote } from './customer.types';

@Injectable({ providedIn: 'root' })
export class CustomerNoteService {
    private _httpClient = inject(HttpClient);
    private _baseApiUrl = inject(API_BASE_URL);
    private _baseUrl = `${this._baseApiUrl}/api/CustomerNotes`;

    /**
     * Get notes for a specific customer
     */
    getNotesByCustomer(customerId: number): Observable<CustomerNote[]> {
        return this._httpClient.get<CustomerNote[]>(`${this._baseUrl}/${customerId}`);
    }

    /**
     * Create a new note
     */
    addNote(note: CreateCustomerNote): Observable<CustomerNote> {
        return this._httpClient.post<CustomerNote>(this._baseUrl, note);
    }

    /**
     * Update an existing note
     */
    updateNote(note: any): Observable<void> {
        return this._httpClient.put<void>(this._baseUrl, note);
    }

    /**
     * Delete a note
     */
    deleteNote(id: number): Observable<void> {
        return this._httpClient.delete<void>(`${this._baseUrl}/${id}`);
    }
}
