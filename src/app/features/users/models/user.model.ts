export interface User {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
}

export interface CreateUserRequest {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
}

export interface UpdateUserRequest {
    userId: string;
    firstName: string;
    lastName: string;
    email: string;
}