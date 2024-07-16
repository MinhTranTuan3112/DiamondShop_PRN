import React, { useEffect, useState } from 'react';
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
  CircularProgress,
} from "@mui/material";
import { useParams } from 'react-router-dom';

// Define the type for the order detail
interface OrderDetail {
  map(arg0: (orderDetail: any, index: number) => import("react/jsx-runtime").JSX.Element): React.ReactNode;
  id: string;
  complexProduction: boolean;
  quantity: number;
  ringSize: string;
  sumSizePrice: number;
  subTotal: number;
  status: string;
  orderId: string;
  productId: string | null;
  diamondId: string | null;
}

const OrderDetails: React.FC = () => {
  const [orderDetails, setOrderDetails] = useState<OrderDetail | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const {id} = useParams();
  useEffect(() => {
    const fetchOrderDetails = async () => {
    
      try {
        const response = await fetch(`https://localhost:7054/order/${id}`);
        const data = await response.json();
        console.log(data);
        
        setOrderDetails(data);
        setLoading(false);
      } catch (err) {
        setError('Error fetching order details');
        setLoading(false);
      }
    };

    fetchOrderDetails();
  }, []);

  if (loading) {
    return <div><CircularProgress /></div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  if (!orderDetails) {
    return <div>No order details found</div>;
  }

  return (
    <>
      <Header />
      <div style={{ padding: "30px" }}>
        <h1>Order Details</h1>
        <TableContainer component={Paper} sx={{ minHeight: "500px" }}>
          <Table>
            <TableHead>
              <TableRow sx={{ background: "#fffb7d" }}>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>Complex Production</TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>Quantity</TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>Ring Size</TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>Sum Size Price</TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>SubTotal</TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>Status</TableCell>
                <TableCell style={{ fontSize: "13px", fontWeight: "700" }}>Product ID</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
                {orderDetails.map((orderDetail, index: number) => (
              <TableRow key={index}>
                <TableCell style={{ fontSize: "12px" }}>{orderDetail.complexProduction ? 'Yes' : 'No'}</TableCell>
                <TableCell style={{ fontSize: "12px" }}>{orderDetail.quantity}</TableCell>
                <TableCell style={{ fontSize: "12px" }}>{orderDetail.ringSize}</TableCell>
                <TableCell style={{ fontSize: "12px" }}>{orderDetail.sumSizePrice}</TableCell>
                <TableCell style={{ fontSize: "12px" }}>{orderDetail.subTotal}</TableCell>
                <TableCell style={{ fontSize: "12px" }}>{orderDetail.status}</TableCell>
                <TableCell style={{ fontSize: "12px" }}>{orderDetail.productId ?? orderDetail.diamondId}</TableCell>
              </TableRow>
                ))
                    }   
            </TableBody>
          </Table>
        </TableContainer>
      </div>
      <Footer />
    </>
  );
};

export default OrderDetails;
