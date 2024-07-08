import React, { useState, useEffect } from "react";
import { Modal, Box, TextField, Button } from "@mui/material";

interface ProductModalProps {
  open: boolean;
  handleClose: () => void;
  handleSave: (product: Partial<Product>) => void;
  initialData?: Partial<Product>;
}

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 400,
  bgcolor: "background.paper",
  boxShadow: 24,
  p: 4,
};

const ProductModal: React.FC<ProductModalProps> = ({
  open,
  handleClose,
  handleSave,
  initialData,
}) => {
  const [product, setProduct] = useState<Partial<Product>>({
    name: "",
    type: "",
    material: "",
    gender: "",
    price: 0,
    point: 0,
    quantity: 0,
    category: {
      name: "",
    },
    pictures: [],
  });

  useEffect(() => {
    if (initialData) {
      setProduct(initialData);
    } else {
      setProduct({
        name: "",
        type: "",
        material: "",
        gender: "",
        price: 0,
        point: 0,
        quantity: 0,
        category: {
          name: "",
        },
        pictures: [],
      });
    }
  }, [initialData]);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setProduct((prev) => ({ ...prev, [name]: value }));
  };

  return (
    <Modal
      open={open}
      onClose={handleClose}
      aria-labelledby="modal-modal-title"
      aria-describedby="modal-modal-description"
    >
      <Box sx={style}>
        <h2>{initialData ? "Edit Product" : "Add Product"}</h2>
        <TextField
          fullWidth
          margin="normal"
          name="name"
          label="Name"
          value={product.name}
          onChange={handleChange}
        />
        <TextField
          fullWidth
          margin="normal"
          name="type"
          label="Type"
          value={product.type}
          onChange={handleChange}
        />
        <TextField
          fullWidth
          margin="normal"
          name="material"
          label="Material"
          value={product.material}
          onChange={handleChange}
        />
        <TextField
          fullWidth
          margin="normal"
          name="gender"
          label="Gender"
          value={product.gender}
          onChange={handleChange}
        />
        <TextField
          fullWidth
          margin="normal"
          name="price"
          label="Price"
          type="number"
          value={product.price}
          onChange={handleChange}
        />
        <TextField
          fullWidth
          margin="normal"
          name="point"
          label="Point"
          type="number"
          value={product.point}
          onChange={handleChange}
        />
        <TextField
          fullWidth
          margin="normal"
          name="quantity"
          label="Quantity"
          type="number"
          value={product.quantity}
          onChange={handleChange}
        />
        <TextField
          fullWidth
          margin="normal"
          name="category.name"
          label="Category"
          value={product.category?.name}
          onChange={(e) =>
            setProduct((prev) => ({
              ...prev,
              category: { ...prev.category, name: e.target.value },
            }))
          }
        />
        <div
          style={{
            display: "flex",
            alignItems: "center",
            justifyContent: "space-between",
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
            onClick={() => handleSave(product)}
          >
            Save
          </Button>
        </div>
      </Box>
    </Modal>
  );
};

export default ProductModal;
