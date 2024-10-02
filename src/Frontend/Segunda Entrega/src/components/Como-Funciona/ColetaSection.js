import React from 'react';
import coleta from '../../assets/Como-Funciona/coleta.svg';
import '../../css/comofunciona.css';

function ColetaSection() {
  return (
    <section className="second-container">
      <div className="text-container">
        <h1 className="text-second-container">Coleta</h1>
        <p className="text-second-container">
        Doadores podem especificar tipo, quantidade e condições dos <br/>
        produtos. ONGs filtram e escolhem as doações necessárias, <br/>
        entrando em contato diretamente com o doador para combinar <br/>
        a coleta.
        </p>
      </div>
      <img src={coleta} alt="Pessoa coletando" />
    </section>
  );
}

export default ColetaSection;
