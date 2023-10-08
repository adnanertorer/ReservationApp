import { Customer } from "./customer";
import { Table } from "./table";

export interface CustomerReservation {
    customerDto: Customer;
    tableDto: Table;
    guestCount: number;
    reservationStartDate?: Date;
    reservationEndDate?: Date;
    tableId: number;
}