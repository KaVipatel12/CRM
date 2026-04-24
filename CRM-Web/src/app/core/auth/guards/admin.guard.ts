import { inject } from '@angular/core';
import { CanActivateChildFn, CanActivateFn, Router } from '@angular/router';
import { UserService } from 'app/core/user/user.service';
import { map, take } from 'rxjs/operators';

export const AdminGuard: CanActivateFn | CanActivateChildFn = (route, state) => {
    const router: Router = inject(Router);
    const userService: UserService = inject(UserService);

    return userService.user$.pipe(
        take(1),
        map(user => {
            if (user && (user.isAdmin || user.isSuperAdmin)) {
                return true;
            }
            
            // Redirect unauthorized users to dashboard
            return router.parseUrl('/dashboard');
        })
    );
};
