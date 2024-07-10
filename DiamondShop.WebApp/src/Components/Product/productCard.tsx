import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";

type Props = {
    product: PagedProduct;
}

const ProductCard = ({ product }: Props) => {
    const navigate = useNavigate();

    const navigateToProductDetails = () => {
        navigate(`/products/${product.id}`);
    };

    return (
        <div
            className="product-card"
            key={product.id}
        >
            {product.pictures && product.pictures.length > 0 && (
                <img
                    onClick={navigateToProductDetails}
                    src={product.pictures[0].urlPath}
                    alt={product.name}
                    className="product-image"
                />
            )}
            <h3 className="product-name" onClick={navigateToProductDetails}>{product.name}</h3>
            <p className="product-price">{product.price}$</p>
            <Button variant="contained" color="primary" style={{ width: "100px" }}>
                Thêm vào giỏ hàng
            </Button>
        </div>
    );
};

export default ProductCard;