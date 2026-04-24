import { Routes } from '@angular/router';
import { ClientDetailsComponent } from './client-details/client-details.component';

export default [
    {
        path: '',
        pathMatch: 'full',
        redirectTo: 'client-details'
    },
    {
        path: 'client-details',
        component: ClientDetailsComponent
    },
    {
        path: 'notes-for-fs',
        loadComponent: () => import('./notes-for-fs/notes-for-fs.component').then(m => m.NotesForFSComponent)
    }
] as Routes;
