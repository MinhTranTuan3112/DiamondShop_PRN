import React, { useState, useEffect } from "react";
import "./style.css";
import Header from "../../Components/Layout/Header";
import Footer from "../../Components/Layout/Footer";
import { FiMinusSquare, FiPlusSquare } from "react-icons/fi";
import { FaRegTrashCan } from "react-icons/fa6";

interface CartItem {
  id: number;
  name: string;
  price: number;
  quantity: number;
  available: string;
  imgSrc: string;
}

const Checkout: React.FC = () => {
  const [cartItems, setCartItems] = useState<CartItem[]>([
    {
      id: 1,
      name: "Dây chuyền vàng trắng",
      price: 47.0,
      quantity: 1,
      available: "Còn hàng",
      imgSrc:
        "https://cdn.pnj.io/images/thumbnails/300/300/detailed/206/sp-gd0000w001069-day-chuyen-vang-trang-y-18k-0-pnj-1.png",
    },
    {
      id: 2,
      name: "Nhẫn kim cương",
      price: 120.0,
      quantity: 1,
      available: "Còn hàng",
      imgSrc:
        "https://cdn.pnj.io/images/thumbnails/300/300/detailed/207/sp-gd0000w001071-day-chuyen-vang-trang-y-18k-pnj-1.png",
    },
    {
      id: 3,
      name: "Vòng tay bạc",
      price: 30.0,
      quantity: 1,
      available: "Hết hàng",
      imgSrc:
        "https://cdn.pnj.io/images/thumbnails/300/300/detailed/204/sp-gd0000w001076-day-chuyen-vang-trang-y-18k-pnj-1.png",
    },
    {
      id: 4,
      name: "Bông tai ngọc trai",
      price: 65.0,
      quantity: 1,
      available: "Còn hàng",
      imgSrc:
        "https://cdn.pnj.io/images/thumbnails/300/300/detailed/204/sp-gd0000w001070-day-chuyen-vang-trang-y-18k-pnj-1.png",
    },
  ]);

  const [subtotal, setSubtotal] = useState<number>(0);

  useEffect(() => {
    const newSubtotal = cartItems.reduce(
      (total, item) => total + item.price * item.quantity,
      0
    );
    setSubtotal(newSubtotal);
  }, [cartItems]);

  const handleQuantityChange = (id: number, delta: number) => {
    setCartItems((prevItems) =>
      prevItems.map((item) =>
        item.id === id
          ? {
              ...item,
              quantity: Math.max(1, item.quantity + delta),
            }
          : item
      )
    );
  };

  const handleRemoveItem = (id: number) => {
    setCartItems((prevItems) => prevItems.filter((item) => item.id !== id));
  };

  return (
    <>
      <Header />
      <div className="checkout-container">
        <div className="col-8">
          <div className="cart-info">
            <div className="cart-info-list">
              {cartItems.map((item) => (
                <article key={item.id} className="cart-item flex">
                  <img src={item.imgSrc} alt={item.name} className="item-img" />
                  <div className="cart-info">
                    <div
                      className="flex"
                      style={{
                        justifyContent: "space-between",
                        marginBottom: "30px",
                      }}
                    >
                      <h3 className="cart-title">{item.name}</h3>
                      <div className="cart-price">
                        ${item.price * item.quantity}
                      </div>
                    </div>
                    <div className="cart-desc">
                      ${item.price} |{" "}
                      <label style={{ color: "#67B044" }}>
                        {item.available}
                      </label>
                    </div>
                    <div
                      className="flex"
                      style={{ justifyContent: "space-between" }}
                    >
                      <div className="action-item-value flex">
                        <FiMinusSquare
                          onClick={() => handleQuantityChange(item.id, -1)}
                          style={{ cursor: "pointer" }}
                        />
                        <label style={{ color: "#000" }}>{item.quantity}</label>
                        <FiPlusSquare
                          onClick={() => handleQuantityChange(item.id, 1)}
                          style={{ cursor: "pointer" }}
                        />
                      </div>
                      <div
                        className="cart-remove flex"
                        onClick={() => handleRemoveItem(item.id)}
                        style={{ cursor: "pointer" }}
                      >
                        <FaRegTrashCan />
                        <label>Remove</label>
                      </div>
                    </div>
                  </div>
                </article>
              ))}
            </div>
          </div>
        </div>
        <div className="col-4">
          <div className="checkout-inner">
            <div className="checkout-counter">
              <div className="space flex">
                <div className="checkout-counter-item">Subtotal (items)</div>
                <div className="checkout-counter-amount">
                  {cartItems.length}
                </div>
              </div>
              <div className="space flex">
                <div className="checkout-counter-item">Price (Total)</div>
                <div className="checkout-counter-amount">
                  ${subtotal.toFixed(2)}
                </div>
              </div>
              <div className="space flex">
                <div className="checkout-counter-item">Shipping</div>
                <div className="checkout-counter-amount">$10.00</div>
              </div>
            </div>
            <div className="checkout-group space flex">
              <div className="checkout-total">Total</div>
              <div className="checkout-counter-amount">
                ${(subtotal + 10).toFixed(2)}
              </div>
            </div>
            <button className="checkout-btn">Checkout</button>
          </div>
        </div>
      </div>
      <Footer />
    </>
  );
};

export default Checkout;
