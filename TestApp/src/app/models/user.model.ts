export class user {
    id: string;
    organizationlevelsId: number;
    username: string;
    roleCode: number;
    roleDescribtion: string;
    email: string;
    phone: string;
    managerid: string;
    password: string;
    salt: string;
    isTemporaryPassword: boolean;
    isActive: boolean;
    createDate: Date;
    lastUpdateDate: Date;
}