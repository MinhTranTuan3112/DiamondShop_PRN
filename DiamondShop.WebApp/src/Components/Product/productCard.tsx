import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { formatPrice } from "../../utils/priceUtils";
import Thumbnail from "../../assets/img/Thumbnail.png";

type Props = {
  product: PagedProduct;
};

const ProductCard = ({ product }: Props) => {
  const navigate = useNavigate();

  const navigateToProductDetails = () => {
    navigate(`/products/${product.id}`);
  };

  return (
    <div className="border border-gray-300 rounded-lg overflow-hidden flex flex-col items-center justify-center w-[250px] h-[350px] p-5">
      {/* {product.pictures && product.pictures.length > 0 && (
        <img
          onClick={navigateToProductDetails}
          //   src={product.pictures[0].urlPath}
          src={Thumbnail}
          alt={product.name}
          className="w-full h-40 object-cover cursor-pointer mb-4"
        />
      )} */}
      <img
        onClick={navigateToProductDetails}
        //   src={product.pictures[0].urlPath}
        src={Thumbnail}
        alt={product.name}
        className="w-full rounded-lg h-80 object-cover cursor-pointer mb-4"
      />
      <h3
        className="text-lg font-bold text-center cursor-pointer"
        onClick={navigateToProductDetails}
      >
        {product.name}
      </h3>
      <p className="text-xl text-gray-600">{formatPrice(product.price)} VNĐ</p>
      <Button
        variant="contained"
        style={{ width: "100px", marginTop: "auto", background: "#1c1c1c" }}
      >
        Thêm vào giỏ hàng
      </Button>
    </div>
  );
};

export default ProductCard;
