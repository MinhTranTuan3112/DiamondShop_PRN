import { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";
import { fetchPagedDiamonds } from "../../services/diamond_service";
import { Pagination, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import { formatPrice } from "../../utils/priceUtils";


type Props = {

}

const DiamondPriceTable = (props: Props) => {
    const [pagedResult, setPagedResult] = useState<PagedResult<PagedDiamond>>();
    const [searchParams, setSearchParams] = useSearchParams();

    const pageParam = searchParams.get("page") ? +searchParams.get("page")! : 1;
    const pageSize = searchParams.get("pageSize")
        ? +searchParams.get("pageSize")!
        : 5;

    useEffect(() => {

        fetchPagedDiamonds(pageParam, pageSize).then((data) => setPagedResult(data));

        return () => {

        }
    }, [pageParam]);

    const handlePageChanged = (
        event: React.ChangeEvent<unknown>,
        value: number
    ) => {
        setSearchParams({ ...searchParams, page: value.toString() });
    };



    return (
        <>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }} aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell align="center">Hình dạng</TableCell>
                            <TableCell align="center">Màu sắc</TableCell>
                            <TableCell align="center">Nguồn gốc</TableCell>
                            <TableCell align="center">Trọng lượng</TableCell>
                            <TableCell align="center">Độ tinh khiết</TableCell>
                            <TableCell align="center">Độ cắt</TableCell>
                            <TableCell align="center">Giá</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {pagedResult?.results.map((diamond) => (
                            <TableRow
                                key={diamond.id}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell align="center">{diamond.shape}</TableCell>
                                <TableCell align="center">{diamond.color}</TableCell>
                                <TableCell align="center">{diamond.origin}</TableCell>
                                <TableCell align="center">{diamond.caratWeight}</TableCell>
                                <TableCell align="center">{diamond.clarity}</TableCell>
                                <TableCell align="center">{diamond.cut}</TableCell>
                                <TableCell align="center">{formatPrice(diamond.price)}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
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
        </>
    );
};

export default DiamondPriceTable;