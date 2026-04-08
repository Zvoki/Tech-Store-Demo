import Navbar from "../Navbar/Navbar";
import Footer from "../Footer/Footer";
import "./Layout.scss";

function Layout({ children }) {
  return (
    <>
      <Navbar />
      <main>{children}</main>
      <Footer />
    </>
  );
}

export default Layout;
