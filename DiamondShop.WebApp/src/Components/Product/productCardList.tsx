import ProductCard from './productCard';

type Props = {
    products: PagedProduct[];
    isLoading: boolean;
}

const ProductCardList = ({ products, isLoading }: Props) => {
    return (
        isLoading ? (
            <div className="text-center">Đang tải dữ liệu...</div>
        ) :
            products.length === 0 ? (
                <div className="text-center">Không tìm thấy sản phẩm</div>
            ) : (
                <div className="product-container">
                    {products.map((product, index) => (
                        <ProductCard product={product} key={index} />
                    ))}
                </div>
            )
    );

};

export default ProductCardList;