import React, { useState } from "react";
import axios from "axios";
import "./CadastroConta.css";

function CadastroConta() {
  const [nome, setNome] = useState("");
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const [cpf, setCpf] = useState("");
  const [dataNascimento, setDataNascimento] = useState("");
  const [endereco, setEndereco] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Formatar a data para o formato 'yyyy-MM-dd' (ISO 8601)
    const formattedDate = new Date(dataNascimento);
    const day = String(formattedDate.getDate()).padStart(2, "0"); // Adiciona zero à esquerda se o dia for menor que 10
    const month = String(formattedDate.getMonth() + 1).padStart(2, "0"); // O mês começa do 0, então somamos 1
    const year = formattedDate.getFullYear();

    // Formata a data como dd/mm/yyyy
    const formattedDateString = `${day}/${month}/${year}`;

    // Aqui o código vai parar para depuração
    
    try {
      const response = await axios.post(
        "https://localhost:7160/api/Usuario/cadastrar-doador",
        {
          nome: nome,
          email: email,
          senha: senha,
          cpf: cpf,
          dataNascimentoString: formattedDateString,
          endereco: endereco,
        }
      );
      
      if (response.status === 200) {
        alert("Usuário cadastrado com sucesso!");
      }
    } catch (error) {
      console.error(
        "Erro ao cadastrar usuário:",
        error.response ? error.response.data : error
      );
      alert("Erro ao cadastrar usuário. Tente novamente!");
      debugger; // O código vai parar aqui, permitindo inspecionar as variáveis
    }
  };

  return (
    <div className="signup-page">
      <div className="signup-card">
        <h2>Seja bem-vindo(a)!</h2>
        <form onSubmit={handleSubmit}>
          <label>
            Digite seu e-mail
            <input
              type="email"
              placeholder="E-mail"
              required
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
          </label>
          <label>
            Crie sua senha
            <div className="password-input">
              <input
                type="password"
                placeholder="Senha"
                required
                value={senha}
                onChange={(e) => setSenha(e.target.value)}
              />
              <span className="show-password">👁️</span>
            </div>
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
            Data de Nascimento
            <input
              type="date"
              required
              value={dataNascimento}
              onChange={(e) => setDataNascimento(e.target.value)}
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
          <button type="button" className="google-signup">
            Entrar com o Google
          </button>
        </form>
      </div>
    </div>
  );
}

export default CadastroConta;
