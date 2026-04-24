import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { BehaviorSubject, Observable, tap } from 'rxjs';

export interface UpcomingBirthday {
    customerId: number;
    name: string;
    email: string;
    dateOfBirth: string;
    daysUntil: number;
    day: string;
    month: string;
}

@Injectable({ providedIn: 'root' })
export class BirthdayService {
    private _httpClient = inject(HttpClient);
    private _baseUrl = inject(API_BASE_URL) + '/api/Customers/upcoming-birthdays';
    
    private _birthdays: BehaviorSubject<UpcomingBirthday[] | null> = new BehaviorSubject(null);

    /**
     * Getter for birthdays
     */
    get birthdays$(): Observable<UpcomingBirthday[] | null> {
        return this._birthdays.asObservable();
    }

    /**
     * Fetch birthdays from API
     * Only fetches if not already loaded to optimize performance
     */
    getUpcomingBirthdays(forceRefresh: boolean = false): Observable<UpcomingBirthday[]> {
        console.log('BirthdayService: getUpcomingBirthdays called', { forceRefresh, currentCache: this._birthdays.value });

        if (!forceRefresh && this._birthdays.value !== null) {
            console.log('BirthdayService: Returning cached data');
            return new Observable<UpcomingBirthday[]>(subscriber => {
                subscriber.next(this._birthdays.value as UpcomingBirthday[]);
                subscriber.complete();
            });
        }

        console.log('BirthdayService: Hitting API...', this._baseUrl, { forceRefresh });
        return this._httpClient.get<UpcomingBirthday[]>(this._baseUrl, {
            params: { forceRefresh: forceRefresh.toString() }
        }).pipe(
            tap((birthdays) => {
                console.log('BirthdayService: API response received', birthdays);
                this._birthdays.next(birthdays);
            })
        );
    }

    /**
     * Clear cache
     */
    clearCache(): void {
        this._birthdays.next(null);
    }
}
