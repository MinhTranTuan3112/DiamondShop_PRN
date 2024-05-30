import './style.css';
import Header from '../../Components/Layout/Header';
import Footer from '../../Components/Layout/Footer';

type Props = {}

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
                <div className="filter_bar flex gap-3">
                    <select name="" id="" 
                            className="material_option border border-black rounded-sm p-2">
                        <option value="" defaultChecked>Chất liệu</option>
                        <option value="">Vàng</option>
                        <option value="">Bạc</option>
                    </select>
                    <select name="" id="" 
                    className="diamonds_option border border-black rounded-sm p-2">
                        <option value="" defaultChecked>Kim cương đính kèm</option>
                        <option value="">Kim cương LUCKY START</option>
                    </select>
                    <div className="search_bar">
                        <input type="search" 
                                className='border border-black rounded-sm p-2'
                                 placeholder='Tìm kiếm sản phẩm...' />
                    </div>
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