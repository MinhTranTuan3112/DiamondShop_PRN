import Header from "../../Components/Layout/Header";
import Footer from "../../Components/Layout/Footer";
import Register from "../../Components/Layout/Auth/RegisterForm";

type Props = {};

const RegisterPage = (props: Props) => {
  return (
    <>
      <Header />
      <div
        style={{
          height: "600px",
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          background: "linear-gradient(to right, #FFE5B4, #FFC085)",
        }}
      >
        <Register />
      </div>
      <Footer />
    </>
  );
};

export default RegisterPage;
