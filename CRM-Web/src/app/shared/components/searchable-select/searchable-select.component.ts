import { Component, Input, OnInit, forwardRef, OnDestroy, OnChanges, SimpleChanges } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, FormControl, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { Subject, takeUntil } from 'rxjs';

@Component({
    selector: 'searchable-select',
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MatSelectModule,
        MatFormFieldModule,
        MatInputModule,
        MatIconModule,
        MatButtonModule
    ],
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => SearchableSelectComponent),
            multi: true
        }
    ],
    templateUrl: './searchable-select.component.html',
    styles: [`
        .search-container {
            position: sticky;
            top: 0;
            z-index: 100;
            background: white;
            padding: 8px 16px;
            border-bottom: 1px solid #e2e8f0;
        }
        .dark .search-container {
            background: #1e293b;
            border-bottom: 1px solid #334155;
        }
    `]
})
export class SearchableSelectComponent implements OnInit, OnDestroy, OnChanges, ControlValueAccessor {
    @Input() items: any[] = [];
    @Input() label: string = '';
    @Input() placeholder: string = 'Search...';
    @Input() multiple: boolean = false;
    @Input() displayKey: string = 'name';
    @Input() valueKey: string = 'id';
    @Input() required: boolean = false;

    filterCtrl: FormControl = new FormControl('');
    filteredItems: any[] = [];
    value: any;

    private _unsubscribeAll: Subject<any> = new Subject<any>();

    onChange: any = () => {};
    onTouched: any = () => {};

    ngOnInit(): void {
        this.filteredItems = this.items;

        this.filterCtrl.valueChanges
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((searchTerm: string) => {
                this._filter(searchTerm);
            });
    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes.items) {
            this._filter(this.filterCtrl.value);
        }
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();
    }

    private _filter(searchTerm: string): void {
        if (!searchTerm) {
            this.filteredItems = this.items;
            return;
        }

        searchTerm = searchTerm.toLowerCase();
        this.filteredItems = this.items.filter(item => {
            const val = item[this.displayKey];
            return val && val.toLowerCase().includes(searchTerm);
        });
    }

    writeValue(value: any): void {
        this.value = value;
    }

    registerOnChange(fn: any): void {
        this.onChange = fn;
    }

    registerOnTouched(fn: any): void {
        this.onTouched = fn;
    }

    onValueChange(event: any): void {
        this.value = event.value;
        this.onChange(this.value);
    }

    toggleAll(all: boolean): void {
        if (all) {
            this.value = this.items.map(i => i[this.valueKey]);
        } else {
            this.value = [];
        }
        this.onChange(this.value);
    }

    setDisabledState?(isDisabled: boolean): void {
        // Handle disabled state if needed
    }
}
