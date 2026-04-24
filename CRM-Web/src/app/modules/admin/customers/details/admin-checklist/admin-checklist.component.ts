import { Component, Input, OnInit, OnChanges, SimpleChanges, inject, ViewEncapsulation } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatTooltipModule } from '@angular/material/tooltip';
import { FormsModule } from '@angular/forms';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CustomerService } from '../../customer.service';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'admin-checklist',
  standalone: true,
  imports: [CommonModule, MatIconModule, MatCheckboxModule, MatTooltipModule, FormsModule, MatProgressSpinnerModule, MatSnackBarModule],
  templateUrl: './admin-checklist.component.html',
  encapsulation: ViewEncapsulation.None
})
export class AdminChecklistComponent implements OnInit, OnChanges {
  @Input() customerId: number;
  @Input() clientType: number; // to reload if type changes
  @Input() isAdmin: boolean = false;

  private _customerService = inject(CustomerService);
  private _snackBar = inject(MatSnackBar);

  isLoading: boolean = false;
  checklistItems: any[] = [];
  groupedItems: { category: string, items: any[] }[] = [];

  ngOnInit(): void {
    if (this.customerId) {
      this.loadChecklist();
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['customerId'] && !changes['customerId'].firstChange) {
        this.loadChecklist();
    }
  }

  loadChecklist(): void {
    this.isLoading = true;
    this._customerService.getChecklist(this.customerId).subscribe({
      next: (res) => {
        this.checklistItems = res;
        this.groupItems();
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Failed to load checklist', err);
        this.isLoading = false;
      }
    });
  }

  groupItems(): void {
    const groups = {};
    for (const item of this.checklistItems) {
      if (!groups[item.category]) {
        groups[item.category] = [];
      }
      groups[item.category].push(item);
    }

    this.groupedItems = Object.keys(groups).map(category => ({
      category,
      items: groups[category]
    })).sort((a, b) => {
      // Sort categories: ADMIN first, then CHECKLIST, etc. Just alphabetical for now or custom logic
      return a.category.localeCompare(b.category);
    });
  }

  toggleStatus(item: any): void {
    // Optimistic UI update
    const previousState = !item.isCompleted;
    
    this._customerService.toggleChecklistStatus(this.customerId, item.checklistMasterId, item.isCompleted, item.notes).subscribe({
      next: () => {
        // Reload to get the actual audit trail (who did it, when) from backend
        this.loadChecklist();
        this._snackBar.open(`Task marked as ${item.isCompleted ? 'completed' : 'pending'}`, 'Dismiss', { duration: 3000 });
      },
      error: (err) => {
        // Revert on error
        item.isCompleted = previousState;
        this._snackBar.open('Failed to update task status.', 'Dismiss', { duration: 3000 });
      }
    });
  }
}
