type PagedDiamond = {
    id: string;
    shape: string;
    color: string;
    origin: string;
    certificationUrl: string;
    caratWeight: string;
    clarity: string;
    cut: string;
    price: number;
    quantity: number;
    warrantyPeriod: number;
    lastUpdate: string;
    status: string;
    pictures: Array<{
        id: string;
        urlPath: string;
    }>;
};