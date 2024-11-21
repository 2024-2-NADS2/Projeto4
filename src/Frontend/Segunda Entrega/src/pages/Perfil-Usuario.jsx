import React, { useState, useEffect } from "react"; 
import { Link } from "react-router-dom";
import "../css/perfil-usuario.css";
import NavbarUsuario from "../components/NavBarUsuario";

const PerfilUsuario = () => {
  // Estado para armazenar o nome do usuário
  const [nomeUsuario, setNomeUsuario] = useState(null);
  const [produtosDoados, setProdutosDoados] = useState([]);
  const [produtosInteresse, setProdutosInteresse] = useState([]);
  const [produtosRecebidos, setProdutosRecebidos] = useState([]);
  const [produtosDoadosParaOutros, setProdutosDoadosParaOutros] = useState([]);

  // Recupera o nome do usuário e produtos do localStorage ao montar o componente
  useEffect(() => {
    const storedUser = localStorage.getItem("usuarioCadastrado");
    if (storedUser) {
      const user = JSON.parse(storedUser);
      setNomeUsuario(user.Nome);  // Aqui, 'Nome' é o campo correto
    }

    // Recupera os produtos do localStorage
    const doados = JSON.parse(localStorage.getItem("produtosDoados")) || [];
    const interesse = JSON.parse(localStorage.getItem("produtosInteresse")) || [];
    const recebidos = JSON.parse(localStorage.getItem("produtosRecebidos")) || [];
    const doadosParaOutros = JSON.parse(localStorage.getItem("produtosDoadosParaOutros")) || [];

    setProdutosDoados(doados);
    setProdutosInteresse(interesse);
    setProdutosRecebidos(recebidos);
    setProdutosDoadosParaOutros(doadosParaOutros);
  }, []);
  
  return (
    <div className="user-profile">
      {/* Cabeçalho */}
      <NavbarUsuario />
      <Link to="/dadosusuario">
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
      </Link>
      {/* Seções */}
      <section className="sections">
        {/* Itens Doado */}
        <div className="section">
          <h3>Itens doados ({produtosDoados.length})</h3>
          {produtosDoados.length > 0 ? (
            produtosDoados.map((produto, index) => (
              <div className="item" key={index}>
                <img src={produto.imagem || "https://via.placeholder.com/60"} alt={produto.descricao} />
                <div className="item-details">
                  <p className="title">{produto.descricao}</p>
                </div>
                <p className="status delivered">Doado</p>
              </div>
            ))
          ) : (
            <p className="no-items-message">Você ainda não doou nenhum item.</p>
          )}
        </div>

        {/* Meus Interesses */}
        <div className="section">
          <h3>Meus interesses ({produtosInteresse.length})</h3>
          {produtosInteresse.length > 0 ? (
            produtosInteresse.map((produto, index) => (
              <div className="item" key={index}>
                <img src={produto.imagem || "https://via.placeholder.com/60"} alt={produto.descricao} />
                <div className="item-details">
                  <p className="title">{produto.descricao}</p>
                </div>
                <p className="status in-review">Em análise</p>
              </div>
            ))
          ) : (
            <p className="no-items-message">Você ainda não tem interesses cadastrados.</p>
          )}
        </div>

        {/* Recebidos */}
        <div className="section">
          <h3>Recebidos ({produtosRecebidos.length})</h3>
          {produtosRecebidos.length > 0 ? (
            produtosRecebidos.map((produto, index) => (
              <div className="item" key={index}>
                <img src={produto.imagem || "https://via.placeholder.com/60"} alt={produto.descricao} />
                <div className="item-details">
                  <p className="title">{produto.descricao}</p>
                </div>
                <p className="status delivered">Entregue</p>
              </div>
            ))
          ) : (
            <p className="no-items-message">Você ainda não recebeu nenhum item.</p>
          )}
        </div>

        {/* Doados para Outra Pessoa */}
        <div className="section">
          <h3>Doados para outra pessoa ({produtosDoadosParaOutros.length})</h3>
          {produtosDoadosParaOutros.length > 0 ? (
            produtosDoadosParaOutros.map((produto, index) => (
              <div className="item" key={index}>
                <img src={produto.imagem || "https://via.placeholder.com/60"} alt={produto.descricao} />
                <div className="item-details">
                  <p className="title">{produto.descricao}</p>
                </div>
                <p className="status unavailable">Indisponível</p>
              </div>
            ))
          ) : (
            <p className="no-items-message">Você ainda não doou nenhum item para outra pessoa.</p>
          )}
        </div>
      </section>
    </div>
  );
};

export default PerfilUsuario;
