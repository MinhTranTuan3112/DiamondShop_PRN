import Header from "../../Components/Layout/Header";
import Footer from "../../Components/Layout/Footer";
import LoginForm from "../../Components/Layout/Auth/LoginForm";

type Props = {};

const LoginPage = (props: Props) => {
  return (
    <>
      <Header />
      <div
        style={{
          height: "500px",
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          background: "linear-gradient(to right, #FFE5B4, #FFC085)",
        }}
      >
        <LoginForm />
      </div>
      <Footer />
    </>
  );
};

export default LoginPage;
