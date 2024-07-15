import { useState } from "react";
import { fetchRegister } from "../../../services/auth_service"; // Assuming you have a service for registration
import { Link, useNavigate } from "react-router-dom";
import { MdOutlineMailOutline } from "react-icons/md";
import { CiLock } from "react-icons/ci";
import { CiUser } from "react-icons/ci";
import Favicon from "../../../assets/icons/icon.png";

const RegisterForm = () => {
  const [formState, setFormState] = useState({
    email: "",
    fullname: "",
    password: "",
    repassword: "",
  });

  const navigate = useNavigate();

  const handleFormSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (formState.password !== formState.repassword) {
      alert("Passwords do not match.");
      return;
    }

    const response = await fetchRegister(
      formState.email,
      formState.fullname,
      formState.password
    );

    if (response.ok) {
      navigate("/login");
    } else {
      alert("Registration failed. Please try again.");
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
        <p className="mt-2 text-orange-600">Create your account</p>
        <form className="w-full mt-8" onSubmit={handleFormSubmit} method="POST">
          <div className="flex flex-col gap-8">
            <div className="relative flex items-center h-12 mb-8">
              <input
                type="text"
                className="flex-1 h-full px-4 rounded-lg border border-gray-300 text-lg font-medium"
                name="fullname"
                placeholder="Full Name"
                id="fullname"
                value={formState.fullname}
                onChange={(e) =>
                  setFormState({ ...formState, fullname: e.target.value })
                }
                required
              />
              <CiUser className="absolute right-4 text-2xl" />
            </div>
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
                value={formState.password}
                onChange={(e) =>
                  setFormState({ ...formState, password: e.target.value })
                }
                required
              />
              <CiLock className="absolute right-4 text-2xl" />
            </div>
            <div className="relative flex items-center h-12 mb-8">
              <input
                type="password"
                className="flex-1 h-full px-4 rounded-lg border border-gray-300 text-lg font-medium"
                name="repassword"
                placeholder="Confirm Password"
                id="repassword"
                value={formState.repassword}
                onChange={(e) =>
                  setFormState({ ...formState, repassword: e.target.value })
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
            Register
          </button>
        </form>
        <div className="flex items-center">
          <span className="text-gray-600">Already have an account?</span>
          <Link to="/login" className="ml-2 text-orange-600">
            Login
          </Link>
        </div>
      </div>
    </div>
  );
};

export default RegisterForm;
