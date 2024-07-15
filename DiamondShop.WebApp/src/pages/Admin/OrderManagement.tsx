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
import { fetchOrders, deleteOrder } from "./APIClient";
import { Empty } from "antd";
import OrderModal from "./Modal/OrderModal";

interface Order {
  id: string;
  code: string;
  productName: string;
  diamondName: string;
  quantity: number;
  orderDate: string;
  shipDate: string;
  ringSize: string;
  totalPrice: number;
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

const OrderManagement: React.FC = () => {
  const [orders, setOrders] = useState<Order[]>([]);
  const [page, setPage] = useState<number>(1);
  const [rowsPerPage, setRowsPerPage] = useState<number>(5);
  const [totalOrders, setTotalOrders] = useState<number>(0);
  const [search, setSearch] = useState<string>("");
  const [loading, setLoading] = useState<boolean>(true);
  const [sortColumn, setSortColumn] = useState<string>("");
  const [orderByDesc, setOrderByDesc] = useState<boolean>(true);
  const [modalOpen, setModalOpen] = useState<boolean>(false);
  const [currentOrder, setCurrentOrder] = useState<Partial<Order> | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      try {
        const data = await fetchOrders(
          search,
          page,
          rowsPerPage,
          sortColumn,
          orderByDesc
        );
        const mappedOrders: Order[] = data.results.map((result: any) => ({
          id: result.id,
          code: result.code,
          productName: result.productName,
          diamondName: result.diamondName,
          quantity: result.quantity,
          orderDate: result.orderDate,
          shipDate: result.shipDate,
          ringSize: result.ringSize,
          totalPrice: result.totalPrice,
          status: result.status,
        }));
        setOrders(mappedOrders);
        setTotalOrders(data.totalCount);
      } catch (error) {
        console.error("Error fetching orders:", error);
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

  const handleOpenModal = (order: Partial<Order> | null = null) => {
    setCurrentOrder(order);
    setModalOpen(true);
  };

  const handleCloseModal = () => {
    setModalOpen(false);
    setCurrentOrder(null);
  };

  const handleSaveOrder = (order: Partial<Order>) => {
    // Add logic to save the order
    setModalOpen(false);
  };

  const handleDeleteOrder = async (orderId: string) => {
    try {
      await deleteOrder(orderId);
      setOrders((prevOrders) =>
        prevOrders.filter((order) => order.id !== orderId)
      );
      setTotalOrders(totalOrders - 1);
    } catch (error) {
      console.error("Error deleting order:", error);
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
          Add Order
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
      ) : orders.length === 0 ? (
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            height: "500px",
          }}
        >
          <Empty description="No Orders Found" />
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
                  onClick={() => handleSort("code")}
                >
                  Code {sortColumn === "code" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "15%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("productName")}
                >
                  Product Name{" "}
                  {sortColumn === "productName" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "15%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("diamondName")}
                >
                  Diamond Name{" "}
                  {sortColumn === "diamondName" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("quantity")}
                >
                  Quantity{" "}
                  {sortColumn === "quantity" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("orderDate")}
                >
                  Order Date{" "}
                  {sortColumn === "orderDate" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("shipDate")}
                >
                  Ship Date{" "}
                  {sortColumn === "shipDate" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("ringSize")}
                >
                  Ring Size{" "}
                  {sortColumn === "ringSize" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("totalPrice")}
                >
                  Total Price ($){" "}
                  {sortColumn === "totalPrice" && (orderByDesc ? "↓" : "↑")}
                </TableCell>
                <TableCell
                  sx={{
                    fontWeight: 700,
                    color: "#2e2e2e",
                    width: "10%",
                    cursor: "pointer",
                  }}
                  onClick={() => handleSort("status")}
                >
                  Status {sortColumn === "status" && (orderByDesc ? "↓" : "↑")}
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
              {orders.map((order) => (
                <TableRow
                  key={order.id}
                  sx={{ background: "rgb(243,247,251)" }}
                >
                  <TableCell sx={{ width: "10%" }}>{order.code}</TableCell>
                  <TableCell sx={{ width: "15%" }}>
                    {order.productName}
                  </TableCell>
                  <TableCell sx={{ width: "15%" }}>
                    {order.diamondName}
                  </TableCell>
                  <TableCell sx={{ width: "10%" }}>{order.quantity}</TableCell>
                  <TableCell sx={{ width: "10%" }}>{order.orderDate}</TableCell>
                  <TableCell sx={{ width: "10%" }}>{order.shipDate}</TableCell>
                  <TableCell sx={{ width: "10%" }}>{order.ringSize}</TableCell>
                  <TableCell sx={{ width: "10%" }}>
                    {order.totalPrice}
                  </TableCell>
                  <TableCell sx={{ width: "10%" }}>{order.status}</TableCell>
                  <TableCell sx={{ width: "10%" }}>
                    <IconButton
                      style={{ color: "#FFD700" }}
                      onClick={() => handleOpenModal(order)}
                    >
                      <EditIcon />
                    </IconButton>
                    <IconButton
                      style={{ color: "orangered" }}
                      onClick={() => handleDeleteOrder(order.id)}
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
        count={Math.ceil(totalOrders / rowsPerPage)}
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
      <OrderModal
        open={modalOpen}
        handleClose={handleCloseModal}
        handleSave={handleSaveOrder}
        initialData={currentOrder}
      />
    </ThemeProvider>
  );
};

export default OrderManagement;
