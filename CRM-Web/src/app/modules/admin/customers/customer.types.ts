export interface Customer {
    id: number;
    name: string;
    code: string;
    clientType: number;
    email?: string;
    contactType?: number;
    tradingName?: string;
    isActive?: boolean;
    groupName?: string;
    abnNumber?: string;
    tfnNumber?: string;
    phone?: string;
    mobile?: string;
    website?: string;
    isDeleted?: boolean;
    isArchived?: boolean;
    isExcluded?: boolean;
    lastVarifiedDate?: string | Date;
    lastVarifiedUserName?: string;
    bankAccounts?: BankAccount[];
}

export interface BankAccount {
    id: number;
    accountName: string;
    bankName: string;
    bsb: string;
    accountNumber: string;
}

export interface CustomerListFilter {
    includeInactive?: boolean;
    contactType?: number;
    varifiedType?: string;
    searchString?: string;
    currentPage: number;
    pageSize: number;
    orderBy?: string;
    includeArchived?: boolean;
    includeExcluded?: boolean;
}

export interface Address {
    id: number;
    type?: number;
    addressLine1?: string;
    addressLine2?: string;
    city?: string;
    state?: string;
    postalCode?: string;
    country?: string;
}

export interface ContactInfo {
    id: number;
    salutation?: string;
    contactName?: string;
    cellPhone?: string;
    workPhone?: string;
    email?: string;
    email2?: string;
}

export interface CustomerStatistics {
    total: number;
    verified: number;
    unverified: number;
    active: number;
    inactive: number;
}

export interface CustomerPagedResponse {
    items: Customer[];
    totalCount: number;
    currentPage: number;
    pageSize: number;
}
