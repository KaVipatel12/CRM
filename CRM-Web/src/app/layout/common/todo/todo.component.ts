import { AsyncPipe, NgIf } from '@angular/common';
import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';
import { TodoManagerComponent } from 'app/modules/admin/dashboard/todo-manager/todo-manager.component';
import { TodoService } from 'app/modules/admin/dashboard/todo.service';
import { map } from 'rxjs';

@Component({
    selector: 'todo-header',
    template: `
        <button
            class="relative"
            mat-icon-button
            [matMenuTriggerFor]="todoMenu"
            [matTooltip]="'Personal To-Dos'">
            <mat-icon [svgIcon]="'heroicons_outline:clipboard-document-list'"></mat-icon>
            <ng-container *ngIf="(uncompletedCount$ | async) as count">
                <span
                    class="absolute top-0 right-0 flex items-center justify-center min-w-4 h-4 px-1 rounded-full bg-primary text-on-primary text-[10px] font-bold ring-2 ring-card"
                    *ngIf="count > 0">
                    {{count}}
                </span>
            </ng-container>
        </button>

        <mat-menu #todoMenu="matMenu" [overlapTrigger]="false" class="todo-header-menu">
            <div class="w-[280px] sm:w-[520px] p-0" (click)="$event.stopPropagation()">
                <div class="p-4 border-b bg-primary text-on-primary rounded-t-xl">
                    <div class="text-lg font-bold">Personal Tasks</div>
                    <div class="text-sm opacity-80 font-medium">Manage your daily reminders</div>
                </div>
                <todo-manager [mode]="'mini'"></todo-manager>
            </div>
        </mat-menu>
    `,
    styles: [
        `
            .todo-header-menu {
                max-width: none !important;
                padding: 0 !important;
            }
        `
    ],
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    standalone: true,
    imports: [
        AsyncPipe,
        NgIf,
        MatButtonModule,
        MatIconModule,
        MatMenuModule,
        MatTooltipModule,
        TodoManagerComponent
    ]
})
export class TodoHeaderComponent implements OnInit {
    private _todoService = inject(TodoService);

    uncompletedCount$ = this._todoService.todos$.pipe(
        map(todos => todos.filter(t => !t.isCompleted).length)
    );

    ngOnInit(): void {
        this._todoService.getTodos().subscribe();
    }
}
