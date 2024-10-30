import React from "react";
import { Link, useLocation } from "react-router-dom";
import "../css/navbar.css";
import logo from "../assets/logoSYP.png";

function Navbar() {
  const location = useLocation();

  return (
    <nav className="navbar">
      <div className="logo">
        <Link to="/">
          <img className="logo-img" src={logo} alt="Pessoas realizando busca" />
        </Link>
      </div>

      <ul className="nav-links">
        <li className={location.pathname === "/about" ? "active" : ""}>
          <Link to="/about">Quem Somos</Link>
        </li>
        <li className={location.pathname === "/como-funciona" ? "active" : ""}>
          <Link to="/como-funciona">Como Funciona</Link>
        </li>
        <li className={location.pathname === "/contato" ? "active" : ""}>
          <Link to="/contato">Contato</Link>
        </li>
        <li className={location.pathname === "/doe-agora" ? "active" : ""}>
          <Link to="/doe-agora">Doe Agora</Link>
        </li>
      </ul>
      <button className={`btn-initial ${location.pathname === "/login" ? "active" : ""}`}>
  <Link to="/login" className="text-white"> Doar </Link>
</button>



    </nav>
  );
}

export default Navbar;
