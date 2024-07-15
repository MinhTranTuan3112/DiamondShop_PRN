import React from 'react'
import { useNavigate } from 'react-router-dom';
import Thumbnail from "../../assets/img/Thumbnail.png";
import { formatPrice } from '../../utils/priceUtils';
import { Button } from '@mui/material';

type Props = {
    diamond: PagedDiamond;
}

const getDiamondName = (diamond: PagedDiamond) => {
    return `Kim cương ${diamond.color}_${diamond.caratWeight}_${diamond.clarity}`
}

const DiamondCard = ({diamond}: Props) => {
    const navigate = useNavigate();

    const navigateToDiamondDetails = () => {
        navigate(`/diamonds/${diamond.id}`);
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
                onClick={navigateToDiamondDetails}
                //   src={product.pictures[0].urlPath}
                src={Thumbnail}
                alt={getDiamondName(diamond)}
                className="w-full rounded-lg h-80 object-cover cursor-pointer mb-4"
            />
            <h3
                className="text-lg font-bold text-center cursor-pointer"
                onClick={navigateToDiamondDetails}
            >
                {getDiamondName(diamond)}
            </h3>
            <p className="text-xl text-gray-600">{formatPrice(diamond.price)} VNĐ</p>
            <Button onClick={navigateToDiamondDetails}
                variant="contained"
                style={{ width: "100px", marginTop: "auto", background: "#1c1c1c" }}
            >
                Chi tiết
            </Button>
        </div>
    );
};

export default DiamondCard;