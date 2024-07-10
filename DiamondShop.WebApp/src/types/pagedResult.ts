type PagedResult<T> = {
    totalCount: number;
    currentPage: number;
    pageSize: number;
    totalPages: number;
    results: T[];
};