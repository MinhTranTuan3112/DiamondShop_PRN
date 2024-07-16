import React, { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";
import {
  fetchPagedProducts,
  fetchProductTypes,
} from "../../services/product_service";
import ProductCard from "./productCard";
import Pagination from "@mui/material/Pagination";
import {
  Box,
  Checkbox,
  FormControlLabel,
  FormGroup,
  Slider,
  Typography,
} from "@mui/material";
import { formatPrice } from "../../utils/priceUtils";

type Props = {};

const ProductPageContent = (props: Props) => {
  const [pagedResult, setPagedResult] = useState<PagedResult<PagedProduct>>();
  const [searchParams, setSearchParams] = useSearchParams();
  const [productTypes, setProductTypes] = useState<string[]>([]);
  const [isLoading, setIsLoading] = useState(true);

  const pageParam = searchParams.get("page") ? +searchParams.get("page")! : 1;
  const pageSize = searchParams.get("pageSize")
    ? +searchParams.get("pageSize")!
    : 8;

  const sortColumn = searchParams.get("sort")
    ? searchParams.get("sort")!
    : "id";
  const orderByDesc = searchParams.get("desc")
    ? searchParams.get("desc")! === "true"
    : false;

  const nameParam = searchParams.get("name") || "";
  const startPriceParam = searchParams.get("startPrice")
    ? +searchParams.get("startPrice")!
    : null;
  const endPriceParam = searchParams.get("endPrice")
    ? +searchParams.get("endPrice")!
    : null;
  const typesParam = searchParams.get("types")
    ? searchParams.get("types")?.split(",")
    : [];

  const [priceRange, setPriceRange] = useState<number[]>([0, 100000000]);

  useEffect(() => {
    setIsLoading(true);

    fetchProductTypes().then((data) => setProductTypes(data));

    const timer = setTimeout(() => {
      fetchPagedProducts(
        pageParam,
        pageSize,
        sortColumn,
        orderByDesc,
        startPriceParam,
        endPriceParam,
        nameParam,
        typesParam
      ).then((data) => setPagedResult(data));
    }, 400);

    setIsLoading(false);

    return () => {
      clearTimeout(timer);
    };
  }, [
    pageParam,
    nameParam,
    startPriceParam,
    endPriceParam,
    JSON.stringify(typesParam),
  ]);

  const handleNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchParams({
      ...searchParams,
      page: '1',
      name: e.target.value,
      startPrice: startPriceParam?.toString(),
      endPrice: endPriceParam?.toString(),
      types: typesParam?.join(","),
    });
  };

  function valuetext(value: number) {
    return `${formatPrice(value)} VNĐ`;
  }

  const handlePriceChange = (
    event: Event,
    newValue: number | number[],
    activeThumb: number
  ) => {
    if (!Array.isArray(newValue)) {
      return;
    }

    let newStartPrice = priceRange[0];
    let newEndPrice = priceRange[1];

    if (activeThumb === 0) {
      newStartPrice = Math.min(newValue[0], priceRange[1] - 10);
    } else {
      newEndPrice = Math.max(newValue[1], priceRange[0] + 10);
    }

    setPriceRange([newStartPrice, newEndPrice]);
    setSearchParams({
      ...searchParams,
      page: '1',
      startPrice: newStartPrice.toString(),
      endPrice: newEndPrice.toString(),
      name: nameParam,
      types: typesParam?.join(","),
    });
  };

  const handlePageChanged = (
    event: React.ChangeEvent<unknown>,
    value: number
  ) => {
    setSearchParams({
      ...searchParams,
      page: value.toString(),
      startPrice: startPriceParam?.toString(),
      endPrice: endPriceParam?.toString(),
      name: nameParam,
      types: typesParam?.join(","),
    });
  };

  const handleTypeChange = (
    event: React.ChangeEvent<HTMLInputElement>,
    checked: boolean
  ) => {
    let newTypesParam = typesParam ? [...typesParam] : [];
    const newValue = event.target.value;

    if (checked) {
      if (!newTypesParam.includes(newValue)) {
        newTypesParam.push(newValue);
      }
    } else {
      newTypesParam = newTypesParam.filter((type) => type !== newValue);
    }

    const newTypesString = newTypesParam.join(",");

    setSearchParams({
      ...searchParams,
      page: '1',
      types: newTypesString,
      startPrice: startPriceParam?.toString(),
      endPrice: endPriceParam?.toString(),
      name: nameParam,
    });
  };

  return (
    <div className="w-[1170px] max-w-[calc(100%-48px)] mx-auto">
      <div className="flex flex-row">
        <aside className="left_content ml-5 mt-5 text-3xl">
          <p className="font-bold">Loại sản phẩm</p>
          <FormGroup>
            {productTypes.map((type, index) => (
              <FormControlLabel
                control={
                  <Checkbox
                    onChange={handleTypeChange}
                    checked={typesParam?.includes(type)}
                    sx={{
                      "& .MuiSvgIcon-root": { fontSize: 28, color: "#141313" },
                      color: "#141313",
                    }}
                  />
                }
                label={type}
                value={type}
                key={index}
              />
            ))}
          </FormGroup>
        </aside>
        <aside className="right_content flex-1">
          <section className="">
            <div className="filter_section flex flex-col justify-center items-center gap-2 my-7">
              <input
                type="search"
                value={searchParams.get("name") || ""}
                onChange={handleNameChange}
                name="name"
                placeholder="Tên sản phẩm..."
                className="text-[#141313] p-7 text-[1.8rem] font-['Be_Vietnam_Pro',_sans-serif] h-[50px] font-normal w-[300px] outline-none rounded-[8px]"
              />

              <Box sx={{ width: 300, margin: "0 auto" }}>
                <Slider
                  getAriaLabel={() => "Minimum distance"}
                  value={[startPriceParam || 0, endPriceParam || 100000000]}
                  onChange={handlePriceChange}
                  min={0}
                  max={100000000}
                  step={1000000}
                  valueLabelDisplay="auto"
                  getAriaValueText={valuetext}
                  disableSwap
                  sx={{
                    color: "#141313",
                    "& .MuiSlider-thumb": {
                      borderRadius: "50%",
                      width: "24px",
                      height: "24px",
                      color: "#141313",
                    },
                    "& .MuiSlider-track": {
                      color: "#141313",
                    },
                    "& .MuiSlider-rail": {
                      color: "#141313",
                    },
                  }}
                />
                <Typography variant="h6" className="mt-4">
                  Lọc theo giá
                </Typography>
              </Box>
            </div>
          </section>
          <section className="products_content mt-10">
            {isLoading ? (
              <div className="text-center">Đang tải dữ liệu...</div>
            ) : pagedResult?.results.length === 0 ? (
              <div className="text-center">Không tìm thấy sản phẩm</div>
            ) : (
              <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-6">
                {pagedResult?.results.map((product, index) => (
                  <ProductCard
                    product={product}
                    key={index}
                  // className="border border-gray-300 rounded-lg overflow-hidden flex flex-col items-center justify-center w-full h-[300px]"
                  />
                ))}
              </div>
            )}
            <Pagination
              size="large"
              className="my-5 inline-center"
              color="primary"
              count={pagedResult?.totalPages}
              onChange={handlePageChanged}
              page={searchParams.get("page") ? +searchParams.get("page")! : 1}
              sx={{
                marginTop: "40px",
                "& .MuiPaginationItem-root": {
                  fontSize: "1.2rem",
                  fontWeight: "500",
                },
                "& .Mui-selected": {
                  background: "#1a1a1a !important",
                  color: "white",
                  fontSize: "1.5rem",
                },
              }}
            />
          </section>
        </aside>
      </div>
    </div>
  );
};

export default ProductPageContent;
