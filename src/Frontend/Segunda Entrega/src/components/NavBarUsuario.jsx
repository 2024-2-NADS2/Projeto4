import React, { useState } from "react";
import { Link, useLocation } from "react-router-dom";
import "../css/navbar.css";
import logo from "../assets/logoSYP.png";

function Navbar() {
  const [isLoggedIn, setIsLoggedIn] = useState(false); // Controle do estado de login
  const location = useLocation();

  // Exemplo de alteração do estado de login
  const toggleLoginStatus = () => {
    setIsLoggedIn(prevState => !prevState);
  };

  return (
    <nav className="navbar">
      <div className="logo">
        <Link to="/">
          <img className="logo-img" src={logo} alt="Logo SYP" />
        </Link>
      </div>

      <ul className="nav-links">
        <li className={location.pathname === "/about" ? "active" : ""}>
          <Link to="/about">Doar Produto</Link>
        </li>
        <li className={location.pathname === "/como-funciona" ? "active" : ""}>
          <Link to="/como-funciona">Feed</Link>
        </li>
        <li className={location.pathname === "/contato" ? "active" : ""}>
          <Link to="/contato">Contato</Link>
        </li>

        {/* Navbar quando o usuário está logado */}
        {isLoggedIn ? (
          <li className={location.pathname === "/doe-agora" ? "active" : ""}>
            <Link to="/doe-agora">Olá, Usuário!</Link>
          </li>
        ) : (
          <li className={location.pathname === "/login" ? "active" : ""}>
            <Link to="/login">Login</Link>
          </li>
        )}
      </ul>

      {/* Button para alternar entre logado e não logado */}
      <button onClick={toggleLoginStatus}>
        {isLoggedIn ? "Sair" : "Entrar"}
      </button>
    </nav>
  );
}

export default Navbar;
