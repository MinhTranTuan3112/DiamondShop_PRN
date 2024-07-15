import React, { useEffect, useState } from 'react'
import { useSearchParams } from 'react-router-dom';
import { fetchPagedDiamonds } from '../../services/diamond_service';
import { Box, Checkbox, FormControlLabel, FormGroup, Pagination, Slider, Typography } from '@mui/material';
import { formatPrice } from '../../utils/priceUtils';
import DiamondCard from './DiamondCard';
import { DiamondCut } from '../../enums/DiamondCut';

type Props = {

};

const DiamondPageContent = (props: Props) => {

    const [pagedResult, setPagedResult] = useState<PagedResult<PagedDiamond>>();
    const [searchParams, setSearchParams] = useSearchParams();
    const [isLoading, setIsLoading] = useState(true);
    const [priceRange, setPriceRange] = useState<number[]>([0, 100000000]);
    const pageParam = searchParams.get('page') ? +searchParams.get('page')! : 1;
    const pageSizeParam = searchParams.get('pageSize') ? +searchParams.get('pageSize')! : 5;
    const sortColumn = searchParams.get('sortColumn') ? searchParams.get('sortColumn')! : 'id';
    const orderByDesc = searchParams.get('orderByDesc') ? searchParams.get('orderByDesc') === 'true' : false;
    const startPriceParam = searchParams.get("startPrice")
        ? +searchParams.get("startPrice")!
        : null;
    const endPriceParam = searchParams.get("endPrice")
        ? +searchParams.get("endPrice")!
        : null;

    const cutsParam = searchParams.get("cuts") ? searchParams.get("cuts")?.split(",") : [];

    useEffect(() => {
        setIsLoading(true);

        const timer = setTimeout(() => {
            fetchPagedDiamonds(pageParam, pageSizeParam, sortColumn, orderByDesc, startPriceParam, endPriceParam,
                cutsParam
            ).then((data) => setPagedResult(data));
        }, 400);

        setIsLoading(false);

        return () => {
            clearTimeout(timer);
        }

    }, [pageParam, pageSizeParam, startPriceParam, endPriceParam, cutsParam]);

    const handlePageChanged = (
        event: React.ChangeEvent<unknown>,
        value: number
    ) => {
        setSearchParams({ ...searchParams, page: value.toString() });
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
            startPrice: newStartPrice.toString(),
            endPrice: newEndPrice.toString(),
        });
    };

    const handleCutsChanged = (
        event: React.ChangeEvent<HTMLInputElement>,
        checked: boolean
    ) => {
        let newCutsParam = cutsParam ? [...cutsParam] : [];
        const newValue = event.target.value;

        if (checked) {
            if (!newCutsParam.includes(newValue)) {
                newCutsParam.push(newValue);
            }
        } else {
            newCutsParam = newCutsParam.filter((cut) => cut !== newValue);
        }

        const newCutsString = newCutsParam.join(",");

        setSearchParams({ ...searchParams, cuts: newCutsString });
    };

    return (
        <div className="w-[1170px] max-w-[calc(100%-48px)] mx-auto">
            <div className="flex flex-row">
                <aside className="left_content ml-5 mt-5 text-3xl">
                    <p className="font-bold">Độ cắt</p>
                    <FormGroup>
                        {Object.values(DiamondCut).map((cut, index) => (
                            <FormControlLabel
                                control={
                                    <Checkbox
                                        // onChange={handleTypeChange}
                                        // checked={typesParam?.includes(type)}
                                        onChange={handleCutsChanged}
                                        checked={cutsParam?.includes(cut)}
                                        sx={{
                                            "& .MuiSvgIcon-root": { fontSize: 28, color: "#141313" },
                                            color: "#141313",
                                        }}
                                    />
                                }
                                label={cut}
                                value={cut}
                                key={index}
                            />
                        ))}
                    </FormGroup>
                    <br />
                </aside>
                <aside className="right_content flex-1">
                    <section className="">
                        <div className="filter_section flex flex-col justify-center items-center gap-2 my-7">
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
                    <section className="diamonds_content mt-10">
                        {isLoading ? (
                            <div className="text-center">Đang tải dữ liệu...</div>
                        ) : pagedResult?.results.length === 0 ? (
                            <div className="text-center">Không tìm thấy kim cương</div>
                        ) : (
                            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-6">
                                {pagedResult?.results.map((diamond, index) => (
                                    <DiamondCard
                                        diamond={diamond}
                                        key={index}
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

export default DiamondPageContent;