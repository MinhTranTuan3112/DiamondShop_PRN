type OrderCartInfo = {
    id: string;
    code: string;
    orderDate: string;
    total: number;
    payMethod: string;
    shipDate: string;
    shipAddress: string;
    note: string;
    status: string;
    customerId: string;
    orderDetails: OrderDetail[];
};

type OrderDetail = {
    id: string;
    complexProduction: boolean;
    quantity: number;
    ringSize: string;
    sumSizePrice: number;
    subTotal: number;
    status: string;
    orderId: string;
    productId: string;
    diamondId: string;
    diamond: Diamond;
    product: Product;
};

// type Diamond = {
//     id: string;
//     shape: string;
//     color: string;
//     origin: string;
//     certificationUrl: string;
//     caratWeight: string;
//     clarity: string;
//     cut: string;
//     price: number;
//     quantity: number;
//     warrantyPeriod: number;
//     lastUpdate: string;
//     status: string;
// };

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
    lastUpdate: string;
    status: string;
    categoryId: string;
    category: Category;
    pictures: Picture[];
};

// type Category = {
//     id: string;
//     name: string;
//     lastUpdate: string;
//     status: string;
// };

// type Picture = {
//     id: string;
//     urlPath: string;
// };