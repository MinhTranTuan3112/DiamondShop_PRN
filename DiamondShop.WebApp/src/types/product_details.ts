type Category = {
    id: string;
    name: string;
    lastUpdate: Date;
    status: string;
};

type Picture = {
    id: string;
    urlPath: string;
};

type Diamond = {
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
    lastUpdate: Date;
    status: string;
    pictures: [],
};

type ProductPart = {
    id: string;
    isMain: boolean;
    productId: string;
    diamondId: string;
    diamond: Diamond;
};

type Product = {
    id: string;
    name: string;
    type: string;
    material: string;
    gender: boolean;
    price: number;
    point: number;
    quantity: number;
    warrantyPeriod: number;
    lastUpdate: Date;
    status: string;
    category: Category;
    pictures: Picture[];
    productParts: ProductPart[];
};