import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import "./Products.scss";
import Messages from "../../components/Messages/Messages";
// Function Products: Category + List of products.
function Products() {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [viewMode, setViewMode] = useState("category");
  const [selectedType, setSelectedType] = useState(null);

  // FETCH PRODUCTS ON MOUNT
  useEffect(() => {
    fetch("http://localhost:5239/api/product")
      .then((res) => res.json())
      .then((data) => {
        setProducts(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Error fetching products:", err);
        setLoading(false);
      });
  }, []);

  // PRELOAD IMAGES
  useEffect(() => {
    if (!products.length) return;

    products.forEach((p) => {
      const img = new Image();
      img.src = p.imageUrl;
    });
  }, [products]);

    if (loading) {
    return <Messages code="products.loading" className="products-loading" />;
  }

  const handleChooseCategory = (type) => {
    setSelectedType(type);
    setViewMode("list");
  };

  const handleBackToCategory = () => {
    setViewMode("category");
    setSelectedType(null);
  };

  const categoryId =
    selectedType === "mobile" ? 1 :
    selectedType === "laptop" ? 2 :
    null;

  const filteredProducts = categoryId
    ? products.filter((p) => p.categoryId === categoryId)
    : [];

  return (
    <div className="products-container">

      {/* CATEGORY VIEW (PERSISTENT DOM) */}
      <div style={{ display: viewMode === "category" ? "block" : "none" }}>
        <h1 className="category-title">Category</h1>
        <h2 className="category-subtitle">Choose your category</h2>

        <div className="category-grid">
          <button
            className="category-card"
            onClick={() => handleChooseCategory("mobile")}
          >
            <img
              src="/img/10mobil.webp"
              alt="Futuristic Smartphones"
              className="category-image"
              loading="lazy"
            />
            <h3 className="category-name">Futuristic Smartphones</h3>
          </button>

          <button
            className="category-card"
            onClick={() => handleChooseCategory("laptop")}
          >
            <img
              src="/img/5laptop.webp"
              alt="Super Gamer Laptops"
              className="category-image"
              loading="lazy"
            />
            <h3 className="category-name">Super Gamer Laptops</h3>
          </button>
        </div>
      </div>

      {/* LIST VIEW (PERSISTENT DOM) */}
      <div style={{ display: viewMode === "list" ? "block" : "none" }}>
        <h1 className="products-title">
          {selectedType === "mobile"
            ? "All Futuristic Smartphones"
            : "All Super Gamer Laptops"}
        </h1>

        <div className="products-grid">
          {filteredProducts.map((p) => (
            <article key={p.id} className="product-card">
              <img src={p.imageUrl} alt={p.name} className="product-image" />

              <Link to={`/product/${p.id}`} className="product-name">
                <h3>{p.name}</h3>
              </Link>

              <p className="product-sku">SKU: {p.sku}</p>
              <p className="product-brand">Brand: {p.brand}</p>
              <p className="product-price">€{p.price}</p>

              <Link to={`/product/${p.id}`}>
                <button className="btn-view">View</button>
              </Link>
            </article>
          ))}
        </div>

        <button className="btn-back" onClick={handleBackToCategory}>
          Back to Category
        </button>
      </div>

    </div>
  );
}

export default Products;