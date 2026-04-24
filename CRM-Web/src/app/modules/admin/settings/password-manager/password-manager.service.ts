import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { Observable } from 'rxjs';
import { MasterPasswordRequest, PasswordManager, SavePasswordRequest } from './password-manager.types';

@Injectable({ providedIn: 'root' })
export class PasswordManagerService {
    private _httpClient = inject(HttpClient);
    private _baseUrl = inject(API_BASE_URL) + '/api/PasswordManager';

    /**
     * Get all passwords (encrypted)
     */
    getPasswords(): Observable<PasswordManager[]> {
        return this._httpClient.get<PasswordManager[]>(this._baseUrl);
    }

    /**
     * Get a specific password (decrypted)
     * Requires master password in header
     */
    getPasswordDetails(id: number, masterPassword: string): Observable<PasswordManager> {
        const headers = new HttpHeaders().set('X-Vault-Master-Password', masterPassword);
        return this._httpClient.get<PasswordManager>(`${this._baseUrl}/${id}`, { headers });
    }

    /**
     * Save/Update a password
     */
    savePassword(request: SavePasswordRequest): Observable<PasswordManager> {
        return this._httpClient.post<PasswordManager>(this._baseUrl, request);
    }

    /**
     * Delete a password
     * Requires master password in header
     */
    deletePassword(id: number, masterPassword: string): Observable<any> {
        const headers = new HttpHeaders().set('X-Vault-Master-Password', masterPassword);
        return this._httpClient.delete(`${this._baseUrl}/${id}`, { headers });
    }

    /**
     * Check if master password is set
     */
    getMasterPasswordStatus(): Observable<{ isSet: boolean }> {
        return this._httpClient.get<{ isSet: boolean }>(`${this._baseUrl}/master-password-status`);
    }

    /**
     * Verify master password
     */
    verifyMasterPassword(request: MasterPasswordRequest): Observable<{ isValid: boolean }> {
        return this._httpClient.post<{ isValid: boolean }>(`${this._baseUrl}/verify-master-password`, request);
    }

    /**
     * Set master password
     */
    setMasterPassword(request: MasterPasswordRequest): Observable<{ success: boolean }> {
        return this._httpClient.post<{ success: boolean }>(`${this._baseUrl}/set-master-password`, request);
    }
}
