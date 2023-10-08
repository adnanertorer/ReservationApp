export class GenericBaseResponse<T> {
    constructor() {
        this.errors = [];
    }
    dynamicClass!: T;
    success!: boolean;
    message!: string;
    clientMessage!: string;
    time?: number;
    errors: ApiError[];
    getErrorsText(): string {
        return this.errors.map(e => e.text).join(' ');
    }
    hasErrors(): boolean {
        return this.errors.length > 0;
    }
}

export class ApiError { code!: ErrorCode; text!: string; }

export enum ErrorCode {
    UnknownError = 1,
    OrderIsOutdated = 2,
    LoginError = 3,
    ServerError = 4,
}
