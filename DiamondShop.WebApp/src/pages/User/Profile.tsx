import Avatar from "../../assets/img/Anhcuatoi.png";
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

const User = {
  name: "Phuc Le",
  email: "tarek97.ta@gmail.com",
  phone: "+000 11122 2345 657",
  DOB: "11-11-2002",
  Address: "Bangladesh Embassy, Washington, DC 20008",
  registed: "11-11-2002",
};

export default function Profile() {
  return (
    <>
      <Header />
      <div className="profile-container">
        <aside className="profile-sidebar">
          {/* User */}
          <div className="profile-user">
            <img
              src={Avatar}
              alt="avatar"
              className="profile-user-avatar"
              style={{}}
            />
            <h1 className="profile-user-name">{User.name}</h1>
            <p className="profile-user-desc">Ngày đăng ký: {User.registed}</p>
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
                <Link to={""} className="profile-menu-link">
                  <span className="profile-menu-icon">
                    <FaUser />
                  </span>
                  Personal Info
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
                <p className="account-info-desc">{User.email}</p>
              </div>
            </div>
            <div className="account-info">
              <span className="account-info-icon">
                <LuPhone />
              </span>
              <div className="account-info-detail">
                <h3 className="account-info-heading">Số điện thoại</h3>
                <p className="account-info-desc">{User.phone}</p>
              </div>
            </div>
            <div className="account-info">
              <span className="account-info-icon">
                <LiaBirthdayCakeSolid />
              </span>
              <div className="account-info-detail">
                <h3 className="account-info-heading">Ngày sinh</h3>
                <p className="account-info-desc">{User.DOB}</p>
              </div>
            </div>
            <div className="account-info">
              <span className="account-info-icon">
                <CiLocationOn />
              </span>
              <div className="account-info-detail">
                <h3 className="account-info-heading">Địa chỉ</h3>
                <p className="account-info-desc">{User.Address}</p>
              </div>
            </div>
          </div>
        </div>
      </div>
      <Footer />
    </>
  );
}
