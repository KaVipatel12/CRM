import { ChangeDetectorRef, Component, Inject, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { CallsService } from '../calls.service';
import { Purpose, CallLog } from '../calls.types';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from 'app/app.config';
import { toCamelCase } from 'app/core/utils/case-utils';
import { UserService } from 'app/core/user/user.service';

@Component({
    selector: 'call-dialog',
    templateUrl: './call-dialog.component.html',
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatDialogModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatSelectModule,
        MatDatepickerModule,
        MatCheckboxModule
    ]
})
export class CallDialogComponent implements OnInit {
    private _fb = inject(FormBuilder);
    private _callsService = inject(CallsService);
    private _dialogRef = inject(MatDialogRef<CallDialogComponent>);
    private _httpClient = inject(HttpClient);
    private _baseUrl = inject(API_BASE_URL);
    private _changeDetectorRef = inject(ChangeDetectorRef);
    private _userService = inject(UserService);

    callForm: FormGroup;
    purposes: Purpose[] = [];
    staff: any[] = [];
    statusMasters: any[] = [];
    isEdit: boolean = false;
    currentUserId: number | null = null;

    natureOfBusinessList = [
        { id: 1, name: 'Student' },
        { id: 2, name: 'TR' },
        { id: 3, name: 'PR' },
        { id: 4, name: 'Citizenship' },
        { id: 5, name: 'Visit Visa' },
        { id: 6, name: 'Accounting' },
        { id: 7, name: 'Others' }
    ];

    hearAboutUsList = [
        { id: 1, name: 'Google' },
        { id: 2, name: 'Social Media' },
        { id: 3, name: 'Newspaper' },
        { id: 4, name: 'Referred by current client' },
        { id: 5, name: 'Word of Mouth' },
        { id: 6, name: 'Others' }
    ];

    constructor(@Inject(MAT_DIALOG_DATA) public data: { call: CallLog | null }) {
        this.isEdit = !!data.call;
        
        this.callForm = this._fb.group({
            id: [data.call?.id || 0],
            receiveDate: [data.call?.receiveDate || new Date(), Validators.required],
            receiverId: [{ value: data.call?.receiverId || null, disabled: true }, Validators.required],
            forWhomId: [data.call?.forWhomId || null, Validators.required],
            name: [data.call?.name || '', Validators.required],
            email: [data.call?.email || ''],
            mobileNo: [data.call?.mobileNo || ''],
            companyName: [data.call?.companyName || ''],
            purposeId: [data.call?.purposeId || null],
            statusId: [data.call?.statusId || null],
            remark: [data.call?.remark || ''],
            otherPurpose: [data.call?.otherPurpose || ''],
            natureOfBusiness: [data.call?.natureOfBusiness || ''],
            otherNatureOfBusiness: [data.call?.otherNatureOfBusiness || ''],
            hearAboutUs: [data.call?.hearAboutUs || ''],
            otherHearAboutUs: [data.call?.otherHearAboutUs || ''],
            selectedNatureOfBusiness: this._fb.array([]),
            selectedHearAboutUs: this._fb.array([])
        });
    }

    ngOnInit(): void {
        // Get current user and set receiver
        this._userService.user$.subscribe((user) => {
            if (user && !this.isEdit) {
                this.currentUserId = parseInt(user.id);
                this.callForm.get('receiverId')?.setValue(this.currentUserId);
            }
        });
        this._callsService.getPurposes().subscribe(p => this.purposes = p);
        
        // Load staff from service
        this._callsService.getUsers().subscribe(u => {
            this.staff = u;
            this._changeDetectorRef.markForCheck();
        });

        // Fetch all lookups to get statuses
        this._httpClient.get<any>(`${this._baseUrl}/api/Lookups`).subscribe(data => {
            const lookups = toCamelCase(data);
            const allStatuses = lookups.jobStatusMasters || [];
            
            // Filter only the specific statuses requested
            const allowedStatusNames = [
                'Ready for Lodgement - waiting client confirmation',
                'Filed',
                'Job Closed',
                'N/A',
                'Pending',
                'Continue'
            ];
            
            this.statusMasters = allStatuses.filter(s => 
                allowedStatusNames.some(name => s.statusName?.trim().toLowerCase() === name.trim().toLowerCase())
            );

            // Sort them to match the order in the screenshot
            this.statusMasters.sort((a, b) => {
                return allowedStatusNames.indexOf(a.statusName) - allowedStatusNames.indexOf(b.statusName);
            });

            this._changeDetectorRef.markForCheck();
        });
        if (this.isEdit && this.data.call) {
            const natureOfBusiness = this.data.call.natureOfBusiness?.split(',') || [];
            natureOfBusiness.forEach(id => {
                if (id) this.selectedNatureOfBusiness.push(this._fb.control(parseInt(id)));
            });

            const hearAboutUs = this.data.call.hearAboutUs?.split(',') || [];
            hearAboutUs.forEach(id => {
                if (id) this.selectedHearAboutUs.push(this._fb.control(parseInt(id)));
            });
        }
    }

    get selectedNatureOfBusiness(): FormArray {
        return this.callForm.get('selectedNatureOfBusiness') as FormArray;
    }

    get selectedHearAboutUs(): FormArray {
        return this.callForm.get('selectedHearAboutUs') as FormArray;
    }

    onCheckboxChange(event: any, id: number, arrayName: string): void {
        const formArray = arrayName === 'nature' ? this.selectedNatureOfBusiness : this.selectedHearAboutUs;
        const fieldName = arrayName === 'nature' ? 'natureOfBusiness' : 'hearAboutUs';

        if (event.checked) {
            formArray.push(this._fb.control(id));
        } else {
            const index = formArray.controls.findIndex(x => x.value === id);
            formArray.removeAt(index);
        }

        const value = formArray.value.join(',');
        this.callForm.get(fieldName)?.setValue(value);
    }

    isCheckboxChecked(id: number, arrayName: string): boolean {
        const formArray = arrayName === 'nature' ? this.selectedNatureOfBusiness : this.selectedHearAboutUs;
        return formArray.value.includes(id);
    }

    save(): void {
        if (this.callForm.invalid) return;

        const callData = this.callForm.getRawValue();
        if (this.isEdit) {
            this._callsService.updateCall(callData.id, callData).subscribe(() => {
                this._dialogRef.close(true);
            });
        } else {
            this._callsService.createCall(callData).subscribe(() => {
                this._dialogRef.close(true);
            });
        }
    }

    close(): void {
        this._dialogRef.close();
    }
}
