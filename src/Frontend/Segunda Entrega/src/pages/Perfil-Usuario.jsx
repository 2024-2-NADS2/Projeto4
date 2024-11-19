import React, { useState, useEffect } from "react"; 
import { Link } from "react-router-dom";
import "../css/perfil-usuario.css";

const PerfilUsuario = () => {
  // Estado para armazenar o nome do usuário
  const [nomeUsuario, setNomeUsuario] = useState("");

  // Recupera o nome do usuário do localStorage ao montar o componente
  useEffect(() => {
    const nome = localStorage.getItem("nomeUsuario");
    if (nome) {
      setNomeUsuario(nome);
    }
  }, []);

  return (
    <div className="user-profile">
      {/* Cabeçalho */}
      <header className="header">
        <div className="logo">SYP</div>
        <nav>
          <Link to="/cadastroproduto">Doar Produto</Link>
          <a href="#">Feed</a>
          <a href="#">Contato</a>
        </nav>
        <div className="user-menu">
          <span>Olá, {nomeUsuario}!</span>
          <img
            src="https://via.placeholder.com/40"
            alt="Usuário"
            className="user-avatar"
          />
        </div>
      </header>

      {/* Cartão de Perfil */}
      <div className="profile-card">
        <img
          src="https://via.placeholder.com/100"
          alt="Profile"
          className="profile-image"
        />
        <div>
          <h2>{nomeUsuario || "Usuário da Silva"}</h2>
          <p className="role">Doador</p>
          <p className="date">Cadastrado em 21/10/2024</p>
        </div>
        <button className="edit-button">Editar</button>
      </div>

      {/* Seções */}
      <section className="sections">
        {/* Itens Doado */}
        <div className="section">
        <h3>Itens doados (1)</h3>
          <div className="item">
            <img src="https://via.placeholder.com/60" alt="Livro" />
            <div className="item-details">
            <p className="title">É assim que acaba</p>
            </div>
            <p className="status delivered">Doado</p>
          </div>
        </div>

        {/* Meus Interesses */}
        <div className="section">
        <h3>Meus interesses(3)</h3>
          <div className="item">
            <img src="https://via.placeholder.com/60" alt="Camiseta" />
            <div className="item-details">
              <p className="title">Camiseta</p>
            </div>
            <p className="status in-review">Em análise</p>
          </div>
        </div>

        {/* Recebidos */}
        <div className="section">
        <h3>Recebidos(3)</h3>
          <div className="item">
            <img src="https://via.placeholder.com/60" alt="Bone" />
            <div className="item-details">
              <p className="title">Bone</p>
            </div>
            <p className="status delivered">Entregue</p>
          </div>
       
        </div>

        {/* Doados para Outra Pessoa */}
        <div className="section">
          <h3>Doados para outra pessoa (1)</h3>
          <div className="item">
  <img src="https://via.placeholder.com/60" alt="Harry Potter" />
  <div className="item-details">
    <p className="title">Harry Potter</p>
  </div>
  <p className="status unavailable">Indisponível</p>
</div>
        </div>
      </section>
    </div>
  );
};

export default PerfilUsuario;
