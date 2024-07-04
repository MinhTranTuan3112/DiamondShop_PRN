import React, { useEffect, useState } from "react";
import { Button, Pagination, Slider } from "@mui/material";
import { listProduct } from "../../services/product_service";
import Footer from "../../Components/Layout/Footer";
import Header from "../../Components/Layout/Header";
import "./styles.css";

interface Product {
  id: string;
  name: string;
  price: number;
  pictures: { urlPath: string }[];
}

const Products: React.FC = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(0);
  const [priceRange, setPriceRange] = useState([1000, 5000]);

  useEffect(() => {
    fetchData(currentPage, priceRange);
  }, [currentPage, priceRange]);

  const handlePageChange = (event: React.ChangeEvent<unknown>, value: number) => {
    setCurrentPage(value)    
  };

  const handlePriceChange = (event: Event, newValue: number | number[]) => {
    setPriceRange(newValue as number[]);
    setCurrentPage(1);
  };

  const fetchData = async (page: number, priceRange: number[]) => {
    try {
      const [startPrice, endPrice] = priceRange;
      const data = await listProduct(page, startPrice, endPrice);
      setTotalPages(Math.ceil(data.totalCount / data.pageSize));
      setProducts(data.results);
    } catch (error) {
      console.error("Error fetching products:", error);
    }
  };

  return (
    <div>
      <Header />
      <div className="filter-container">
        <h3>Filter by Price:</h3>
        <Slider
          value={priceRange}
          onChange={handlePriceChange}
          valueLabelDisplay="auto"
          min={1000}
          max={10000}
          step={100}
        />
      </div>
      <div className="product-container">
        {products.map((prod, index) => (
          <div
            className="product-card"
            key={index}
            onClick={() => {
              window.location.href = `/product/${prod.id}`;
            }}
          >
            {prod.pictures && prod.pictures.length > 0 && (
              <img
                src={prod.pictures[0].urlPath}
                alt={prod.name}
                className="product-image"
              />
            )}
            <h3 className="product-name">{prod.name}</h3>
            <p className="product-price">{prod.price}$</p>
            <Button variant="contained" color="primary" style={{ width: "100px" }}>
              Add to cart
            </Button>
          </div>
        ))}
      </div>
      <Pagination
        count={totalPages}
        color="primary"
        className="pagination"
        page={currentPage}
        onChange={handlePageChange}
      />
      <Footer />
    </div>
  );
};

export default Products;
