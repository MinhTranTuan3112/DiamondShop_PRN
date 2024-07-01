import Footer from "../../Components/Layout/Footer";
import Header from "../../Components/Layout/Header";

type Props = {}

const ProductDetailsPage = (props: Props) => {
    return (
        <>
            <Header/>
            <div className="my-44">
                <section className="images_section">
                    <img className="main_img h-1/3 w-1/3" src="https://firebasestorage.googleapis.com/v0/b/diamondshop-253ae.appspot.com/o/374c626ed88cc488c2d0dee3dc451186.jpg?alt=media&token=87e6a06d-c928-4346-934a-aab1260ca193" alt="" />
                    <div className="imgs">
                        <div className="product_img"><img src="https://product.hstatic.net/1000381168/product/upload_268609f8be9b4a6484170c54417f1978_master.jpg" alt="" /></div>
                        <div className="product_img"><img src="https://product.hstatic.net/1000381168/product/upload_268609f8be9b4a6484170c54417f1978_master.jpg" alt="" /></div>
                        <div className="product_img"><img src="https://product.hstatic.net/1000381168/product/upload_268609f8be9b4a6484170c54417f1978_master.jpg" alt="" /></div>
                    </div>
                </section>
            </div>
            <Footer/>
        </>
    );
};

export default ProductDetailsPage;