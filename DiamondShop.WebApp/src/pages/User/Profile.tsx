import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import Userimg from "../../assets/img/non-user.png";
import "./style.css";
import { FaUser } from "react-icons/fa";
import { FaCartShopping } from "react-icons/fa6";
import { MdOutlineMail } from "react-icons/md";
import { LuPhone } from "react-icons/lu";
import { CiLocationOn } from "react-icons/ci";
import { LiaBirthdayCakeSolid } from "react-icons/lia";
import Header from "../../Components/Layout/Header";
import Footer from "../../Components/Layout/Footer";
import { Link } from "react-router-dom";
import { FaInbox } from "react-icons/fa";
import { fetchWhoAmI } from "../../services/auth_service";
import useAuth from "../../hooks/useAuth";
import { User } from "../../types/User";

export default function Profile() {
  const { accessToken } = useAuth();
  const [user, setUser] = useState<User | null>(null);
  const navigate = useNavigate();

  useEffect(() => {
    if (accessToken === null) {
      window.location.href = "/login";
    } else {
      const handlefetch = async () => {
        const response = await fetchWhoAmI(accessToken);
        if (response.ok) {
          const data: User = await response.json();
          setUser(data);
        } else {
          navigate("/login");
        }
      };
      handlefetch();
    }
  }, [accessToken, navigate]);

  if (!user) {
    return <div>Loading...</div>;
  }

  return (
    <>
      <Header />
      <div className="profile-container">
        <aside className="profile-sidebar">
          {/* User */}
          <div className="profile-user">
            <img
              src={user.avatarUrl ? user.avatarUrl : Userimg}
              alt="avatar"
              className="profile-user-avatar"
              style={{}}
            />
            <h1 className="profile-user-name">{user.customer.fullname}</h1>
            <p className="profile-user-desc">
              Ngày đăng ký:{" "}
              {user.timeStamp
                ? new Date(user.timeStamp).toLocaleDateString()
                : "N/A"}
            </p>
          </div>
          {/* Menu 1*/}
          <div className="profile-menu">
            <h3 className="profile-menu-title">Manage Account</h3>
            <ul className="menu-list">
              <li>
                <Link to={"/user"} className="profile-menu-link">
                  <span className="profile-menu-icon">
                    <FaUser />
                  </span>
                  Personal Info
                </Link>
              </li>
              <li>
                <Link to={"/checkout"} className="profile-menu-link">
                  <span className="profile-menu-icon">
                    <FaCartShopping />
                  </span>
                  Cart
                </Link>
              </li>
              <li>
                <Link to={"/order"} className="profile-menu-link">
                  <span className="profile-menu-icon">
                    <FaInbox />
                  </span>
                  Order
                </Link>
              </li>
            </ul>
          </div>
        </aside>
        <div className="profile-info">
          <div className="profile-wrap">
            <h2 className="profile-info-heading">Account info</h2>

            <button className="profile-edit-btn">Edit</button>
          </div>
          <p className="profile-info-desc">
            Addresses, contact information and password
          </p>
          <div className="account-inner">
            <div className="account-info">
              <span className="account-info-icon">
                <MdOutlineMail />
              </span>
              <div className="account-info-detail">
                <h3 className="account-info-heading">Email</h3>
                <p className="account-info-desc">{user.email}</p>
              </div>
            </div>
            <div className="account-info">
              <span className="account-info-icon">
                <LuPhone />
              </span>
              <div className="account-info-detail">
                <h3 className="account-info-heading">Số điện thoại</h3>
                <p className="account-info-desc">{user.customer.phoneNumber}</p>
              </div>
            </div>
            <div className="account-info">
              <span className="account-info-icon">
                <LiaBirthdayCakeSolid />
              </span>
              <div className="account-info-detail">
                <h3 className="account-info-heading">Điểm</h3>
                <p className="account-info-desc">{user.customer.point}</p>
              </div>
            </div>
            <div className="account-info">
              <span className="account-info-icon">
                <CiLocationOn />
              </span>
              <div className="account-info-detail">
                <h3 className="account-info-heading">Địa chỉ</h3>
                <p className="account-info-desc">
                  {user.customer.address || "N/A"}
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
      <Footer />
    </>
  );
}
