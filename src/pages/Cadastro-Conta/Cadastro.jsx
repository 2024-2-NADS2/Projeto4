import React, { useState } from "react";
import axios from "axios";
import "./CadastroConta.css";

function CadastroConta() {
  const [formType, setFormType] = useState("doador"); // Estado para alternar entre Empresa e Doador
  const [nome, setNome] = useState("");
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const [cpf, setCpf] = useState("");
  const [dataNascimento, setDataNascimento] = useState("");
  const [endereco, setEndereco] = useState("");
  const [razaoSocial, setRazaoSocial] = useState(""); // Campo adicional para Empresa
  const [cnpj, setCnpj] = useState(""); // Campo adicional para Empresa

  const handleSubmit = async (e) => {
    e.preventDefault();

    const formattedDate = new Date(dataNascimento);
    const day = String(formattedDate.getDate()).padStart(2, "0");
    const month = String(formattedDate.getMonth() + 1).padStart(2, "0");
    const year = formattedDate.getFullYear();
    const formattedDateString = `${day}/${month}/${year}`;

    const data =
      formType === "doador"
        ? { nome, email, senha, cpf, dataNascimentoString: formattedDateString, endereco }
        : { razaoSocial, cnpj, email, senha, endereco };

    const url =
      formType === "doador"
        ? "https://localhost:7160/api/Usuario/cadastrar-doador"
        : "https://localhost:7160/api/Usuario/cadastrar-empresa";

    try {
      const response = await axios.post(url, data);
      if (response.status === 200) {
        alert("Usuário cadastrado com sucesso!");
      }
    } catch (error) {
      console.error("Erro ao cadastrar usuário:", error.response ? error.response.data : error);
      alert("Erro ao cadastrar usuário. Tente novamente!");
    }
  };

  return (
    
    <div className="signup-page">
      <div className="signup-card">
        {/* Conteúdo do form permanece igual */}
        <h2>Seja bem-vindo(a)!</h2>
        <div style={{ display: "flex", justifyContent: "center", marginBottom: "1rem" }}
      >
          <button
            type="button"
            className={`toggle-button ${formType === "empresa" ? "active" : ""}`}
            onClick={() => setFormType("empresa")}
          >
            Empresa
          </button>
          <button
            type="button"
            className={`toggle-button ${formType === "doador" ? "active" : ""}`}
            onClick={() => setFormType("doador")}
          >
            Doador
          </button>
        </div>
        <form onSubmit={handleSubmit}>
          {formType === "doador" ? (
            <>
              <label>
                Nome Completo
                <input
                  type="text"
                  placeholder="Nome Completo"
                  required
                  value={nome}
                  onChange={(e) => setNome(e.target.value)}
                />
              </label>
              <label>
                CPF
                <input
                  type="text"
                  placeholder="CPF"
                  required
                  value={cpf}
                  onChange={(e) => setCpf(e.target.value)}
                />
              </label>
              <label>
                Data de Nascimento
                <input
                  type="date"
                  required
                  value={dataNascimento}
                  onChange={(e) => setDataNascimento(e.target.value)}
                />
              </label>
            </>
          ) : (
            <>
              <label>
                Razão Social
                <input
                  type="text"
                  placeholder="Razão Social"
                  required
                  value={razaoSocial}
                  onChange={(e) => setRazaoSocial(e.target.value)}
                />
              </label>
              <label>
                CNPJ
                <input
                  type="text"
                  placeholder="CNPJ"
                  required
                  value={cnpj}
                  onChange={(e) => setCnpj(e.target.value)}
                />
              </label>
            </>
          )}
          <label>
            E-mail
            <input
              type="email"
              placeholder="E-mail"
              required
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
          </label>
          <label>
            Senha
            <input
              type="password"
              placeholder="Senha"
              required
              value={senha}
              onChange={(e) => setSenha(e.target.value)}
            />
          </label>
          <label>
            Endereço
            <input
              type="text"
              placeholder="Endereço"
              required
              value={endereco}
              onChange={(e) => setEndereco(e.target.value)}
            />
          </label>
          <button type="submit" className="signup-button">
            Cadastrar
          </button>
        </form>
      </div>
    </div>
  );
}

export default CadastroConta;
