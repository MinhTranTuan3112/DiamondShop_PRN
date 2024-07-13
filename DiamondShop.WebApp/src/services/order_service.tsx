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

    } catch (error) {
        console.error(`Error occurred while fetching cart info: ${error}`);
    }
};