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
}

export interface CustomerListFilter {
    includeInactive?: boolean;
    contactType?: number;
    searchString?: string;
    currentPage: number;
    pageSize: number;
    orderBy?: string;
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
