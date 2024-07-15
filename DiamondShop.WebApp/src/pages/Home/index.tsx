import React, { useEffect } from "react";
import { Link } from "react-router-dom";
import Thumbnail from "../../assets/img/Thumbnail.png";
import Thumbnail2 from "../../assets/img/Thumbnail2.png";
import Footer from "../../Components/Layout/Footer";
import Header from "../../Components/Layout/Header";
import useAuth from "../../hooks/useAuth";
import { useNavigate } from "react-router-dom";
import { fetchWhoAmI } from "../../services/auth_service";
import { AuthAccount } from "../../types/account";

const Home: React.FC = () => {
  const { accessToken } = useAuth();
  const navigate = useNavigate();
  useEffect(() => {
    const handleAuth = async () => {
      const userInfoResponse = await fetchWhoAmI(accessToken);
      if (userInfoResponse.ok) {
        const userInfo: AuthAccount = await userInfoResponse.json();
        const userRole = userInfo.role;
        if (userRole === "Customer") {
          navigate("/");
        } else {
          navigate("/dashboard");
        }
      }
    };

    handleAuth();
  }, [accessToken, navigate]);
  return (
    <>
      <div className="min-h-screen bg-gradient-to-r from-[#FFE5B4] to-[#FFC085] ">
        <div className="w-[1170px] max-w-[calc(100%-48px)] mx-auto ">
          <Header />
          <section className="flex items-center mt-[76px]">
            <section className="flex-shrink-0 w-[44%]">
              <h1 className="font-semibold text-[20px] leading-[1.14] tracking-[-0.02em] text-[#2e2e2e]">
                Khám phá nét đẹp bất tận.
              </h1>
              <p className="mt-[22px] font-light text-[18px] leading-[1.67] text-[#2e2e2e]">
                Lấp lánh sự hoàn hảo - Nâng tầm vẻ đẹp. Biểu tượng của sang
                trọng và tinh túy.
              </p>
              <div className="flex items-center mt-[38px]">
                <Link
                  to="/products"
                  className="min-h-[44px] min-w-[104px] inline-block px-[20px] rounded-full border border-[#1A1A1A] text-[16px] font-normal text-center leading-[44px] text-white bg-[#1A1A1A] cursor-pointer"
                >
                  Tìm hiểu ngay
                </Link>
                <span className="ml-[25px] text-[18px] leading-[1.67] text-[#2e2e2e]">
                  or contact mapth@gmail.com
                </span>
              </div>
            </section>
            <div className="flex-grow">
              <figure className="flex items-center justify-end">
                <img
                  src={Thumbnail}
                  alt=""
                  className="w-[330px] h-[500px] rounded-[6px] object-cover mr-[-6px] relative"
                />
                <img
                  src={Thumbnail2}
                  alt=""
                  className="w-[210px] h-[400px] rounded-[6px] object-cover"
                />
              </figure>
            </div>
          </section>
        </div>
      </div>
      <Footer />
    </>
  );
};

export default Home;
