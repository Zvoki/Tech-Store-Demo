import { useCart } from "../../hooks/useCart";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import confetti from "canvas-confetti";
import "./Checkout.scss";
import Messages from "../../components/Messages/Messages";
import { API_URL } from "../../config";

export default function Checkout() {
  const { cartItems, updateQuantity, removeFromCart, cartTotal, clearCart } = useCart();
  const navigate = useNavigate();
  
  console.log("CART:", cartItems);

  // FORM
  const [client, setClient] = useState({
    firstName: "",
    lastName: "",
    email: "",
    phone: "",
    street: "",
    postcode: "",
    city: "",
    country: "",
    wantsNewsletter: false,
  });
  
  // SUCCESS MESSAGE STATE
  const [successMessage, setSuccessMessage] = useState(false);

  function handleClientChange(e) {
    setClient({ ...client, [e.target.name]: e.target.value });
  }

  async function handleBuy(e) {
    e.preventDefault();

    const payload = {
      client,
      items: cartItems.map((item) => ({
        sku: item.sku,
        productName: item.name,
        quantity: item.quantity,
        priceUnit: item.price,
        priceTotal: item.price * item.quantity,
      })),
    };

    try {
      const res = await fetch(`${API_URL}/buy`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
      });

      const data = await res.json();

      if (data.success) {
        // CONFETTI
        confetti({ particleCount: 500, spread: 200 });

        // CLEAR CART
        clearCart();

        // SHOW SUCCESS MESSAGE
        setSuccessMessage(true);

        // REDIRECT AFTER 10 SECONDS
        setTimeout(() => {
          navigate("/");
        }, 10000);
      }
    } catch (error) {
      console.error("Error during purchase:", error);
    }
  }

  return (
    <>
      {/* SUCCESS MESSAGE OVERLAY */}
      {successMessage && (
       <Messages code="checkout.success" className="ts-checkout-success" />
      )}

      <main className="checkout-page">
        <h1>Checkout</h1>

        {/* PRODUCT LIST */}
        <section className="checkout-products">
          {cartItems.length === 0 && (
            <div className="checkout-empty">
              <div className="empty-icon">🛒</div>

              <h2>Your cart is empty</h2>

              <p>
                Looks like you haven’t added anything yet.
                Explore our products and find your next device ⚡
              </p>

    <button
      className="btn-go-shop"
      onClick={() => navigate("/products")}
    >
      Go to products
    </button>
  </div>
)}
        {cartItems.map((item) => (
          <div key={item.id} className="basket-item">
            <img src={item.imageUrl} alt={item.name} className="basket-item-image" />

            <div className="basket-info">
              <h3>{item.name}</h3>
              <p className="basket-price">€ {item.price.toFixed(2)}</p>

              <div className="basket-controls">
                <select
                  className="basket-qty"
                  value={item.quantity}
                  onChange={(e) =>
                    updateQuantity(item.id, Number(e.target.value))
                  }
                >
                  {[...Array(11)].map((_, i) => (
                    <option key={i} value={i}>
                      {i === 0 ? "Remove" : i}
                    </option>
                  ))}
                </select>

                <button
                  className="basket-remove"
                  onClick={() => removeFromCart(item.id)}
                >
                  Remove
                </button>
              </div>
            </div>
          </div>
        ))}

        {cartItems.length > 0 && (
          <h2>Total: € {cartTotal.toFixed(2)}</h2>
        )}
      </section>

      {/* FORM */}
      {cartItems.length > 0 && (
        <form className="checkout-form" onSubmit={handleBuy}>
          <h3>Customer details</h3>

          <input name="firstName" placeholder="First name" onChange={handleClientChange} required />
          <input name="lastName" placeholder="Last name" onChange={handleClientChange} required />
          <input name="email" placeholder="Email" onChange={handleClientChange} required />
          <input name="phone" placeholder="Phone" onChange={handleClientChange} />
          <input name="street" placeholder="Street" onChange={handleClientChange} required />
          <input name="postcode" placeholder="Postcode" onChange={handleClientChange} required />
          <input name="city" placeholder="City" onChange={handleClientChange} required />
          <input name="country" placeholder="Country" onChange={handleClientChange} />

          <label>
            <input
              type="checkbox"
              checked={client.wantsNewsletter}
              onChange={(e) =>
                setClient({ ...client, wantsNewsletter: e.target.checked })
              }
            />
            I want newsletter
          </label>

          <button type="submit" className="btn-buy">Buy</button>
        </form>
      )}
    </main>
    </>
  );
}