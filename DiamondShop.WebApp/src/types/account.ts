export type AuthAccount = {
    id: string;
    email: string;
    password: string;
    avatarUrl: string;
    timeStamp: string;
    role: string;
    status: string;
    customer: {
        id: string;
        fullname: string;
        address: string;
        phoneNumber: string;
        point: number;
    };
    stakeHolder: {
        id: string;
        fullname: string;
        address: string;
        phoneNumber: string;
        salary: number;
        dateHired: {
            year: number;
            month: number;
            day: number;
            dayOfWeek: string;
            dayOfYear: number;
            dayNumber: number;
        };
    };
};