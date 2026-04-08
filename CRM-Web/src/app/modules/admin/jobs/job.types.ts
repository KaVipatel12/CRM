export interface Job {
    id: number;
    caption: string;
    jobTypeId: number;
    jobTypeName?: string;
    customerId?: number | null;
    customerName?: string;
    ownerId?: number;
    staffName?: string;
    responsibleId?: number;
    responsibleName?: string;
    currentStage?: number;
    statusName?: string;
    priority: number;
    deadline?: string;
    startDate?: string;
    isRecurring: boolean;
    isInternal?: boolean;
    period?: number;
    targetEndDate?: string;
    dueDateDays?: number;
    dueDateBasis?: string;
    tasks?: JobTask[];
    comments?: JobComment[];
    history?: JobHistory[];
}

export interface JobTask {
    id: number;
    jobId: number;
    description: string;
    isCompleted: boolean;
    completedDate?: string;
    sequence: number;
}

export interface JobLookups {
    jobTypes: any[];
    jobStatusMasters: any[];
    staff: any[];
    customers: {id: number, name: string}[];
}

export interface JobComment {
    id: number;
    jobId: number;
    userId: number;
    userName?: string;
    text: string;
    createdAt: string;
}

export interface JobHistory {
    id: number;
    jobId: number;
    event: string;
    userId: number;
    userName?: string;
    timestamp: string;
}

export interface JobFilter {
    searchString?: string;
    statusId?: number;
    priority?: number;
    jobTypeId?: number;
    ownerId?: number;
    responsibleId?: number;
    customerId?: number;
    isActive?: boolean;
    isRecurring?: boolean;
    isInternal?: boolean;
    pageNumber: number;
    pageSize: number;
    orderBy?: string;
}

export interface JobPagedResponse {
    items: Job[];
    totalCount: number;
    pageNumber: number;
    pageSize: number;
}

export interface JobStatistics {
    totalActive: number;
    active: number;
    onHold: number;
    overdue: number;
    todoLater: number;
    completed: number;
}
