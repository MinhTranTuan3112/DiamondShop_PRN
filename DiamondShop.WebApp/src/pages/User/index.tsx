import Avatar from "../../assets/img/Anhcuatoi.jpg";
import "./style.css";
import { FaUser } from "react-icons/fa";
import { MdOutlineMail } from "react-icons/md";
import { LuPhone } from "react-icons/lu";
import { CiLocationOn } from "react-icons/ci";
import Header from "../../Components/Layout/Header";
import Footer from "../../Components/Layout/Footer";

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
            <h1 className="profile-user-name">Phuc Le</h1>
            <p className="profile-user-desc">Registed: 17th May 2024</p>
          </div>
          {/* Menu 1*/}
          <div className="profile-menu">
            <h3 className="profile-menu-title">Manage Account</h3>
            <ul className="menu-list">
              <li>
                <a href="" className="profile-menu-link">
                  <span className="profile-menu-icon">
                    <FaUser />
                  </span>
                  Personal Info
                </a>
              </li>
              <li>
                <a href="" className="profile-menu-link">
                  <span className="profile-menu-icon">
                    <FaUser />
                  </span>
                  Addresses
                </a>
              </li>
              <li>
                <a href="" className="profile-menu-link">
                  <span className="profile-menu-icon">
                    <FaUser />
                  </span>
                  Personal Info
                </a>
              </li>
            </ul>
          </div>
          {/* Menu 2*/}
          <div className="profile-menu">
            <h3 className="profile-menu-title">My items</h3>
            <ul className="menu-list">
              <li>
                <a href="" className="profile-menu-link">
                  <span className="profile-menu-icon">
                    <FaUser />
                  </span>
                  Personal Info
                </a>
              </li>
              <li>
                <a href="" className="profile-menu-link">
                  <span className="profile-menu-icon">
                    <FaUser />
                  </span>
                  Personal Info
                </a>
              </li>
              <li>
                <a href="" className="profile-menu-link">
                  <span className="profile-menu-icon">
                    <FaUser />
                  </span>
                  Personal Info
                </a>
              </li>
            </ul>
          </div>
        </aside>
        <div className="profile-info">
          <h2 className="profile-info-heading">Account info</h2>
          <p className="profile-info-desc">
            Addresses, contact information and password
          </p>
          <div className="account-info">
            <span className="account-info-icon">
              <MdOutlineMail />
            </span>
            <div className="account-info-detail">
              <h3 className="account-info-heading">Email Address</h3>
              <p className="account-info-desc">tarek97.ta@gmail.com</p>
            </div>
          </div>
          <div className="account-info">
            <span className="account-info-icon">
              <LuPhone />
            </span>
            <div className="account-info-detail">
              <h3 className="account-info-heading">Phone number</h3>
              <p className="account-info-desc">+000 11122 2345 657</p>
            </div>
          </div>
          <div className="account-info">
            <span className="account-info-icon">
              <CiLocationOn />
            </span>
            <div className="account-info-detail">
              <h3 className="account-info-heading">Add an address</h3>
              <p className="account-info-desc">
                Bangladesh Embassy, Washington, DC 20008
              </p>
            </div>
          </div>
        </div>
      </div>
      <Footer />
    </>
  );
}
