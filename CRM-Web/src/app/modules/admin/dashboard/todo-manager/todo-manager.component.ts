import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnDestroy, OnInit, ViewChild, ViewEncapsulation, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm, ReactiveFormsModule, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
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
        MatTooltipModule,
        MatSelectModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatButtonToggleModule
    ]
})
export class TodoManagerComponent implements OnInit, OnDestroy {
    @ViewChild('todoNGForm') todoNGForm: NgForm;
    @Input() mode: 'full' | 'mini' = 'full';
    
    todos: UserTodo[] = [];
    filteredTodos: UserTodo[] = [];
    filterState: 'all' | 'high' | 'overdue' | 'completed' = 'all';

    todoForm: UntypedFormGroup;
    isLoading: boolean = false;
    expandedTodoId: number | null = null;
    today: Date = new Date();

    private _changeDetectorRef = inject(ChangeDetectorRef);
    private _todoService = inject(TodoService);
    private _formBuilder = inject(UntypedFormBuilder);
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    constructor() {
        this.todoForm = this._formBuilder.group({
            note: ['', [Validators.required]],
            dueDate: [null],
            priority: [1] // 0=Low, 1=Medium, 2=High
        });
    }

    ngOnInit(): void {
        // Subscribe to todos changes
        this._todoService.todos$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((todos) => {
                this.todos = todos;
                this.applyFilter();
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

        const todo = this.todoForm.getRawValue(); // gets note, dueDate, priority
        this._todoService.createTodo(todo)
            .subscribe(() => {
                this.todoNGForm.resetForm({ priority: 1 });
            });
    }

    setFilter(filter: 'all' | 'high' | 'overdue' | 'completed'): void {
        this.filterState = filter;
        this.applyFilter();
    }

    applyFilter(): void {
        let result = this.todos;

        if (this.filterState === 'high') {
            result = result.filter(t => t.priority === 2 && !t.isCompleted);
        } else if (this.filterState === 'overdue') {
            const today = new Date();
            today.setHours(0, 0, 0, 0);
            result = result.filter(t => t.dueDate && new Date(t.dueDate) < today && !t.isCompleted);
        } else if (this.filterState === 'completed') {
            result = result.filter(t => t.isCompleted);
        } else {
            // 'all' ignores completed in mini mode usually, but user asked for completed tab. 
            // In 'all', let's show everything or mostly incomplete. Let's just show all.
        }

        // Apply mini mode constraint (only top 5)
        if (this.mode === 'mini') {
            result = result.slice(0, 5);
        }

        this.filteredTodos = result;
        this._changeDetectorRef.markForCheck();
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

    toggleExpand(id: number, event: Event): void {
        event.stopPropagation();
        this.expandedTodoId = this.expandedTodoId === id ? null : id;
    }
}
