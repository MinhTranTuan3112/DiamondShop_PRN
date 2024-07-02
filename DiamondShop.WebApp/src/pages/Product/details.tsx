import React, { useState } from "react";
import Footer from "../../Components/Layout/Footer";
import Header from "../../Components/Layout/Header";
import './details.css';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
type Props = {}

const ProductDetailsPage = (props: Props) => {
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
                    <h1 className="text-4xl mb-2">Nhẫn kim cương LUCKY STAR</h1>
                    <h3 className="mb-3 flex gap-3">
                        <span className="old_price text-gray-400"><del>4.000.000 VNĐ</del></span>
                        <span className="new_price text-red-600 text-3xl font-bold">3.000.000 VNĐ</span>
                    </h3>
                    <hr />

                    <div className="product_info flex flex-col gap-4 mt-7">
                        <div className="form-group mb-4">
                            <label htmlFor="material" className="block w-[15%] mb-2">Chất liệu</label>
                            <select name="material" id="material" className="w-[40%]">
                                <option value="" selected>Chọn chất liệu</option>
                                <option value="Vàng">Vàng</option>
                                <option value="Bạc">Bạc</option>
                            </select>
                        </div>
                        <div className="form-group mb-4">
                            <label htmlFor="main-stone" className="block w-[15%] mb-2">Viên chính</label>
                            <select name="main-stone" id="main-stone" className="w-[40%]">
                                <option value="" selected>Chọn viên chính</option>
                            </select>
                        </div>
                        <div className="form-group">
                            <label htmlFor="size" className="block w-[15%] mb-2">Ni</label>
                            <input type="number" className="w-[40%]" name="size" id="size" value={0} />
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