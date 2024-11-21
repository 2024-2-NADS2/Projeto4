import React from "react";
import { BrowserRouter as Router, Route, Routes, useLocation } from "react-router-dom";
import Navbar from "./components/Navbar";
import Home from "./pages/Home";
import About from "./pages/About";
import ComoFunciona from "./pages/Como-Funciona";
import Contato from "./pages/Contato";
import Cadastro from "./pages/Cadastro";
import Footer from "./components/Footer";
import Login from "./pages/Login";
import PerfilUsuario from "./pages/Perfil-Usuario"; 
import CadastroProduto from "./pages/CadastroProduto";
import DadosUsuario from "./pages/DadosUsuario"
import DadosOng from "./pages/DadosOng";
import "./App.css";
import PerfilOng from "./pages/Perfil-Ong";
import Feed from "./pages/Feed";

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
          <Route path="/login" element={<Login />} />
          <Route path="/user-profile" element={<PerfilUsuario />} />  
          <Route path="/cadastroproduto" element={<CadastroProduto />} /> 
          <Route path="/dadosusuario" element={<DadosUsuario />} /> 
          <Route path="/ong-profile" element={<PerfilOng />} /> 
          <Route path="/dadosong" element={<DadosOng />} /> 
          <Route path="/feed" element={<Feed />} /> 
         
        </Routes>
        <FooterWrapper />
      </div>
    </Router>
  );
}

function NavbarWrapper() {
  const location = useLocation();

  // Renderiza a Navbar apenas se não estiver na página de Cadastro ou Login
  return location.pathname !== '/cadastro' && location.pathname !== '/login' 
  && location.pathname !== '/user-profile' && location.pathname !== '/dadosusuario' 
  && location.pathname !== '/cadastroproduto'  
  && location.pathname !== '/dadosong' && location.pathname !== '/feed'  ? <Navbar /> : null;
}

function FooterWrapper() {
  const location = useLocation();
  
  // Renderiza o Footer apenas se não estiver na página de Contato
  return location.pathname !== '/contato'  && location.pathname !== '/user-profile' && location.pathname !== '/dadosusuario' 
  && location.pathname !== '/cadastroproduto'  
  && location.pathname !== '/dadosong' && location.pathname !== '/feed' ? <Footer />  : null;
}

export default App;
