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
} from "@mui/material";

interface ProductModalProps {
  open: boolean;
  handleClose: () => void;
  handleSave: (product: Partial<Product>) => void;
  initialData?: Partial<Product>;
  categories: { id: string; name: string }[];
  productId?: string;
  fetchProductById: (id: string) => Promise<Partial<Product>>;
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
  categories,
  productId,
  fetchProductById,
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
      id: "",
      name: "",
    },
    pictures: [],
  });

  useEffect(() => {
    if (productId) {
      fetchProductById(productId).then(setProduct);
    } else if (initialData) {
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
          id: "",
          name: "",
        },
        pictures: [],
      });
    }
  }, [productId, initialData, fetchProductById]);

  const handleChange = (
    e: React.ChangeEvent<
      HTMLInputElement | HTMLTextAreaElement | { name?: string; value: unknown }
    >
  ) => {
    const { name, value } = e.target;
    setProduct((prev) => ({ ...prev, [name as string]: value }));
  };

  const handleCategoryChange = (
    event: React.ChangeEvent<{ value: unknown }>
  ) => {
    const selectedCategory = categories.find(
      (category) => category.id === event.target.value
    );
    setProduct((prev) => ({
      ...prev,
      category: {
        id: selectedCategory?.id,
        name: selectedCategory?.name,
      },
    }));
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
          value={product.name || ""}
          onChange={handleChange}
        />
        <FormControl fullWidth margin="normal">
          <InputLabel id="type-label">Type</InputLabel>
          <Select
            labelId="type-label"
            name="type"
            value={product.type}
            onChange={handleChange}
            label="Type"
          >
            <MenuItem value={"Ring"}>Ring</MenuItem>
            <MenuItem value={"Necklace"}>Necklace</MenuItem>
            <MenuItem value={"Bracelet"}>Bracelet</MenuItem>
            <MenuItem value={"Earring"}>Earring</MenuItem>
            <MenuItem value={"Watch"}>Watch</MenuItem>
            <MenuItem value={"Diamond"}>Diamond</MenuItem>
            <MenuItem value={"Gemstone"}>Gemstone</MenuItem>
            <MenuItem value={"Pearl"}>Pearl</MenuItem>
            <MenuItem value={"Other"}>Other</MenuItem>
          </Select>
        </FormControl>
        <TextField
          fullWidth
          margin="normal"
          name="material"
          label="Material"
          value={product.material || ""}
          onChange={handleChange}
        />
        <TextField
          fullWidth
          margin="normal"
          name="gender"
          label="Gender"
          value={product.gender || ""}
          onChange={handleChange}
        />
        <TextField
          fullWidth
          margin="normal"
          name="price"
          label="Price"
          type="number"
          value={product.price || ""}
          onChange={handleChange}
        />
        <TextField
          fullWidth
          margin="normal"
          name="point"
          label="Point"
          type="number"
          value={product.point || ""}
          onChange={handleChange}
        />
        <TextField
          fullWidth
          margin="normal"
          name="quantity"
          label="Quantity"
          type="number"
          value={product.quantity || ""}
          onChange={handleChange}
        />
        <FormControl fullWidth margin="normal">
          <InputLabel id="category-label">Category</InputLabel>
          <Select
            labelId="category-label"
            value={product.category?.id || ""}
            onChange={handleCategoryChange}
          >
            {categories.map((category) => (
              <MenuItem key={category.id} value={category.id}>
                {category.name}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
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
