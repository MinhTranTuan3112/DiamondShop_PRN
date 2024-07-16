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
import {
  fetchDashboardStats,
  DashboardStats,
  fetchDataForMonthLineChat,
} from "./APIClient";
import MyLineChart from "./MyLineChart";

const theme = createTheme({
  typography: {
    fontSize: 15,
    htmlFontSize: 15,
  },
});

const Dashboard: React.FC = () => {
  const [stats, setStats] = useState<DashboardStats | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [totalOrderEachMonth, settotalOrderEachMonth] = useState([]);
  const [totalRevenueEachMonth, settotalRevenueEachMonth] = useState([]);
  const [averageOrderValueEachMonth, setaverageOrderValueEachMonth] = useState(
    []
  );

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

    const fetchChartData = async () => {
      const allData = [];
      for (let month = 1; month <= 12; month++) {
        const monthlyData = await fetchDataForMonthLineChat(month);
        allData.push({
          month: `Month ${month}`,
          totalOrders: monthlyData.totalOrders,
          totalRevenue: monthlyData.totalRevenue,
          averageOrderValue: monthlyData.averageOrderValue,
          diamondCount: monthlyData.diamondCount,
          productCount: monthlyData.productCount,
        });
      }

      settotalOrderEachMonth(allData.map((item) => item.totalOrders));
      settotalRevenueEachMonth(allData.map((item) => item.totalRevenue));
      setaverageOrderValueEachMonth(
        allData.map((item) => item.averageOrderValue)
      );

      setStats({
        ...stats,
        numberOfDiamonds: allData[0].diamondCount,
        numberOfProducts: allData[0].productCount,
        revenue: allData[0].totalRevenue,
        profit: 0,
      });
    };

    getStats();
    fetchChartData();
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
                  <Typography variant="h4">
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
                  <Typography variant="h4">
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
                  <Typography variant="h4">
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
                  <Typography variant="h4">
                    ${stats?.profit.toLocaleString() ?? 0}
                  </Typography>
                </CardContent>
              </Card>
            </Grid>
          </Grid>
        )}

        <MyLineChart
          averageOrderValue={averageOrderValueEachMonth}
          totalOrderEachMonth={totalOrderEachMonth}
          totalRevenueEachMonth={totalRevenueEachMonth}
        />
      </div>
    </ThemeProvider>
  );
};

export default Dashboard;
