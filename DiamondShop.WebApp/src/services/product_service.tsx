
import { customFetch } from "./custom_fetch";
export const listProduct = async (page: number, startPrice: number, endPrice: number) => {
  console.log('Call fetch products');
  const response = await customFetch({
    endpointPath:
      `/products?pageNumber=${page}&startPrice=${startPrice}&endPrice=${endPrice}`
  });
  if (!response.ok) {
    throw new Error("Failed to fetch products");
  }
  return await response.json();
}

export const fetchProductDetails = async (id: string) => {
  const response = await customFetch({
    endpointPath: `/products/${id}`,
  });

  return response;
};

export const fetchPagedProducts = async (pageNumber: number = 1, pageSize: number = 10,
  sortColumn: string = "id", orderByDesc: boolean = false,
  startPrice: number | null = null,
  endPrice: number | null = null,
  name: string = '',
  types: string[] = []) => {
    
  try {
    let url = `/products?pageNumber=${pageNumber}&pageSize=${pageSize}&sortColumn=${sortColumn}&orderByDesc=${orderByDesc}`;

    if (name && name != '') {
      url += `&name=${name}`;
    }

    if (startPrice) {
      url += `&startPrice=${startPrice}`;
    }

    if (endPrice) {
      url += `&endPrice=${endPrice}`;
    }

    if (types && types.length > 0) {
      types.forEach(type => {
        url += `&types=${type}`;
      });
    }

    console.log(`Fetching paged products from: ${url}`);

    const response = await customFetch({
      endpointPath: url
    });

    const data = await response.json();
    console.log(`Paged product data:`);
    console.log({ data });

    return data;

  } catch (error) {
    console.error(`Failed to fetch paged products: ${error}`);
    return null;
  }
}

export const fetchProductTypes = async () => {
  const response = await customFetch({
    endpointPath: '/products/types',
  });

  return await response.json();
};