export interface CustomerView {
    custid: number;
    companyname: string;
    lastOrderDate?: Date;
    nextPredictedOrder?: Date;
}