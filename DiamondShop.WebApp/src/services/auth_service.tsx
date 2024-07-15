import { customFetch } from "./custom_fetch";

export const fetchLogin = async (email: string, password: string) => {
  const response = await customFetch({
    options: { method: "POST" },
    endpointPath: "/auth/login",
    body: {
      email: email,
      password: password,
    },
  });

  return response;
};

export const fetchRegister = async (
  email: string,
  fullname: string,
  password: string
) => {
  const response = await customFetch({
    options: { method: "POST" },
    endpointPath: "/auth/register",
    body: {
      email: email,
      fullname: fullname,
      password: password,
    },
  });

  return response;
};

export const fetchWhoAmI = async (accessToken: string) => {
  try {
    const response = await customFetch({
      endpointPath: '/auth/who-am-i',
      options: {
        method: 'GET'
      },
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${accessToken}`
      }
    });

    return response;
    
  } catch (error) {
    console.error("Error fetching who am I:", error);
    throw error;
  }
};


