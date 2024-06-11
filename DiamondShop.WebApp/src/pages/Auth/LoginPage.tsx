import Header from '../../Components/Layout/Header';
import Footer from '../../Components/Layout/Footer';
import LoginForm from '../../Components/Layout/Auth/LoginForm';

type Props = {}

const LoginPage = (props: Props) => {
    return (
        <>
            <Header />
            <div
                style={{
                    height: "100rem",
                }}
            >
                <LoginForm />
            </div>
            <Footer />
        </>
    );
};

export default LoginPage;