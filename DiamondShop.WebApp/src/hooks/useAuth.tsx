import { useState } from "react";
import useLocalStorage from "./useLocalStorage";
import { useQuery } from "@tanstack/react-query";
import { fetchWhoAmI } from "../services/auth_service";
import { AuthAccount } from "../types/account";

type Props = {
    authAccount: AuthAccount | null;
    setAuthAccount: (authAccount: AuthAccount) => void;
    accessToken: string;
    setAccessToken: (accessToken: string) => void;
    isTokenExpired: boolean;
    setIsTokenExpired: (isTokenExpired: boolean) => void;
    isLoading: boolean;
    isError: boolean;
};

const useAuth = (): Props => {
    const [accessToken, setAccessToken] = useLocalStorage<string>('accessToken', '');
    const [isTokenExpired, setIsTokenExpired] = useState(false);
    const [authAccount, setAuthAccount] = useState<AuthAccount | null>(null);

    const { isLoading, isError } = useQuery({
        queryKey: ['who-am-i'],
        queryFn: async () => {
            const response = await fetchWhoAmI(accessToken);
            if (response.ok && !authAccount) {
                const data = await response.json();
                setAuthAccount(data);
                setIsTokenExpired(false);
            } else {
                setIsTokenExpired(true);
            }
        },
        staleTime: Infinity,
    });

    return { authAccount, setAuthAccount, accessToken, setAccessToken, isTokenExpired, setIsTokenExpired, isLoading, isError };
};

export default useAuth;