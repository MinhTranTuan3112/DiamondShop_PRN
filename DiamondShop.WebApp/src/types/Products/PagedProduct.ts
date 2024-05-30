type PagedProduct = {
    id: string;
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
  