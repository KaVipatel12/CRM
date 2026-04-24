export interface Job {
    id: number;
    caption: string;
    jobTypeId: number;
    jobTypeName?: string;
    customerId?: number | null;
    customerName?: string;
    customerCode?: string;
    customerEmail?: string;
    customerPhone?: string;
    ownerId?: number;
    staffName?: string;
    responsibleId?: number;
    responsibleName?: string;
    originalResponsibleId?: number;
    temporaryAssignmentUntil?: string;
    currentStage?: number;
    statusName?: string;
    statusColor?: string;
    statusIcon?: string;
    priority: number;
    assignDate?: string;
    deadline?: string;
    startDate?: string;
    daysLeft?: number;
    isRecurring: boolean;
    isInternal?: boolean;
    period?: number;
    recurringMode?: string;
    parentJobId?: number;
    targetEndDate?: string;
    dueDateDays?: number;
    dueDateBasis?: string;
    createdUserId?: number;
    createdUserName?: string;
    createdDateTime?: string;
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

export interface JobTypeStatusMapping {
    id: number;
    jobTypeId: number;
    jobStatusMasterId: number;
    displayOrder?: number;
}

export interface JobLookups {
    jobTypes: any[];
    jobStatusMasters: any[];
    jobTypeStatusMappings: JobTypeStatusMapping[];
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
    createdUserId?: number;
    customerId?: number;
    isActive?: boolean;
    isRecurring?: boolean;
    isInternal?: boolean;
    deadlineFrom?: string;
    deadlineTo?: string;
    pageNumber: number;
    pageSize: number;
    orderBy?: string;
    orderDirection?: 'asc' | 'desc';
}

export interface JobPagedResponse {
    items: Job[];
    totalCount: number;
    pageNumber: number;
    pageSize: number;
}

export interface ChartDataPoint {
    label: string;
    value: number;
}

export interface JobStatistics {
    totalActive: number;
    active: number;
    onHold: number;
    overdue: number;
    createdByMe: number;
    ownedByMe: number;
    highPriority: number;
    temporaryTasks: number;
    todoLater: number;
    completed: number;
    jobsByStage: ChartDataPoint[];
    jobsByType: ChartDataPoint[];
}
