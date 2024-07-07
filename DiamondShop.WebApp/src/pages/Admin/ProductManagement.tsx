// ProductManagement.tsx

import React, { useState, useEffect } from "react";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  IconButton,
  Button,
  Pagination,
  CircularProgress,
  ThemeProvider,
  createTheme,
} from "@mui/material";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import { fetchProducts } from "./APIClient";
import avatar from "../../assets/img/Anhcuatoi.png";

interface Product {
  id: string;
  name: string;
  type: string;
  material: string;
  price: number;
  point: number;
  pictures: {
    id: string;
    urlPath: string;
  }[];
}

const theme = createTheme({
  typography: {
    fontSize: 15, // Default font size for the entire page
    htmlFontSize: 15,
  },
  components: {
    MuiTableCell: {
      styleOverrides: {
        root: {
          fontSize: "13px", // Override TableCell font size to 13px
        },
      },
    },
  },
});

const ProductManagement: React.FC = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [page, setPage] = useState<number>(1);
  const [rowsPerPage, setRowsPerPage] = useState<number>(5);
  const [totalProducts, setTotalProducts] = useState<number>(0);
  const [search, setSearch] = useState<string>("");
  const [loading, setLoading] = useState<boolean>(true);
  const [sortColumn, setSortColumn] = useState<string>("");
  const [orderByDesc, setOrderByDesc] = useState<boolean>(true);

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      try {
        const data = await fetchProducts(
          search,
          page,
          rowsPerPage,
          sortColumn,
          orderByDesc
        );
        setProducts(data.results);
        setTotalProducts(data.totalCount);
      } catch (error) {
        console.error("Error fetching products:", error);
      } finally {
        setLoading(false);
      }
    };

    const timeoutId = setTimeout(() => {
      fetchData();
    }, 400);

    return () => clearTimeout(timeoutId);
  }, [page, rowsPerPage, search, sortColumn, orderByDesc]);

  useEffect(() => {
    setPage(1);
  }, [search, rowsPerPage, sortColumn, orderByDesc]);

  const handleChangePage = (
    event: React.ChangeEvent<unknown>,
    value: number
  ) => {
    setPage(value);
  };

  const handleSort = (column: string) => {
    if (column === sortColumn) {
      setOrderByDesc((prev) => !prev);
    } else {
      setSortColumn(column);
      setOrderByDesc(true);
    }
  };

  return (
    <ThemeProvider theme={theme}>
      <div style={{ display: "flex", justifyContent: "space-between" }}>
        <input
          type="text"
          placeholder="Search..."
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          style={{
            width: "300px",
            padding: "10px",
            outline: "none",
            border: "none",
            borderBottom: "2px solid #FFD700 ",
          }}
        />
        <Button
          variant="contained"
          style={{ background: "#FFD700 ", fontSize: "10px" }}
        >
          Add Product
        </Button>
      </div>

      {loading ? (
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            height: "500px",
          }}
        >
          <CircularProgress style={{ color: "#FFD700 " }} />
        </div>
      ) : (
        <TableContainer
          component={Paper}
          sx={{ borderRadius: "5px", marginTop: "10px", minHeight: "300px" }}
        >
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow sx={{ height: "25px" }}>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "20%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("name")}
                >
                  Name {sortColumn === "name" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "15%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("type")}
                >
                  Type {sortColumn === "type" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "15%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("material")}
                >
                  Material{" "}
                  {sortColumn === "material" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("price")}
                >
                  Price ($){" "}
                  {sortColumn === "price" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("point")}
                >
                  Point {sortColumn === "point" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "30%",
                  }}
                >
                  Picture
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                  }}
                >
                  Action
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {products.map((product) => (
                <TableRow
                  key={product.id}
                  sx={{ background: "rgb(243,247,251)" }}
                >
                  <TableCell sx={{ width: "25%" }}>{product.name}</TableCell>
                  <TableCell sx={{ width: "15%" }}>{product.type}</TableCell>
                  <TableCell sx={{ width: "15%" }}>
                    {product.material}
                  </TableCell>
                  <TableCell sx={{ width: "10%" }}>{product.price}</TableCell>
                  <TableCell sx={{ width: "10%" }}>{product.point}</TableCell>
                  <TableCell sx={{ width: "20%" }}>
                    {product.pictures.length > 0 && (
                      <img
                        // src={product.pictures[0].urlPath}
                        src={avatar}
                        alt={product.name}
                        style={{
                          width: "50px",
                          height: "100px",
                          objectFit: "contain",
                        }}
                      />
                    )}
                  </TableCell>
                  <TableCell sx={{ width: "15%" }}>
                    <IconButton style={{ color: "#FFD700 " }}>
                      <EditIcon />
                    </IconButton>
                    <IconButton style={{ color: "orangered" }}>
                      <DeleteIcon />
                    </IconButton>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      )}
      <div
        style={{
          display: "flex",
          justifyContent: "flex-end",
          alignItems: "center",
          gap: "10px",
          marginTop: "20px",
        }}
      >
        <label>Rows Per Page:</label>
        <input
          value={rowsPerPage}
          onChange={(e) => setRowsPerPage(parseInt(e.target.value))}
          type="number"
          min={1}
          max={25}
          style={{ width: "50px", padding: "5px" }}
        />
      </div>
      <Pagination
        count={Math.ceil(totalProducts / rowsPerPage)}
        page={page}
        onChange={handleChangePage}
        sx={{
          display: "flex",
          justifyContent: "center",
          "& .MuiPaginationItem-root.Mui-selected": {
            backgroundColor: "#FFD700",
            color: "white",
          },
        }}
      />
    </ThemeProvider>
  );
};

export default ProductManagement;
