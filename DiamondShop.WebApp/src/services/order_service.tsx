import { AddToCartRequest } from "../types/addToCartRequest";
import { customFetch } from "./custom_fetch";

export const fetchAddToCart = async (accessToken: string, request: AddToCartRequest) => {
  console.log(`Sending request:`);
  console.log({ request });

  try {

    const response = await customFetch({
      endpointPath: '/orders/add-to-cart',
      options: {
        method: 'POST'
      },
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${accessToken}`
      },
      body: request
    });

    return response;

  } catch (error) {
    console.error(`Error occurred while adding to cart: ${error}`);
    throw new Error(`Error occurred while adding to cart: ${error}`);
  }
};

export const fetchCartInfo = async (accessToken: string) => {
  try {
    
    const response = await customFetch({
      endpointPath: '/orders/cart-info',
      options: {
        method: 'GET'
      },
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${accessToken}`
      }
    });

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    return response;

  } catch (error) {
    console.error("Error fetching who am I:", error);
    throw error;
  }
};