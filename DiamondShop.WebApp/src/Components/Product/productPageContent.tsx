import React, { useEffect, useState } from 'react'
import { useSearchParams } from 'react-router-dom';
import { fetchPagedProducts } from '../../services/product_service';
import ProductCard from './productCard';
import Pagination from '@mui/material/Pagination';
import { Box, Slider } from '@mui/material';
import { formatPrice } from '../../utils/priceUtils';
type Props = {}

const ProductPageContent = (props: Props) => {

    const [pagedResult, setPagedResult] = useState<PagedResult<PagedProduct>>();
    const [searchParams, setSearchParams] = useSearchParams();
    const [isLoading, setIsLoading] = useState(true);

    const pageParam = searchParams.get('page') ? +searchParams.get('page')! : 1;
    const pageSize = searchParams.get('pageSize') ? +searchParams.get('pageSize')! : 10;

    const sortColumn = searchParams.get('sort') ? searchParams.get('sort')! : 'id';
    const orderByDesc = searchParams.get('desc') ? searchParams.get('desc')! === 'true' : false;

    const nameParam = searchParams.get('name') || '';
    const startPriceParam = searchParams.get('startPrice') ? +searchParams.get('startPrice')! : null;
    const endPriceParam = searchParams.get('endPrice') ? +searchParams.get('endPrice')! : null;
    const [priceRange, setPriceRange] = useState<number[]>([0, 100000]);

    useEffect(() => {

        setIsLoading(true);

        const timer = setTimeout(() => {
            fetchPagedProducts(pageParam, pageSize, sortColumn, orderByDesc, startPriceParam, endPriceParam, nameParam)
                .then(data => setPagedResult(data));
        }, 500);

        setIsLoading(false);

        return () => {
            clearTimeout(timer);
        }

    }, [pageParam, nameParam, startPriceParam, endPriceParam]);

    const handleNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSearchParams({ ...searchParams, name: e.target.value });
    };

    function valuetext(value: number) {
        return `${formatPrice(value)} VNĐ`;
    }

    const handlePriceChange = (
        event: Event,
        newValue: number | number[],
        activeThumb: number,
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
        setSearchParams({ ...searchParams, startPrice: newStartPrice.toString(), endPrice: newEndPrice.toString() });
    };

    // const handleStartPriceChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    //     const newStartPrice = +e.target.value;
    //     setSearchParams({ ...searchParams, startPrice: newStartPrice.toString() });
    // };

    // const handleEndPriceChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    //     const newEndPrice = +e.target.value;
    //     setSearchParams({ ...searchParams, endPrice: newEndPrice.toString() });
    // };

    const handlePageChanged = (event: React.ChangeEvent<unknown>, value: number) => {
        setSearchParams({ ...searchParams, page: value.toString() });
    };

    return (
        <>
            <div className="filter_section flex justify-center gap-2 my-7">
                <input type="search" value={searchParams.get('name') || ''}
                    onChange={handleNameChange} name="name" placeholder="Nhập tên sản phẩm..."
                    className="p-2 mr-10" />



                {/* <p className="flex items-center">Từ</p>
                <input type="number" className="p-2" placeholder="Giá bắt đầu"
                value={searchParams.get('startPrice') || ''}
                onChange={handleStartPriceChange} />
                <p className="flex items-center">Đến</p>
                <input type="number" className="p-2" value={searchParams.get('endPrice') || ''}
                onChange={handleEndPriceChange}
                placeholder="Giá kết thúc"
                name="" id="" /> */}
            </div>
            <Box sx={{ width: 300, margin: '0 auto' }}>
                <Slider
                    getAriaLabel={() => 'Minimum distance'}
                    value={[startPriceParam || 0, endPriceParam || 100000]}
                    onChange={handlePriceChange}
                    min={0}
                    max={100000}
                    step={100}
                    valueLabelDisplay="auto"
                    getAriaValueText={valuetext}
                    disableSwap
                />
            </Box>
            {
                isLoading ? (
                    <div className="text-center">Đang tải dữ liệu...</div>
                ) :
                    pagedResult?.results.length === 0 ? (
                        <div className="text-center">Không tìm thấy sản phẩm</div>
                    ) : (
                        <div className="product-container">
                            {pagedResult?.results.map((product, index) => (
                                <ProductCard product={product} key={index} />
                            ))}
                        </div>
                    )
            }

            <Pagination size='large' className='my-5 inline-center' color='primary' count={pagedResult?.totalPages}
                onChange={handlePageChanged} page={searchParams.get('page') ? +searchParams.get('page')! : 1} />

        </>
    );
};

export default ProductPageContent;