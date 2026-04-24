export interface PasswordManager {
    id: number;
    title: string;
    url?: string;
    userName?: string;
    password?: string;
    decryptedPassword?: string;
    isRevealed?: boolean;
    note?: string;
    updateUserId?: number;
    updateDateTime?: string;
}

export interface SavePasswordRequest {
    passwordData: Partial<PasswordManager>;
    masterPassword: string;
}

export interface MasterPasswordRequest {
    masterPassword: string;
}
