import Header from "../../Components/Layout/Header";
import Footer from "../../Components/Layout/Footer";
import Filter from "../../Components/Layout/Filter";
import Collections from "./Collections";

export default function Home() {
  return (
    <div className="">
      <Header />
      <Filter />
      <Collections />
      <Footer />
    </div>
  );
}
