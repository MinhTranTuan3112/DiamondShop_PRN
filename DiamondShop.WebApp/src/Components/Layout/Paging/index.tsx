import Pagination from "@mui/material/Pagination";
import Stack from "@mui/material/Stack";
import { useState } from "react";

export default function Paging() {
  const [page, setPage] = useState(1);
  const handleChange = (event: React.ChangeEvent<unknown>, value: number) => {
    setPage(value);
  };

  return (
    <div
      style={{
        display: "flex",
        justifyContent: "center",
        height: "100px",
        alignItems: "center",
      }}
    >
      <Stack spacing={2}>
        <Pagination
          count={10}
          page={page}
          onChange={handleChange}
          size="large"
          sx={{
            "& .MuiPaginationItem-root": {
              fontSize: "1.2rem",
              fontWeight: "500",
            },
            "& .Mui-selected": {
              backgroundColor: "#FFD700",
              color: "white",
              fontSize: "1.5rem",
            },
          }}
        />
      </Stack>
    </div>
  );
}
