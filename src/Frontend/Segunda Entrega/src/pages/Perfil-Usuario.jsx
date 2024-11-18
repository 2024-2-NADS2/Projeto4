import React, { useState, useEffect } from "react"; // Adicionar useState e useEffect
import { Link } from "react-router-dom"; // Importando o Link
import "../css/perfil-usuario.css";

const PerfilUsuario = () => {
  const [nomeUsuario, setNomeUsuario] = useState(""); // Definindo o estado para armazenar o nome

  useEffect(() => {
    // Recuperando o nome do usuário do localStorage
    const nome = localStorage.getItem('nomeUsuario');
    if (nome) {
      setNomeUsuario(nome); // Definindo o nome do usuário no estado
    }
  }, []); // O useEffect roda uma vez, logo após o componente ser montado

  return (
    <div className="user-profile">
      <header className="header">
        <div className="logo">SYP</div>
        <nav>
          <Link to="/cadastroproduto">Doar Produto</Link>
          <a href="#">Feed</a>
          <a href="#">Contato</a>
        </nav>
        <div className="user-menu">
          <span>Olá, {nomeUsuario}!</span> {/* Exibe o nome do usuário */}
          <img
            src="https://via.placeholder.com/40"
            alt="Usuário"
            className="user-avatar"
          />
        </div>
      </header>

      <div className="profile-card">
        <img
          src="https://via.placeholder.com/100"
          alt="Profile"
          className="profile-image"
        />
        <div>
          <h2>{nomeUsuario || 'Usuário da Silva'}</h2> {/* Exibe o nome ou um nome padrão */}
          <p className="role">Doador</p>
          <p className="date">Cadastrado em 21/10/2024</p>
        </div>
        <button className="edit-button">Editar</button>
      </div>

      <section className="sections">
        <div className="section">
          <h3>Itens doados (1)</h3>
          <div className="item">
            <img
              src="https://via.placeholder.com/60"
              alt="É assim que acaba"
            />
            <div>
              <p>É assim que acaba</p>
              <p className="status donated">Doado</p>
            </div>
          </div>
        </div>

        <div className="section">
          <h3>Meus interesses (3)</h3>
          <div className="item">
            <img
              src="https://via.placeholder.com/60"
              alt="Camiseta"
            />
            <div>
              <p>Camiseta</p>
              <p className="status in-review">Em análise</p>
            </div>
          </div>
        </div>

        <div className="section">
          <h3>Recebidos (3)</h3>
          <div className="item">
            <img src="https://via.placeholder.com/60" alt="Boné" />
            <div>
              <p>Boné</p>
              <p className="status delivered">Entregue</p>
            </div>
          </div>
        </div>

        <div className="section">
          <h3>Doados para outra pessoa (1)</h3>
          <div className="item">
            <img src="https://via.placeholder.com/60" alt="Harry Potter" />
            <div>
              <p>Harry Potter</p>
              <p className="status unavailable">Entregue</p>
            </div>
          </div>
        </div>
      </section>
    </div>
  );
};

export default PerfilUsuario;
