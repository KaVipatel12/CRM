import { ChangeDetectionStrategy, Component, inject, OnInit, ViewEncapsulation } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
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

import { FormsGridComponent } from './grid/grid.component';

@Component({
    selector       : 'forms-dashboard',
    templateUrl    : './forms.component.html',
    encapsulation  : ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    animations     : fuseAnimations,
    standalone     : true,
    imports        : [CommonModule, FormsGridComponent, MatIconModule, RouterLink]
})
export class FormsComponent
{
    /**
     * Constructor
     */
    constructor()
    {
    }
}
