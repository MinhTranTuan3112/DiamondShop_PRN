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

export const deleteObject = async (object: string, objectId: string) => {
  const response = await fetch(`${BASE_URL}/${object}/${objectId}/2`, {
    method: 'PUT'
  });
  if (response.status === 204) {
    return;
  } else {
    throw new Error(`HTTP error! Status: ${response.status}`);
  }
};

export const fetchDiamonds = async (
  search: string,
  page: number,
  rowsPerPage: number,
  sortColumn: string,
  orderByDesc: boolean
) => {
  const response = await fetch(
    `${BASE_URL}/Diamonds?QueryDto.PageNumber=${page}&QueryDto.PageSize=${rowsPerPage}&QueryDto.SortBy=${sortColumn}&QueryDto.OrderByDesc=${orderByDesc}&Name=${search}`
  );
  if (!response.ok) {
    throw new Error("Failed to fetch diamonds");
  }
  return response.json();
};

export const fetchDiamondById = async (id: string) => {
  const response = await fetch(`${BASE_URL}/Diamonds/${id}`);
  if (!response.ok) {
    throw new Error('Failed to fetch diamond data');
  }
  return await response.json();
};

export const updateDiamond = async (id: string, diamondData: FormData) => {
  try {
    const response = await fetch(`${BASE_URL}/Diamonds/${id}`, {
      method: 'PUT',
      body: diamondData,
    });

    if (response.status !== 204) {
      throw new Error('Failed to update diamond');
    }

    return await response.json();
  } catch (error) {
    throw new Error('Failed to update diamond');
  }
};

// Mock API Client
export interface DashboardStats {
  numberOfDiamonds: number;
  numberOfProducts: number;
  revenue: number;
  profit: number;
}

export const fetchDashboardStats = async (): Promise<DashboardStats> => {
  const response = await fetch("https://localhost:7054/api/Orders/dashboard-stats");
  const data = await response.json();
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve({
        numberOfDiamonds: data.numberOfDiamonds,
        numberOfProducts: data.numberOfProducts,
        revenue: data.totalRevenue,
        profit: data.profit,
      });
    }, 1000); // 1 second delay
  });
};

export const fetchDataForMonthLineChat = async (month: number) => {
  const response = await fetch(
    `https://localhost:7054/api/Orders/statistic?month=${month}`
  );
  const data = await response.json();
  return data;
};

export const fetchCategories = async () => {
  const response = await fetch(`${BASE_URL}/Categories`);
  const data = response.json();
  return data;
};

export const fetchOrders = async (
  Size: number, Page: number,
  Code?: string, PayMethod?: string, ShipAddress?: string, Note?: string, Status?: string,
  OrderByCode?: boolean, IsDescendingCode?: boolean, IsDescendingTime?: boolean,
  accessToken?: string):

  Promise<{ results: any[]; totalCount: number }> => {
  let url = `${BASE_URL}/Orders/list`;

  Size = (Size === 0) ? 5 : Size;
  Page = (Page === 0) ? 1 : Page;
  OrderByCode = (OrderByCode === undefined) ? true : OrderByCode;
  IsDescendingCode = (IsDescendingCode === undefined) ? true : IsDescendingCode;
  IsDescendingTime = (IsDescendingTime === undefined) ? true : IsDescendingTime;

  console.log("page before to server:" +Page);
  const response = await fetch(url, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${accessToken}`
    },
    body: JSON.stringify({
      Size,
      Page,
      Code,
      PayMethod,
      ShipAddress,
      Note,
      Status,
      OrderByCode,
      IsDescendingCode,
      IsDescendingTime,
    })
  });

  if (!response.ok) {
    throw new Error(`HTTP error! Status: ${response.status}\nMessage: ${response.text()}`);
  }
  return await response.json();
};

export const deleteOrder = async (orderId: string) => {
  const response = await fetch(`${BASE_URL}/Orders/${orderId}`, {
    method: 'DELETE'
  });
  if (response.status === 204) {
    return;
  } else {
    throw new Error(`HTTP error! Status: ${response.status}`);
  }
};


export const fetchPromotions = async (
  name: string,
  pageNumber: number,
  pageSize: number,
): Promise<{ results: Promotion[]; totalPage: number }> => {
  let url = `${BASE_URL}/Promotions?pageIndex=${pageNumber}&pageSize=${pageSize}`;

  if (name.trim() !== "") {
    url += `&name=${name}`;
  }

  const response = await fetch(url);
  if (!response.ok) {
    throw new Error(`HTTP error! Status: ${response.status}`);
  }

  const data = await response.json();
  return data;
};

export const deletePromotion = async (promotionId: string) => {
  const response = await fetch(`${BASE_URL}/Promotions?id=${promotionId}`, {
    method: "DELETE",
  });
  if (!response.ok) {
    throw new Error(`HTTP error! Status: ${response.status}`);
  }
};