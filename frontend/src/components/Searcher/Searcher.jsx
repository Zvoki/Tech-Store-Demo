import { useState } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import "./Searcher.scss";

function Searcher() {
  const [text, setText] = useState("");
  const navigate = useNavigate();
  const location = useLocation();

  const handleSearch = () => {
    const query = text.trim();
    if (!query) return;

    if (location.pathname === "/search") {
      navigate(`/search?q=${encodeURIComponent(query)}`, { replace: true });
    } else {
      navigate(`/search?q=${encodeURIComponent(query)}`);
    }

    setText("");
  };

  const handleKeyDown = (e) => {
    if (e.key === "Enter") {
      handleSearch();
    }
  };

  return (
    <div className="searcher">
      <input
        type="text"
        placeholder="Search products..."
        value={text}
        onChange={(e) => setText(e.target.value)}
        onKeyDown={handleKeyDown}
      />

      <button onClick={handleSearch}>🔍</button>
      <button>❤️</button>
      
    </div>
  );
}

export default Searcher;