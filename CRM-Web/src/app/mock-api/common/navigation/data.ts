/* eslint-disable */
import { FuseNavigationItem } from '@fuse/components/navigation';

export const defaultNavigation: FuseNavigationItem[] = [
    {
        id   : 'dashboard',
        title: 'Dashboard',
        type : 'basic',
        icon : 'heroicons_outline:presentation-chart-bar',
        link : '/dashboard'
    },
    {
        id   : 'customers',
        title: 'Customers',
        type : 'basic',
        icon : 'heroicons_outline:user-group',
        link : '/customers'
    },
    {
        id   : 'jobs',
        title: 'Jobs',
        type : 'basic',
        icon : 'heroicons_outline:briefcase',
        link : '/jobs'
    },
    {
        id   : 'calls',
        title: 'Call Tracker',
        type : 'basic',
        icon : 'heroicons_outline:phone',
        link : '/calls'
    },
    {
        id   : 'forms',
        title: 'Forms',
        type : 'basic',
        icon : 'heroicons_outline:document-duplicate',
        link : '/forms'
    },
    {
        id      : 'reports',
        title   : 'Reports',
        type    : 'collapsable',
        icon    : 'heroicons_outline:document-chart-bar',
        children: [
            {
                id   : 'reports.client-details',
                title: 'Client Details',
                type : 'basic',
                icon : 'heroicons_outline:identification',
                link : '/reports/client-details'
            },
            {
                id   : 'reports.notes-for-fs',
                title: 'Notes for FS',
                type : 'basic',
                icon : 'heroicons_outline:document-text',
                link : '/reports/notes-for-fs'
            }
        ]
    },
    {
        id   : 'settings',
        title: 'Settings',
        type : 'collapsable',
        icon : 'heroicons_outline:cog-6-tooth',
        children: [
            {
                id   : 'settings.email',
                title: 'Email Configuration',
                type : 'basic',
                icon : 'heroicons_outline:envelope',
                link : '/settings/email'
            },
            {
                id   : 'settings.dynamic-fields',
                title: 'Dynamic Fields',
                type : 'basic',
                icon : 'heroicons_outline:adjustments-horizontal',
                link : '/settings/dynamic-fields'
            },
            {
                id   : 'settings.passwords',
                title: 'Password Manager',
                type : 'basic',
                icon : 'heroicons_outline:key',
                link : '/settings/passwords'
            }
        ]
    }
];
export const compactNavigation: FuseNavigationItem[] = [
    {
        id   : 'dashboard',
        title: 'Dashboard',
        type : 'basic',
        icon : 'heroicons_outline:presentation-chart-bar',
        link : '/dashboard'
    },
    {
        id   : 'customers',
        title: 'Customers',
        type : 'basic',
        icon : 'heroicons_outline:user-group',
        link : '/customers'
    },
    {
        id   : 'forms',
        title: 'Forms',
        type : 'basic',
        icon : 'heroicons_outline:document-duplicate',
        link : '/forms'
    }
];
export const futuristicNavigation: FuseNavigationItem[] = [
    {
        id   : 'dashboard',
        title: 'Dashboard',
        type : 'basic',
        icon : 'heroicons_outline:presentation-chart-bar',
        link : '/dashboard'
    },
    {
        id   : 'customers',
        title: 'Customers',
        type : 'basic',
        icon : 'heroicons_outline:user-group',
        link : '/customers'
    },
    {
        id   : 'forms',
        title: 'Forms',
        type : 'basic',
        icon : 'heroicons_outline:document-duplicate',
        link : '/forms'
    }
];
export const horizontalNavigation: FuseNavigationItem[] = [
    {
        id   : 'dashboard',
        title: 'Dashboard',
        type : 'basic',
        icon : 'heroicons_outline:presentation-chart-bar',
        link : '/dashboard'
    },
    {
        id   : 'customers',
        title: 'Customers',
        type : 'basic',
        icon : 'heroicons_outline:user-group',
        link : '/customers'
    },
    {
        id   : 'forms',
        title: 'Forms',
        type : 'basic',
        icon : 'heroicons_outline:document-duplicate',
        link : '/forms'
    }
];
