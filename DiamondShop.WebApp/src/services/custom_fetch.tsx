type FetchOptions = {
  method?: string;
};

type Props = {
  endpointPath: string;
  options?: FetchOptions;
  baseUrl?: string;
  headers?: Record<string, string>;
  body?: any;
};

export const customFetch = async ({
  endpointPath,
  options = {},
  baseUrl = "https://localhost:7054/api",
  headers = {},
  body,
}: Props): Promise<Response> => {
  const fullUrl = `${baseUrl}${endpointPath}`;

  const allHeaders = {
    "Content-Type": "application/json",
    ...headers,
  };

  const allOptions = {
    ...options,
    headers: allHeaders,
    body: JSON.stringify(body),
  };

  const response = await fetch(fullUrl, allOptions);
  return response;
};
