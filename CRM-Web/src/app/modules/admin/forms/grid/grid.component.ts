import { ChangeDetectionStrategy, Component, inject, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, UntypedFormControl } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';
import { fuseAnimations } from '@fuse/animations';
import { FormMaster, FormsService } from 'app/modules/admin/forms/forms.service';
import { FormContactPickerComponent } from 'app/modules/admin/forms/contact-picker/contact-picker.component';
import { BehaviorSubject, combineLatest, map, Observable, startWith } from 'rxjs';
import { Router } from '@angular/router';

@Component({
    selector       : 'forms-grid',
    templateUrl    : './grid.component.html',
    encapsulation  : ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    animations     : fuseAnimations,
    standalone     : true,
    imports        : [CommonModule, FormsModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatIconModule, MatButtonModule, MatSelectModule, MatTooltipModule, MatDialogModule]
})
export class FormsGridComponent implements OnInit
{
    private _formsService = inject(FormsService);
    private _matDialog = inject(MatDialog);
    private _router = inject(Router);

    @Input() customerId: number | null = null;
    @Input() showFilters: boolean = true;

    forms$: Observable<FormMaster[]>;
    categories$: Observable<string[]>;
    searchInputControl: UntypedFormControl = new UntypedFormControl('');
    filterCategory$: BehaviorSubject<string> = new BehaviorSubject('all');

    /**
     * On init
     */
    ngOnInit(): void
    {
        // Get the forms
        this._formsService.getForms(this.customerId).subscribe();

        // Setup filter logic
        this.forms$ = combineLatest([
            this._formsService.forms$,
            this.searchInputControl.valueChanges.pipe(startWith('')),
            this.filterCategory$
        ]).pipe(
            map(([forms, query, category]) => {
                if (!forms) return [];

                return forms.filter(form => {
                    const matchesQuery = form.name.toLowerCase().includes(query.toLowerCase());
                    const matchesCategory = category === 'all' || form.category === category;
                    return matchesQuery && matchesCategory;
                });
            })
        );

        // Get unique categories for the filter
        this.categories$ = this._formsService.forms$.pipe(
            map(forms => {
                if (!forms) return [];
                const categories = forms.map(f => f.category).filter((c): c is string => !!c);
                return Array.from(new Set(categories));
            })
        );
    }

    /**
     * Handle form action
     */
    onAction(form: FormMaster, action: string): void
    {
        // If customerId is provided, go straight to the action
        if (this.customerId)
        {
            const queryParams: any = { 
                customerId: this.customerId,
                from: 'customer' // <--- Tell the view we came from the customer page
            };
            if (action === 'email') queryParams.action = 'email';
            
            this._router.navigate(['/forms/view', form.slug], { queryParams });
        }
        else
        {
            // Otherwise open picker
            this.openContactPicker(form);
        }
    }

    /**
     * Open contact picker dialog
     */
    openContactPicker(form: FormMaster): void
    {
        this._matDialog.open(FormContactPickerComponent, {
            autoFocus: false,
            width: '520px',
            panelClass: 'contact-picker-dialog'
        }).afterClosed().subscribe((result) => {
            if (!result) return;

            const queryParams: any = {
                from: 'dashboard' // <--- Tell the view we came from the dashboard
            };
            if (result.contact) {
                queryParams.customerId = result.contact.id;
            }

            // Navigate to form preview/generation page
            this._router.navigate(['/forms/view', form.slug], { queryParams });
        });
    }

    /**
     * Filter by category
     */
    filterByCategory(category: string): void
    {
        this.filterCategory$.next(category);
    }

    /**
     * Track by function for ngFor
     */
    trackByFn(index: number, item: any): any
    {
        return item.id || index;
    }
}
