import { LineChart } from "@mui/x-charts/LineChart";

interface props {
  totalOrderEachMonth: Array<number>;
  totalRevenueEachMonth: Array<number>;
  averageOrderValue: Array<number>;
}
const MyLineChart = ({ totalOrderEachMonth, totalRevenueEachMonth,averageOrderValue }: props) => {
  return (
    <LineChart
      width={500}
      height={300}
      series={[
        { data: totalOrderEachMonth, label: "totalOrderEachMonth" },
        { data: totalRevenueEachMonth, label: "totalRevenueEachMonth" },
        { data: averageOrderValue, label: "averageOrderValue" },
      ]}
      xAxis={[
        { scaleType: "point", data: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
      ]}
    />
  );
};

export default MyLineChart;
