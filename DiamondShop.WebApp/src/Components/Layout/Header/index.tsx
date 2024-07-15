import useAuth from "../../../hooks/useAuth";

import React from "react";
import { Link } from "react-router-dom";
import { CiShoppingCart } from "react-icons/ci";

const Header: React.FC = () => {
  const { authAccount, logout } = useAuth();
  // console.log(`Auth account on navbar`);
  // console.log({authAccount});

  return (
    <>
      <header className="h-[100px] pt-[30px] bg-gradient-to-r from-[#FFE5B4] to-[#FFC085]">
        <div className="w-[1170px] max-w-[calc(100%-48px)] mx-auto">
          <div className="flex items-center justify-between">
            <Link to="/">
              <div className="relative inline-flex text-[10px]">
                <span className="relative w-[3em] h-[3em] bg-[#1A1A1A] rounded-full mr-[0.6em]">
                  <span className="absolute top-[1.1em] left-[1.1em] w-[1.6em] h-[1.6em] bg-white rounded-full"></span>
                </span>
                <span className="text-right leading-[1.6em]">
                  <span className="block font-['Sora',_sans-serif] text-[1.8em] font-normal text-[#2e2e2e]">
                    diamond
                  </span>
                  <span className="text-[1.2em] font-light text-[#2e2e2e]">
                    mapth
                  </span>
                </span>
              </div>
            </Link>
            <nav>
              <ul className="flex list-none">
                <li>
                  <Link
                    to="/"
                    className="px-[21px] py-[4px] text-[17px] font-semibold  text-[#2e2e2e] text-shadow"
                  >
                    Trang chủ
                  </Link>
                </li>
                <li>
                  <Link
                    to="/products"
                    className="px-[21px] py-[4px] text-[17px] font-semibold text-[#2e2e2e]"
                  >
                    Trang sức
                  </Link>
                </li>
                <li>
                  <Link
                    to="/pricing"
                    className="px-[21px] py-[4px] text-[17px] font-semibold text-[#2e2e2e]"
                  >
                    Bảng giá kim cương
                  </Link>
                </li>
              </ul>
            </nav>
            <div className="flex items-center space-x-10">
              {authAccount ? (
                <>
                  <div className="flex items-center rounded-8 shadow-box-shadow min-w-[50px] h-50px">
                    <Link
                      className="flex items-center p-13px-20px gap-10px"
                      to={"/checkout"}
                    >
                      <CiShoppingCart className="text-[25px]" />
                      <span className="">$65.42</span>
                    </Link>
                  </div>
                  <Link to={"/user"}>
                    <p>Hello {authAccount?.email}</p>
                  </Link>
                  <button
                    className="min-h-[44px] min-w-[104px] inline-block px-[20px] rounded-full border border-[#1A1A1A] text-[16px] font-normal text-center leading-[44px] text-white bg-[#1A1A1A] cursor-pointer"
                    onClick={logout}
                  >
                    Logout
                  </button>
                </>
              ) : (
                <>
                  <Link to="/login" className="mr-[7px] text-[#2e2e2e]">
                    Log In
                  </Link>
                  <Link to="/register">
                    <button className="min-h-[44px] min-w-[104px] inline-block px-[20px] rounded-full border border-[#1A1A1A] text-[16px] font-normal text-center leading-[44px] text-white bg-[#1A1A1A] cursor-pointer">
                      Sign Up
                    </button>
                  </Link>
                </>
              )}
            </div>
          </div>
        </div>
      </header>
    </>
  );
};

export default Header;
