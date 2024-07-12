import React, { useState, useEffect } from "react";
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
  TextField,
} from "@mui/material";

interface Order {
  id: string;
  customerName: string;
  orderDate: string;
  deliveryDate: string;
  status: string;
  totalAmount: number;
  items: {
    productId: string;
    quantity: number;
  }[];
}

interface OrderModalProps {
  open: boolean;
  handleClose: () => void;
  handleSave: (order: Partial<Order>) => void;
  initialData: Partial<Order> | null;
}

const OrderModal: React.FC<OrderModalProps> = ({
  open,
  handleClose,
  handleSave,
  initialData,
}) => {
  const [orderData, setOrderData] = useState<Partial<Order>>({
    customerName: "",
    orderDate: "",
    deliveryDate: "",
    status: "",
    totalAmount: 0,
    items: [],
  });

  useEffect(() => {
    if (initialData) {
      setOrderData(initialData);
    }
  }, [initialData]);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setOrderData((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = () => {
    handleSave(orderData);
  };

  return (
    <Dialog open={open} onClose={handleClose}>
      <DialogTitle>{orderData.id ? "Edit Order" : "Add Order"}</DialogTitle>
      <DialogContent>
        <TextField
          margin="dense"
          label="Customer Name"
          name="customerName"
          fullWidth
          value={orderData.customerName || ""}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Order Date"
          name="orderDate"
          type="date"
          fullWidth
          InputLabelProps={{
            shrink: true,
          }}
          value={orderData.orderDate || ""}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Delivery Date"
          name="deliveryDate"
          type="date"
          fullWidth
          InputLabelProps={{
            shrink: true,
          }}
          value={orderData.deliveryDate || ""}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Status"
          name="status"
          fullWidth
          value={orderData.status || ""}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Total Amount"
          name="totalAmount"
          type="number"
          fullWidth
          value={orderData.totalAmount || 0}
          onChange={handleChange}
        />
        {/* Additional fields for order items can be added here */}
      </DialogContent>
      <DialogActions>
        <Button onClick={handleClose}>Cancel</Button>
        <Button onClick={handleSubmit}>Save</Button>
      </DialogActions>
    </Dialog>
  );
};

export default OrderModal;
