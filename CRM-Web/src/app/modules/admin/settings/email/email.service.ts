import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class EmailSettingsService {
    private _httpClient = inject(HttpClient);
    private _baseUrl = inject(API_BASE_URL) + '/api/SmtpSettings';

    /**
     * Get the active SMTP settings
     */
    getSettings(): Observable<any> {
        return this._httpClient.get<any>(this._baseUrl);
    }

    /**
     * Save SMTP settings
     */
    saveSettings(settings: any): Observable<any> {
        return this._httpClient.post<any>(this._baseUrl, settings);
    }
}
