import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { BirthdayService, UpcomingBirthday } from '../birthday.service';
import { Observable } from 'rxjs';

@Component({
    selector: 'birthday-dialog',
    standalone: true,
    imports: [CommonModule, MatButtonModule, MatDialogModule, MatIconModule],
    templateUrl: './birthday-dialog.component.html',
    styles: [`
        .birthday-card {
            transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
        }
        .birthday-card:hover {
            transform: translateY(-4px) scale(1.01);
            box-shadow: 0 10px 15px -3px rgba(0, 0, 0, 0.1), 0 4px 6px -2px rgba(0, 0, 0, 0.05);
        }
        .birthday-card .date-block {
            transition: transform 0.3s ease;
        }
        .birthday-card:hover .date-block {
            transform: scale(1.05);
        }
    `]
})
export class BirthdayDialogComponent implements OnInit {
    private _birthdayService = inject(BirthdayService);
    public dialogRef = inject(MatDialogRef<BirthdayDialogComponent>);
    
    birthdays$: Observable<UpcomingBirthday[] | null> = this._birthdayService.birthdays$;

    ngOnInit(): void {
        // Use cached data if available to optimize performance
        this._birthdayService.getUpcomingBirthdays().subscribe();
    }

    /**
     * Get a random color class for the date block
     */
    getColorClass(index: number): string {
        const colors = ['bg-teal-500', 'bg-blue-500', 'bg-indigo-500', 'bg-rose-500', 'bg-amber-500'];
        return colors[index % colors.length];
    }
}
