export interface Job {
    id: number;
    caption: string;
    jobTypeId: number;
    jobTypeName?: string;
    customerId: number;
    customerName?: string;
    ownerId?: number;
    staffName?: string;
    currentStage?: number;
    statusName?: string;
    priority: number;
    deadline?: string;
    startDate?: string;
    isRecurring: boolean;
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
    staffId?: number;
    customerId?: number;
    currentPage: number;
    pageSize: number;
}
