import Footer from "../../Components/Layout/Footer";
import Header from "../../Components/Layout/Header";
import './details.css';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import { fetchProductDetails } from "../../services/product_service";
import { useNavigate, useParams } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import { useEffect } from "react";
import { formatPrice } from "../../utils/priceUtils";
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
                            <select name="material" id="material" className="w-[40%]">
                                <option value="" defaultChecked>Chọn chất liệu</option>
                                <option value="Vàng">Vàng</option>
                                <option value="Bạc">Bạc</option>
                            </select>
                        </div>
                        <div className="form-group mb-4">
                            <label htmlFor="main-stone" className="block w-[15%] mb-2">Viên chính</label>
                            <select name="main-stone" id="main-stone" className="w-[40%]">
                                <option value="" defaultChecked>Chọn viên chính</option>
                            </select>
                        </div>
                        <div className="form-group">
                            <label htmlFor="size" className="block w-[15%] mb-2">Ni</label>
                            <input type="number" className="w-[40%]" name="size" id="size" />
                        </div>
                    </div>


                    <button type="button" className="add_to_cart_btn mt-10">
                        <ShoppingCartIcon className="mr-2" />
                        Thêm vào giỏ hàng</button>

                </section>
            </div>
            <Footer />
        </>
    );
};

export default ProductDetailsPage;