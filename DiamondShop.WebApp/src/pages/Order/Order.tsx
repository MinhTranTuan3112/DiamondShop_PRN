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

// Sample data for orders
const orders = [
  {
    code: "ORD001",
    productName: "Engagement Ring",
    diamondName: "Round Brilliant",
    quantity: 1,
    orderDate: "2024-07-01",
    shipDate: "2024-07-03",
    ringSize: "6",
    totalPrice: 5000,
    status: "pending",
  },
  {
    code: "ORD001",
    productName: "Engagement Ring",
    diamondName: "Round Brilliant",
    quantity: 1,
    orderDate: "2024-07-01",
    shipDate: "2024-07-03",
    ringSize: "6",
    totalPrice: 5000,
    status: "pending",
  },
  {
    code: "ORD001",
    productName: "Engagement Ring",
    diamondName: "Round Brilliant",
    quantity: 1,
    orderDate: "2024-07-01",
    shipDate: "2024-07-03",
    ringSize: "6",
    totalPrice: 5000,
    status: "pending",
  },
  {
    code: "ORD001",
    productName: "Engagement Ring",
    diamondName: "Round Brilliant",
    quantity: 1,
    orderDate: "2024-07-01",
    shipDate: "2024-07-03",
    ringSize: "6",
    totalPrice: 5000,
    status: "pending",
  },
  {
    code: "ORD001",
    productName: "Engagement Ring",
    diamondName: "Round Brilliant",
    quantity: 1,
    orderDate: "2024-07-01",
    shipDate: "2024-07-03",
    ringSize: "6",
    totalPrice: 5000,
    status: "pending",
  },
  {
    code: "ORD001",
    productName: "Engagement Ring",
    diamondName: "Round Brilliant",
    quantity: 1,
    orderDate: "2024-07-01",
    shipDate: "2024-07-03",
    ringSize: "6",
    totalPrice: 5000,
    status: "pending",
  },
  {
    code: "ORD001",
    productName: "Engagement Ring",
    diamondName: "Round Brilliant",
    quantity: 1,
    orderDate: "2024-07-01",
    shipDate: "2024-07-03",
    ringSize: "6",
    totalPrice: 5000,
    status: "pending",
  },
  // Add more sample orders here
];

export default function Order() {
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
                  Product Name
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                  Diamond Name
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                  Quantity
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                  Order Date
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                  Ship Date
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                  Ring Size
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                  Total Price
                </TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>
                  Status
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {orders.map((order) => (
                <TableRow key={order.code}>
                  <TableCell style={{ fontSize: "10px" }}>
                    {order.code}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    {order.productName}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    {order.diamondName}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    {order.quantity}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    {order.orderDate}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    {order.shipDate}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    {order.ringSize}
                  </TableCell>
                  <TableCell style={{ fontSize: "12px" }}>
                    ${order.totalPrice.toFixed(2)}
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
