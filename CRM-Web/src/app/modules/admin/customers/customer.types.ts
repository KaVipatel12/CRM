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
    annualFinancialStatements?: boolean;
    annualABNTaxReturn?: boolean;
    annualGSTClient?: boolean;
    annualNonGST?: boolean;
    basa?: boolean;
    basq?: boolean;
    prepareGroupCertificates?: boolean;
    lodgement?: boolean;
    financialStatement?: boolean;
    paygWeekly?: boolean;
    bankAccounts?: BankAccount[];
    dynamicFieldValues?: UpsertDynamicFieldValue[];
    relationships?: CreateCustomerRelationship[];
    branches?: Branch[];
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
    branchId?: number;
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

/**
 * Dynamic Field Types
 */
export type DynamicFieldType = 'boolean' | 'dropdown' | 'string' | 'textarea' | 'number' | 'date';

export interface DynamicFieldMaster {
    id: number;
    fieldName: string;
    displayName: string;
    fieldType: DynamicFieldType | string;
    fieldAbbreviation?: string;
    defaultValue?: string;
    category?: string;
    isActive: boolean;
    sortOrder: number;
    options?: string; // JSON string for dropdown options
    displayTypeIds?: string; // Comma separated IDs of customer types
}

export interface DynamicFieldValue {
    id: number;
    customerId: number;
    fieldId: number;
    fieldValue?: string;
    fieldDisplayName?: string;
}

export interface UpsertDynamicFieldValue {
    fieldId: number;
    fieldValue: string | boolean | number | null;
}

export interface CustomerNote {
    id: number;
    customerId: number;
    noteText: string;
    isPinned: boolean;
    createdDateTime: string | Date;
    createdUserName?: string;
}

export interface CreateCustomerNote {
    customerId: number;
    noteText: string;
    isPinned: boolean;
}

export interface CustomerRelationship {
    id: number;
    sourceCustomerId: number;
    targetCustomerId: number;
    relationshipTypeId: number;
    relationshipTypeName: string;
    targetCustomerName: string;
    startDate?: string | Date;
    endDate?: string | Date;
    noOfShare?: number;
    note?: string;
}

export interface CreateCustomerRelationship {
    sourceCustomerId: number;
    targetCustomerId: number;
    relationshipTypeId: number;
    startDate?: string | Date;
    endDate?: string | Date;
    noOfShare?: number;
    note?: string;
}

export interface Lookup {
    id: number;
    name: string;
}

export interface ServiceMaster {
    id: number;
    name: string;
    description?: string;
}

export interface CustomerServicePortfolio {
    id: number;
    customerId: number;
    serviceId: number;
    serviceName?: string;
    amount?: number;
    unit?: string;
    internalNotes?: string;
    updateUserId?: number;
    updateUserName?: string;
    updateDateTime?: string | Date;
}

export interface Branch {
    id: number;
    customerId: number;
    branchName: string;
}

