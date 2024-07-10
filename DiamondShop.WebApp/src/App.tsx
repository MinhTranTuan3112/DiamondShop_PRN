import { BrowserRouter, Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import Profile from "./pages/User/Profile";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import LoginPage from "./pages/Auth/LoginPage";
import AuthorizedRoute from "./Components/AuthorizedRoute";
import TestPage from "./pages/TestPage";
import ProductDetailsPage from "./pages/Product/details";
import Checkout from "./pages/Checkout/Checkout";
import Admin from "./pages/Admin/Admin";
import NotFoundPage from "./pages/NotFound";
import ProductsPage from "./pages/Product";

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
          <Route path="/dashboard" element={<Admin />} />

          <Route
            element={
              <AuthorizedRoute role={"customer"} redirectPath={"/login"} />
            }
          />
          <Route element={<TestPage />} path="/test" />
          {/* <Route path="/products" element={<Products />} /> */}
          <Route path="/products" element={<ProductsPage />} />
          <Route
            element={
              <AuthorizedRoute role={"customer"} redirectPath={"/login"} />
            }
          >
            <Route element={<TestPage />} path="/test" />
          </Route>
          <Route path="/products/:id" element={<ProductDetailsPage />}></Route>
          <Route path="/products/:id" element={<ProductDetailsPage />}></Route>

          <Route path="*" element={<NotFoundPage />} />
        </Routes>
      </BrowserRouter>
    </QueryClientProvider>
  );
}

export default App;
