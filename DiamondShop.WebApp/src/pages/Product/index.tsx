import React, { useEffect, useState } from "react";
import { fetchPagedProducts, listProduct } from "../../services/product_service";
import Footer from "../../Components/Layout/Footer";
import Header from "../../Components/Layout/Header";
import "./styles.css";
import { useSearchParams } from 'react-router-dom';
import ProductCard from "../../Components/Product/productCard";
import { FormControl, Input, InputAdornment, InputLabel } from "@mui/material";
import { AccountCircle } from "@mui/icons-material";

type Props = {

}

const ProductsPage = (props: Props) => {
  console.log('Render ProductsPage');
  const [products, setProducts] = useState<PagedProduct[]>([]);
  const [searchParams, setSearchParams] = useSearchParams();
  const [isLoading, setIsLoading] = useState(true);
  const page = searchParams.get('page') ? +searchParams.get('page')! : 1;
  const pageSize = searchParams.get('pageSize') ? +searchParams.get('pageSize')! : 10;

  const sortColumn = searchParams.get('sort') ? searchParams.get('sort')! : 'id';
  const orderByDesc = searchParams.get('desc') ? searchParams.get('desc')! === 'true' : false;

  const nameParam = searchParams.get('name') || '';
  const startPriceParam = searchParams.get('startPrice') ? +searchParams.get('startPrice')! : null;
  const endPriceParam = searchParams.get('endPrice') ? +searchParams.get('endPrice')! : null;


  useEffect(() => {
    setIsLoading(true);
    const timer = setTimeout(() => {
      fetchPagedProducts(page, pageSize, sortColumn, orderByDesc, startPriceParam, endPriceParam, nameParam)
        .then(data => setProducts(data.results));
    }, 500);
    setIsLoading(false);

    return () => {
      clearTimeout(timer);
    }

  }, [page, nameParam, startPriceParam, endPriceParam]);

  if (isLoading) {
    return <div className="text-center">Loading...</div>;
  }

  const handleNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchParams({ ...Object.fromEntries(searchParams), name: e.target.value });
  };

  const handleStartPriceChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const newStartPrice = +e.target.value;
    setSearchParams({ ...Object.fromEntries(searchParams), startPrice: newStartPrice.toString() });
    if (endPriceParam && newStartPrice < endPriceParam) {
    }
  };

  const handleEndPriceChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const newEndPrice = +e.target.value;
    setSearchParams({ ...Object.fromEntries(searchParams), endPrice: newEndPrice.toString() });
    if (startPriceParam && newEndPrice > startPriceParam) {
    }
  };

  return (
    <>
      <Header />
      <div className="filter_section flex justify-center gap-2 my-7">
        <input type="search" value={searchParams.get('name') || ''} 
        onChange={handleNameChange} name="name" placeholder="Nhập tên sản phẩm..." 
        className="p-2 mr-10" />
        <p className="flex items-center">Từ</p>
        <input type="number" className="p-2" placeholder="Giá bắt đầu"
          value={searchParams.get('startPrice') || ''}
          onChange={handleStartPriceChange} />
        <p className="flex items-center">Đến</p>
        <input type="number" className="p-2" value={searchParams.get('endPrice') || ''}
          onChange={handleEndPriceChange}
          placeholder="Giá kết thúc"
          name="" id="" />
      </div>
      {products.length === 0 ? (
        <div className="text-center">Không tìm thấy sản phẩm</div>
      ) : (
        <div className="product-container">
          {products.map((product, index) => (
            <ProductCard product={product} key={index} />
          ))}
        </div>
      )}
      <Footer />
    </>
  );
};

export default ProductsPage;


// const Products = () => {
//   const [searchParams, setSearchParams] = useSearchParams();
//   const [products, setProducts] = useState<Product[]>([]);
//   const [currentPage, setCurrentPage] = useState(1);
//   const [totalPages, setTotalPages] = useState(0);
//   const [priceRange, setPriceRange] = useState([1000, 5000]);


//   useEffect(() => {
//     const timer = setTimeout(() => {
//       fetchData(currentPage, priceRange);
//     }, 1000);

//     return () => {
//       clearTimeout(timer);
//     };

//   }, [currentPage, priceRange]);

//   const handlePageChange = (event: React.ChangeEvent<unknown>, value: number) => {
//     setCurrentPage(value)
//   };

//   const handlePriceChange = (event: Event, newValue: number | number[]) => {
//     setPriceRange(newValue as number[]);
//     setCurrentPage(1);
//   };


//   const fetchData = async (page: number, priceRange: number[]) => {
//     try {
//       const [startPrice, endPrice] = priceRange;
//       const data = await listProduct(page, startPrice, endPrice);
//       setTotalPages(Math.ceil(data.totalCount / data.pageSize));
//       setProducts(data.results);
//     } catch (error) {
//       console.error("Error fetching products:", error);
//     }
//   };

//   return (
//     <div>
//       <Header />
//       <div className="filter-container mt-10">
//         <h3>Filter by Price:</h3>
//         <Slider
//           value={priceRange}
//           onChange={handlePriceChange}
//           valueLabelDisplay="auto"
//           min={1000}
//           max={10000}
//           step={100}
//         />
//       </div>
//       <div className="product-container">
//         {products.map((prod, index) => (
//           <div
//             className="product-card"
//             key={index}
//             onClick={() => {
//               window.location.href = `/products/${prod.id}`;
//             }}
//           >
//             {prod.pictures && prod.pictures.length > 0 && (
//               <img
//                 src={prod.pictures[0].urlPath}
//                 alt={prod.name}
//                 className="product-image"
//               />
//             )}
//             <h3 className="product-name">{prod.name}</h3>
//             <p className="product-price">{prod.price}$</p>
//             <Button variant="contained" color="primary" style={{ width: "100px" }}>
//               Add to cart
//             </Button>
//           </div>
//         ))}
//       </div>
//       <Pagination
//         count={totalPages}
//         color="primary"
//         className="pagination"
//         page={currentPage}
//         onChange={handlePageChange}
//       />
//       <Footer />
//     </div>
//   );
// };

// export default Products;
