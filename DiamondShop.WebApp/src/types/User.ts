// types.ts
export interface Customer {
    id: string;
    fullname: string;
    address: string | null;
    phoneNumber: string;
    point: number;
  }
  
  export interface User {
    id: string;
    email: string;
    password: string;
    avatarUrl: string | null;
    timeStamp: string | null;
    role: string;
    status: string;
    customer: Customer;
  }
  