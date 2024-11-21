import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import "../css/navbarusuario.css";

const NavbarUsuario = () => {
  const [nomeUsuario, setNomeUsuario] = useState("");

  useEffect(() => {
    const storedUser = localStorage.getItem("usuarioLogado"); // Usa a chave correta, 'usuarioLogado'
    
    if (storedUser) {
      const user = JSON.parse(storedUser);
      const nome = user?.name; // Verifica se 'name' existe
  
      if (nome) {
        const primeiroNome = nome.split(" ")[0]; // Pega o primeiro nome
        setNomeUsuario(primeiroNome);
      } else {
        setNomeUsuario("Usuário"); // Se o 'name' não estiver disponível
      }
    } else {
      setNomeUsuario("Usuário"); // Se não houver usuário logado
    }
  }, []);
  
  

  return (
    <header className="header">
      <div className="logo">SYP</div>
      <nav>
        <Link to="/cadastroproduto">Doar Produto</Link>
        <Link to="/feed">Feed</Link>
        <a href="/contato">Contato</a>
      </nav>
      <div className="user-menu">
        <span>Olá, {nomeUsuario}!</span> {/* Exibe o primeiro nome */}
        <img
          src="https://via.placeholder.com/40"
          alt="Usuário"
          className="user-avatar"
        />
      </div>
    </header>
  );
};

export default NavbarUsuario;
