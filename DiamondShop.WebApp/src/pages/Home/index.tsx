import Header from "../../Components/Layout/Header";
import Footer from "../../Components/Layout/Footer";
import Filter from "../../Components/Layout/Filter";

export default function Home() {
  return (
    <div className="">
      <Header />
      <div
        style={{
          height: "500px",
          background: "#ccc",
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
        }}
      >
        <Filter />
      </div>
      <Footer />
    </div>
  );
}
