export interface CallLog {
    id: number;
    receiveDate: string;
    receiverId: number | null;
    receiverName: string | null;
    forWhomId: number | null;
    forWhomName: string | null;
    name: string;
    email: string;
    mobileNo: string;
    companyName: string;
    purposeId: number | null;
    purposeName: string | null;
    statusId: number | null;
    statusName: string | null;
    statusColor: string | null;
    remark: string;
    isClosed: boolean;
    isChecked: boolean;
    otherPurpose: string;
    natureOfBusiness: string;
    otherNatureOfBusiness: string;
    hearAboutUs: string;
    otherHearAboutUs: string;
    updateDateTime: string;
    commentCount: number;
}

export interface CallLogPagedResponse {
    items: CallLog[];
    totalCount: number;
    pageNumber: number;
    pageSize: number;
}

export interface Purpose {
    id: number;
    purposeName: string;
}

export interface CallLogComment {
    id: number;
    callLogId: number;
    comment: string;
    createdUserId: number;
    createdDateTime: string;
    updateUserId: number;
    updateUserName: string;
    updateDateTime: string;
}
