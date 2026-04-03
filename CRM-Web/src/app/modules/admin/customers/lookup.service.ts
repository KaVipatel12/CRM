import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, shareReplay } from 'rxjs';

export interface LookupData {
    contactTypes: any[];
    relationshipTypes: any[];
    customerTypes: any[];
    businessTypes: any[];
    taxAgents: any[];
    tradingStatuses: any[];
    staff: any[];
}

@Injectable({
    providedIn: 'root'
})
export class LookupService {
    private _lookups$: Observable<LookupData> | null = null;

    constructor(private _httpClient: HttpClient) { }

    /**
     * Get all lookups
     */
    getLookups(): Observable<LookupData> {
        if (!this._lookups$) {
            this._lookups$ = this._httpClient.get<LookupData>('/api/lookups').pipe(
                shareReplay(1)
            );
        }
        return this._lookups$;
    }
}
