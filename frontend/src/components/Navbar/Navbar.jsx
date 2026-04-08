import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useCart } from "../../hooks/useCart";
import Searcher from "../Searcher/Searcher";
import "./Navbar.scss";

function Navbar() {
  const [menuOpen, setMenuOpen] = useState(false);
  const navigate = useNavigate();
  const { cartItems } = useCart();

  return (
    <>
      <nav className="navbar">
        {/* LEFT */}
        <div className="navbar-left">
          <h2 className="logo">TekStore</h2>
        </div>

        {/* CENTER */}
        <div className="navbar-center">
          <Link to="/">Home</Link>
          <Link to="/products">Products</Link>
          <Link to="/checkout">Checkout</Link>
          <Link to="/admin">Admin</Link>
        </div>

        {/* RIGHT */}
        <div className="navbar-right">
          <Searcher />

          {/* 🛒 CARRITO */}
          <button
            className="cart-btn"
            onClick={() => navigate("/checkout")}
            aria-label="Go to checkout"
          >
            🛒
            {cartItems.length > 0 && (
              <span className="cart-badge">{cartItems.length}</span>
            )}
          </button>

          <button
            className="hamburger"
            onClick={() => setMenuOpen(true)}
          >
            ☰
          </button>
        </div>
      </nav>

      {/* overlay */}
      {menuOpen && (
        <div className="overlay" onClick={() => setMenuOpen(false)} />
      )}

      {/* drawer */}
      <div className={`side-menu ${menuOpen ? "open" : ""}`}>
        <button className="close-btn" onClick={() => setMenuOpen(false)}>
          ✕
        </button>

        <Link to="/" onClick={() => setMenuOpen(false)}>Home</Link>
        <Link to="/products" onClick={() => setMenuOpen(false)}>Products</Link>
        <Link to="/checkout" onClick={() => setMenuOpen(false)}>Checkout</Link>
        <Link to="/admin" onClick={() => setMenuOpen(false)}>Admin</Link>
      </div>
    </>
  );
}

export default Navbar;