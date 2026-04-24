import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { API_BASE_URL } from 'app/app.config';

export interface FormMaster {
    id: number;
    name: string;
    slug: string;
    category?: string;
    icon?: string;
    allowPdf: boolean;
    allowEmail: boolean;
    allowView: boolean;
    allowDownload: boolean;
    displayOrder: number;
    data?: string;
}

@Injectable({ providedIn: 'root' })
export class FormsService {
    private _httpClient = inject(HttpClient);
    private _baseUrl = inject(API_BASE_URL) + '/api/Form';

    private _forms: BehaviorSubject<FormMaster[] | null> = new BehaviorSubject<FormMaster[] | null>(null);

    /**
     * Getter for forms
     */
    get forms$(): Observable<FormMaster[] | null> {
        return this._forms.asObservable();
    }

    /**
     * Get all forms
     */
    getForms(customerId?: number): Observable<FormMaster[]> {
        const params = customerId ? { customerId: customerId.toString() } : {};
        return this._httpClient.get<FormMaster[]>(this._baseUrl, { params }).pipe(
            tap((forms) => {
                this._forms.next(forms);
            })
        );
    }

    /**
     * Get form by slug
     */
    getFormBySlug(slug: string): Observable<FormMaster> {
        return this._httpClient.get<FormMaster>(`${this._baseUrl}/slug/${slug}`);
    }

    /**
     * Get form PDF from backend
     */
    getFormPDF(slug: string, customerId: number, month: number = 0, year: number = 0): Observable<any> {
        return this._httpClient.get(`${this._baseUrl}/pdf/${slug}`, {
            params: {
                customerId,
                month,
                year
            }
        });
    }
    /**
     * Send form via email
     */
    sendFormEmail(slug: string, customerId: number, emailDetails: any): Observable<any> {
        return this._httpClient.post(`${this._baseUrl}/email/${slug}`, emailDetails, {
            params: {
                customerId
            }
        });
    }

    /**
     * Update form data
     */
    updateForm(id: number, data: string): Observable<any> {
        return this._httpClient.put(`${this._baseUrl}/${id}`, { id, data });
    }
}
