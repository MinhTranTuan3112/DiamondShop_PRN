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
    const response = await fetch("https://localhost:7054/api/Auth/who-am-i", {
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


