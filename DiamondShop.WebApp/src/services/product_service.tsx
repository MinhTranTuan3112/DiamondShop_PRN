import { customFetch } from "./custom_fetch";


export const fetchProductDetails = async (id: string) => {
    const response = await customFetch({
        endpointPath: `/products/${id}`,
    });
    
    return response;
};
