import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { toCamelCase } from 'app/core/utils/case-utils';
import { Observable, map } from 'rxjs';
import { CallLog, CallLogPagedResponse, Purpose, CallLogComment } from './calls.types';

@Injectable({ providedIn: 'root' })
export class CallsService {
    private _httpClient = inject(HttpClient);
    private _baseApiUrl = inject(API_BASE_URL);
    private _baseUrl = `${this._baseApiUrl}/api/Calls`;

    /**
     * Get calls with filters and pagination
     */
    getCalls(filter: any): Observable<CallLogPagedResponse> {
        let params = new HttpParams();
        
        if (filter.searchString) params = params.set('SearchString', filter.searchString);
        if (filter.receiverId !== undefined && filter.receiverId !== null) params = params.set('ReceiverId', filter.receiverId.toString());
        if (filter.forWhomId !== undefined && filter.forWhomId !== null) params = params.set('ForWhomId', filter.forWhomId.toString());
        if (filter.purposeId !== undefined && filter.purposeId !== null) params = params.set('PurposeId', filter.purposeId.toString());
        if (filter.statusId !== undefined && filter.statusId !== null) params = params.set('StatusId', filter.statusId.toString());
        if (filter.isClosed !== undefined && filter.isClosed !== null) params = params.set('IsClosed', filter.isClosed.toString());
        if (filter.fromDate) params = params.set('FromDate', filter.fromDate);
        if (filter.toDate) params = params.set('ToDate', filter.toDate);
        
        params = params.set('PageNumber', (filter.pageNumber || 1).toString());
        params = params.set('PageSize', (filter.pageSize || 10).toString());
        
        return this._httpClient.get<CallLogPagedResponse>(this._baseUrl, { params }).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Get single call by ID
     */
    getCall(id: number): Observable<CallLog> {
        return this._httpClient.get<CallLog>(`${this._baseUrl}/${id}`).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Create call
     */
    createCall(call: any): Observable<CallLog> {
        return this._httpClient.post<CallLog>(this._baseUrl, call).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Update call
     */
    updateCall(id: number, call: any): Observable<CallLog> {
        return this._httpClient.put<CallLog>(`${this._baseUrl}/${id}`, call).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Update call status
     */
    updateStatus(id: number, statusId: number): Observable<void> {
        return this._httpClient.put<void>(`${this._baseUrl}/${id}/status`, statusId, {
            headers: { 'Content-Type': 'application/json' }
        });
    }

    /**
     * Close a call
     */
    closeCall(id: number): Observable<void> {
        return this._httpClient.put<void>(`${this._baseUrl}/${id}/close`, {});
    }

    /**
     * Get comments for a call
     */
    getComments(id: number): Observable<CallLogComment[]> {
        return this._httpClient.get<CallLogComment[]>(`${this._baseUrl}/${id}/comments`).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Add comment to call
     */
    addComment(id: number, comment: string): Observable<CallLogComment> {
        return this._httpClient.post<CallLogComment>(`${this._baseUrl}/${id}/comments`, JSON.stringify(comment), {
            headers: { 'Content-Type': 'application/json' }
        }).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Update comment
     */
    updateComment(commentId: number, comment: string): Observable<void> {
        return this._httpClient.put<void>(`${this._baseUrl}/comments/${commentId}`, JSON.stringify(comment), {
            headers: { 'Content-Type': 'application/json' }
        });
    }

    /**
     * Delete comment
     */
    deleteComment(commentId: number): Observable<void> {
        return this._httpClient.delete<void>(`${this._baseUrl}/comments/${commentId}`);
    }

    /**
     * Get purposes list
     */
    getPurposes(): Observable<Purpose[]> {
        return this._httpClient.get<Purpose[]>(`${this._baseUrl}/purposes`).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Get users list (Staff)
     */
    getUsers(): Observable<any[]> {
        return this._httpClient.get<any>(`${this._baseApiUrl}/api/Lookups`).pipe(
            map(data => toCamelCase(data).staff)
        );
    }
}
