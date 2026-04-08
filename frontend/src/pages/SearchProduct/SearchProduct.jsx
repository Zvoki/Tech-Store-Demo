import { useEffect, useState } from "react";
import { useSearchParams, useNavigate } from "react-router-dom";
import { useCart } from "../../hooks/useCart";
import "./SearchProduct.scss";

function SearchProduct() {
  const [mainProduct, setMainProduct] = useState(null);
  const [similarProducts, setSimilarProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  const [searchParams] = useSearchParams();
  const query = searchParams.get("q");

  const { addToCart } = useCart();
  const navigate = useNavigate();

  useEffect(() => {
    if (!query?.trim()) {
      setError("No search query provided.");
      setLoading(false);
      return;
    }

    const fetchData = async () => {
      try {
        setLoading(true);
        setError("");

        const res = await fetch(
          `http://localhost:5239/api/product/search?q=${encodeURIComponent(query)}`
        );

        if (!res.ok) throw new Error("Error fetching search results");

        const data = await res.json();

        setMainProduct(data.mainProduct);
        setSimilarProducts(data.similarProducts || []);
      } catch (err) {
        setError(err.message || "Unknown error");
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [query]);

  // 🧠 PRO CART HANDLER (igual que ProductDetail)
  const handleAddToCart = (product) => {
    if (!product) return;

    addToCart({
      id: product.id,
      name: product.name,                                   
      sku: product.sku,
      price: product.price,
      imageUrl: product.imageUrl,
    });
   
    const msg = document.createElement("div");
    msg.className = "ts-inline-message";
    msg.textContent = "Added to checkout ☻";

    const parent = event.target.parentElement;
    parent.appendChild(msg);

    setTimeout(() => {
    msg.remove();
    navigate("/checkout");
    }, 3000);
    };

  if (loading)
    return <div className="search-loading">Loading search results...</div>;

  if (error)
    return <div className="search-error">Error: {error}</div>;

  if (!mainProduct)
    return <div className="search-empty">No product found.</div>;

  return (
    <div className="search-container">
      <h1 className="search-title">
        Search results for: {query}
      </h1>

      {/* MAIN PRODUCT */}
      <section className="main-product-section">
        <h2>Main Product</h2>

        <div className="main-product-card">
          <img
            src={mainProduct.imageUrl}
            alt={mainProduct.name}
            className="main-product-image"
          />

          <h3>{mainProduct.name}</h3>
          <p>SKU: {mainProduct.sku}</p>
          <p>Price: €{mainProduct.price}</p>
          <p>Category: {mainProduct.category?.name}</p>
          <p>{mainProduct.description}</p>

          <button
            type="button"
            className="btn-add"
            onClick={() => handleAddToCart(mainProduct)}
          >
            Add to cart
          </button>
        </div>
      </section>

      {/* SIMILAR PRODUCTS */}
      <section className="similar-products-section">
        <h2>Similar products</h2>

        <div className="similar-grid">
          {similarProducts.map((p) => (
            <div key={p.id} className="similar-card">
              <img
                src={p.imageUrl}
                alt={p.name}
                className="similar-image"
              />

              <div className="similar-name">{p.name}</div>
              <div className="similar-sku">{p.sku}</div>

              <button
                type="button"
                className="btn-add"
                onClick={() => handleAddToCart(p)}
              >
                Add to cart
              </button>
            </div>
          ))}
        </div>
      </section>
    </div>
  );
}

export default SearchProduct;