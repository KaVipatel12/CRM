import { Component, ViewEncapsulation } from '@angular/core';

import { inject } from '@angular/core';
import { UserService } from 'app/core/user/user.service';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
    selector     : 'example',
    standalone   : true,
    imports      : [CommonModule, MatIconModule],
    templateUrl  : './example.component.html',
    encapsulation: ViewEncapsulation.None,
})
export class ExampleComponent
{
    private _userService = inject(UserService);
    user$ = this._userService.user$;

    /**
     * Constructor
     */
    constructor()
    {
    }
}
