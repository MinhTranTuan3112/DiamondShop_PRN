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
  search: string,
  page: number,
  rowsPerPage: number,
  sortColumn?: string,
  orderByDesc?: boolean
): Promise<{ results: any[]; totalCount: number }> => {
  let url = `${BASE_URL}/Orders?pageNumber=${page}&pageSize=${rowsPerPage}`;

  if (search.trim() !== "") {
    url += `&search=${search}`;
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
): Promise<{ results: Promotion[]; totalCount: number }> => {
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

// const buildPromotionFormData = (promotion: Partial<Promotion>): FormData => {
//   const formData = new FormData();
//   formData.append("Name", promotion.name || "");
//   formData.append("Description", promotion.description || "");
//   formData.append("ExpiredDate", promotion.expiredDate || "");
//   formData.append("DiscountPercent", promotion.discountPercent ? promotion.discountPercent.toString() : "");
//   formData.append("Status", promotion.status || "");

//   return formData;
// };

// export const createPromotion = async (promotion: Partial<Promotion>) => {
//   const formData = buildPromotionFormData(promotion);

//   const response = await fetch(`${BASE_URL}/Promotions`, {
//     method: 'POST',
//     headers: {
//       'accept': '*/*',
//     },
//     body: formData,
//   });

//   if (!response.ok) {
//     throw new Error('Failed to create promotion');
//   }

//   return await response.json();
// };

// export const updatePromotion = async (promotion: Partial<Promotion>) => {
//   if (!promotion.id) {
//     throw new Error('Promotion ID is required for updating');
//   }
  
//   const formData = buildPromotionFormData(promotion);

//   const response = await fetch(`${BASE_URL}/Promotions/${promotion.id}`, {
//     method: 'PUT',
//     headers: {
//       'accept': '*/*',
//     },
//     body: formData,
//   });

//   if (!response.ok) {
//     throw new Error('Failed to update promotion');
//   }

//   return await response.json();
// };