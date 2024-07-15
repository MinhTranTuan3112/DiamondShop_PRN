import React, { useState, useEffect } from "react";
import {
  Modal,
  Box,
  TextField,
  Button,
  MenuItem,
  Select,
  InputLabel,
  FormControl,
  Grid,
} from "@mui/material";
import {
  DiamondShape,
  DiamondOrigin,
  DiamondClarity,
  DiamondCut,
  DiamondColor,
} from "./DiamondEnums"; // Import enums

interface DiamondModalProps {
  open: boolean;
  handleClose: () => void;
  handleSave: (diamond: Partial<Diamond>) => void;
  initialData?: Partial<Diamond>;
  diamondId?: string;
  fetchDiamondById: (id: string) => Promise<Partial<Diamond>>;
}

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 600,
  bgcolor: "background.paper",
  boxShadow: 24,
  p: 4,
};

const DiamondModal: React.FC<DiamondModalProps> = ({
  open,
  handleClose,
  handleSave,
  initialData,
  diamondId,
  fetchDiamondById,
}) => {
  const [diamond, setDiamond] = useState<Partial<Diamond>>({
    shape: "",
    color: "",
    origin: "",
    certificationUrl: "",
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
    if (diamondId) {
      fetchDiamondById(diamondId).then((data) => {
        setDiamond(data);
      });
    } else if (initialData) {
      setDiamond(initialData);
    } else {
      setDiamond({
        shape: "",
        color: "",
        origin: "",
        certificationUrl: "",
        caratWeight: "",
        clarity: "",
        cut: "",
        price: 0,
        quantity: 0,
        warrantyPeriod: 0,
        status: "",
        pictures: [],
      });
    }
  }, [diamondId, initialData, fetchDiamondById]);

  const handleChange = (
    e: React.ChangeEvent<
      HTMLInputElement | HTMLTextAreaElement | { name?: string; value: unknown }
    >
  ) => {
    const { name, value } = e.target;
    setDiamond((prev) => ({ ...prev, [name as string]: value }));
  };

  return (
    <Modal
      open={open}
      onClose={handleClose}
      aria-labelledby="modal-modal-title"
      aria-describedby="modal-modal-description"
    >
      <Box sx={style}>
        <h2>{initialData ? "Edit Diamond" : "Add Diamond"}</h2>
        <Grid container spacing={2}>
          <Grid item xs={6}>
            <FormControl fullWidth margin="normal">
              <InputLabel id="shape-label">Shape</InputLabel>
              <Select
                labelId="shape-label"
                name="shape"
                value={diamond.shape}
                onChange={handleChange}
                label="Shape"
              >
                {Object.values(DiamondShape).map((shape) => (
                  <MenuItem key={shape} value={shape}>
                    {shape}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <FormControl fullWidth margin="normal">
              <InputLabel id="color-label">Color</InputLabel>
              <Select
                labelId="color-label"
                name="color"
                value={diamond.color}
                onChange={handleChange}
                label="color"
              >
                {Object.values(DiamondColor).map((color) => (
                  <MenuItem key={color} value={color}>
                    {color}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <FormControl fullWidth margin="normal">
              <InputLabel id="origin-label">Origin</InputLabel>
              <Select
                labelId="origin-label"
                name="origin"
                value={diamond.origin}
                onChange={handleChange}
                label="Origin"
              >
                {Object.values(DiamondOrigin).map((origin) => (
                  <MenuItem key={origin} value={origin}>
                    {origin}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <FormControl fullWidth margin="normal">
              <InputLabel id="clarity-label">Clarity</InputLabel>
              <Select
                labelId="clarity-label"
                name="clarity"
                value={diamond.clarity}
                onChange={handleChange}
                label="Clarity"
              >
                {Object.values(DiamondClarity).map((clarity) => (
                  <MenuItem key={clarity} value={clarity}>
                    {clarity}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <FormControl fullWidth margin="normal">
              <InputLabel id="cut-label">Cut</InputLabel>
              <Select
                labelId="cut-label"
                name="cut"
                value={diamond.cut}
                onChange={handleChange}
                label="Cut"
              >
                {Object.values(DiamondCut).map((cut) => (
                  <MenuItem key={cut} value={cut}>
                    {cut}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </Grid>
          {/* Remaining fields like certificationUrl, caratWeight, price, quantity, warrantyPeriod */}
          <Grid item xs={6}>
            <TextField
              fullWidth
              margin="normal"
              name="certificationUrl"
              label="Certification URL"
              value={diamond.certificationUrl || ""}
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              fullWidth
              margin="normal"
              name="caratWeight"
              label="Carat Weight"
              type="number"
              value={diamond.caratWeight || ""}
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              fullWidth
              margin="normal"
              name="price"
              label="Price"
              type="number"
              value={diamond.price || ""}
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              fullWidth
              margin="normal"
              name="quantity"
              label="Quantity"
              type="number"
              value={diamond.quantity || ""}
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              fullWidth
              margin="normal"
              name="warrantyPeriod"
              label="Warranty Period"
              type="number"
              value={diamond.warrantyPeriod || ""}
              onChange={handleChange}
            />
          </Grid>
        </Grid>
        <div
          style={{
            display: "flex",
            alignItems: "center",
            justifyContent: "space-between",
            marginTop: "1rem",
          }}
        >
          <Button
            variant="outlined"
            style={{
              border: "1px solid red",
              color: "orangered",
            }}
            onClick={handleClose}
          >
            Cancel
          </Button>
          <Button
            variant="contained"
            style={{ background: "#FFD700" }}
            onClick={() => handleSave(diamond)}
          >
            Save
          </Button>
        </div>
      </Box>
    </Modal>
  );
};

export default DiamondModal;
