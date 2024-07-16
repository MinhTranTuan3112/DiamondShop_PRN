import React, { useState, useEffect } from "react";
import {
  Modal,
  Box,
  TextField,
  Button,
  Select,
  MenuItem,
  FormControl,
  InputLabel,
} from "@mui/material";
import { AuthAccount } from "../../../types/account";

interface AccountModalProps {
  open: boolean;
  handleClose: () => void;
  handleSave: (account: Partial<AuthAccount>) => void;
}

const AccountModal: React.FC<AccountModalProps> = ({
  open,
  handleClose,
  handleSave,
}) => {
  const [account, setAccount] = useState({
    email: "",
    role: "",
    fullname: "",
    password: "",
  });

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | { name?: string; value: unknown }>
  ) => {
    const { name, value } = e.target as HTMLInputElement;
    if (name === "customer.fullname" || name === "stakeHolder.fullname") {
      setAccount((prev) => ({
        ...prev,
        [name.split(".")[0]]: { ...prev[name.split(".")[0]], fullname: value },
      }));
    } else {
      setAccount((prev) => ({ ...prev, [name]: value }));
    }
  };

  const handleSubmit = () => {
    handleSave(account);
  };

  const modalStyle = {
    position: "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    width: 400,
    bgcolor: "background.paper",
    boxShadow: 24,
    p: 4,
    borderRadius: "5px",
  };

  return (
    <Modal open={open} onClose={handleClose}>
      <Box sx={modalStyle}>
        <h2>Add Account</h2>
        <TextField
          fullWidth
          margin="normal"
          label="Full Name"
          name="fullname"
          value={account.fullname}
          onChange={handleChange}
        />
        <TextField
          fullWidth
          margin="normal"
          label="Email"
          name="email"
          value={account.email}
          onChange={handleChange}
        />
        <FormControl fullWidth margin="normal">
          <InputLabel>Role</InputLabel>
          <Select name="role" value={account.role} onChange={handleChange}>
            <MenuItem value="Admin">Admin</MenuItem>
            <MenuItem value="Customer">Customer</MenuItem>
            <MenuItem value="Manager">Manager</MenuItem>
            <MenuItem value="SalesStaff">SalesStaff</MenuItem>
            <MenuItem value="DeliveryStaff">DeliveryStaff</MenuItem>
          </Select>
        </FormControl>
        <TextField
          fullWidth
          margin="normal"
          label="Password"
          name="password"
          value={account.password}
          onChange={handleChange}
        />

        <div
          style={{
            display: "flex",
            justifyContent: "space-between",
            marginTop: "20px",
          }}
        >
          <Button variant="contained" color="primary" onClick={handleSubmit}>
            Save
          </Button>
          <Button variant="outlined" color="secondary" onClick={handleClose}>
            Cancel
          </Button>
        </div>
      </Box>
    </Modal>
  );
};

export default AccountModal;
