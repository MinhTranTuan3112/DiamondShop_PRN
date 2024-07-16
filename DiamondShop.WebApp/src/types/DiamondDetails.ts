type Certificate = {
    id: string;
    reportNumber: string;
    origin: string;
    shape: string;
    color: string;
    clarity: string;
    cut: string;
    caratWeight: string;
    dateOfIssue: string; // ISO 8601 date format string
    status: string;
};

type DiamondDetails = {
    id: string;
    shape: string;
    color: string;
    origin: string;
    caratWeight: string;
    clarity: string;
    cut: string;
    price: number;
    quantity: number;
    warrantyPeriod: number;
    lastUpdate: string; // ISO 8601 date format string
    status: string;
    certificate: Certificate;
    pictures: Picture[];
    productParts: ProductPart[];
};
