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
  TextField,
} from "@mui/material";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import {
  fetchPromotions,
  deletePromotion,
  createPromotion,
  updatePromotion,
} from "./APIClient";
import { Empty } from "antd";
import PromotionModal from "./Modal/PromotionModal";

interface Promotion {
  id: string;
  name: string;
  description: string;
  expiredDate: string;
  discountPercent: number;
  status: string;
}

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

const PromotionManagement: React.FC = () => {
  const [promotions, setPromotions] = useState<Promotion[]>([]);
  const [page, setPage] = useState<number>(1);
  const [rowsPerPage, setRowsPerPage] = useState<number>(5);
  const [totalPromotion, settotalPromotion] = useState<number>(0);
  const [search, setSearch] = useState<string>("");
  const [loading, setLoading] = useState<boolean>(true);
  const [modalOpen, setModalOpen] = useState<boolean>(false);
  const [currentPromotion, setCurrentPromotion] =
    useState<Partial<Promotion> | null>(null);

  const fetchData = async () => {
    setLoading(true);
    try {
      const response = await fetchPromotions(search, page, rowsPerPage);
      if (response) {
        const data = response;
        setPromotions(data.data);
        settotalPromotion(data.totalCount);
      }
    } catch (error) {
      console.error("Error fetching promotions:", error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    const timeoutId = setTimeout(() => {
      fetchData();
    }, 400);

    return () => clearTimeout(timeoutId);
  }, [page, rowsPerPage, search, totalPromotion]);

  console.log(promotions);
  const handleChangePage = (
    event: React.ChangeEvent<unknown>,
    value: number
  ) => {
    setPage(value);
  };

  const handleOpenModal = (promotion: Partial<Promotion> | null = null) => {
    setCurrentPromotion(promotion);
    setModalOpen(true);
  };

  const handleCloseModal = () => {
    setModalOpen(false);
    setCurrentPromotion(null);
  };

  const handleSavePromotion = async (promotion: Partial<Promotion>) => {
    setModalOpen(false);
    if (promotion.id) {
      await updatePromotion(promotion);
    } else {
      await createPromotion(promotion);
      settotalPromotion(totalPromotion + 1);
    }

    fetchData();
  };

  const handleDeletePromotion = async (promotionId: string) => {
    try {
      await deletePromotion(promotionId);
      setPromotions((prevPromotions) =>
        prevPromotions.filter((promotion) => promotion.id !== promotionId)
      );
      settotalPromotion(totalPromotion - 1);
    } catch (error) {
      console.error("Error deleting promotion:", error);
    }
  };

  const handleSearch = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { value } = event.target;
    setSearch(value);
    setPage(1);
  };

  return (
    <ThemeProvider theme={theme}>
      <div style={{ display: "flex", justifyContent: "space-between" }}>
        <TextField
          type="text"
          placeholder="Search by expired date..."
          value={search}
          onChange={handleSearch}
          InputProps={{
            style: {
              width: "300px",
              padding: "10px",
              outline: "none",
              border: "none",
              borderBottom: "2px solid #FFD700",
            },
          }}
        />
        <Button
          variant="contained"
          style={{ background: "#FFD700", fontSize: "10px" }}
          onClick={() => handleOpenModal()}
        >
          Add Promotion
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
      ) : promotions.length === 0 ? (
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            height: "500px",
          }}
        >
          <Empty description="No Promotions Found" />
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
                  }}
                >
                  Name
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "20%",
                  }}
                >
                  Description
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "15%",
                  }}
                >
                  Expired Date
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                  }}
                >
                  Discount (%)
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "15%",
                  }}
                >
                  Status
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "20%",
                  }}
                >
                  Action
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {promotions.map((promotion) => (
                <TableRow
                  key={promotion.id}
                  sx={{ background: "rgb(243,247,251)" }}
                >
                  <TableCell sx={{ width: "20%" }}>{promotion.name}</TableCell>
                  <TableCell sx={{ width: "20%" }}>
                    {promotion.description}
                  </TableCell>
                  <TableCell sx={{ width: "15%" }}>
                    {promotion.expiredDate}
                  </TableCell>
                  <TableCell sx={{ width: "10%" }}>
                    {promotion.discountPercent}
                  </TableCell>
                  <TableCell sx={{ width: "15%" }}>
                    {promotion.status}
                  </TableCell>
                  <TableCell sx={{ width: "20%" }}>
                    <IconButton
                      style={{ color: "#FFD700" }}
                      onClick={() => handleOpenModal(promotion)}
                    >
                      <EditIcon />
                    </IconButton>
                    <IconButton
                      style={{ color: "orangered" }}
                      onClick={() => handleDeletePromotion(promotion.id)}
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
        count={Math.ceil(totalPromotion / rowsPerPage)}
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
      <PromotionModal
        open={modalOpen}
        handleClose={handleCloseModal}
        handleSave={handleSavePromotion}
        initialData={currentPromotion}
      />
    </ThemeProvider>
  );
};

export default PromotionManagement;
