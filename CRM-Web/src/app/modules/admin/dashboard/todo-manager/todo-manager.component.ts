import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnDestroy, OnInit, ViewChild, ViewEncapsulation, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm, ReactiveFormsModule, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { Subject, takeUntil } from 'rxjs';
import { TodoService, UserTodo } from '../todo.service';

@Component({
    selector: 'todo-manager',
    templateUrl: './todo-manager.component.html',
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatCheckboxModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatTooltipModule
    ]
})
export class TodoManagerComponent implements OnInit, OnDestroy {
    @ViewChild('todoNGForm') todoNGForm: NgForm;
    @Input() mode: 'full' | 'mini' = 'full';
    
    todos: UserTodo[] = [];
    todoForm: UntypedFormGroup;
    isLoading: boolean = false;

    private _changeDetectorRef = inject(ChangeDetectorRef);
    private _todoService = inject(TodoService);
    private _formBuilder = inject(UntypedFormBuilder);
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor() {
        this.todoForm = this._formBuilder.group({
            note: ['', [Validators.required]]
        });
    }

    ngOnInit(): void {
        // Subscribe to todos changes
        this._todoService.todos$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((todos) => {
                this.todos = this.mode === 'mini' ? todos.slice(0, 5) : todos;
                this._changeDetectorRef.markForCheck();
            });

        this.loadTodos();
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }

    loadTodos(): void {
        this.isLoading = true;
        this._todoService.getTodos()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(() => {
                this.isLoading = false;
                this._changeDetectorRef.markForCheck();
            });
    }

    addTodo(): void {
        if (this.todoForm.invalid) return;

        const note = this.todoForm.get('note')?.value;
        this._todoService.createTodo(note)
            .subscribe(() => {
                this.todoNGForm.resetForm();
                // No need to call loadTodos() here as the service updates the subject
            });
    }

    toggleTodo(todo: UserTodo): void {
        this._todoService.updateTodo({ ...todo, isCompleted: !todo.isCompleted })
            .subscribe(() => {
                this.loadTodos();
            });
    }

    deleteTodo(id: number): void {
        this._todoService.deleteTodo(id)
            .subscribe(() => {
                this.loadTodos();
            });
    }
}
