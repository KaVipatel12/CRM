import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_BASE_URL } from 'app/app.config';
import { BehaviorSubject, Observable, take, tap } from 'rxjs';

export interface UserTodo {
    id: number;
    userId: number;
    note: string;
    isCompleted: boolean;
    dueDate: string | null;
    priority: number;
    createdDateTime: string;
}

@Injectable({ providedIn: 'root' })
export class TodoService {
    private _baseUrl = inject(API_BASE_URL);
    private _httpClient = inject(HttpClient);
    private _todos: BehaviorSubject<UserTodo[]> = new BehaviorSubject<UserTodo[]>([]);

    /**
     * Getter for todos
     */
    get todos$(): Observable<UserTodo[]> {
        return this._todos.asObservable();
    }

    /**
     * Get todos for the current user
     */
    getTodos(): Observable<UserTodo[]> {
        return this._httpClient.get<UserTodo[]>(`${this._baseUrl}/api/UserTodos`).pipe(
            tap((todos) => {
                this._todos.next(todos);
            })
        );
    }

    /**
     * Create a new todo
     *
     * @param note
     */
    createTodo(todo: { note: string; dueDate?: string | null; priority?: number }): Observable<UserTodo> {
        return this._httpClient.post<UserTodo>(`${this._baseUrl}/api/UserTodos`, todo).pipe(
            tap((newTodo) => {
                const currentTodos = this._todos.value;
                this._todos.next([newTodo, ...currentTodos]);
            })
        );
    }

    /**
     * Update an existing todo
     *
     * @param todo
     */
    updateTodo(todo: { id: number; note: string; isCompleted: boolean; dueDate?: string | null; priority?: number }): Observable<any> {
        return this._httpClient.put(`${this._baseUrl}/api/UserTodos`, todo).pipe(
            tap(() => {
                const currentTodos = this._todos.value;
                const index = currentTodos.findIndex((t) => t.id === todo.id);
                if (index !== -1) {
                    currentTodos[index] = { ...currentTodos[index], ...todo };
                    this._todos.next([...currentTodos]);
                }
            })
        );
    }

    /**
     * Delete a todo
     *
     * @param id
     */
    deleteTodo(id: number): Observable<any> {
        return this._httpClient.delete(`${this._baseUrl}/api/UserTodos/${id}`).pipe(
            tap(() => {
                const currentTodos = this._todos.value;
                const index = currentTodos.findIndex((t) => t.id === id);
                if (index !== -1) {
                    currentTodos.splice(index, 1);
                    this._todos.next([...currentTodos]);
                }
            })
        );
    }
}
