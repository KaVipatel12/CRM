import { Routes } from '@angular/router';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';

export default [
    {
        path     : '',
        component: ListComponent,
    },
    {
        path     : 'new',
        component: DetailsComponent,
    },
    {
        path     : ':id',
        component: DetailsComponent,
    }
] as Routes;
