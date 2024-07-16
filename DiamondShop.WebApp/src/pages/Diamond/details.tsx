import DiamondDetailsPageContent from "../../Components/Diamond/DiamondDetailsPageContent";
import Footer from "../../Components/Layout/Footer";
import Header from "../../Components/Layout/Header";
import './details.css';
type Props = {}

const DiamondDetailsPage = (props: Props) => {
  
    return (
        <>
        <Header/>
        <DiamondDetailsPageContent/>
        <Footer/>
        </>
    );
};

export default DiamondDetailsPage;