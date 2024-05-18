import Header from "../../Components/Layout/Header";
import Footer from "../../Components/Layout/Footer";

export default function Home() {
  return (
    <div className="container">
      <Header />
      <div style={{ height: "1000px" }}></div>
      <div className="main-content">
        <Footer />
      </div>
    </div>
  );
}
