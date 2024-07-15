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
        const response = await fetch("https://localhost:7054/api/Orders/cart-info", {
          method: "GET",
          headers: {
            'Authorization': `Bearer ${accessToken}`,
            'accept': 'text/plain',
          },
        });
    
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
    
        const data = await response.text();
        
        return data;
      } catch (error) {
        console.error("Error fetching who am I:", error);
        throw error;
      }
};