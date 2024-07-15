import Footer from "../../Components/Layout/Footer";
import Header from "../../Components/Layout/Header";
import "./details.css";
import ShoppingCartIcon from "@mui/icons-material/ShoppingCart";
import { fetchProductDetails } from "../../services/product_service";
import { useNavigate, useParams } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import { useEffect, useState } from "react";
import { formatPrice, getRingSizePrice } from "../../utils/priceUtils";
import Swal from 'sweetalert2'
import { AddToCartRequest } from "../../types/addToCartRequest";
import { fetchAddToCart } from "../../services/order_service";
import useAuth from "../../hooks/useAuth";
import { ProductType } from "../../enums/ProductType";
import useLocalStorage from "../../hooks/useLocalStorage";

type Props = {};

const fetchData = async (id: string) => {
  const response = await fetchProductDetails(id);

  if (response.status === 404) {
    const error = new Error("Product not found");
    (error as any).status = 404;
    throw error;
  }

  if (!response.ok) {
    throw new Error("Failed to fetch product details");
  }

  const data: ProductDetails = await response.json();

  console.log({ data });

  return data;
};

const ProductDetailsPage = (props: Props) => {
  const { id } = useParams();
  const navigate = useNavigate();

  if (!id) {
    return <div>Invalid product id</div>;
  }

  const { accessToken } = useAuth();

  const [quantity, setQuantity] = useState(1);
  const [ringSize, setRingSize] = useState<number | undefined>(undefined);

  const { isPending, error, data } = useQuery({
    queryKey: ["product_details", id],
    queryFn: async () => await fetchData(id),
    retry: false,
  });

  useEffect(() => {
    if (error && (error as any).status === 404) {
      navigate("/notfound");
    }
  }, [error, navigate]);

  if (error) {
    return <div>Error: {error.message}</div>;
  }

  if (isPending) {
    <div>Loading...</div>;
  }

  const handleAddToCart = async () => {
    if (accessToken === null || accessToken === "") {
      navigate("/login");
      return;
    }

    const result = await Swal.fire({
      title: 'Thêm sản phẩm này vào giỏ hàng?',
      icon: 'question',
      confirmButtonText: 'Thêm vào giỏ hàng',
      showCancelButton: true,
      cancelButtonText: 'Hủy',
    });

    if (!result.isConfirmed) {
      return;
    }

    const productId = data?.id;

    let request: AddToCartRequest = {
      productId: productId,
      quantity: quantity,
      ringSize: ringSize,
      sumSizePrice: data?.type == ProductType.Ring.toString() ? getRingSizePrice(ringSize!, data.material) : 0,
    };

    const response = await fetchAddToCart(accessToken, request);
    if (response.ok) {
      await Swal.fire({
        title: 'Đã thêm vào giỏ hàng',
        icon: 'success',
        confirmButtonText: 'OK',
      });
    }
  }

  return (
    <>
      <Header />
      <div className="my-44 flex">
        <section
          className="images_section"
          style={{
            width: "50%",
          }}
        >
          <div className="main_img h-[20rem] w-[20rem inline-center">
            <img
              className="h-full w-full"
              src={data?.pictures[0]?.urlPath}
              alt=""
            />
          </div>
          <div className="imgs flex justify-center">
            {data?.pictures.slice(1).map((picture, index) => (
              <div key={index} className="product_img">
                <img src={picture.urlPath} alt="" />
              </div>
            ))}
          </div>
        </section>
        <section className="product_info_section" style={{ width: "50%" }}>
          <h1 className="text-4xl mb-2">{data?.name}</h1>
          <h3 className="mb-3">
            <span className="new_price text-red-600 text-3xl font-bold">
              {formatPrice(data?.price)} VNĐ
            </span>
          </h3>
          <hr />

          <div className="product_info flex flex-col gap-4 mt-7">
            <div className="form-group mb-4">
              <label htmlFor="material" className="block w-[15%] mb-2">
                Chất liệu
              </label>
              <select name="material" id="material" className="w-[40%]">
                <option value="" defaultChecked>
                  Chọn chất liệu
                </option>
                <option value="Vàng">Vàng</option>
                <option value="Bạc">Bạc</option>
              </select>
            </div>
            <div className="form-group mb-4">
              <label htmlFor="main-stone" className="block w-[15%] mb-2">
                Viên chính
              </label>
              <select name="main-stone" id="main-stone" className="w-[40%]">
                <option value="" defaultChecked>
                  Chọn viên chính
                </option>
              </select>
            </div>
            {data?.type === ProductType.Ring.toString() && (
              <div className="form-group">
                <label htmlFor="size" className="block w-[15%] mb-2">
                  Ni
                </label>
                <input type="number" className="w-[40%]" name="size" id="size"
                  value={ringSize ?? 1}
                  onChange={(e) => setRingSize(+e.target.value)} required />
              </div>
            )}
            <div className="form-group">
              <label htmlFor="quantity" className="block w-[15%] mb-2">Số lượng</label>
              <input type="number" className="w-[40%]" name="quantity"
                id="quantity"
                value={quantity}
                onChange={(e) => setQuantity(+e.target.value)} required />
            </div>
          </div>

          <button type="button" onClick={handleAddToCart} className="add_to_cart_btn mt-10">
            <ShoppingCartIcon className="mr-2" />
            Thêm vào giỏ hàng
          </button>
        </section>
      </div>
      <Footer />
    </>
  );
};

export default ProductDetailsPage;
