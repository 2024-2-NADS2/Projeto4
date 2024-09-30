import React from "react";
import { Link, useLocation } from 'react-router-dom';
import '../css/navbar.css' 

function Navbar() {
  const location = useLocation();

  return (
    <nav className="navbar">
      <div className="logo">
        <Link to="/">SYP</Link>
      </div>
      <ul className="nav-links">
        <li className={location.pathname === "/about" ? "active" : ""}>
          <Link to="/about">Quem Somos</Link>
        </li>
        <li className={location.pathname === "/como-funciona" ? "active" : ""}>
          <Link to="/como-funciona">Como Funciona</Link>
        </li>
        <li className={location.pathname === "/parceiros" ? "active" : ""}>
          <Link to="/parceiros">Parceiros</Link>
        </li>
        <li className={location.pathname === "/doe-agora" ? "active" : ""}>
          <Link to="/doe-agora">Doe Agora</Link>
        </li>
        <button className="btn-initial">Doar</button>
      </ul>
    </nav>
  );
}

export default Navbar;
