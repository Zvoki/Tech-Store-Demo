import "./Messages.scss";
import { messages } from "./messages.config";

function Messages({ code, className = "" }) {
  const text = messages[code] || code;

  const isCenter = className.includes("ts-message-center");

  return (
    <div className={`${isCenter ? "" : "ts-message"} ${className}`}>
      <span className="ts-message-text">{text}</span>
    </div>
  );
}

export default Messages;