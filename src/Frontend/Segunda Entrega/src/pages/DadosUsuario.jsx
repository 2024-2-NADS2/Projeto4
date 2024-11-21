import React, { useEffect, useState } from "react";
import "../css/dadosusuario.css";
import NavbarUsuario from "../components/NavBarUsuario";

const DadosUsuario = () => {
  const [usuario, setUsuario] = useState({
    Nome: "",
    Sobrenome: "",
    Email: "",
    Telefone: "",
    Cpf: "",
    DataNascimentoString: "",
  });

  useEffect(() => {
    // Recuperar os dados do usuário do localStorage
    const usuarioSalvo = localStorage.getItem("usuarioCadastrado");
    if (usuarioSalvo) {
      const usuarioData = JSON.parse(usuarioSalvo);

      // Separar o nome completo
      const [nome, ...sobrenome] = usuarioData.Nome.split(" ");
      
      setUsuario({
        ...usuarioData,
        Nome: nome, // Primeiro nome
        Sobrenome: sobrenome.join(" "), // Sobrenome (restante do nome)
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
            alt="Foto do usuário"
            className="profile-image"
          />
          <div>
            <h2>
              {usuario.Nome || "Usuário"} {usuario.Sobrenome || "da Silva"}
            </h2>
            <p className="role">Doador</p>
            <p className="date">Cadastrado em 21/10/2024</p>
          </div>
        </div>

        {/* Formulário de Dados */}
        <div className="profile-form">
          <div className="form-group">
            <div>
              <label>Nome</label>
              <input
                type="text"
                name="Nome"
                value={usuario.Nome}
                disabled // Campo não editável
              />
            </div>
            <div>
              <label>Sobrenome</label>
              <input
                type="text"
                name="Sobrenome"
                value={usuario.Sobrenome}
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
                value={usuario.Email}
                disabled // Campo não editável
              />
            </div>
            <div>
              <label>Telefone</label>
              <input
                type="text"
                name="Telefone"
                value={usuario.Telefone}
                disabled // Campo não editável
              />
            </div>
          </div>
          <div className="form-group">
            <div>
              <label>CPF</label>
              <input
                type="text"
                name="Cpf"
                value={usuario.Cpf}
                disabled // Campo não editável
              />
            </div>
            <div>
              <label>Data de nascimento</label>
              <input
                type="text"
                name="DataNascimentoString"
                value={usuario.DataNascimentoString}
                disabled // Campo não editável
              />
            </div>
          </div>
          <button className="save-button" disabled>
            Salvar dados
          </button>
          <a href="/user-profile" className="my-items-link">
            Meus itens →
          </a>
        </div>
      </div>
    </>
  );
};

export default DadosUsuario;
