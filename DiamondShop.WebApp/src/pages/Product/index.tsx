import { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";
import Footer from "../../Components/Layout/Footer";
import Header from "../../Components/Layout/Header";
import "./style.css";
import { AiFillCaretLeft, AiFillCaretRight } from "react-icons/ai";
import { Button, InputLabel, MenuItem, Select, TextField } from "@mui/material";
import { CiShoppingCart } from "react-icons/ci";
const productFunc = {
  id: "",
  name: "",
  material: "",
  gender: false,
  price: 0,
  point: 0,
  quantity: 0,
  warrantyPeriod: 15,
  lastUpdate: "",
  status: "available",
  category: {
    id: "",
    name: "",
    lastUpdate: "",
    status: "available",
  },
  pictures: [
    {
      id: "",
      urlPath: "",
    },
  ],
  productParts: [],
};

const initialAddToCart = {
  quantity: "1",
  productId: "",
  ringSize: "1",
  diamondId: "",
  sumSizePrice: "",
};

const initDiamond = {
  id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  name: "string",
  color: "string",
  origin: "string",
  caratWeight: "string",
  clarity: "string",
  cut: "string",
  price: 0,
  quantity: 0,
  warrantyPeriod: 0,
  lastUpdate: "2024-06-04T09:26:28.155Z",
  status: "string",
  pictures: [
    {
      id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      urlPath: "string",
    },
  ],
};

function Product() {
  
  const [searchParams] = useSearchParams();
  const productid = searchParams.get("id");
  const [product, setProduct] = useState(productFunc);
  const [pictureIndex, setPictureIndex] = useState(0);
  const [diamond, setDiamond] = useState([initDiamond]);
  const [addToCart, setAddToCart] = useState(initialAddToCart);
  console.log(localStorage.getItem('account'));

  useEffect(() => {
    const fetchDiamond = async () => {
      const response = await fetch(`https://localhost:7054/api/Diamonds`);
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }

      const data = await response.json();
      setDiamond(data.results);
    };

    const fetchProduct = async () => {
      try {
        const response = await fetch(
          `https://localhost:7054/api/Products/${productid}`
        );
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        const data = await response.json();
        setProduct(data);
        setAddToCart((prevAddToCart) => ({
          ...prevAddToCart,
          productId: productid ?? "",
          sumSizePrice: data.price.toString(),
        }));
      } catch (error) {
        console.error("Fetch error:", error);
      }
    };

    if (productid) {
      fetchProduct();
      fetchDiamond();
    }
  }, [productid]);

  const toLeftPic = () => {
    setPictureIndex((prevIndex) =>
      prevIndex === 0 ? product.pictures.length - 1 : prevIndex - 1
    );
  };

  const toRightPic = () => {
    setPictureIndex((prevIndex) =>
      prevIndex === product.pictures.length - 1 ? 0 : prevIndex + 1
    );
  };

  const handleChangeSizeandQuantity = (e) => {
    const { name, value } = e.target;
    setAddToCart((prevAddToCart) => {
      const newAddToCart = {
        ...prevAddToCart,
        [name]: value,
      };
      newAddToCart.sumSizePrice = (
        product.price *
        parseInt(newAddToCart.quantity) *
        parseInt(newAddToCart.ringSize)
      ).toString();
      return newAddToCart;
    });
  };

  const handleSubmit = async () => {
    //console.log(addToCart);
    if(localStorage.getItem('account') === null){
      window.location.href = "/login"
    }
    const response = await fetch(
      "https://localhost:7054/api/Orders/add-to-cart",
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${localStorage.getItem("account")}`,
        },
        body: JSON.stringify(addToCart),
      }
    );

    if (!response.ok) {
      // Handle error
      const errorData = await response.json();
      throw new Error(errorData.message || "Something went wrong");
    }

    const data = await response.json();
    console.log(data);
  };

  return (
    <div>
      <Header />
      <h3 style={{ textAlign: "center", fontSize: "20px", marginTop: "20px" }}>
        {product.name}
      </h3>
      <div className="product-container">
        <div className="product-left">
          <div className="diamond-up">
            <button onClick={toLeftPic}>
              <AiFillCaretLeft className="arrow leftarrow" />
            </button>

            {product.pictures.length > 0 && (
              <img
                src={`https://localhost:7054/${product.pictures[pictureIndex].urlPath}`}
                alt={`Slide ${pictureIndex}`}
                height="400px"
              />
            )}
            <button onClick={toRightPic}>
              <AiFillCaretRight className="arrow rightarrow" />
            </button>
          </div>
          <div className="diamond-under">
            {product.pictures.map((pro, key) => (
              <img
                key={key}
                src={`https://localhost:7054/${product.pictures[key].urlPath}`}
                width="150px"
                onClick={() => setPictureIndex(key)}
                className={pictureIndex === key ? "active" : "blur"}
              />
            ))}
          </div>
        </div>

        <div className="product-right">
          <h3>{product.price}</h3>
          <div className="product-right-item">
            <AiFillCaretRight />
            <p>RingSize</p>
            <TextField
              name="ringSize"
              value={addToCart.ringSize}
              onChange={handleChangeSizeandQuantity}
              InputProps={{ style: { fontSize: 16 } }}
              InputLabelProps={{ style: { fontSize: 16 } }}
            />
          </div>
          <div className="product-right-item">
            <AiFillCaretRight />
            <p>Quantity</p>
            <TextField
              name="quantity"
              value={addToCart.quantity}
              onChange={handleChangeSizeandQuantity}
              InputProps={{ style: { fontSize: 16 } }}
              InputLabelProps={{ style: { fontSize: 16 } }}
            />
          </div>
          <div className="product-right-item">
            <InputLabel id="demo-simple-select-label">Age</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              label="Age"
              onChange={(e) => {
                setAddToCart({
                  ...addToCart,
                  diamondId: (e.target as HTMLInputElement).value,
                });
              }}
            >
              {diamond.map((dia, key) => (
                <MenuItem key={key} value={dia.id}>
                  {dia.name}
                </MenuItem>
              ))}
            </Select>
          </div>
          <Button variant="contained" color="info" onClick={handleSubmit}>
            <CiShoppingCart className="top-act-img" />
            <span style={{ fontSize: "10px" }}>Add to cart</span>
          </Button>
        </div>
      </div>
      <Footer />
    </div>
  );
}

export default Product;
