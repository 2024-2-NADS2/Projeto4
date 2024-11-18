import React, { useState } from "react";
import axios from "axios";
import "../css/cadastroproduto.css";

const CadastroProduto = () => {
  const [descricao, setDescricao] = useState("");
  const [estado, setEstado] = useState("");
  const [tamanho, setTamanho] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    const calcado = {
      descricao,
      estado,
      tamanho,
    };

    try {
      const response = await axios.post(
        "https://appsyp-hta3f0a6grhugmff.brazilsouth-01.azurewebsites.net/api/Produto/calcado",
        calcado,
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      alert("Calçado cadastrado com sucesso!");
    } catch (error) {
      if (error.response) {
        alert(`Erro: ${error.response.data}`);
      } else {
        alert("Erro ao cadastrar. Tente novamente.");
      }
    }
  };

  return (
    <div className="signup-page">
      <div className="signup-card">
        <h2>Cadastro de Calçado</h2>
        <form onSubmit={handleSubmit}>
          <label>
            Descrição
            <input
              type="text"
              placeholder="Descrição do Calçado"
              required
              value={descricao}
              onChange={(e) => setDescricao(e.target.value)}
            />
          </label>
          <label>
            Estado
            <input
              type="text"
              placeholder="Condição do Calçado (Ex: Novo)"
              required
              value={estado}
              onChange={(e) => setEstado(e.target.value)}
            />
          </label>
          <label>
            Tamanho
            <input
              type="text"
              placeholder="Tamanho do Calçado"
              required
              value={tamanho}
              onChange={(e) => setTamanho(e.target.value)}
            />
          </label>
          <button type="submit" className="signup-button">
            Cadastrar Calçado
          </button>
        </form>
      </div>
    </div>
  );
};

export default CadastroProduto;
