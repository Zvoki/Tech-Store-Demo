import "./Footer.scss";

function Footer() {
  return (
    <footer className="footer">
      <div className="footer-container">

        {/* LEFT */}
        <div className="footer-brand">
          <h2>TekStore</h2>
          <p>Your tech marketplace</p>
        </div>

        {/* CENTER */}
        <div className="footer-links">
          <h4>Navigation</h4>
          <a href="/">Home</a>
          <a href="/products">Products</a>
          <a href="/checkout">Checkout</a>
          <a href="/admin">Admin</a>
        </div>

        {/* RIGHT */}
        <div className="footer-social">
          <h4>Follow</h4>
          <div className="icons">
            <span>🐦</span>
            <span>📸</span>
            <span>💼</span>
          </div>
        </div>

      </div>

      <div className="footer-bottom">
        <p>© 2026 TekStore. All rights reserved.</p>
        <p>Designed by KodinGaston - REMOVED_CONTACT</p>
      </div>
    </footer>
  );
}

export default Footer;