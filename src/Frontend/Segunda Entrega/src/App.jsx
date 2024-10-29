import React from "react";
import { BrowserRouter as Router, Route, Routes, useLocation } from "react-router-dom";
import Navbar from "./components/Navbar";
import Home from "./pages/Home";
import About from "./pages/About";
import ComoFunciona from "./pages/Como-Funciona";
import Contato from "./pages/Contato";
import Cadastro from "./pages/Cadastro";
import Footer from "./components/Footer";
import "./App.css";

function App() {
  return (
    <Router>
      <div>
        <NavbarWrapper />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />} />
          <Route path="/como-funciona" element={<ComoFunciona />} />
          <Route path="/contato" element={<Contato />} />
          <Route path="/cadastro" element={<Cadastro />} />
        </Routes>
        <Footer />
      </div>
    </Router>
  );
}

function NavbarWrapper() {
  const location = useLocation();

  // Renderiza a Navbar apenas se não estiver na página de Cadastro
  return location.pathname !== '/cadastro' && '/contato' ? <Navbar /> : null;
  
}

export default App;
