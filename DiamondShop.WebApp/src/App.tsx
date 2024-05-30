import { BrowserRouter, Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import Profile from "./pages/User";
import ProductsPage from "./pages/Products";
function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/user" element={<Profile />} />
        <Route path={'/products'} element={<ProductsPage/>}/>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
