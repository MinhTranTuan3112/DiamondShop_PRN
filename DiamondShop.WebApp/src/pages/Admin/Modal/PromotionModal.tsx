import React, { useState, useEffect } from "react";
import {
  Button,
  TextField,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  IconButton,
} from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";

interface Promotion {
  id: string;
  name: string;
  description: string;
  expiredDate: string;
  discountPercent: number;
  status: string;
}

interface PromotionModalProps {
  open: boolean;
  handleClose: () => void;
  handleSave: (promotion: Partial<Promotion>) => void;
  initialData: Partial<Promotion> | null;
}

const PromotionModal: React.FC<PromotionModalProps> = ({
  open,
  handleClose,
  handleSave,
  initialData,
}) => {
  const [promotionData, setPromotionData] = useState<Partial<Promotion>>({
    name: "",
    description: "",
    expiredDate: "",
    discountPercent: 0,
    status: "",
  });

  useEffect(() => {
    if (initialData) {
      setPromotionData(initialData);
    } else {
      setPromotionData({
        name: "",
        description: "",
        expiredDate: "",
        discountPercent: 0,
        status: "",
      });
    }
  }, [initialData]);

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setPromotionData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = () => {
    handleSave(promotionData);
  };

  return (
    <Dialog open={open} onClose={handleClose} fullWidth maxWidth="sm">
      <DialogTitle>
        {promotionData.id ? "Edit Promotion" : "Add Promotion"}
        <IconButton
          aria-label="close"
          onClick={handleClose}
          sx={{
            position: "absolute",
            right: 8,
            top: 8,
          }}
        >
          <CloseIcon />
        </IconButton>
      </DialogTitle>
      <DialogContent>
        <TextField
          margin="dense"
          label="Name"
          name="name"
          fullWidth
          value={promotionData.name || ""}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Description"
          name="description"
          fullWidth
          value={promotionData.description || ""}
          onChange={handleChange}
          multiline
          rows={4}
        />
        <TextField
          margin="dense"
          label="Expired Date"
          name="expiredDate"
          type="date"
          InputLabelProps={{
            shrink: true,
          }}
          fullWidth
          value={promotionData.expiredDate || ""}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Discount Percent"
          name="discountPercent"
          type="number"
          fullWidth
          value={promotionData.discountPercent || 0}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Status"
          name="status"
          fullWidth
          value={promotionData.status || ""}
          onChange={handleChange}
        />
      </DialogContent>
      <DialogActions>
        <Button onClick={handleClose}>Cancel</Button>
        <Button onClick={handleSubmit}>Save</Button>
      </DialogActions>
    </Dialog>
  );
};

export default PromotionModal;
