import { useState } from "react";
import "./style.css";
import LogoIMG from "../../../assets/icons/icon.png";
import Avatar from "../../../assets/img/non-user.png";
import { CiShoppingCart } from "react-icons/ci";
import { CiSearch } from "react-icons/ci";
import { Link } from "react-router-dom";
import useAuth from "../../../hooks/useAuth";

const Navbar = [
  {
    title: "Home",
    path: "/",
    id: 0,
    src: "/",
  },
  {
    title: "Trang Sức",
    path: "/",
    id: 1,
    src: "/",
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
  const { authAccount, logout } = useAuth();
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
                <Link to={item.path}>{item.title}</Link>
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
            <Link className="top-act-btn" to={"/checkout"}>
              <CiShoppingCart className="top-act-img" />
              <span className="top-act-title">$65.42</span>
            </Link>
          </div>
          <Link to={"/user"} className="top-act-user">
            <img
              src={authAccount?.avatarUrl || Avatar}
              alt=""
              className="top-act-avatar"
            />
          </Link>
          {authAccount ? <button onClick={logout}>Logout</button> : <></>}
        </div>
      </div>
    </header>
  );
}
