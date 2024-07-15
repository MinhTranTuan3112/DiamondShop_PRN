import React, { useState, useEffect } from "react";
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
  TextField,
} from "@mui/material";

interface Diamond {
  id: string;
  shape: string;
  color: string;
  origin: string;
  certificationUrl: string | null;
  caratWeight: string;
  clarity: string;
  cut: string;
  price: number;
  quantity: number;
  warrantyPeriod: number;
  lastUpdate: string;
  status: string;
  pictures: {
    id: string;
    urlPath: string;
  }[];
}

interface DiamondModalProps {
  open: boolean;
  handleClose: () => void;
  handleSave: (diamond: Partial<Diamond>) => void;
  initialData: Partial<Diamond> | null;
}

const DiamondModal: React.FC<DiamondModalProps> = ({
  open,
  handleClose,
  handleSave,
  initialData,
}) => {
  const [diamondData, setDiamondData] = useState<Partial<Diamond>>({
    shape: "",
    color: "",
    origin: "",
    certificationUrl: null,
    caratWeight: "",
    clarity: "",
    cut: "",
    price: 0,
    quantity: 0,
    warrantyPeriod: 0,
    status: "",
    pictures: [],
  });

  useEffect(() => {
    if (initialData) {
      setDiamondData(initialData);
    }
  }, [initialData]);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setDiamondData((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = () => {
    handleSave(diamondData);
  };

  return (
    <Dialog open={open} onClose={handleClose}>
      <DialogTitle>
        {diamondData.id ? "Edit Diamond" : "Add Diamond"}
      </DialogTitle>
      <DialogContent>
        <TextField
          margin="dense"
          label="Name"
          name="name"
          fullWidth
          value={diamondData.shape || ""}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Color"
          name="color"
          fullWidth
          value={diamondData.color || ""}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Origin"
          name="origin"
          fullWidth
          value={diamondData.origin || ""}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Certification URL"
          name="certificationUrl"
          fullWidth
          value={diamondData.certificationUrl || ""}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Carat Weight"
          name="caratWeight"
          fullWidth
          value={diamondData.caratWeight || ""}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Clarity"
          name="clarity"
          fullWidth
          value={diamondData.clarity || ""}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Cut"
          name="cut"
          fullWidth
          value={diamondData.cut || ""}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Price"
          name="price"
          type="number"
          fullWidth
          value={diamondData.price || 0}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Quantity"
          name="quantity"
          type="number"
          fullWidth
          value={diamondData.quantity || 0}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Warranty Period"
          name="warrantyPeriod"
          type="number"
          fullWidth
          value={diamondData.warrantyPeriod || 0}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          label="Status"
          name="status"
          fullWidth
          value={diamondData.status || ""}
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

export default DiamondModal;
