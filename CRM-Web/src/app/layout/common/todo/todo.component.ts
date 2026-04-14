import { ChangeDetectionStrategy, Component, ViewEncapsulation } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';
import { TodoManagerComponent } from 'app/modules/admin/dashboard/todo-manager/todo-manager.component';

@Component({
    selector: 'todo-header',
    template: `
        <button
            mat-icon-button
            [matMenuTriggerFor]="todoMenu"
            [matTooltip]="'Personal To-Dos'">
            <mat-icon [svgIcon]="'heroicons_outline:clipboard-document-check'"></mat-icon>
        </button>

        <mat-menu #todoMenu="matMenu" [overlapTrigger]="false" class="todo-header-menu">
            <div class="w-80 sm:w-96 p-0" (click)="$event.stopPropagation()">
                <div class="p-4 border-b bg-primary text-on-primary">
                    <div class="text-lg font-bold">Quick Tasks</div>
                    <div class="text-sm opacity-80">Manage your reminders anywhere</div>
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
        MatButtonModule,
        MatIconModule,
        MatMenuModule,
        MatTooltipModule,
        TodoManagerComponent
    ]
})
export class TodoHeaderComponent {
    constructor() {}
}
