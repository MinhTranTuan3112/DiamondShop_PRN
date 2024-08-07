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

export const fetchProductById = async (id: string) => {
  const response = await fetch(`${BASE_URL}/Products/${id}`);
  if (!response.ok) {
    throw new Error('Failed to fetch diamond data');
  }
  return await response.json();
};

const buildProductFormData = (product: Partial<Product>): FormData => {
  const formData = new FormData();
  formData.append("Gender", product.gender || "");
  formData.append("Material", product.material || "");
  formData.append("Price", product.price ? product.price.toString() : "");
  formData.append("Quantity", product.quantity ? product.quantity.toString() : "");
  formData.append("Name", product.name || "");
  formData.append("Point", product.point ? product.point.toString() : "");
  formData.append("CategoryId", product.category?.id || "");
  formData.append("Type", product.type || "");
  formData.append("WarrantyPeriod", product.warrantyPeriod || "");

  return formData;
};

export const updateProduct = async (product: Partial<Product>) => {
  const formData = buildProductFormData(product);

  const response = await fetch(`${BASE_URL}/Products/${product.id}`, {
    method: 'PUT',
    headers: {
      'accept': '*/*',
    },
    body: formData,
  });

  if (!response.ok) {
    throw new Error('Failed to update product');
  }

  return await response;
};

export const createProduct = async (product: Partial<Product>) => {
  const formData = buildProductFormData(product);

  const response = await fetch(`${BASE_URL}/Products`, {
    method: 'POST',
    headers: {
      'accept': '*/*',
    },
    body: formData,
  });

  if (!response.ok) {
    throw new Error('Failed to create product');
  }

  return await response;
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

// Fetch Diamond

export const fetchDiamonds = async (
  search: string,
  page: number,
  rowsPerPage: number,
  sortColumn: string,
  orderByDesc: boolean
) => {
  const response = await fetch(
    `${BASE_URL}/Diamonds?QueryDto.PageNumber=${page}.PageSize=${rowsPerPage}.SortBy=${sortColumn}.OrderByDesc=${orderByDesc}&Name=${search}`
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

const buildDiamondFormData = (diamond: Partial<Diamond>): FormData => {
  const formData = new FormData();
  formData.append("Shape", diamond.shape || "");
  formData.append("Color", diamond.color || "");
  formData.append("Origin", diamond.origin || "");
  formData.append("CertificateId", diamond.certificationUrl || "");
  formData.append("CaratWeight", diamond.caratWeight || "");
  formData.append("Clarity", diamond.clarity || "");
  formData.append("Cut", diamond.cut || "");
  formData.append("Price", diamond.price ? diamond.price.toString() : "");
  formData.append("Quantity", diamond.quantity ? diamond.quantity.toString() : "");
  formData.append("WarrantyPeriod", diamond.warrantyPeriod ? diamond.warrantyPeriod.toString() : "");

  return formData;
};

export const updateDiamond = async (diamond: Partial<Diamond>) => {
  const formData = buildDiamondFormData(diamond);

  const response = await fetch(`${BASE_URL}/Diamonds/${diamond.id}`, {
    method: 'PUT',
    headers: {
      'accept': '*/*',
    },
    body: formData,
  });

  if (!response.ok) {
    throw new Error('Failed to update diamond');
  }

  return await response;
};

export const createDiamond = async (diamond: Partial<Diamond>) => {
  const formData = buildDiamondFormData(diamond);

  const response = await fetch(`${BASE_URL}/Diamonds`, {
    method: 'POST',
    headers: {
      'accept': '*/*',
    },
    body: formData,
  });

  if (!response.ok) {
    throw new Error('Failed to create diamond');
  }

  return await response;
};

export const createCertificate = async (certificate: Partial<Certificate>) => {
  const response = await fetch(`${BASE_URL}/Certificates`, {
    method: 'POST',
    headers: {
      'accept': 'text/plain',
      'Content-Type': 'application/json-patch+json',
    },
    body: JSON.stringify(certificate),
  });

  if (!response.ok) {
    throw new Error('Failed to create certificate');
  }

  return await response.json();
};


// Fetch Dashboard
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
  OrderByCode = (OrderByCode === undefined) ? true : OrderByCode;
  IsDescendingCode = (IsDescendingCode === undefined) ? true : IsDescendingCode;
  IsDescendingTime = (IsDescendingTime === undefined) ? true : IsDescendingTime;

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

export const deleteOrder = async (orderId: string, accessToken?: string) => {
  const response = await fetch(`${BASE_URL}/Orders/${orderId}`, {
    method: 'DELETE',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${accessToken}`
    },
  });
  if (response.status === 201) {
    return;
  } else {
    throw new Error(`HTTP error! Status: ${response.status}\nMessage: ${response.text()}`);
  }
};


export const fetchPromotions = async (
  name: string,
  pageNumber: number,
  pageSize: number,
): Promise<{ data: any[]; totalCount: number }> => {
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


export const createPromotion = async (promotion) => {
  const query = new URLSearchParams({
    Name: promotion.name || "",
    Description: promotion.description || "",
    ExpiredDate: promotion.expiredDate || "",
    DiscountPercent: promotion.discountPercent?.toString() || "0",
    Status: promotion.status || "",
  }).toString();

  const response = await fetch(`${BASE_URL}/Promotions?${query}`, {
    method: 'POST',
    headers: {
      'accept': '*/*',
    },
  });

  if (!response.ok) {
    throw new Error('Failed to create promotion');
  }

  return await response.json();
};

export const updatePromotion = async (promotion) => {
  if (!promotion.id) {
    throw new Error('Promotion ID is required for updating');
  }

  const query = new URLSearchParams({
    Id: promotion.id,
    Name: promotion.name || "",
    Description: promotion.description || "",
    ExpiredDate: promotion.expiredDate || "",
    DiscountPercent: promotion.discountPercent?.toString() || "0",
    Status: promotion.status || "",
  }).toString();

  const response = await fetch(`${BASE_URL}/Promotions?${query}`, {
    method: 'PUT',
    headers: {
      'accept': '*/*',
    },
  });

  if (!response.ok) {
    throw new Error('Failed to update promotion');
  }

  return await response.json();
};


export const deletePromotion = async (promotionId: string) => {
  const response = await fetch(`${BASE_URL}/Promotions?id=${promotionId}`, {
    method: "DELETE",
  });
  if (!response.ok) {
    throw new Error(`HTTP error! Status: ${response.status}`);
  }
};


// Account

export const fetchAccounts = async (
  search: string,
  page: number,
  rowsPerPage: number,
  sortColumn: string,
  orderByDesc: boolean
) => {
  const response = await fetch(
    `${BASE_URL}/Accounts?PageNumber=${page}&PageSize=${rowsPerPage}&SortBy=${sortColumn}&OrderByDesc=${orderByDesc}&email=${search}`
  );
  if (!response.ok) {
    throw new Error("Failed to fetch accounts");
  }
  return response.json();
};

export const fetchAccountById = async (id: string) => {
  const response = await fetch(`${BASE_URL}/Accounts/${id}`);
  if (!response.ok) {
    throw new Error('Failed to fetch account data');
  }
  return await response.json();
};



export const createAccount = async (account) => {
  try {
    const response = await fetch(`${BASE_URL}/Auth/create-account`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Accept': '*/*', 
      },
      body: JSON.stringify(account), 
    });

    if (!response.ok) {
      throw new Error('Failed to create account');
    }

    return await response.json();
  } catch (error) {
    console.error('Error creating account:', error);
    throw error; 
  }
};

export const deleteAccount = async (accountId: string) => {
  const response = await fetch(`${BASE_URL}/Accounts/${accountId}/Deleted`, {
    method: 'PUT',
  });

  if (!response.ok) {
    throw new Error('Failed to delete account');
  }
};
