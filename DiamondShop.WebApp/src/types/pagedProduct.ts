type PagedProduct = {
    id: string;
    name: string;
    type: string;
    material: string;
    gender: boolean;
    price: number;
    point: number;
    quantity: number;
    warrantyPeriod: number;
    lastUpdate: string;
    status: string;
    categoryId: string;
    category: {
        id: string;
        name: string;
        lastUpdate: string;
        status: string;
    };
    pictures: Array<{
        id: string;
        urlPath: string;
    }>;
};