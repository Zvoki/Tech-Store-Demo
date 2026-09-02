import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { useCart } from "../../hooks/useCart";
import { useNavigate } from "react-router-dom";
import "./ProductDetail.scss";
import { API_URL } from "../../config";
import Messages from "../../components/Messages/Messages";

function ProductDetail() {
  const { id } = useParams();
  const { addToCart } = useCart();
  const navigate = useNavigate();

  const [product, setProduct] = useState(null);
  const [similarProducts, setSimilarProducts] = useState([]);
  const [loading, setLoading] = useState(true);
// FETCH PRODUCT ON MOUNT
  useEffect(() => {
    fetch(`${API_URL}/product/${id}`)
      .then((res) => res.json())
      .then((data) => {
        setProduct(data);
        setLoading(false);
      })
      .catch(() => setLoading(false));
  }, [id]);

  useEffect(() => {
    if (!product) return;

    fetch(`${API_URL}/product/search?q=${product.sku}`)
      .then((res) => res.json())
      .then((data) => {
        setSimilarProducts(data.similarProducts || []);
      });
  }, [product]);

 if (loading) {
  return <Messages code="product.loading" className="product-loading" />;
}

  if (!product) return <Messages code="product.notfound" className="product-error" />;

  const handleAddToCart = () => {
    addToCart({
      id: product.id,
      name: product.name,
      sku: product.sku,
      price: product.price,
      imageUrl: product.imageUrl,
    });

    navigate("/checkout");
  };

  return (
    <div className="product-detail-page">

      {/* MAIN PRODUCT */}
      <div className="product-main">

        <img src={product.imageUrl} alt={product.name} />

        <div className="product-info">
          <h1>{product.name}</h1>

          <div className="product-meta">
            <p>SKU: {product.sku}</p>
            <p>Brand: {product.brand}</p>
            <p>Price: €{product.price}</p>
          </div>

          <p>{product.description}</p>

          <button className="btn-add-main" onClick={handleAddToCart}>
            Add to cart
          </button>
        </div>
      </div>

      {/* SIMILAR PRODUCTS   x 6*/}
      <div className="similar-section">
        <h2>Similar products</h2>

        <div className="similar-grid">
          {similarProducts.map((p) => (
            <div className="similar-card" key={p.id}>
              <img src={p.imageUrl} alt={p.name} />

              <div className="similar-name">{p.name}</div>
              <div className="similar-sku">{p.sku}</div>

              <button
                className="btn-add-small"
                onClick={() => {
                addToCart({
                  id: p.id,
                  name: p.name,
                  sku: p.sku,
                  price: p.price,
                  imageUrl: p.imageUrl,
                });

            // ✅ Crear mensaje inline futurista
            const msg = document.createElement("div");
            msg.className = "ts-inline-message";
            msg.textContent = "Added to checkout ☺";

            // ✅ Insertarlo justo debajo del botón presionado
            const parent = event.target.parentElement;
            parent.appendChild(msg);

            // ✅ Eliminarlo después de 2 segundos
            setTimeout(() => msg.remove(), 3000);
            }}
            >
            Add to cart
            </button>

                 
            </div>
          ))}
        </div>
      </div>

    </div>
  );
}

export default ProductDetail;