import React from "react";
import "./collections.css";
import Paging from "../../Components/Layout/Paging";

// Mock data
const products = [
  {
    id: 1,
    title: "Dây chuyền vàng trắng",
    price: "$47.00",
    status: "Còn hàng",
    img: "https://cdn.pnj.io/images/thumbnails/300/300/detailed/206/sp-gd0000w001069-day-chuyen-vang-trang-y-18k-0-pnj-1.png",
  },
  {
    id: 2,
    title: "Nhẫn kim cương",
    price: "$120.00",
    status: "Còn hàng",
    img: "https://cdn.pnj.io/images/thumbnails/300/300/detailed/207/sp-gd0000w001071-day-chuyen-vang-trang-y-18k-pnj-1.png",
  },
  {
    id: 3,
    title: "Vòng tay bạc",
    price: "$30.00",
    status: "Hết hàng",
    img: "https://cdn.pnj.io/images/thumbnails/300/300/detailed/204/sp-gd0000w001076-day-chuyen-vang-trang-y-18k-pnj-1.png",
  },
  {
    id: 4,
    title: "Bông tai ngọc trai",
    price: "$65.00",
    status: "Còn hàng",
    img: "https://cdn.pnj.io/images/thumbnails/300/300/detailed/204/sp-gd0000w001070-day-chuyen-vang-trang-y-18k-pnj-1.png",
  },
  {
    id: 5,
    title: "Dây chuyền đá quý",
    price: "$95.00",
    status: "Còn hàng",
    img: "https://cdn.pnj.io/images/thumbnails/300/300/detailed/182/sp-GD0000W000948-day-chuyen-vang-trang-y-18k-pnj-1.png",
  },
  {
    id: 6,
    title: "Nhẫn vàng",
    price: "$85.00",
    status: "Hết hàng",
    img: "https://cdn.pnj.io/images/thumbnails/300/300/detailed/177/sp-gd0000w061234-day-chuyen-vang-trang-pnj-18k-1.png",
  },
  {
    id: 7,
    title: "Vòng cổ bạc",
    price: "$40.00",
    status: "Còn hàng",
    img: "https://cdn.pnj.io/images/thumbnails/300/300/detailed/161/gd0000w061237-Day-chuyen-Vang-18K-PNJ-1.png",
  },
  {
    id: 8,
    title: "Lắc tay bạc",
    price: "$35.00",
    status: "Còn hàng",
    img: "https://cdn.pnj.io/images/thumbnails/300/300/detailed/157/gd0000c060177-day-chuyen-vang-18k-pnj-1.png",
  },
  {
    id: 9,
    title: "Hoa tai kim cương",
    price: "$150.00",
    status: "Còn hàng",
    img: "https://cdn.pnj.io/images/thumbnails/300/300/detailed/209/sp-gd0000w000266-day-chuyen-vang-trang-y-18k-pnj-1.png",
  },
  {
    id: 10,
    title: "Hoa tai kim cương",
    price: "$150.00",
    status: "Còn hàng",
    img: "https://cdn.pnj.io/images/thumbnails/300/300/detailed/209/sp-gd0000w000266-day-chuyen-vang-trang-y-18k-pnj-1.png",
  },
  {
    id: 11,
    title: "Hoa tai kim cương",
    price: "$150.00",
    status: "Còn hàng",
    img: "https://cdn.pnj.io/images/thumbnails/300/300/detailed/209/sp-gd0000w000266-day-chuyen-vang-trang-y-18k-pnj-1.png",
  },
];

interface ProductProps {
  title: string;
  price: string;
  status: string;
  img: string;
}

function Collections() {
  return (
    <>
      <div className="product-container">
        {products.map((product) => (
          <Product
            key={product.id}
            title={product.title}
            price={product.price}
            status={product.status}
            img={product.img}
          />
        ))}
      </div>
      <Paging />
    </>
  );
}

const Product: React.FC<ProductProps> = ({ title, price, status, img }) => {
  return (
    <article className="product-card">
      <div className="product-card-img-wrap">
        <a href="#!">
          <img src={img} alt={title} className="product-card-thumb" />
        </a>
      </div>

      <div className="product-card-info">
        <h3 className="product-card-title">
          <a href="">{title}</a>
        </h3>
        <p className="product-card-price">{price}</p>
      </div>

      <p
        className={`product-card-status ${
          status === "Còn hàng" ? "in-stock" : "out-of-stock"
        }`}
      >
        {status}
      </p>
    </article>
  );
};

export default Collections;
