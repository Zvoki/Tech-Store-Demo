import { Link } from "react-router-dom";
import "./Home.scss";

export default function Home() {
  const slides = [
    "/img/1laptop.webp", "/img/1mobil.webp",
    "/img/2laptop.webp", "/img/2mobil.webp",
    "/img/3laptop.webp", "/img/4mobil.webp",
    "/img/4laptop.webp", "/img/5mobil.webp",
    "/img/5laptop.webp", "/img/6laptop.webp",
    "/img/7laptop.webp", "/img/6mobil.webp",
    "/img/8laptop.webp", "/img/7mobil.webp",
    "/img/9laptop.webp", "/img/8mobil.webp",
    "/img/10laptop.webp", "/img/2mobil.webp"
  ];

  const doubled = [...slides, ...slides];

  return (
    <div className="home-container">
//Hero section.
      {/* HERO Section */}

      <section className="home-welcome">
        <h1>Welcome to Tek✨Store</h1>
        <p>Premium gaming laptops and next-gen smartphones built for performance.</p>
      </section>

        <section className="home-features">

        <Link to="/products" className="feature-card">
          <h3>⚡ Performance</h3>
          <p>High-speed gaming laptops with extreme power.</p>
        </Link>

        <Link to="/products" className="feature-card">
          <h3>📱 Innovation</h3>
          <p>Smartphones with cutting-edge technology.</p>
        </Link>

        <Link to="/products" className="feature-card">
          <h3>🎮 Gaming Ready</h3>
          <p>Optimized for competitive gaming experience.</p>
        </Link>

        <Link to="/products" className="feature-card">
          <h3>🚀 Fast Delivery</h3>
          <p>Quick shipping and secure checkout worldwide.</p>
        </Link>

      </section>

      {/* BANNER */}
      <section className="home-banner">
        <Link to="/products" className="banner-link">
          <img src="/img/logo.webp" alt="products" />
        </Link>
      </section>

      {/* CAROUSEL (🔥 FIX BIG + VISUAL WEIGHT) */}
      <section className="tek-carousel">

        <h4>✨ Explore our latest devices</h4>

        <div className="carousel-viewport">
          <div className="carousel-track">

            {doubled.map((src, i) => (
              <div className="carousel-slide" key={i}>
                <img src={src} alt="product" />
              </div>
            ))}

          </div>
        </div>

      </section>

      {/* BOTTOM 4 CARDS */}
      <section className="home-bottom">

        <Link to="/products" className="bottom-card">
          <h3>🔥 Built for performance</h3>
          <p>High-end devices optimized for speed and gaming power.</p>
        </Link>

        <Link to="/products" className="bottom-card">
          <h3>🛡️ Secure shopping</h3>
          <p>Encrypted payments and trusted checkout.</p>
        </Link>

        <Link to="/products" className="bottom-card">
          <h3>🚀 Fast delivery</h3>
          <p>Worldwide shipping with fast logistics.</p>
        </Link>

        <Link to="/products" className="bottom-card">
          <h3>⚙️ Latest tech</h3>
          <p>Always updated with newest generation devices.</p>
        </Link>

      </section>

    </div>
  );
}