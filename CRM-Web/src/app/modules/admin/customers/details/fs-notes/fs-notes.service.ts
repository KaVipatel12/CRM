import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { Observable } from 'rxjs';

export interface FSNoteMaster {
    id: number;
    noteType: string;
}

export interface FSNote {
    id?: number;
    customerId: number;
    fsNoteMasterId: number;
    noteType: string;
    noteContent: string;
    createdDateTime: string;
    createdByUserName: string;
    updatedByUserName: string;
    updateDateTime: string;
}

@Injectable({
    providedIn: 'root'
})
export class FSNoteService {
    private _httpClient = inject(HttpClient);
    private _baseUrl = inject(API_BASE_URL);

    getNotesForCustomer(customerId: number): Observable<{ masterTypes: FSNoteMaster[], notes: FSNote[] }> {
        return this._httpClient.get<{ masterTypes: FSNoteMaster[], notes: FSNote[] }>(`${this._baseUrl}/api/FSNote/${customerId}`);
    }

    createNote(note: { customerId: number, fsNoteMasterId: number, noteContent: string }): Observable<any> {
        return this._httpClient.post(`${this._baseUrl}/api/FSNote`, note);
    }

    updateNote(id: number, note: { customerId: number, fsNoteMasterId: number, noteContent: string }): Observable<any> {
        return this._httpClient.put(`${this._baseUrl}/api/FSNote/${id}`, note);
    }

    deleteNote(id: number): Observable<any> {
        return this._httpClient.delete(`${this._baseUrl}/api/FSNote/${id}`);
    }
}
