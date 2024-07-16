import { BrowserRouter, Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import Profile from "./pages/User/Profile";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import RegisterPage from "./pages/Auth/RegisterPage";
import LoginPage from "./pages/Auth/LoginPage";
import AuthorizedRoute from "./Components/AuthorizedRoute";
import TestPage from "./pages/TestPage";
import ProductDetailsPage from "./pages/Product/details";
import Checkout from "./pages/Checkout/Checkout";
import Admin from "./pages/Admin/Admin";
import NotFoundPage from "./pages/NotFound";
import ProductsPage from "./pages/Product";
import Order from "./pages/Order/Order";
import DiamondPricingPage from "./pricing/DiamondPricing";
import DiamondsPage from "./pages/Diamond";
import DiamondDetailsPage from "./pages/Diamond/details";
import OrderDetails from "./pages/Order/OrderDetail";

const queryClient = new QueryClient();

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/user" element={<Profile />} />
          <Route path="/checkout" element={<Checkout />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/dashboard" element={<Admin />} />
          <Route path="/order" element={<Order />} />
          <Route path="/pricing" element={<DiamondPricingPage />} />
          <Route path="/diamonds" element={<DiamondsPage />} />
          <Route path="/pricing" element={<DiamondPricingPage/>}/>
          <Route path="/order/:id" element={<OrderDetails />} />
          <Route
            element={
              <AuthorizedRoute role={"customer"} redirectPath={"/login"} />
            }>
            <Route element={<TestPage />} path="/test" />
          </Route>
          <Route path="/products" element={<ProductsPage />} />
          <Route path="/products/:id" element={<ProductDetailsPage />}></Route>
          <Route path="/diamonds/:id" element={<DiamondDetailsPage />}></Route>
          <Route path="*" element={<NotFoundPage />} />
        </Routes>
      </BrowserRouter>
    </QueryClientProvider>
  );
}

export default App;
