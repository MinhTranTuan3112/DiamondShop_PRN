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
import {
  fetchProducts,
  deleteObject,
  fetchCategories,
  fetchProductById,
  updateProduct,
  createProduct,
} from "./APIClient";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import { Empty } from "antd";
import ProductModal from "./Modal/ProductModal";

const theme = createTheme({
  typography: {
    fontSize: 15,
    htmlFontSize: 15,
  },
  components: {
    MuiTableCell: {
      styleOverrides: {
        root: {
          fontSize: "13px",
        },
      },
    },
  },
});

const ProductManagement: React.FC = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [categories, setCategories] = useState<{ id: string; name: string }[]>(
    []
  );
  const [page, setPage] = useState<number>(1);
  const [rowsPerPage, setRowsPerPage] = useState<number>(10);
  const [totalProducts, setTotalProducts] = useState<number>(0);
  const [search, setSearch] = useState<string>("");
  const [loading, setLoading] = useState<boolean>(true);
  const [sortColumn, setSortColumn] = useState<string>("");
  const [orderByDesc, setOrderByDesc] = useState<boolean>(true);
  const [modalOpen, setModalOpen] = useState<boolean>(false);
  const [currentProduct, setCurrentProduct] = useState<Partial<Product> | null>(
    null
  );
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
  useEffect(() => {
    const timeoutId = setTimeout(() => {
      fetchData();
    }, 400);

    return () => clearTimeout(timeoutId);
  }, [page, rowsPerPage, search, sortColumn, orderByDesc]);

  useEffect(() => {
    const getCategories = async () => {
      try {
        const data = await fetchCategories();
        setCategories(data);
      } catch (error) {
        console.error("Error fetching categories:", error);
      }
    };

    getCategories();
  }, []);

  useEffect(() => {
    setPage(1);
  }, []);

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

  const handleOpenModal = (product: Partial<Product> | null = null) => {
    setCurrentProduct(product);
    setModalOpen(true);
  };

  const handleCloseModal = () => {
    setModalOpen(false);
    setCurrentProduct(null);
  };

  const handleSaveProduct = async (product: Partial<Product>) => {
    setModalOpen(false);
    if (product.id) {
      await updateProduct(product);
    } else {
      await createProduct(product);
      setTotalProducts(totalProducts + 1);
    }
    fetchData();
    console.log("ngu ac");
  };

  const handleDeleteProduct = async (productId: string) => {
    try {
      await deleteObject("Products", productId);
      setProducts((prevProducts) =>
        prevProducts.filter((product) => product.id !== productId)
      );
      setTotalProducts(totalProducts - 1);
    } catch (error) {
      console.error("Lỗi khi xóa sản phẩm:", error);
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
            borderBottom: "2px solid #FFD700",
          }}
        />
        <Button
          variant="contained"
          style={{ background: "#FFD700", fontSize: "10px" }}
          onClick={() => handleOpenModal()}
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
          <CircularProgress style={{ color: "#FFD700" }} />
        </div>
      ) : products.length === 0 ? (
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            height: "500px",
          }}
        >
          <Empty description="No Products Found" />
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
                  Tên {sortColumn === "name" && (orderByDesc ? "↓" : "↑")}
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
                  Loại {sortColumn === "type" && (orderByDesc ? "↓" : "↑")}
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
                  Chất liệu{" "}
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
                  Giá ($) {sortColumn === "price" && (orderByDesc ? "↓" : "↑")}
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
                  Điểm {sortColumn === "point" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "15%",
                  }}
                >
                  Danh mục
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "20%",
                  }}
                >
                  Ảnh
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
                  <TableCell sx={{ width: "15%" }}>
                    {product.category.name}
                  </TableCell>
                  <TableCell sx={{ width: "20%" }}>
                    {product.pictures.length > 0 && (
                      <img
                        src={product.pictures[0].urlPath}
                        alt={product.name}
                        style={{
                          width: "50px",
                          height: "80px",
                          objectFit: "contain",
                        }}
                      />
                    )}
                  </TableCell>
                  <TableCell sx={{ width: "10%" }}>
                    <IconButton
                      style={{ color: "#FFD700" }}
                      onClick={() => handleOpenModal(product)}
                    >
                      <EditIcon />
                    </IconButton>
                    <IconButton
                      style={{ color: "orangered" }}
                      onClick={() => handleDeleteProduct(product.id)}
                    >
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
      <ProductModal
        open={modalOpen}
        handleClose={handleCloseModal}
        handleSave={handleSaveProduct}
        initialData={currentProduct || undefined}
        categories={categories}
        productId={currentProduct?.id || undefined}
        fetchProductById={fetchProductById}
      />
    </ThemeProvider>
  );
};

export default ProductManagement;
