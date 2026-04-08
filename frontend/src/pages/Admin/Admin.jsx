import { useState } from "react";
import "./Admin.scss";

function Admin() {
  const [token, setToken] = useState(localStorage.getItem("token") || "");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = async (e) => {
    e.preventDefault();

    try {
      const res = await fetch("http://localhost:5239/api/auth/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username, password }),
      });

      if (!res.ok) {
        alert("Invalid credentials");
        return;
      }

      const data = await res.json();
      localStorage.setItem("token", data.access_token);
      setToken(data.access_token);
    } catch (err) {
      console.error("Login error:", err);
    }
  };

  const handleLogout = () => {
    localStorage.removeItem("token");
    setToken("");
  };

  // Si NO hay token → mostrar login
  if (!token) {
    return (
      <div className="admin-container">
        <h1>Admin Login</h1>

        <form className="admin-form" onSubmit={handleLogin}>
          <input
            type="text"
            placeholder="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />

          <input
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />

          <button type="submit">Login</button>
        </form>
      </div>
    );
  }

  // Si hay token → mostrar panel admin
  
  return (
  <div className="admin-container">
    <h1>Welcome ☺ Admin</h1>

    <button className="logout-btn" onClick={handleLogout}>
      Logout
    </button>

    <div className="admin-cards">
      <div className="admin-card" onClick={() => {}}>
        <h3>Manage Products</h3>
        <p>View and organize all products.</p>
      </div>

      <div className="admin-card" onClick={() => {}}>
        <h3>Manage Categories</h3>
        <p>View and organize product categories.</p>
      </div>

      <div className="admin-card" onClick={() => {}}>
        <h3>Create Product</h3>
        <p>Add a new product to the store.</p>
      </div>

      <div className="admin-card" onClick={() => {}}>
        <h3>Create Category</h3>
        <p>Add a new category to the store.</p>
      </div>

      <div className="admin-card" onClick={() => {}}>
        <h3>User Management</h3>
        <p>Manage admin users. (Coming soon)</p>
      </div>

      <div className="admin-card" onClick={() => {}}>
        <h3>Settings</h3>
        <p>Configure system settings. (Coming soon)</p>
      </div>
    </div>
  </div>
);

}

export default Admin;