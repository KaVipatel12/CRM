import { Routes } from '@angular/router';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';
import { UploadComponent } from './upload/upload.component';

export default [
    {
        path: '',
        component: ListComponent,
    },
    {
        path: 'upload',
        component: UploadComponent,
    },
    {
        path: 'new',
        component: DetailsComponent,
    },
    {
        path: ':id',
        component: DetailsComponent,
    }
] as Routes;
