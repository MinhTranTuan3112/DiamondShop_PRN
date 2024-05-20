import "./style.css";
import LogoIMG from "../../../assets/icons/icon.png";
import Avartar from "../../../assets/img/Anhcuatoi.jpg";
import { MdKeyboardArrowDown } from "react-icons/md";
import { CiShoppingCart } from "react-icons/ci";
import { CiSearch } from "react-icons/ci";
import { FaRegHeart } from "react-icons/fa6";
import { useState } from "react";
import { Link } from "react-router-dom";

export default function Header() {
  const Navbar = [
    {
      title: "Home",
      path: "/",
      id: 0,
      src: "/",
    },
    {
      title: "Product",
      path: "/product",
      id: 1,
      src: "/",
    },
    {
      title: "Policy",
      path: "/policy",
      id: 2,
      src: "/",
    },
  ];
  const [isActive, setIsActive] = useState("");
  return (
    <header className="header fixed ">
      <div className="top-bar">
        {/* Logo */}
        <Link to={"/"} className="logo">
          <img className="logo-img" src={LogoIMG} alt="MAPTH" />
          <h2 className="logo-title">MAPTH</h2>
        </Link>
        {/* Nav bar */}
        <nav className="navbar">
          <ul className="navbar-list">
            {Navbar.map((item) => (
              <li
                key={item.id}
                className={
                  isActive === item.title ? "navbar-link active" : "navbar-link"
                }
              >
                <a
                  href="#!"
                  onMouseOver={() => setIsActive(item.title)}
                  onMouseOut={() => setIsActive("")}
                >
                  {item.title}
                </a>
                <MdKeyboardArrowDown className="navbar-arrow" />
              </li>
            ))}
          </ul>
        </nav>
        {/* Action */}
        <div className="top-act">
          <div className="top-act-group">
            <button className="top-act-btn">
              <input
                type="text"
                className="top-act-search"
                placeholder="Search..."
                style={{ fontFamily: "Be Vietnam Pro" }}
              />
              <CiSearch className="top-act-img" />
            </button>
          </div>
          <div className="top-act-group">
            <button className="top-act-btn">
              <FaRegHeart className="top-act-img" />
              <span className="top-act-title">03</span>
            </button>
            <div className="top-act-seperate"></div>
            <button className="top-act-btn">
              <CiShoppingCart className="top-act-img" />
              <span className="top-act-title">$65.42</span>
            </button>
          </div>
          <Link to={"/user"} className="top-act-user">
            <img src={Avartar} alt="" className="top-act-avatar" />
          </Link>
        </div>
      </div>
    </header>
  );
}
