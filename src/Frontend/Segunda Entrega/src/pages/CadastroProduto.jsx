import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import "../css/cadastroproduto.css";

const CadastroProduto = () => {
  const [descricao, setDescricao] = useState("");
  const [estado, setEstado] = useState("");
  const [tamanho, setTamanho] = useState(0);
  const [doadorId, setDoadorId] = useState(null);
  const [imagem, setImagem] = useState(null);
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);

  // Campos específicos de livro
  const [genero, setGenero] = useState("");
  const [autor, setAutor] = useState("");
  const [editora, setEditora] = useState("");

  // Campos específicos de roupa
  const [tipoRoupa, setTipoRoupa] = useState("0"); // Valor padrão "0" (Camisa)
  const [cor, setCor] = useState("");

  // Tipo de produto
  const [tipoProduto, setTipoProduto] = useState(""); // Pode ser "livro" ou "roupa"
  const [tamanhoCalcado, setTamanhoCalcado] = useState(""); // Para tamanho de calçado

  const navigate = useNavigate();

  useEffect(() => {
    const storedUser = localStorage.getItem("usuarioLogado");
    if (storedUser) {
      const user = JSON.parse(storedUser);
      if (user.id) {
        setDoadorId(user.id);
      } else {
        setError("ID de usuário não encontrado.");
      }
    } else {
      setError("Usuário não autenticado. Faça login.");
    }
  }, []);

  const handleImagemChange = (e) => {
    const file = e.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => {
        setImagem(reader.result);
      };
      reader.readAsDataURL(file);
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setLoading(true);
    setError("");

    if (!doadorId) {
      setError("Usuário não autenticado. Faça login novamente.");
      setLoading(false);
      return;
    }

    // Construa o objeto do produto
    let produto;
    if (tipoProduto === "livro") {
      produto = {
        descricao,
        estado,
        tamanho,
        doadorId,
        imagem,
        genero,
        autor,
        editora,
      };
    } else if (tipoProduto === "roupa") {
      if (tipoRoupa === "4" && tamanhoCalcado === "") {
        setError("Por favor, forneça o tamanho do calçado.");
        setLoading(false);
        return;
      }
      produto = {
        descricao,
        estado,
        doadorId,
        imagem,
        tipoRoupa,
        cor,
        tamanhoCalcado, // Apenas se for calçado
      };
    } else {
      produto = {
        descricao,
        estado,
        tamanho,
        doadorId,
        imagem,
      };
    }

    try {
      let produtos = JSON.parse(localStorage.getItem("produtosDoados")) || [];
      produtos.push(produto);
      localStorage.setItem("produtosDoados", JSON.stringify(produtos));

      alert("Produto cadastrado com sucesso!");

      // Limpa os campos do formulário
      setDescricao("");
      setEstado("");
      setTamanho(0);
      setImagem(null);
      setGenero("");
      setAutor("");
      setEditora("");
      setTipoRoupa("0");
      setCor("");
      setTipoProduto("");
      setTamanhoCalcado("");
      setLoading(false);

      // Redireciona para o feed
      navigate("/feed");
    } catch (error) {
      console.error("Erro ao cadastrar produto:", error);
      setError("Erro ao cadastrar produto. Verifique os campos e tente novamente.");
      setLoading(false);
    }
  };

  return (
    <div className="signup-page">
      <div className="signup-card">
        <h2>Cadastro de Produto</h2>
        {error && <p className="error-message">{error}</p>}
        <form onSubmit={handleSubmit}>
          <label>
            Descrição
            <input
              type="text"
              placeholder="Descrição do Produto"
              required
              value={descricao}
              onChange={(e) => setDescricao(e.target.value)}
            />
          </label>
          <label>
            Estado
            <input
              type="text"
              placeholder="Condição do Produto"
              required
              value={estado}
              onChange={(e) => setEstado(e.target.value)}
            />
          </label>

          {/* Campo para selecionar o tipo de produto */}
          <label>
            Tipo de Produto
            <select
              value={tipoProduto}
              onChange={(e) => setTipoProduto(e.target.value)}
              required
            >
              <option value="">Selecione</option>
              <option value="livro">Livro</option>
              <option value="roupa">Roupa</option>
            </select>
          </label>

          {/* Condição para mostrar campos específicos para Livro */}
          {tipoProduto === "livro" && (
            <>
              <label>
                Gênero
                <input
                  type="text"
                  placeholder="Gênero do Livro"
                  value={genero}
                  onChange={(e) => setGenero(e.target.value)}
                />
              </label>
              <label>
                Autor
                <input
                  type="text"
                  placeholder="Autor do Livro"
                  value={autor}
                  onChange={(e) => setAutor(e.target.value)}
                />
              </label>
              <label>
                Editora
                <input
                  type="text"
                  placeholder="Editora do Livro"
                  value={editora}
                  onChange={(e) => setEditora(e.target.value)}
                />
              </label>
            </>
          )}

          {/* Condição para mostrar campos específicos para Roupa */}
          {tipoProduto === "roupa" && (
            <>
              <label>
                Tipo de Roupa
                <select
                  value={tipoRoupa}
                  onChange={(e) => setTipoRoupa(e.target.value)}
                >
                  <option value="0">Camisa</option>
                  <option value="1">Calça</option>
                  <option value="2">Jaqueta</option>
                  <option value="3">Saia</option>
                  <option value="4">Calçado</option>
                </select>
              </label>
              <label>
                Cor
                <input
                  type="text"
                  placeholder="Cor da Roupa"
                  value={cor}
                  onChange={(e) => setCor(e.target.value)}
                />
              </label>

              {/* Exibe campo de tamanho apenas se o tipo de roupa for calçado */}
              {tipoRoupa === "4" && (
                <label>
                  Tamanho do Calçado
                  <input
                    type="text"
                    placeholder="Tamanho do Calçado"
                    value={tamanhoCalcado}
                    onChange={(e) => setTamanhoCalcado(e.target.value)}
                  />
                </label>
              )}
            </>
          )}

          {/* Campo para upload de imagem */}
          <label>
            Imagem do Produto
            <input
              type="file"
              accept="image/*"
              onChange={handleImagemChange}
            />
          </label>

          {/* Exibe uma pré-visualização da imagem */}
          {imagem && <img src={imagem} alt="Imagem do produto" width="100" />}

          <button type="submit" className="signup-button" disabled={loading}>
            {loading ? "Cadastrando..." : "Cadastrar Produto"}
          </button>
        </form>
      </div>
    </div>
  );
};

export default CadastroProduto;
