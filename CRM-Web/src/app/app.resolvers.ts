import { inject } from '@angular/core';
import { NavigationService } from 'app/core/navigation/navigation.service';
import { MessagesService } from 'app/layout/common/messages/messages.service';
import { NotificationsService } from 'app/layout/common/notifications/notifications.service';
import { QuickChatService } from 'app/layout/common/quick-chat/quick-chat.service';
import { ShortcutsService } from 'app/layout/common/shortcuts/shortcuts.service';
import { forkJoin, of } from 'rxjs';

export const initialDataResolver = () => {
    const navigationService = inject(NavigationService);
    
    // Provide basic navigation for now so the sidebar is not empty
    const navigation = {
        compact: [],
        default: [
            {
                id      : 'dashboard',
                title   : 'Dashboard',
                type    : 'basic',
                icon    : 'heroicons_outline:home',
                link    : '/dashboard'
            },
            {
                id      : 'contacts',
                title   : 'Contacts',
                type    : 'basic',
                icon    : 'heroicons_outline:user-group',
                link    : '/customer'
            },
            {
                id      : 'jobs',
                title   : 'Jobs',
                type    : 'basic',
                icon    : 'heroicons_outline:clipboard-document-list',
                link    : '/jobs'
            },
            {
                id      : 'forms',
                title   : 'Forms',
                type    : 'basic',
                icon    : 'heroicons_outline:document-text',
                link    : '/forms'
            },
            {
                id      : 'reports',
                title   : 'Reports',
                type    : 'basic',
                icon    : 'heroicons_outline:chart-bar',
                link    : '/reports'
            },
            {
                id      : 'settings',
                title   : 'Setting',
                type    : 'basic',
                icon    : 'heroicons_outline:cog-8-tooth',
                link    : '/settings'
            }
        ],
        futuristic: [],
        horizontal: []
    };

    // Push the navigation data to the service manually since we stubbed it
    // @ts-ignore
    navigationService._navigation.next(navigation);

    return forkJoin([
        of(navigation),
        of([]), // messages
        of([]), // notifications
        of([]), // quickChat
        of([]), // shortcuts
    ]);
};
