import React from 'react';
import entrega from '../../assets/Como-Funciona/entrega.svg';
import '../../css/comofunciona.css';

function EntregaSection() {
  return (
    <section className="fourth-container">
      <img src={entrega} alt="Realização de uma entrega" />
      <div className="text-container">
        <h1 className="text-fourth-container">Entrega</h1>
        <p className="text-fourth-container">
          O primeiro passo é cadastrar-se na plataforma. Doadores <br />
          podem listar produtos para doação, como roupas e livros, <br />
          enquanto ONGs acessam e selecionam itens disponíveis.
        </p>
      </div>
    </section>
  );
}

export default EntregaSection;
