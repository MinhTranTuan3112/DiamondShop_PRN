// import React, { useContext, useState } from "react";
// import useLocalStorage from "../hooks/useLocalStorage";

// type AuthProviderProps = {
//     children: React.ReactNode;
// };


// type AuthContextType = {
//     accessToken: string | null;
//     setAccessToken: React.Dispatch<React.SetStateAction<string>>;
// };

// export const AuthContext = React.createContext<AuthContextType | null>(null);

// const AuthProvider = ({ children }: AuthProviderProps) => {
//     const [accessToken, setAccessToken] = useLocalStorage<string>("accessToken", '');

//     return (
//         <AuthContext.Provider value={{ theme, setTheme }}>
//             {children}
//         </AuthContext.Provider>
//     );
// };

// export default AuthProvider;

// export const useAuthContext = () => {
//     const context = useContext(AuthContext);
//     if (!context) {
//         throw new Error("useAuthContext must be used within a AuthProvider");
//     }
//     return context;
// };