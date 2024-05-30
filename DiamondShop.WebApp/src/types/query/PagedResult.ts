type PagedResult<T> = {
    totalCount: number;
    currentPage: number;
    pageSize: number;
    results: T[];
};