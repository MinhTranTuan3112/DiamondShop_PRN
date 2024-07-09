// APIClient.ts
  const BASE_URL = "https://localhost:7054/api";
  export const fetchProducts = async (
    name: string,
    pageNumber: number,
    pageSize: number,
    sortColumn?: string,
    orderByDesc?: boolean
  ): Promise<{ results: any[]; totalCount: number }> => {
    let url = `${BASE_URL}/Products?pageNumber=${pageNumber}&pageSize=${pageSize}`;
  
    if (name.trim() !== "") {
      url += `&name=${name}`;
    }
  
    if (sortColumn) {
      url += `&sortColumn=${sortColumn}&orderByDesc=${orderByDesc ? "true" : "false"}`;
    }
  
    const response = await fetch(url);
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
  
    const data = await response.json();
    return data;
  };

  export const fetchDiamonds = async (search: string, page: number, rowsPerPage: number, sortColumn: string, orderByDesc: boolean) => {
    const response = await fetch(
      `${BASE_URL}/Diamonds?QueryDto.PageNumber=${page}&QueryDto.PageSize=${rowsPerPage}&QueryDto.SortBy=${sortColumn}&QueryDto.OrderByDesc=${orderByDesc}&Name=${search}`
    );
    if (!response.ok) {
      throw new Error("Failed to fetch diamonds");
    }
    return response.json();
  };

// Mock API Client
export interface DashboardStats {
  numberOfDiamonds: number;
  numberOfProducts: number;
  revenue: number;
  profit: number;
}

export const fetchDashboardStats = async (): Promise<DashboardStats> => {
  // Simulating a delay for fetching data
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve({
        numberOfDiamonds: 150,
        numberOfProducts: 150,
        revenue: 250000,
        profit: 80000,
      });
    }, 1000); // 1 second delay
  });
};