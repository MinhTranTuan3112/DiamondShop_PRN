type QueryPagedProductRequest = {
    pageNumber?: number;
    pageSize?: number;
    sortColumn?: string;
    orderByDesc?: boolean;
    startPrice?: number | null;
    endPrice?: number | null;
    name?: string;
    categoryIds?: number[];
    material?: string;
    diamondIds?: number[];
};