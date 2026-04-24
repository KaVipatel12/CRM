import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { toCamelCase } from 'app/core/utils/case-utils';
import { Observable, map } from 'rxjs';
import { Job, JobFilter, JobPagedResponse, JobStatistics } from './job.types';

@Injectable({ providedIn: 'root' })
export class JobService {
    private _httpClient = inject(HttpClient);
    private _baseApiUrl = inject(API_BASE_URL);
    private _baseUrl = `${this._baseApiUrl}/api/Jobs`;

    /**
     * Get jobs with filters and pagination
     */
    getJobs(filter: JobFilter): Observable<JobPagedResponse> {
        let params = new HttpParams();
        
        if (filter.searchString) params = params.set('SearchString', filter.searchString);
        if (filter.statusId !== undefined) params = params.set('StatusID', filter.statusId.toString());
        if (filter.priority !== undefined) params = params.set('Priority', filter.priority.toString());
        if (filter.jobTypeId !== undefined) params = params.set('JobTypeID', filter.jobTypeId.toString());
        if (filter.ownerId !== undefined) params = params.set('OwnerID', filter.ownerId.toString());
        if (filter.responsibleId !== undefined) params = params.set('ResponsibleID', filter.responsibleId.toString());
        if (filter.createdUserId !== undefined) params = params.set('CreatedUserId', filter.createdUserId.toString());
        if (filter.customerId !== undefined) params = params.set('CustomerID', filter.customerId.toString());
        if (filter.isActive !== undefined) params = params.set('IsActive', filter.isActive.toString());
        if (filter.isRecurring !== undefined) params = params.set('IsRecurring', filter.isRecurring.toString());
        if (filter.isInternal !== undefined) params = params.set('IsInternal', filter.isInternal.toString());
        
        params = params.set('PageNumber', filter.pageNumber.toString());
        params = params.set('PageSize', filter.pageSize.toString());
        
        if (filter.orderBy) params = params.set('OrderBy', filter.orderBy);
        if (filter.orderDirection) params = params.set('OrderDirection', filter.orderDirection);
 
        console.log('Fetching Jobs with Filter:', filter);
        return this._httpClient.get<JobPagedResponse>(this._baseUrl, { params }).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Get jobs for a specific customer
     */
    getJobsByCustomerId(customerId: number): Observable<Job[]> {
        return this._httpClient.get<Job[]>(`${this._baseUrl}/customer/${customerId}`).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Get recurring history for a job
     */
    getRecurringHistory(id: number): Observable<Job[]> {
        return this._httpClient.get<Job[]>(`${this._baseUrl}/recurring-history/${id}`).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Get single job by ID
     */
    getJob(id: number): Observable<Job> {
        return this._httpClient.get<Job>(`${this._baseUrl}/${id}`).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Create job
     */
    createJob(job: Job): Observable<number> {
        return this._httpClient.post<number>(this._baseUrl, job);
    }

    /**
     * Update job
     */
    updateJob(id: number, job: Job): Observable<void> {
        return this._httpClient.put<void>(`${this._baseUrl}/${id}`, job);
    }

    /**
     * Delete job
     */
    deleteJob(id: number): Observable<void> {
        return this._httpClient.delete<void>(`${this._baseUrl}/${id}`);
    }

    /**
     * Add task to job
     */
    addTask(jobId: number, description: string): Observable<any> {
        return this._httpClient.post<any>(`${this._baseUrl}/${jobId}/tasks`, JSON.stringify(description), {
            headers: { 'Content-Type': 'application/json' }
        });
    }

    /**
     * Toggle task status (complete/incomplete)
     */
    toggleTask(taskId: number): Observable<void> {
        return this._httpClient.put<void>(`${this._baseUrl}/tasks/${taskId}/toggle`, {});
    }

    /**
     * Delete task
     */
    deleteTask(taskId: number): Observable<void> {
        return this._httpClient.delete<void>(`${this._baseUrl}/tasks/${taskId}`);
    }

    /**
     * Add comment to job
     */
    addComment(jobId: number, text: string): Observable<any> {
        return this._httpClient.post<any>(`${this._baseUrl}/${jobId}/comments`, JSON.stringify(text), {
            headers: { 'Content-Type': 'application/json' }
        });
    }

    /**
     * Delete a comment
     */
    deleteComment(commentId: number): Observable<void> {
        return this._httpClient.delete<void>(`${this._baseUrl}/comments/${commentId}`);
    }

    /**
     * Get dashboard statistics
     */
    getStatistics(global: boolean = false): Observable<JobStatistics> {
        let params = new HttpParams();
        if (global) params = params.set('global', 'true');
        
        return this._httpClient.get<JobStatistics>(`${this._baseUrl}/stats`, { params }).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Mark multiple jobs with a new status
     */
    bulkUpdateStatus(jobIds: number[], statusId: number): Observable<any> {
        return this._httpClient.put<any>(`${this._baseUrl}/bulk/status`, { jobIds, statusId });
    }

    /**
     * Temporarily assign multiple jobs to a staff member until a specific date
     */
    bulkTemporaryAssign(payload: { jobIds: number[], staffId: number, untilDate: string, note: string }): Observable<any> {
        return this._httpClient.put<any>(`${this._baseUrl}/bulk/temporary-assign`, payload);
    }

    /**
     * Archive multiple jobs at once (Soft Delete)
     */
    bulkArchiveJobs(jobIds: number[]): Observable<any> {
        return this._httpClient.post<any>(`${this._baseUrl}/bulk/archive`, jobIds);
    }

    /**
     * Export filtered jobs to Excel
     */
    exportJobs(filter: JobFilter): Observable<Blob> {
        let params = new HttpParams();
        
        if (filter.searchString) params = params.set('SearchString', filter.searchString);
        if (filter.statusId !== undefined) params = params.set('StatusID', filter.statusId.toString());
        if (filter.priority !== undefined) params = params.set('Priority', filter.priority.toString());
        if (filter.jobTypeId !== undefined) params = params.set('JobTypeID', filter.jobTypeId.toString());
        if (filter.ownerId !== undefined) params = params.set('OwnerID', filter.ownerId.toString());
        if (filter.responsibleId !== undefined) params = params.set('ResponsibleID', filter.responsibleId.toString());
        if (filter.customerId !== undefined) params = params.set('CustomerID', filter.customerId.toString());
        if (filter.isActive !== undefined) params = params.set('IsActive', filter.isActive.toString());
        if (filter.isRecurring !== undefined) params = params.set('IsRecurring', filter.isRecurring.toString());
        if (filter.isInternal !== undefined) params = params.set('IsInternal', filter.isInternal.toString());

        return this._httpClient.get(`${this._baseUrl}/export`, { 
            params,
            responseType: 'blob' 
        });
    }

    /**
     * Quick close a job
     */
    closeJob(id: number): Observable<void> {
        return this._httpClient.put<void>(`${this._baseUrl}/${id}/close`, {});
    }

    /**
     * Get lookup data for filters
     */
    getLookups(): Observable<any> {
        return this._httpClient.get<any>(`${this._baseApiUrl}/api/Lookups`).pipe(
            map(data => toCamelCase(data))
        );
    }

    /**
     * Helper to filter statuses based on job type and mappings
     */
    getFilteredStatuses(jobTypeId: number, allStatuses: any[], mappings: any[]): any[] {
        if (!jobTypeId) return allStatuses;
        
        const allowedStatusIds = mappings
            .filter(m => m.jobTypeId === jobTypeId)
            .map(m => m.jobStatusMasterId);
            
        if (allowedStatusIds.length === 0) return allStatuses;
        
        return allStatuses.filter(s => allowedStatusIds.includes(s.id));
    }
}
