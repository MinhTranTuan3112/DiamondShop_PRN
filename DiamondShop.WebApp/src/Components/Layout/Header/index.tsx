import "./style.css";
import LogoIMG from "../../../assets/icons/icon.png";
import Avartar from "../../../assets/img/Anhcuatoi.jpg";
import { MdKeyboardArrowDown } from "react-icons/md";
import { CiShoppingCart } from "react-icons/ci";
import { CiSearch } from "react-icons/ci";
import { FaRegHeart } from "react-icons/fa6";
import { useState } from "react";
import { Link } from "react-router-dom";

const Navbar = [
  {
    title: "Home",
    path: "/",
    id: 0,
    src: "/",
  },
  {
    title: "Trang Sức",
    path: "/product",
    id: 1,
    src: "/product",
  },
  {
    title: "Policy",
    path: "/policy",
    id: 2,
    src: "/product",
  },
];
const Product = [
  {
    heading: "Chủng loại",
    items: ["Nhẫn", "Dây chuyền", "Mặt dây chuyền", "Bông tai", "Lắc", "Vòng"],
  },
  {
    heading: "Chất Liệu",
    items: ["Vàng", "Bạc", "Platinum"],
  },

  {
    heading: "Dòng hàng",
    items: [
      "Trang sức đính kim cương",
      "Kim cuong viên",
      "Trang sức công nghệ ý",
      "Trang sức đính ngọc trai",
      "Trang sức không đính đá",
      "Kim cương viên",
    ],
  },
  {
    heading: "Trang sức cưới",
    items: ["Cầu hôn", "Kết hôn", "Kỷ niệm", "Nhẫn", "Nhẫn cặp", "Bông tai"],
  },
];

export default function Header() {
  const [isActive, setIsActive] = useState("");
  return (
    <header className="header fixed">
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
                onMouseOver={() => setIsActive(item.title)}
                onMouseOut={() => setIsActive("")}
                className={
                  isActive === item.title ? "navbar-link active" : "navbar-link"
                }
              >
                <a>{item.title}</a>
                <MdKeyboardArrowDown className="navbar-arrow" />
                {isActive === item.title && isActive === Navbar[1].title ? (
                  <div className="dropdown">
                    <div className="dropdown-inner">
                      <div className="top-menu">
                        {Product.map((category, index) => (
                          <div className="top-menu-main" key={index}>
                            <div className="menu-column">
                              <h2 className="menu-column-heading">
                                {category.heading}
                              </h2>
                              <ul className="menu-column-list">
                                {category.items.map((item, index) => (
                                  <li key={index}>
                                    <a href="" className="menu-column-link">
                                      {item}
                                    </a>
                                  </li>
                                ))}
                              </ul>
                            </div>
                          </div>
                        ))}
                      </div>
                    </div>
                  </div>
                ) : (
                  <></>
                )}
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
