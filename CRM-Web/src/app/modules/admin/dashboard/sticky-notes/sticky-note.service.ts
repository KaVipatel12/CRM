import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { BehaviorSubject, Observable, tap } from 'rxjs';

export interface UserNote {
    id: number;
    title?: string;
    content: string;
    isPinned: boolean;
    displayOrder: number;
    createdDateTime: string;
    updateDateTime: string;
}

export interface CreateUserNoteDto {
    title?: string;
    content: string;
    isPinned?: boolean;
    displayOrder?: number;
}

export interface UpdateUserNoteDto {
    id: number;
    title?: string;
    content: string;
    isPinned: boolean;
    displayOrder: number;
}

@Injectable({
    providedIn: 'root'
})
export class StickyNoteService {
    private _httpClient = inject(HttpClient);
    private _apiBaseUrl = inject(API_BASE_URL);
    private _baseUrl = `${this._apiBaseUrl}/api/UserNotes`;

    private _notes: BehaviorSubject<UserNote[]> = new BehaviorSubject<UserNote[]>([]);

    /**
     * Getter for notes
     */
    get notes$(): Observable<UserNote[]> {
        return this._notes.asObservable();
    }

    /**
     * Get all notes for the current user
     */
    getNotes(): Observable<UserNote[]> {
        return this._httpClient.get<UserNote[]>(this._baseUrl).pipe(
            tap((notes) => {
                this._notes.next(notes);
            })
        );
    }

    /**
     * Create a new note
     */
    createNote(dto: CreateUserNoteDto): Observable<UserNote> {
        return this._httpClient.post<UserNote>(this._baseUrl, dto).pipe(
            tap((newNote) => {
                const currentNotes = this._notes.getValue();
                this._notes.next([newNote, ...currentNotes]);
            })
        );
    }

    /**
     * Update an existing note
     */
    updateNote(id: number, dto: UpdateUserNoteDto): Observable<void> {
        return this._httpClient.put<void>(`${this._baseUrl}/${id}`, dto).pipe(
            tap(() => {
                const currentNotes = this._notes.getValue();
                const index = currentNotes.findIndex((n) => n.id === id);
                if (index !== -1) {
                    currentNotes[index] = { ...currentNotes[index], ...dto };
                    this._notes.next([...currentNotes]);
                }
            })
        );
    }

    /**
     * Delete a note
     */
    deleteNote(id: number): Observable<void> {
        return this._httpClient.delete<void>(`${this._baseUrl}/${id}`).pipe(
            tap(() => {
                const currentNotes = this._notes.getValue();
                this._notes.next(currentNotes.filter((n) => n.id !== id));
            })
        );
    }

    /**
     * Convert a note to a todo task
     */
    convertToTodo(id: number): Observable<{ todoId: number }> {
        return this._httpClient.post<{ todoId: number }>(`${this._baseUrl}/${id}/convert-to-todo`, {}).pipe(
            tap(() => {
                // Remove the note from the local list as it's been "converted" (moved)
                const currentNotes = this._notes.getValue();
                this._notes.next(currentNotes.filter((n) => n.id !== id));
            })
        );
    }

    /**
     * Reorder notes (drag and drop)
     */
    updateOrder(updates: { id: number; displayOrder: number }[]): Observable<void> {
        // Optimistic UI update
        const currentNotes = this._notes.getValue();
        const updatedNotes = [...currentNotes];

        // Apply new orders locally
        updates.forEach(update => {
            const noteIndex = updatedNotes.findIndex(n => n.id === update.id);
            if (noteIndex !== -1) {
                updatedNotes[noteIndex].displayOrder = update.displayOrder;
            }
        });

        // Re-sort locally based on pinned status and new display order
        updatedNotes.sort((a, b) => {
            if (a.isPinned !== b.isPinned) {
                return a.isPinned ? -1 : 1; // Pinned notes first
            }
            return a.displayOrder - b.displayOrder; // Then by display order
        });

        this._notes.next(updatedNotes);

        // Send to backend
        return this._httpClient.put<void>(`${this._baseUrl}/reorder`, updates);
    }
}
