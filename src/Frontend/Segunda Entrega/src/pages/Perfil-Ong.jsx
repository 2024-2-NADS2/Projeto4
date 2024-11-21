import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import "../css/perfil-usuario.css";
import NavbarUsuario from "../components/NavBarUsuario";

const PerfilOng = () => {
  // Estado para armazenar o nome da ONG
  const [nomeOng, setNomeOng] = useState(null);

  // Recupera o nome da ONG do localStorage ao montar o componente
  useEffect(() => {
    const storedOng = localStorage.getItem("ongCadastrada");
    if (storedOng) {
      const ong = JSON.parse(storedOng);
      setNomeOng(ong.Nome); // Aqui estamos acessando o campo 'Nome'
      console.log(localStorage.getItem("ongCadastrada"));
    }
  }, []);

  return (
    <div className="ong-profile">
      {/* Cabeçalho */}
      <NavbarUsuario />

      {/* Cartão de Perfil */}
      <div className="profile-card">
        <img
          src="https://via.placeholder.com/100"
          alt="Profile"
          className="profile-image"
        />
        <div>
          <h2>{nomeOng || "Nome da ONG"}</h2> {/* Exibe o nome ou um padrão */}
          <p className="role">ONG</p>
          <p className="date">Cadastrada em 21/10/2024</p>
        </div>
        <Link to="/dadosong">
          <button className="edit-button">Editar</button>
        </Link>
      </div>

      {/* Seções */}
      <section className="sections">
        {/* Itens Arrecadados */}
        <div className="section">
          <h3>Itens arrecadados (3)</h3>
          <div className="item">
            <img src="https://via.placeholder.com/60" alt="Cadeira" />
            <div className="item-details">
              <p className="title">Cadeira de rodas</p>
            </div>
            <p className="status delivered">Arrecadado</p>
          </div>
          <div className="item">
            <img src="https://via.placeholder.com/60" alt="Alimentos" />
            <div className="item-details">
              <p className="title">Cesta básica</p>
            </div>
            <p className="status delivered">Arrecadado</p>
          </div>
          <div className="item">
            <img src="https://via.placeholder.com/60" alt="Roupas" />
            <div className="item-details">
              <p className="title">Roupas infantis</p>
            </div>
            <p className="status delivered">Arrecadado</p>
          </div>
        </div>

        {/* Meus Interesses */}
        <div className="section">
          <h3>Meus interesses (2)</h3>
          <div className="item">
            <img src="https://via.placeholder.com/60" alt="Material Escolar" />
            <div className="item-details">
              <p className="title">Material escolar</p>
            </div>
            <p className="status in-review">Em análise</p>
          </div>
          <div className="item">
            <img src="https://via.placeholder.com/60" alt="Brinquedos" />
            <div className="item-details">
              <p className="title">Brinquedos educativos</p>
            </div>
            <p className="status in-review">Em análise</p>
          </div>
        </div>
      </section>
    </div>
  );
};

export default PerfilOng;
