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
  fetchDiamonds,
  deleteObject,
  fetchDiamondById,
  updateDiamond,
  createDiamond,
} from "./APIClient";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import { Empty } from "antd";
import DiamondModal from "./Modal/DiamondModal";

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

const DiamondManagement: React.FC = () => {
  const [diamonds, setDiamonds] = useState<Diamond[]>([]);
  const [page, setPage] = useState<number>(1);
  const [rowsPerPage, setRowsPerPage] = useState<number>(10);
  const [totalDiamonds, setTotalDiamonds] = useState<number>(0);
  const [search, setSearch] = useState<string>("");
  const [loading, setLoading] = useState<boolean>(true);
  const [sortColumn, setSortColumn] = useState<string>("");
  const [orderByDesc, setOrderByDesc] = useState<boolean>(true);
  const [modalOpen, setModalOpen] = useState<boolean>(false);
  const [currentDiamond, setCurrentDiamond] = useState<Partial<Diamond> | null>(
    null
  );

  const fetchData = async () => {
    setLoading(true);
    try {
      const data = await fetchDiamonds(
        search,
        page,
        rowsPerPage,
        sortColumn,
        orderByDesc
      );

      setDiamonds(data.results);
      setTotalDiamonds(data.totalCount);
    } catch (error) {
      console.error("Error fetching diamonds:", error);
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

  const handleOpenModal = (diamond: Partial<Diamond> | null = null) => {
    setCurrentDiamond(diamond);
    setModalOpen(true);
  };

  const handleCloseModal = () => {
    setModalOpen(false);
    setCurrentDiamond(null);
  };

  const handleSaveDiamond = async (diamond: Partial<Diamond>) => {
    setModalOpen(false);
    if (diamond.id) {
      await updateDiamond(diamond);
    } else {
      await createDiamond(diamond);
      setTotalDiamonds(totalDiamonds + 1);
    }
    fetchData();
  };

  const handleDeleteDiamond = async (diamondId: string) => {
    try {
      await deleteObject("Diamonds", diamondId);
      setDiamonds((prevDiamonds) =>
        prevDiamonds.filter((diamond) => diamond.id !== diamondId)
      );
      setTotalDiamonds(totalDiamonds - 1);
    } catch (error) {
      console.error("Lỗi khi xóa kim cương:", error);
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
          Add Diamond
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
      ) : diamonds.length === 0 ? (
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            height: "500px",
          }}
        >
          <Empty description="No Diamonds Found" />
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
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("shape")}
                >
                  Hình dạng{" "}
                  {sortColumn === "shape" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("color")}
                >
                  Màu sắc {sortColumn === "color" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("origin")}
                >
                  Xuất xứ {sortColumn === "origin" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("caratWeight")}
                >
                  Carat{" "}
                  {sortColumn === "caratWeight" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("clarity")}
                >
                  Độ tinh khiết{" "}
                  {sortColumn === "clarity" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("cut")}
                >
                  Vết cắt {sortColumn === "cut" && (orderByDesc ? "↓" : "↑")}
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
                  }}
                >
                  Số lượng
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                  }}
                >
                  Thời gian bảo hành
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
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
                  Hành động
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {diamonds.map((diamond) => (
                <TableRow
                  key={diamond.id}
                  sx={{ background: "rgb(243,247,251)" }}
                >
                  <TableCell sx={{ width: "10%" }}>{diamond.shape}</TableCell>
                  <TableCell sx={{ width: "10%" }}>{diamond.color}</TableCell>
                  <TableCell sx={{ width: "10%" }}>{diamond.origin}</TableCell>
                  <TableCell sx={{ width: "10%" }}>
                    {diamond.caratWeight}
                  </TableCell>
                  <TableCell sx={{ width: "10%" }}>{diamond.clarity}</TableCell>
                  <TableCell sx={{ width: "10%" }}>{diamond.cut}</TableCell>
                  <TableCell sx={{ width: "10%" }}>{diamond.price}</TableCell>
                  <TableCell sx={{ width: "10%" }}>
                    {diamond.quantity}
                  </TableCell>
                  <TableCell sx={{ width: "10%" }}>
                    {diamond.warrantyPeriod}
                  </TableCell>
                  <TableCell sx={{ width: "10%" }}>
                    {diamond.pictures.length > 0 && (
                      <img
                        src={diamond.pictures[0].urlPath}
                        alt={diamond.shape}
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
                      onClick={() => handleOpenModal(diamond)}
                    >
                      <EditIcon />
                    </IconButton>
                    <IconButton
                      style={{ color: "orangered" }}
                      onClick={() => handleDeleteDiamond(diamond.id)}
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
        count={Math.ceil(totalDiamonds / rowsPerPage)}
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
      <DiamondModal
        open={modalOpen}
        handleClose={handleCloseModal}
        handleSave={handleSaveDiamond}
        initialData={currentDiamond || undefined}
        diamondId={currentDiamond?.id || undefined}
        fetchDiamondById={fetchDiamondById}
      />
    </ThemeProvider>
  );
};

export default DiamondManagement;
