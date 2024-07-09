
import { customFetch } from "./custom_fetch";
export const listProduct = async (page: number, startPrice: number, endPrice: number) => {
  console.log('Call fetch products');
  const response = await fetch(`https://localhost:7054/api/products?pageNumber=${page}&startPrice=${startPrice}&endPrice=${endPrice}`);
  if (!response.ok) {
    throw new Error("Failed to fetch products");
  }
  return await response.json();



export const fetchProductDetails = async (id: string) => {
    const response = await customFetch({
        endpointPath: `/products/${id}`,
    });
    
    return response;
};
