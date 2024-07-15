import React from 'react'
import Header from '../Components/Layout/Header';
import Footer from '../Components/Layout/Footer';

type Props = {}

const NotFoundPage = (props: Props) => {
    return (
        <>
            <Header />
            <div className='flex justify-center items-center my-44 flex-col'>
                <h1 className='font-bold text-5xl'>404 NOT FOUND</h1>
                <br />
                <p className='text-center'>The page you are looking for might have been removed had its name changed or is temporarily unavailable</p>
            </div>
            <Footer />
        </>
    );
};

export default NotFoundPage;