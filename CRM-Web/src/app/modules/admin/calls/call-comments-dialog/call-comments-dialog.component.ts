import { Component, Inject, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatDividerModule } from '@angular/material/divider';
import { CallsService } from '../calls.service';
import { CallLogComment } from '../calls.types';
import { UserService } from 'app/core/user/user.service';
import { FuseConfirmationService } from '@fuse/services/confirmation';

@Component({
    selector: 'call-comments-dialog',
    templateUrl: './call-comments-dialog.component.html',
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
        MatDividerModule
    ]
})
export class CallCommentsDialogComponent implements OnInit {
    private _fb = inject(FormBuilder);
    private _callsService = inject(CallsService);
    private _dialogRef = inject(MatDialogRef<CallCommentsDialogComponent>);
    private _userService = inject(UserService);
    private _fuseConfirmationService = inject(FuseConfirmationService);

    commentForm: FormGroup;
    comments: CallLogComment[] = [];
    callId: number;
    callName: string;
    isLoading: boolean = false;
    currentUser: any;
    editingCommentId: number | null = null;

    constructor(@Inject(MAT_DIALOG_DATA) public data: { callId: number, callName: string }) {
        this.callId = data.callId;
        this.callName = data.callName;
        this.commentForm = this._fb.group({
            comment: ['', Validators.required]
        });
    }

    ngOnInit(): void {
        this._userService.user$.subscribe(user => {
            this.currentUser = user;
        });
        this.loadComments();
    }

    loadComments(): void {
        this.isLoading = true;
        this._callsService.getComments(this.callId).subscribe(comments => {
            this.comments = comments;
            this.isLoading = false;
        });
    }

    addComment(): void {
        if (this.commentForm.invalid) return;

        const comment = this.commentForm.get('comment')?.value;

        if (this.editingCommentId) {
            this._callsService.updateComment(this.editingCommentId, comment).subscribe(() => {
                this.cancelEdit();
                this.loadComments();
            });
        } else {
            this._callsService.addComment(this.callId, comment).subscribe(() => {
                this.commentForm.reset();
                this.loadComments();
            });
        }
    }

    editComment(comment: CallLogComment): void {
        this.editingCommentId = comment.id;
        this.commentForm.patchValue({
            comment: comment.comment
        });
    }

    cancelEdit(): void {
        this.editingCommentId = null;
        this.commentForm.reset();
    }

    deleteComment(commentId: number): void {
        const confirmation = this._fuseConfirmationService.open({
            title: 'Delete Comment',
            message: 'Are you sure you want to delete this comment? This action cannot be undone!',
            actions: {
                confirm: {
                    label: 'Delete',
                    color: 'warn'
                }
            }
        });

        confirmation.afterClosed().subscribe((result) => {
            if (result === 'confirmed') {
                this._callsService.deleteComment(commentId).subscribe(() => {
                    this.loadComments();
                });
            }
        });
    }

    canEdit(comment: CallLogComment): boolean {
        return comment.updateUserId === parseInt(this.currentUser?.id);
    }

    canDelete(comment: CallLogComment): boolean {
        // Comment writer OR admin/superadmin
        const isAdmin = this.currentUser?.roles?.includes('Admin') || this.currentUser?.roles?.includes('SuperAdmin');
        return comment.updateUserId === parseInt(this.currentUser?.id) || isAdmin;
    }

    close(): void {
        this._dialogRef.close();
    }
}
