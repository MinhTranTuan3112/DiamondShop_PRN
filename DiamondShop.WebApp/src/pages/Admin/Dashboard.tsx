import React, { useState, useEffect } from "react";
import {
  Card,
  CardContent,
  Typography,
  Grid,
  CircularProgress,
  ThemeProvider,
  createTheme,
} from "@mui/material";
import DiamondIcon from "@mui/icons-material/Diamond";
import InventoryIcon from "@mui/icons-material/Inventory";
import MonetizationOnIcon from "@mui/icons-material/MonetizationOn";
import TrendingUpIcon from "@mui/icons-material/TrendingUp";
import { fetchDashboardStats, DashboardStats } from "./APIClient"; // Adjust this import based on your folder structure

const theme = createTheme({
  typography: {
    fontSize: 15,
    htmlFontSize: 15,
  },
});

const Dashboard: React.FC = () => {
  const [stats, setStats] = useState<DashboardStats | null>(null);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    const getStats = async () => {
      setLoading(true);
      try {
        const data = await fetchDashboardStats();
        setStats(data);
      } catch (error) {
        console.error("Error fetching dashboard stats:", error);
      } finally {
        setLoading(false);
      }
    };

    getStats();
  }, []);

  return (
    <ThemeProvider theme={theme}>
      <div style={{ padding: "20px" }}>
        {loading ? (
          <div
            style={{
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              height: "500px",
            }}
          >
            <CircularProgress style={{ color: "#FFD700" }} />
          </div>
        ) : (
          <Grid container spacing={3}>
            <Grid item xs={12} sm={6} md={3}>
              <Card sx={{ backgroundColor: "#FFE4E1" }}>
                <CardContent>
                  <Typography
                    variant="h5"
                    component="div"
                    sx={{ display: "flex", alignItems: "center", gap: "10px" }}
                  >
                    <DiamondIcon />
                    Diamonds
                  </Typography>
                  <Typography variant="h2">
                    {stats?.numberOfDiamonds ?? 0}
                  </Typography>
                </CardContent>
              </Card>
            </Grid>
            <Grid item xs={12} sm={6} md={3}>
              <Card sx={{ backgroundColor: "#E0F7FA" }}>
                <CardContent>
                  <Typography
                    variant="h5"
                    component="div"
                    sx={{ display: "flex", alignItems: "center", gap: "10px" }}
                  >
                    <InventoryIcon />
                    Products
                  </Typography>
                  <Typography variant="h2">
                    {stats?.numberOfProducts ?? 0}
                  </Typography>
                </CardContent>
              </Card>
            </Grid>
            <Grid item xs={12} sm={6} md={3}>
              <Card sx={{ backgroundColor: "#FFF9C4" }}>
                <CardContent>
                  <Typography
                    variant="h5"
                    component="div"
                    sx={{ display: "flex", alignItems: "center", gap: "10px" }}
                  >
                    <MonetizationOnIcon /> Revenue
                  </Typography>
                  <Typography variant="h2">
                    ${stats?.revenue.toLocaleString() ?? 0}
                  </Typography>
                </CardContent>
              </Card>
            </Grid>
            <Grid item xs={12} sm={6} md={3}>
              <Card sx={{ backgroundColor: "#C8E6C9" }}>
                <CardContent>
                  <Typography
                    variant="h5"
                    component="div"
                    sx={{ display: "flex", alignItems: "center", gap: "10px" }}
                  >
                    <TrendingUpIcon /> Profit
                  </Typography>
                  <Typography variant="h2">
                    ${stats?.profit.toLocaleString() ?? 0}
                  </Typography>
                </CardContent>
              </Card>
            </Grid>
          </Grid>
        )}
      </div>
    </ThemeProvider>
  );
};

export default Dashboard;
