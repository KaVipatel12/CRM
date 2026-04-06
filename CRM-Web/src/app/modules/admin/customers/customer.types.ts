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
    contactName?: string;
    email?: string;
    cellPhone?: string;
    workPhone?: string;
}
