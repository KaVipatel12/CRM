import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { toCamelCase } from 'app/core/utils/case-utils';
import { Observable, map, shareReplay } from 'rxjs';

export interface LookupData {
    contactTypes: any[];
    relationshipTypes: any[];
    customerTypes: any[];
    businessTypes: any[];
    taxAgents: any[];
    tradingStatuses: any[];
    staff: any[];
    jobTypes: any[];
    jobStatusMasters: any[];
    jobTypeStatusMappings: any[];
}

@Injectable({
    providedIn: 'root'
})
export class LookupService {
    private _httpClient = inject(HttpClient);
    private _baseUrl = inject(API_BASE_URL);
    private _lookups$: Observable<LookupData> | null = null;

    /**
     * Get all lookups
     */
    getLookups(): Observable<LookupData> {
        if (!this._lookups$) {
            this._lookups$ = this._httpClient.get<any>(`${this._baseUrl}/api/lookups`).pipe(
                map(data => toCamelCase(data) as LookupData),
                shareReplay(1)
            );
        }
        return this._lookups$;
    }
}
