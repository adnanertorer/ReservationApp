import { ErrorItemModel } from "./error-item-model";

export interface ErrorModel {
    type: string;
    title: string;
    status: number;
    detail: string;
    instance: string;
    Errors?: ErrorItemModel[];
}
