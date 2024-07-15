import React from 'react'
import Header from '../../Components/Layout/Header';
import Footer from '../../Components/Layout/Footer';
import DiamondPageContent from '../../Components/Diamond/DiamondPageContent';
import "./styles.css";
type Props = {}

const DiamondsPage = (props: Props) => {
    return (
        <>
          <Header/>
          <DiamondPageContent/>
          <Footer/>
        </>
    );
};

export default DiamondsPage;