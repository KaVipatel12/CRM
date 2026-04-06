export interface User {
    id: string;
    name: string;
    email: string;
    avatar?: string;
    status?: string;
    isAdmin?: boolean;
    isChecker?: boolean;
    isSuperAdmin?: boolean;
}
