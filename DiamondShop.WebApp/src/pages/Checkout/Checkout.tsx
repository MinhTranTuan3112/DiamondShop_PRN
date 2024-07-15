import React, { useState, useEffect } from "react";
import "./style.css";
import Header from "../../Components/Layout/Header";
import Footer from "../../Components/Layout/Footer";
import { FiMinusSquare, FiPlusSquare } from "react-icons/fi";
import { FaRegTrashCan } from "react-icons/fa6";
import { customFetch } from "../../services/custom_fetch";
import useAuth from "../../hooks/useAuth";
import { fetchCartInfo, fetchConfirmOrder } from "../../services/order_service";
import { formatPrice } from "../../utils/priceUtils";
import Swal from "sweetalert2";

// interface CartItem {
//   id: number;
//   name: string;
//   price: number;
//   quantity: number;
//   available: string;
//   imgSrc: string;
// }

interface Promotion {
  id: string;
  name: string;
  description: string;
  expiredDate: string;
  discountPercent: number;
  status: string;
}

const Checkout: React.FC = () => {
  const { accessToken } = useAuth();
  // const [cartItems, setCartItems] = useState<CartItem[]>([
  //   {
  //     id: 1,
  //     name: "Dây chuyền vàng trắng",
  //     price: 47.0,
  //     quantity: 1,
  //     available: "Còn hàng",
  //     imgSrc:
  //       "https://cdn.pnj.io/images/thumbnails/300/300/detailed/206/sp-gd0000w001069-day-chuyen-vang-trang-y-18k-0-pnj-1.png",
  //   },
  //   {
  //     id: 2,
  //     name: "Nhẫn kim cương",
  //     price: 120.0,
  //     quantity: 1,
  //     available: "Còn hàng",
  //     imgSrc:
  //       "https://cdn.pnj.io/images/thumbnails/300/300/detailed/207/sp-gd0000w001071-day-chuyen-vang-trang-y-18k-pnj-1.png",
  //   },
  //   {
  //     id: 3,
  //     name: "Vòng tay bạc",
  //     price: 30.0,
  //     quantity: 1,
  //     available: "Hết hàng",
  //     imgSrc:
  //       "https://cdn.pnj.io/images/thumbnails/300/300/detailed/204/sp-gd0000w001076-day-chuyen-vang-trang-y-18k-pnj-1.png",
  //   },
  //   {
  //     id: 4,
  //     name: "Bông tai ngọc trai",
  //     price: 65.0,
  //     quantity: 1,
  //     available: "Còn hàng",
  //     imgSrc:
  //       "https://cdn.pnj.io/images/thumbnails/300/300/detailed/204/sp-gd0000w001070-day-chuyen-vang-trang-y-18k-pnj-1.png",
  //   },
  // ]);
  const [orderInCart, setOrderInCart] = useState<OrderCartInfo | null>(null);
  const [cartItems, setCartItems] = useState<OrderDetail[]>([]);
  const [subtotal, setSubtotal] = useState<number>(0);
  const [coupon, setCoupon] = useState<string>("");
  const [promotion, setPromotion] = useState<Promotion | null>(null);
  const [total, setTotal] = useState<number>(0);

  const handleCoupon = async (code: string) => {
    try {
      const response = await customFetch({
        options: { method: "GET" },
        endpointPath: `/Promotions/${code}`,
      });
      if (response.ok) {
        const data = await response.json();
        setPromotion(data);
      }
    } catch (error) {
      console.error("Failed to fetch promotion:", error);
    }
  };

  const fetchOrderInCart = async () => {
    try {
      const response = await fetchCartInfo(accessToken);

      if (response.status === 404) {
        return null;
      }

      const data = await response.json();

      return data;
    } catch (error) {
      console.error("Failed to fetch order in cart:", error);
      return null;
    }
  };

  useEffect(() => {
    const fetchData = async () => {
      const orderInCart = await fetchOrderInCart();
      if (orderInCart) {
        setOrderInCart(orderInCart);
        setCartItems(orderInCart.orderDetails);
      }
    };
    fetchData();
  }, []);

  // useEffect(() => {
  //   const newSubtotal = cartItems.reduce(
  //     (total, item) => total + item.price * item.quantity,
  //     0
  //   );
  //   setSubtotal(newSubtotal);
  // }, [cartItems]);

  useEffect(() => {
    const newSubtotal = orderInCart?.orderDetails.reduce(
      (total, item) => total + item.subTotal * item.quantity,
      0
    ) || 0;
    setSubtotal(newSubtotal);
  }, [orderInCart?.orderDetails]);

  useEffect(() => {
    const discount = promotion
      ? (promotion.discountPercent / 100) * subtotal
      : 0;
    const newTotal = subtotal - discount + 10; // Adding fixed shipping cost of $10
    setTotal(newTotal);
  }, [subtotal, promotion]);

  // const handleQuantityChange = (id: number, delta: number) => {
  //   setCartItems((prevItems) =>
  //     prevItems.map((item) =>
  //       item.id === id
  //         ? {
  //           ...item,
  //           quantity: Math.max(1, item.quantity + delta),
  //         }
  //         : item
  //     )
  //   );
  // };

  const handleQuantityChange = (newQuantity: number, productId?: string, diamondId?: string) => {
    setCartItems((prevItems) =>
      prevItems.map((item) => {
        const comparisonId = productId || diamondId;
        const isMatch = item.productId === comparisonId || item.diamondId === comparisonId;
        return isMatch
          ? {
            ...item,
            quantity: Math.max(1, item.quantity + newQuantity),
          }
          : item;
      })
    );
  };

  const handleRemoveItem = (productId?: string, diamondId?: string) => {
    setCartItems((prevItems) =>
      prevItems.filter((item) => {
        const comparisonId = productId || diamondId;
        return !(item.productId === comparisonId || item.diamondId === comparisonId);
      })
    );
  };

  const handleConfirmOrder = async () => {

    try {
      const result = await Swal.fire({
        icon: 'question',
        confirmButtonText: 'Ok',
        title: 'Xác nhận đặt hàng?',
        showCancelButton: true,
        cancelButtonText: 'Hủy',
      });

      if (!result.isConfirmed) {
        return;
      }

      const response = await fetchConfirmOrder(accessToken, orderInCart?.id || "");

      if (response?.ok) {
        await Swal.fire({
          icon: 'success',
          title: 'Đặt hàng thành công!',
          text: 'Cảm ơn bạn đã mua hàng tại MAPTH Diamond Shop!',
        });
      }

    } catch (error) {
      console.error("Failed to confirm order:", error);
    }
  }

  return (
    <>
      <Header />
      {!orderInCart ? (
        <p className="text-center font-bold text-3xl">Giỏ hàng của bạn đang trống</p>
      ) : (
        <div className="checkout-container">
          <section className="col-8 product_section">
            <div className="cart_info">
              <div className="cart_info_list">
                {cartItems.map((item) => (
                  <article key={item.id} className="cart-item flex">
                    <img src={item.product?.pictures[0]?.urlPath ?? "https://dictionary.cambridge.org/vi/images/thumb/diamon_noun_002_10599.jpg?version=6.0.25"} alt={item.product?.name ?? "Unknown product"} className="item-img" />
                    <div className="cart-info">
                      <div
                        className="flex"
                        style={{
                          justifyContent: "space-between",
                          marginBottom: "30px",
                        }}
                      >
                        <h3 className="cart-title">{item.product?.name ?? "Unknown product"}</h3>
                        <div className="cart-price">
                          ${formatPrice(item.subTotal)}
                        </div>
                      </div>
                      <div className="cart-desc">
                        ${formatPrice(item.product?.price) ?? "N/A"} |{" "}
                        <label style={{ color: "#67B044" }}>
                          {item.product?.status ?? "Unknown status"}
                        </label>
                      </div>
                      <div
                        className="flex"
                        style={{ justifyContent: "space-between" }}
                      >
                        <div className="action-item-value flex">
                          <FiMinusSquare
                            onClick={() => handleQuantityChange(-1, item.productId, item.diamondId)}
                            style={{ cursor: "pointer" }}
                          />
                          <label style={{ color: "#000" }}>{item.quantity}</label>
                          <FiPlusSquare
                            onClick={() => handleQuantityChange(1, item.productId, item.diamondId)}
                            style={{ cursor: "pointer" }}
                          />
                        </div>
                        <div
                          className="cart-remove flex"
                          onClick={() => handleRemoveItem(item.productId, item.diamondId)}
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
          </section>

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
                    ${formatPrice(total)}
                  </div>
                </div>
                <div className="space flex">
                  <div className="checkout-counter-item">Shipping</div>
                  <div className="checkout-counter-amount">$10.00</div>
                </div>
              </div>
              <div className="checkout-group space flex">
                <div className="checkout-total">Total</div>
                <div className="checkout-counter-amount">${formatPrice(total)}</div>
              </div>
              <div className="checkout-group flex">
                <div className="checkout-total">Coupon</div>
                <input
                  className="checkout-coupon"
                  type="text"
                  value={coupon}
                  onChange={(e) => setCoupon(e.target.value)}
                />
                <button
                  className="checkout-coupon-btn"
                  onClick={() => handleCoupon(coupon)}
                >
                  Apply
                </button>
                {promotion && <span>{promotion.discountPercent}%</span>}
              </div>
              <button className="checkout-btn" onClick={handleConfirmOrder}>Xác nhận đặt hàng</button>
            </div>
          </div>
        </div>
      )}
      <Footer />
    </>
  );
};

export default Checkout;
