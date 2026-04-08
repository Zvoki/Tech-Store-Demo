import { BrowserRouter, Routes, Route } from "react-router-dom";
import { CartProvider } from "../hooks/CartContext";
import Layout from "../components/Layout/Layout";
import Home from "../pages/Home/Home";
import Products from "../pages/Products/products";
import ProductDetail from "../pages/ProductDetail/ProductDetail";
import Admin from "../pages/Admin/Admin"; 
import Checkout from "../pages/Checkout/Checkout";
import SearchProduct from "../pages/SearchProduct/SearchProduct";

function AppRoutes() {
  return (
    <BrowserRouter>
      <CartProvider>
        <Layout>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/search" element={<SearchProduct />} />
            <Route path="/products" element={<Products />} />
            <Route path="/product/:id" element={<ProductDetail />} />
            <Route path="/admin" element={<Admin />} /> {/* ← NUEVO */}
            <Route path="/checkout" element={<Checkout />} />
          </Routes>
        </Layout>
      </CartProvider>
    </BrowserRouter>
  );
}

export default AppRoutes;