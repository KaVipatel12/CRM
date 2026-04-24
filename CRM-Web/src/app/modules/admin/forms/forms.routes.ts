import { Routes } from '@angular/router';
import { FormsComponent } from 'app/modules/admin/forms/forms.component';
import { FormViewComponent } from 'app/modules/admin/forms/view/view.component';

export default [
    {
        path     : '',
        component: FormsComponent,
    },
    {
        path     : 'view/:slug',
        component: FormViewComponent,
    }
] as Routes;
