export interface ReservationResult {
    customerName: string;
    customerSurname: string;
    customerEmail: string;
    tableName: string;
    reservationStartDate: Date;
    reservationEndDate: Date;
    guestCount: number;
}