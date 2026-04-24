import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { AuthUtils } from 'app/core/auth/auth.utils';
import { UserService } from 'app/core/user/user.service';
import { catchError, Observable, of, switchMap, throwError } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
    private _authenticated: boolean = false;
    private _baseUrl = inject(API_BASE_URL);
    private _httpClient = inject(HttpClient);
    private _userService = inject(UserService);

    // -----------------------------------------------------------------------------------------------------
    // @ Accessors
    // -----------------------------------------------------------------------------------------------------

    /**
     * Setter & getter for access token
     */
    set accessToken(token: string) {
        localStorage.setItem('accessToken', token);
    }

    get accessToken(): string {
        return localStorage.getItem('accessToken') ?? '';
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Forgot password
     *
     * @param email
     */
    forgotPassword(email: string): Observable<any> {
        return this._httpClient.post(`${this._baseUrl}/api/Auth/forgot-password`, { email });
    }

    /**
     * Reset password
     *
     * @param data
     */
    resetPassword(data: { email: string; token: string; newPassword: string }): Observable<any> {
        return this._httpClient.post(`${this._baseUrl}/api/Auth/reset-password`, data);
    }

    /**
     * Sign in
     *
     * @param credentials
     */
    signIn(credentials: { email: string; password: string }): Observable<any> {
        if (this._authenticated) {
            return throwError('User is already logged in.');
        }

        return this._httpClient.post(`${this._baseUrl}/api/Auth/login`, credentials).pipe(
            switchMap((response: any) => {
                this.accessToken = response.token || response.accessToken;
                this._authenticated = true;
                
                // Map backend properties to frontend User interface
                const user: any = {
                    id: response.userId?.toString(),
                    name: `${response.firstName} ${response.lastName}`.trim(),
                    email: response.email,
                    isAdmin: response.isAdmin,
                    isChecker: response.isChecker,
                    isSuperAdmin: response.isSuperAdmin,
                    status: 'online'
                };
                
                this._userService.user = user;
                return of(response);
            })
        );
    }

    /**
     * Sign in using the access token
     */
    signInUsingToken(): Observable<any> {
        return this._httpClient
            .get(`${this._baseUrl}/api/Auth/user`)
            .pipe(
                catchError(() => of(false)),
                switchMap((response: any) => {
                    this._authenticated = true;
                    this._userService.user = response;
                    return of(true);
                })
            );
    }

    /**
     * Sign out
     */
    signOut(): Observable<any> {
        // Remove the access token from the local storage
        localStorage.removeItem('accessToken');

        // Set the authenticated flag to false
        this._authenticated = false;

        // Return the observable
        return of(true);
    }

    /**
     * Sign up
     *
     * @param user
     */
    signUp(user: {
        name: string;
        email: string;
        password: string;
        company: string;
    }): Observable<any> {
        return this._httpClient.post(`${this._baseUrl}/api/Auth/register`, user).pipe(
            switchMap((response: any) => {
                // If the response has data (token + user)
                if (response.succeeded && response.data) {
                    this.accessToken = response.data.token;
                    this._authenticated = true;
                    
                    // Map backend properties to frontend User interface
                    const user: any = {
                        id: response.data.userId?.toString(),
                        name: `${response.data.firstName} ${response.data.lastName}`.trim(),
                        email: response.data.email,
                        isAdmin: response.data.isAdmin,
                        isChecker: response.data.isChecker,
                        isSuperAdmin: response.data.isSuperAdmin,
                        status: 'online'
                    };
                    
                    this._userService.user = user;
                }
                return of(response);
            })
        );
    }

    /**
     * Unlock session
     *
     * @param credentials
     */
    unlockSession(credentials: {
        email: string;
        password: string;
    }): Observable<any> {
        return this._httpClient.post('api/auth/unlock-session', credentials);
    }

    /**
     * Check the authentication status
     */
    check(): Observable<boolean> {
        // Check if the user is logged in
        if (this._authenticated) {
            return of(true);
        }

        // Check the access token availability
        if (!this.accessToken) {
            return of(false);
        }

        // Check the access token expire date
        if (AuthUtils.isTokenExpired(this.accessToken)) {
            return of(false);
        }

        // If the access token exists, and it didn't expire, sign in using it
        return this.signInUsingToken();
    }
}
