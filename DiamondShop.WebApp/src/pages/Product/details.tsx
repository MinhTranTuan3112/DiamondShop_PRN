import Footer from "../../Components/Layout/Footer";
import Header from "../../Components/Layout/Header";
import './details.css';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
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
    const [accessToken, setAccessToken] = useLocalStorage<string>("accessToken", "");
    console.log({ accessToken });
    const navigate = useNavigate();

    const [ringSize, setRingSize] = useState<number>(1);
    const [quantity, setQuantity] = useState<number>(1);

    if (!id) {
        return <div>Invalid product id</div>;
    }

    const { isPending, error, data } = useQuery({
        queryKey: ['product_details', id],
        queryFn: async () => await fetchData(id),
        retry: false
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
        <div>Loading...</div>
    }

    const handleAddToCart = async () => {

        const result = await Swal.fire({
            title: 'Xác nhận thêm vào giỏ hàng?',
            showCancelButton: true,
            confirmButtonText: 'Xác nhận',
            cancelButtonText: 'Hủy bỏ'
        });

        if (!result.isConfirmed) {
            return;
        }

        const request: AddToCartRequest = {
            quantity: quantity,
            productId: data?.id,
            ringSize: ringSize,
            sumSizePrice: (data?.type !== ProductType.Ring.toString() ? 0 : getRingSizePrice(ringSize, data.material))
        };

        try {

            const response = await fetchAddToCart(accessToken, request);

            if (response?.ok) {
                await Swal.fire({
                    title: 'Đã thêm sản phẩm vào giỏ hàng',
                    icon: 'success',
                    confirmButtonText: 'OK',
                });

                return;
            }

        } catch (error: any) {
            await Swal.fire({
                icon: 'error',
                title: 'Lỗi khi thêm vào giỏ hàng',
                text: error.message,
            })
        }
    };

    return (
        <>
            <Header />
            <div className="my-44 flex">
                <section className="images_section" style={{
                    width: '50%',
                }}>
                    <div className="main_img h-[20rem] w-[20rem inline-center">
                        <img className="h-full w-full" src="https://product.hstatic.net/1000381168/product/upload_268609f8be9b4a6484170c54417f1978_master.jpg" alt="" />
                    </div>
                    <div className="imgs flex justify-center">
                        <div className="product_img"><img src="https://product.hstatic.net/1000381168/product/upload_268609f8be9b4a6484170c54417f1978_master.jpg" alt="" /></div>
                        <div className="product_img"><img src="https://product.hstatic.net/1000381168/product/upload_268609f8be9b4a6484170c54417f1978_master.jpg" alt="" /></div>
                        <div className="product_img"><img src="https://product.hstatic.net/1000381168/product/upload_268609f8be9b4a6484170c54417f1978_master.jpg" alt="" /></div>
                    </div>
                </section>
                <section className="product_info_section" style={{ width: '50%' }}>
                    <h1 className="text-4xl mb-2">{data?.name}</h1>
                    <h3 className="mb-3">
                        <span className="new_price text-red-600 text-3xl font-bold">{formatPrice(data?.price)} VNĐ</span>
                    </h3>
                    <hr />

                    <div className="product_info flex flex-col gap-4 mt-7">
                        <div className="form-group mb-4">
                            <label htmlFor="material" className="block w-[15%] mb-2">Chất liệu</label>
                            <select name="material" id="material" className="w-[40%]">'
                                <option value="" defaultChecked>{data?.material}</option>
                                {/* <option value="" defaultChecked>Chọn chất liệu</option>
                                <option value="Vàng">Vàng</option>
                                <option value="Bạc">Bạc</option> */}
                            </select>
                        </div>
                        <div className="form-group mb-4">
                            <label htmlFor="main-stone" className="block w-[15%] mb-2">Viên chính</label>
                            <select name="main-stone" id="main-stone" className="w-[40%]">
                                {/* <option value="" >Chọn viên chính</option> */}
                                <option value="" defaultChecked>{data?.productParts.find(pp => pp.isMain === true)?.diamond.name}</option>
                            </select>
                        </div>
                        <div className="form-group">
                            <label htmlFor="size" className="block w-[15%] mb-2">Ni</label>
                            <input type="number" value={ringSize.toString()}
                                onChange={(e) => setRingSize(+e.target.value)}
                                className="w-[40%]" name="size" id="size" required />
                        </div>

                        <div className="form-group">
                            <label htmlFor="" className="block w-[15%] mb-2">Số lượng</label>
                            <input type="number" name="quantity"
                                value={quantity.toString()}
                                className="w-[40%]"
                                onChange={(e) => setQuantity(+e.target.value > 0 ? +e.target.value : 1)}
                                id="quantity" required />
                        </div>
                    </div>


                    <button type="button" className="add_to_cart_btn mt-10"
                        onClick={handleAddToCart}>
                        <ShoppingCartIcon className="mr-2" />
                        Thêm vào giỏ hàng</button>

                </section>
            </div>
            <Footer />
        </>
    );
};

export default ProductDetailsPage;