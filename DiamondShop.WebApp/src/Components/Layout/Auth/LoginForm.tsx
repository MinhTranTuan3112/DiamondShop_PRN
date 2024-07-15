import { useState } from "react";
import "./LoginForm.css";
import { fetchLogin, fetchWhoAmI } from "../../../services/auth_service";
import useAuth from "../../../hooks/useAuth";
import { Link, useNavigate } from "react-router-dom";
import { MdOutlineMailOutline } from "react-icons/md";
import { CiLock } from "react-icons/ci";
import Favicon from "../../../assets/icons/icon.png";
import { AuthAccount } from "../../../types/account";

const LoginForm = () => {
  const [formState, setFormState] = useState({
    email: "",
    password: "",
  });

  const { setAccessToken, setExpirationDate, setAuthAccount } = useAuth();

  const navigate = useNavigate();

  const handleFormSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    try {
      const response = await fetchLogin(formState.email, formState.password);

      if (response.ok) {
        const data = await response.json();
        setAccessToken(data.accessToken);
        setExpirationDate(new Date(data.expireIn));

        try {
          const response = await fetchWhoAmI(data.accessToken);
          if (response.ok) {
            
            const authAccount: AuthAccount = await response.json();

            console.log("user response:", authAccount);

            if (authAccount) {
              setAuthAccount(authAccount);
              const userRole = authAccount.role;
              if (userRole === "Customer") {
                navigate("/");
              } else {
                navigate("/dashboard");
              }
            }
          }
        } catch (error) {
          console.error("Error fetching user info:", error);
        }
      } else {
        console.error("Login failed:", response.statusText);
      }
    } catch (error) {
      console.error("Error during login:", error);
    }
  };

  return (
    <div className="relative flex justify-center items-center p-2 rounded-2xl h-[410px]">
      <div className="flex flex-col items-center text-center p-12 bg-white rounded-2xl">
        <img
          src={Favicon}
          alt=""
          className="footer-icon"
          style={{ height: "70px", objectFit: "contain" }}
        />
        <h1 className="mt-8 mb-8 text-4xl font-medium">
          Welcome to MAPTH diamond
        </h1>
        <p className="mt-2 text-orange-600">Enter your account</p>
        <form className="w-full mt-8" onSubmit={handleFormSubmit} method="POST">
          <div className="flex flex-col gap-8">
            <div className="relative flex items-center h-12 mb-8">
              <input
                type="email"
                className="flex-1 h-full px-4 rounded-lg border border-gray-300 text-lg font-medium"
                name="email"
                placeholder="Email"
                id="email"
                value={formState.email}
                onChange={(e) =>
                  setFormState({ ...formState, email: e.target.value })
                }
                required
              />
              <MdOutlineMailOutline className="absolute right-4 text-2xl" />
            </div>
            <div className="relative flex items-center h-12 mb-8">
              <input
                type="password"
                className="flex-1 h-full px-4 rounded-lg border border-gray-300 text-lg font-medium"
                name="password"
                placeholder="Password"
                id="password"
                onChange={(e) =>
                  setFormState({ ...formState, password: e.target.value })
                }
                required
              />
              <CiLock className="absolute right-4 text-2xl" />
            </div>
          </div>
          <button
            type="submit"
            className="w-full h-11 mb-4 rounded-full border-2 border-gray-200 bg-[#FFC085] text-lg font-semibold text-gray-800 hover:bg-gray-300"
          >
            Login
          </button>
        </form>
        <div className="flex items-center">
          <span className="text-gray-600">You don't have an account?</span>
          <Link to="/register" className="ml-2 text-orange-600">
            Register
          </Link>
        </div>
      </div>
    </div>
  );
};

export default LoginForm;
