import { CustomerReservation } from "./customer-reservation";

export interface CreateCustomerCommand {
    customerReservation:CustomerReservation;
}
