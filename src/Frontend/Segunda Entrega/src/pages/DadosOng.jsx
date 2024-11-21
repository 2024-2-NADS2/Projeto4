import React, { useEffect, useState } from "react";
import "../css/dadosusuario.css";
import NavbarUsuario from "../components/NavBarUsuario";

const DadosOng = () => {
  const [ong, setOng] = useState({
    Nome: "",
    Descricao: "",
    Email: "",
    Telefone: "",
    Endereco: "",
    Cnpj: "",
  });

  useEffect(() => {
    // Recuperar os dados da ONG do localStorage
    const ongSalva = localStorage.getItem("ongCadastrada");
    console.log("Dados da ONG do localStorage:", ongSalva); // Verifique o conteúdo
    if (ongSalva) {
      const ongData = JSON.parse(ongSalva);
      console.log("Dados da ONG após parse:", ongData); // Verifique o conteúdo após parse
      setOng({
        ...ongData,
      });
    }
  }, []);

  return (
    <>
      <NavbarUsuario />
      <div className="profile-container">
        {/* Cartão de Perfil */}
        <div className="profile-header">
          <img
            src="https://via.placeholder.com/100"
            alt="Logo da ONG"
            className="profile-image"
          />
          <div>
            <h2>{ong.Nome || "Nome da ONG"}</h2>
            <p className="role">ONG</p>
            <p className="date">Cadastrada em 21/10/2024</p>
          </div>
        </div>

        {/* Formulário de Dados da ONG */}
        <div className="profile-form">
          <div className="form-group">
            <div>
              <label>Nome da ONG</label>
              <input
                type="text"
                name="Nome"
                value={ong.Nome}
                disabled // Campo não editável
              />
            </div>
          </div>
          <div className="form-group">
            <div>
              <label>Descrição</label>
              <textarea
                name="Descricao"
                value={ong.Descricao}
                disabled // Campo não editável
              />
            </div>
          </div>
          <div className="form-group">
            <div>
              <label>E-mail</label>
              <input
                type="email"
                name="Email"
                value={ong.Email}
                disabled // Campo não editável
              />
            </div>
            <div>
              <label>Telefone</label>
              <input
                type="text"
                name="Telefone"
                value={ong.Telefone}
                disabled // Campo não editável
              />
            </div>
          </div>
          <div className="form-group">
            <div>
              <label>Endereço</label>
              <input
                type="text"
                name="Endereco"
                value={ong.Endereco}
                disabled // Campo não editável
              />
            </div>
            <div>
              <label>CNPJ</label>
              <input
                type="text"
                name="Cnpj"
                value={ong.Cnpj}
                disabled // Campo não editável
              />
            </div>
          </div>
          <button className="save-button" disabled>
            Salvar dados
          </button>
          <a href="/ong-profile" className="my-items-link">
            Meus itens arrecadados → 
          </a>
        </div>
      </div>
    </>
  );
};

export default DadosOng;
