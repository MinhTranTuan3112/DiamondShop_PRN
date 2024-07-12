import { useState } from "react";
import useLocalStorage from "./useLocalStorage";
import { useQuery } from "@tanstack/react-query";
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
  isLoading: boolean;
  isError: boolean;
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

  const { isLoading, isError } = useQuery({
    queryKey: ["who-am-i"],
    queryFn: async () => {
      console.log("fetching who am i");
      const response = await fetchWhoAmI(accessToken);

      if (response.ok && !authAccount) {
        const data = await response.json();
        setAuthAccount(data);
        setIsTokenExpired(false);
        return data;
      } else {
        setIsTokenExpired(true);
        return null;
      }
    },
    staleTime: Infinity,
    retry: false,
  });

  const logout = () => {
    setAccessToken("");
    setAuthAccount(null);
    setIsTokenExpired(false);
    setExpirationDate(null);
    window.location.href = "/login";
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
    isLoading,
    isError,
    logout,
  };
};

export default useAuth;
