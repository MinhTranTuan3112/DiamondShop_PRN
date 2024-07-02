import { BrowserRouter, Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import Profile from "./pages/User/Profile";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import LoginPage from "./pages/Auth/LoginPage";
import AuthorizedRoute from "./Components/AuthorizedRoute";
import TestPage from "./pages/TestPage";
import Checkout from "./pages/Checkout/Checkout";

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
          <Route
            element={
              <AuthorizedRoute role={"customer"} redirectPath={"/login"} />
            }
          >
            <Route element={<TestPage />} path="/test" />
          </Route>
        </Routes>
      </BrowserRouter>
    </QueryClientProvider>
  );
}

export default App;
