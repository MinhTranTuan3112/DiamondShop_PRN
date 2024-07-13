import { useEffect, useState } from "react";
import useLocalStorage from "./useLocalStorage";
import { fetchWhoAmI } from "../services/auth_service";
import { AuthAccount } from "../types/account";

type Props = {
  authAccount: AuthAccount | null;
  setAuthAccount: (authAccount: AuthAccount | null) => void;
  accessToken: string;
  setAccessToken: (accessToken: string) => void;
  expirationDate: Date | null;
  setExpirationDate: (expirationDate: Date) => void;
  isTokenExpired: boolean;
  setIsTokenExpired: (isTokenExpired: boolean) => void;
  logout: () => void;
};

const useAuth = (): Props => {
  const [accessToken, setAccessToken] = useLocalStorage<string>(
    "accessToken",
    ""
  );

  const [isTokenExpired, setIsTokenExpired] = useState(false);
  const [authAccount, setAuthAccount] = useState<AuthAccount | null>(null);
  const [expirationDate, setExpirationDate] = useState<Date | null>(null);

  // const { isLoading, isError } = useQuery({
  //   queryKey: ["who-am-i"],
  //   queryFn: async () => {
  //     console.log("fetching who am i");
  //     const response = await fetchWhoAmI(accessToken);

  //     if (response.ok && !authAccount) {
  //       const data = await response.json();
  //       setAuthAccount(data);
  //       setIsTokenExpired(false);
  //       return data;
  //     } else {
  //       setIsTokenExpired(true);
  //       return null;
  //     }
  //   },
  //   staleTime: Infinity,
  //   retry: false,
  // });

  useEffect(() => { // Step 2: Add useEffect hook
    const fetchAccountDetails = async () => {
      if (!authAccount && accessToken) { // Step 4: Check conditions
        try {
          console.log(`Call fetch who am i`);
          const response = await fetchWhoAmI(accessToken); // Fetch user details
          if (response.status === 200) {
            const accountDetails = await response.json(); // Parse JSON
            setAuthAccount(accountDetails); // Update authAccount
          }
          // Optionally update expirationDate here if the response includes it
        } catch (error) {
          console.error("Failed to fetch account details", error);
          // Handle error (e.g., by logging out the user or showing an error message)
        }
      }
    };

    fetchAccountDetails(); // Call the async function
  }, [accessToken, authAccount]); // Step 3: Dependency array

  const logout = () => {
    setAccessToken("");
    setAuthAccount(null);
    setIsTokenExpired(false);
    setExpirationDate(null);
    window.location.href = "/login"; // Redirect to login page
  };

  return {
    authAccount,
    setAuthAccount,
    accessToken,
    setAccessToken,
    expirationDate,
    setExpirationDate,
    isTokenExpired,
    setIsTokenExpired,
    logout,
  };
};

export default useAuth;
