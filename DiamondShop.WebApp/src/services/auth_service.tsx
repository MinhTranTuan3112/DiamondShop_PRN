import { customFetch } from "./custom_fetch";

export const fetchLogin = async (email: string, password: string) => {

    const response = await customFetch({
        options: { method: 'POST' },
        endpointPath: '/auth/login', body: {
            email: email,
            password: password
        }
    });

    return response;
};

export const fetchWhoAmI = async (accessToken: string) => {
    const response = await customFetch({
        options: { method: 'GET' },
        endpointPath: '/auth/who-am-i',
        headers: {
            'Authorization': `Bearer ${accessToken}`
        }
    });

    return response;
};


