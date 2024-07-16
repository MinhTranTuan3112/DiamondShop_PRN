import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';
import useAuth from '../../hooks/useAuth';
import { fetchDiamondDetails } from '../../services/diamond_service';
import { formatPrice } from '../../utils/priceUtils';
import ShoppingCartIcon from "@mui/icons-material/ShoppingCart";
import { AddToCartRequest } from '../../types/addToCartRequest';
import { fetchAddToCart } from '../../services/order_service';
import Swal from 'sweetalert2';
type Props = {}

const DiamondDetailsPageContent = (props: Props) => {
    const { id } = useParams();
    const navigate = useNavigate();

    if (!id) {
        return <div>Invalid diamond id</div>;
    }

    const { accessToken } = useAuth();
    const [diamond, setDiamond] = useState<DiamondDetails>();
    const [quantity, setQuantity] = useState(1);

    const fetchData = async () => {

        const response = await fetchDiamondDetails(id);
        if (!response?.ok) {
            navigate("notfound");
            return;
        }

        const data = await response?.json();
        console.log({ data });
        setDiamond(data);
    }

    useEffect(() => {

        fetchData();

        return () => {

        }

    }, []);

    const handleAddToCart = async () => {
        if (accessToken === null || accessToken === "") {
            navigate("/login");
            return;
        }

        const result = await Swal.fire({
            title: 'Thêm kim cương này vào giỏ hàng?',
            icon: 'question',
            confirmButtonText: 'Thêm vào giỏ hàng',
            showCancelButton: true,
            cancelButtonText: 'Hủy',
        });

        if (!result.isConfirmed) {
            return;
        }

        let request: AddToCartRequest = {
            diamondId: diamond?.id,
            quantity: quantity,
            sumSizePrice: 0
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
                        src={diamond?.pictures[0]?.urlPath}
                        alt=""
                    />
                </div>
                <div className="imgs flex justify-center">
                    {diamond?.pictures.slice(1).map((picture, index) => (
                        <div key={index} className="product_img">
                            <img src={picture.urlPath} alt="" />
                        </div>
                    ))}
                </div>
            </section>
            <section className="product_info_section" style={{ width: "50%" }}>
                <h1 className="text-4xl mb-2">{`Kim cương ${diamond?.color}_${diamond?.caratWeight}_${diamond?.clarity}`}</h1>
                <h3 className="mb-3">
                    <span className="new_price text-red-600 text-3xl font-bold">
                        {formatPrice(diamond?.price)} VNĐ
                    </span>
                </h3>
                <hr />

                <div className="product_info flex flex-col gap-4 mt-7">
                    
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
    );
};

export default DiamondDetailsPageContent;