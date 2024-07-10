import { useState } from "react";
import "./LoginForm.css";
import { fetchLogin } from "../../../services/auth_service";
import useAuth from "../../../hooks/useAuth";

const LoginForm = () => {
  const [formState, setFormState] = useState({
    email: "",
    password: "",
  });

  const { setAccessToken, setExpirationDate } = useAuth();

  const handleFormSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const response = await fetchLogin(formState.email, formState.password);

    if (response.ok) {
      const data = await response.json();
      console.log(data);
      setAccessToken(data.accessToken);
      setExpirationDate(new Date(data.expireIn));
    }
  };

  return (
    <>
      <div className="flex justify-center mt-5">
        <form
          action=""
          className="w-[40%] p-5 shadow-lg rounded-lg"
          onSubmit={handleFormSubmit}
          method="POST"
        >
          <h1 className="text-4xl font-bold text-center mb-10">Đăng nhập</h1>
          <div className="w-[52%] inline-center">
            <div className="relative mb-14">
              <input
                type="email"
                className="border border-black p-2 rounded-md w-full pt-6 pb-2"
                name="email"
                placeholder=" "
                id="email"
                value={formState.email}
                onChange={(e) =>
                  setFormState({ ...formState, email: e.target.value })
                }
                required
              />
              <label
                htmlFor="email"
                className="absolute top-1/2 left-0 px-2 text-gray-500 transition-all duration-200 transform -translate-y-1/2 scale-90 origin-left 
        pointer-events-none select-none"
              >
                Email
              </label>
            </div>

            <div className="relative">
              <input
                type="password"
                className="border border-black p-2 rounded-md w-full pt-6 pb-2"
                name="password"
                placeholder=" "
                id="password"
                onChange={(e) =>
                  setFormState({ ...formState, password: e.target.value })
                }
                required
              />
              <label
                htmlFor="password"
                className="absolute top-1/2 left-0 px-2 text-gray-500 transition-all duration-200 transform -translate-y-1/2 scale-90 origin-left 
        pointer-events-none select-none"
              >
                Mật khẩu
              </label>
            </div>
            <button
              type="submit"
              className="login_btn border border-solid border-slate-600 text-black p-4 rounded-md inline-center mt-6
transition duration-300 ease-in-out 
                        "
            >
              Đăng nhập
            </button>
          </div>
        </form>
      </div>
    </>
  );
};

export default LoginForm;
