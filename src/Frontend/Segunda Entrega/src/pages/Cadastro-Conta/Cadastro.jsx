import React, { useState } from "react";
import axios from "axios";
import "./CadastroConta.css";

const CadastroConta = () => {
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const [cpf, setCpf] = useState("");
  const [nome, setNome] = useState("");
  const [dataNascimento, setDataNascimento] = useState("");
  const [endereco, setEndereco] = useState("");
  const [telefone, setTelefone] = useState(""); // Novo campo
  const [formType, setFormType] = useState("doador"); // Estado para alternar entre "doador" e "empresa"

  // Definindo estados para empresa
  const [razaoSocial, setRazaoSocial] = useState(""); // Para armazenar a razão social
  const [cnpj, setCnpj] = useState(""); // Para armazenar o CNPJ

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Formatar a data para o formato dd/MM/yyyy
    const [ano, mes, dia] = dataNascimento.split("-");  // Pega a data no formato yyyy-MM-dd
    const formattedDataNascimento = `${dia}/${mes}/${ano}`; // Converte para dd/MM/yyyy

    let usuario = {};

    if (formType === "doador") {
      usuario = {
        Nome: nome,
        Email: email,
        Senha: senha,
        Cpf: cpf,
        Endereco: endereco,
        Telefone: telefone, // Enviado para a API
        DataNascimentoString: formattedDataNascimento, // Enviar a data formatada
      };
    } else {
      usuario = {
        RazaoSocial: razaoSocial,
        Cnpj: cnpj,
        Email: email,
        Senha: senha,
        Endereco: endereco,
        Telefone: telefone,
      };
    }

    try {
      const response = await axios.post(
        "https://appsyp-hta3f0a6grhugmff.brazilsouth-01.azurewebsites.net/api/Usuario/cadastrar-doador",
        usuario
      );
      alert("Cadastro realizado com sucesso!");
      localStorage.setItem('nomeUsuario', nome); // Salva o nome do usuário
    } catch (error) {
      if (error.response) {
        // Exibe a mensagem de erro retornada pela API
        alert(`Erro: ${error.response.data}`);
      } else {
        alert("Erro ao cadastrar. Tente novamente.");
      }
    }
  };

  return (
    <div className="signup-page">
      <div className="signup-card">
        <h2>Seja bem-vindo(a)!</h2>
        <div style={{ display: "flex", justifyContent: "center", marginBottom: "1rem" }}>
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
          <label>
            Telefone
            <input
              type="text"
              placeholder="Telefone"
              required
              value={telefone}
              onChange={(e) => setTelefone(e.target.value)}
            />
          </label>
          <button type="submit" className="signup-button">
            Cadastrar
          </button>
        </form>
      </div>
    </div>
  );
};

export default CadastroConta;
