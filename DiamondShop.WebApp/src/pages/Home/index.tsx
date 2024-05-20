import Header from "../../Components/Layout/Header";
import Footer from "../../Components/Layout/Footer";

export default function Home() {
  return (
    <div className="">
      <Header />
      <div style={{ height: "1000px" }}>
        <p className="text-red-600 text-center">Hello World</p>
      </div>
      <Footer />
    </div>
  );
}
