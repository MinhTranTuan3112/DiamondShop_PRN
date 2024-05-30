import './style.css';
import Header from '../../Components/Layout/Header';
import Footer from '../../Components/Layout/Footer';
import { FaFilter } from 'react-icons/fa6';

type Props = {}

const MaterialOption = () => {
    return (
        <select name="" id=""
            className="material_option border border-black rounded-sm p-3 text-[1.4rem]">
            <option value="" defaultChecked>Chất liệu</option>
            <option value="">Vàng</option>
            <option value="">Bạc</option>
        </select>
    );
};


const DiamondsOption = () => {
    return (
        <select name="" id=""
            className="diamonds_option border border-black rounded-sm p-3 text-[1.4rem]">
            <option value="" defaultChecked>Kim cương đính kèm</option>
            <option value="">Kim cương LUCKY START</option>
        </select>
    );
};




const ProductsPage = (props: Props) => {
    return (
        <>
            <Header />
            <div style={{
                // height: "80rem",
                backgroundColor: 'white',
                padding: '10rem',
                // display: "flex",
                // alignItems: "center",
                // justifyContent: "center",
            }}>
                <div className="filter_bar flex gap-5 justify-center shadow-lg py-7 rounded-md
                max-md:flex-col max-md:px-7">
                    <div className="text-[3.5rem]">
                        <FaFilter />
                    </div>
                    <MaterialOption/>
                    <DiamondsOption/>
                    <div className="search_bar">
                        <input type="search"
                            className='border border-black rounded-sm p-3 text-[1.4rem]'
                            placeholder='Tìm kiếm sản phẩm...' />
                    </div>
                    <input type="number" className='start_price border border-black rounded-sm p-3 text-[1.4rem]'
                        placeholder='Giá từ...' name="" id="" />

                    <input type="number" className='end_price border border-black rounded-sm p-3 text-[1.4rem]'
                        placeholder='Đến...' name='' id='' />

                    <select name="" id="" className="sort_option border border-black rounded-sm p-3 text-[1.4rem]">
                        <option value="" defaultChecked>Sắp xếp theo</option>
                        <option value="">Tên A-Z</option>
                        <option value="">Tên Z-A</option>
                        <option value="">Giá tăng dần</option>
                        <option value="">Giá giảm dần</option>
                    </select>

                    <button type="button" className='bg-[#EEEEEE] p-3 rounded-md'>Tìm kiếm</button>

                </div>
                <div className="card_list mt-20">
                    <div className="card">
                        <div className="card_img">
                            <img src="https://locphuc.com.vn/Content/Images/Product/San-pham-lan-22/bong-tai-kim-cuong-vang-trang-18k-DFH0149E-D02200122-g3.jpg" className='' alt="" />
                        </div>
                        <div className="card_description">PT950/18KW | CZ | DIA</div>
                        <div className="card_name">Hoa tai kim cương tấm platinum...</div>
                        <div className="card_price">
                            <span className="current_price">38.754.000đ</span>
                            <span className="original_price">45.000.000đ</span>
                        </div>
                    </div>
                    <div className="card">
                        <div className="card_img">
                            <img src="https://locphuc.com.vn/Content/Images/Product/San-pham-lan-22/bong-tai-kim-cuong-vang-trang-18k-DFH0149E-D02200122-g3.jpg" className='' alt="" />
                        </div>
                        <div className="card_description">PT950/18KW | CZ | DIA</div>
                        <div className="card_name">Hoa tai kim cương tấm platinum...</div>
                        <div className="card_price">
                            <span className="current_price">38.754.000đ</span>
                            <span className="original_price">45.000.000đ</span>
                        </div>
                    </div>
                    <div className="card">
                        <div className="card_img">
                            <img src="https://locphuc.com.vn/Content/Images/Product/San-pham-lan-22/bong-tai-kim-cuong-vang-trang-18k-DFH0149E-D02200122-g3.jpg" className='' alt="" />
                        </div>
                        <div className="card_description">PT950/18KW | CZ | DIA</div>
                        <div className="card_name">Hoa tai kim cương tấm platinum...</div>
                        <div className="card_price">
                            <span className="current_price">38.754.000đ</span>
                            <span className="original_price">45.000.000đ</span>
                        </div>
                    </div>
                    <div className="card">
                        <div className="card_img">
                            <img src="https://locphuc.com.vn/Content/Images/Product/San-pham-lan-22/bong-tai-kim-cuong-vang-trang-18k-DFH0149E-D02200122-g3.jpg" className='' alt="" />
                        </div>
                        <div className="card_description">PT950/18KW | CZ | DIA</div>
                        <div className="card_name">Hoa tai kim cương tấm platinum...</div>
                        <div className="card_price">
                            <span className="current_price">38.754.000đ</span>
                            <span className="original_price">45.000.000đ</span>
                        </div>
                    </div>
                </div>

            </div>

            <Footer />
        </>
    );
};

export default ProductsPage;