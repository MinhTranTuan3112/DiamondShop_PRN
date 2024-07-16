import React, { useState } from "react";
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

interface CertificateModalProps {
  open: boolean;
  handleClose: () => void;
  handleSave: (certificate: Partial<Certificate>) => void;
  certificateId?: string;
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

const CertificateModal: React.FC<CertificateModalProps> = ({
  open,
  handleClose,
  handleSave,
}) => {
  const [certificate, setCertificate] = useState<Partial<Certificate>>({
    reportNumber: "",
    origin: "",
    shape: "",
    color: "",
    clarity: "",
    cut: "",
    caratWeight: "",
    dateOfIssue: "",
  });

  const handleChange = (
    e: React.ChangeEvent<
      HTMLInputElement | HTMLTextAreaElement | { name?: string; value: unknown }
    >
  ) => {
    const { name, value } = e.target;
    setCertificate((prev) => ({ ...prev, [name as string]: value }));
  };

  return (
    <Modal
      open={open}
      onClose={handleClose}
      aria-labelledby="modal-modal-title"
      aria-describedby="modal-modal-description"
    >
      <Box sx={style}>
        <h2>Add Certificate</h2>
        <Grid container spacing={2}>
          <Grid item xs={6}>
            <TextField
              fullWidth
              margin="normal"
              name="reportNumber"
              label="Report Number"
              value={certificate.reportNumber || ""}
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={6}>
            <FormControl fullWidth margin="normal">
              <InputLabel id="origin-label">Origin</InputLabel>
              <Select
                labelId="origin-label"
                name="origin"
                value={certificate.origin}
                onChange={handleChange}
                label="Origin"
              >
                <MenuItem value="AGS">AGS</MenuItem>
                <MenuItem value="GIA">GIA</MenuItem>
                <MenuItem value="IGI">IGI</MenuItem>
                <MenuItem value="HRD">HRD</MenuItem>
                <MenuItem value="EGL">EGL</MenuItem>
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <TextField
              fullWidth
              margin="normal"
              name="shape"
              label="Shape"
              value={certificate.shape || ""}
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              fullWidth
              margin="normal"
              name="color"
              label="Color"
              value={certificate.color || ""}
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              fullWidth
              margin="normal"
              name="clarity"
              label="Clarity"
              value={certificate.clarity || ""}
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              fullWidth
              margin="normal"
              name="cut"
              label="Cut"
              value={certificate.cut || ""}
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
              value={certificate.caratWeight || ""}
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              fullWidth
              margin="normal"
              name="dateOfIssue"
              label="Date of Issue"
              type="date"
              InputLabelProps={{
                shrink: true,
              }}
              value={certificate.dateOfIssue || ""}
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
            onClick={() => handleSave(certificate)}
          >
            Save
          </Button>
        </div>
      </Box>
    </Modal>
  );
};

export default CertificateModal;
