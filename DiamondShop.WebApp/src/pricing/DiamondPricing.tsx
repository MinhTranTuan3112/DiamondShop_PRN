import React from 'react';
import Header from '../Components/Layout/Header';
import Footer from '../Components/Layout/Footer';
import DiamondPriceTable from '../Components/Diamond/DiamondPriceTable';

type Props = {

}

const DiamondPricingPage = (props: Props) => {
    return (
        <>
            <Header />
            <div className="w-[1170px] max-w-[calc(100%-48px)] mx-auto py-32">
                <h1 className='font-bold text-center mb-4'>Bảng giá kim cương MAPTH</h1>
                <DiamondPriceTable/>
            </div>
            <Footer />
        </>
    );
};

export default DiamondPricingPage;  