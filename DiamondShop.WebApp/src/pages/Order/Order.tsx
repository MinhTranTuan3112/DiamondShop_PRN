import Header from "../../Components/Layout/Header";
import Footer from "../../Components/Layout/Footer";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
} from "@mui/material";
import { useEffect, useState } from "react";
import useAuth from "../../hooks/useAuth";
import { useNavigate } from "react-router-dom";

// Sample data for orders
// const orders = [
//   {
//     code: "ORD001",
//     productName: "Engagement Ring",
//     diamondName: "Round Brilliant",
//     quantity: 1,
//     orderDate: "2024-07-01",
//     shipDate: "2024-07-03",
//     ringSize: "6",
//     totalPrice: 5000,
//     status: "pending",
//   },
//   {
//     code: "ORD001",
//     productName: "Engagement Ring",
//     diamondName: "Round Brilliant",
//     quantity: 1,
//     orderDate: "2024-07-01",
//     shipDate: "2024-07-03",
//     ringSize: "6",
//     totalPrice: 5000,
//     status: "pending",
//   },
//   {
//     code: "ORD001",
//     productName: "Engagement Ring",
//     diamondName: "Round Brilliant",
//     quantity: 1,
//     orderDate: "2024-07-01",
//     shipDate: "2024-07-03",
//     ringSize: "6",
//     totalPrice: 5000,
//     status: "pending",
//   },
//   {
//     code: "ORD001",
//     productName: "Engagement Ring",
//     diamondName: "Round Brilliant",
//     quantity: 1,
//     orderDate: "2024-07-01",
//     shipDate: "2024-07-03",
//     ringSize: "6",
//     totalPrice: 5000,
//     status: "pending",
//   },
//   {
//     code: "ORD001",
//     productName: "Engagement Ring",
//     diamondName: "Round Brilliant",
//     quantity: 1,
//     orderDate: "2024-07-01",
//     shipDate: "2024-07-03",
//     ringSize: "6",
//     totalPrice: 5000,
//     status: "pending",
//   },
//   {
//     code: "ORD001",
//     productName: "Engagement Ring",
//     diamondName: "Round Brilliant",
//     quantity: 1,
//     orderDate: "2024-07-01",
//     shipDate: "2024-07-03",
//     ringSize: "6",
//     totalPrice: 5000,
//     status: "pending",
//   },
//   {
//     code: "ORD001",
//     productName: "Engagement Ring",
//     diamondName: "Round Brilliant",
//     quantity: 1,
//     orderDate: "2024-07-01",
//     shipDate: "2024-07-03",
//     ringSize: "6",
//     totalPrice: 5000,
//     status: "pending",
//   },
//   // Add more sample orders here
// ];
interface Order {
  id: string;
  total: string;
  payMethod: string;
  shipAddress: string;
  note: string;
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

export default function Order() {
  const [orders, setOrders] = useState<Order[]>([]);
  const { accessToken } = useAuth();
  const navigate = useNavigate();
  useEffect(() => {
    const fetchData = async () => {
      const response = await fetch(
        "https://localhost:7054/api/Orders/customer-orders/InCart",
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${accessToken}`,
          },
        }
      );
      const data = await response.json();
      console.log(data);
      setOrders(data);
    };
    fetchData();
  }, []);
  return (
    <>
      <Header />
      <div style={{ padding: "30px" }}>
        <h1>Order History</h1>
        <TableContainer component={Paper} sx={{ minHeight: "500px" }}>
          <Table>
            <TableHead>
              <TableRow sx={{ background: "#fffb7d" }}>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                  Code
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                  Order Date
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                total
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                payMethod
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                shipDate
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                shipAddress
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                note
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                status
                </TableCell>
                
              </TableRow>
            </TableHead>
            <TableBody>
              {orders.map((order) => (
                <TableRow key={order.code} onClick={() => navigate(`/order/${order.id}`)}>
                  <TableCell style={{ fontSize: "10px" }}>
                    {order.code}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    {order.orderDate}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    {order.total}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    {order.payMethod ?? "Trống"}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    {order.shipDate ?? "Trống"}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    {order.shipAddress ?? "Trống"}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    {order.note}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    {order.status}
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </div>
      <Footer />
    </>
  );
}
