import React from 'react';
import doadores from '../../../assets/Home/Doadores.svg';
import './First.css'

function FirstSection() {
  return (
    <section id="first-container">
      <h1 id="first-h1">
        Faça a diferença com um <br /><span>clique: </span> doe livros e roupas!
      </h1>
      <h6>
      Lorem ipsum dolor sit amet, consectetur adipiscing elit. In ultricies
        luctus <br/> accumsan. Vestibulum laoreet eros dignissim accumsan auctor. Nulla
        <br/> euismod commodo lorem, eu varius leo. Mauris nisl erat, condimentum in
        <br/> pharetra in, pharetra ut metus. Duis vel eros mauris. Ut accumsan odio
        <br/> turpis, et pretium massa
      </h6>
      <div className="cta-container">
        <button id="btn-first-container">Agende uma coleta!</button>
        <h2>Sua ação gera impacto.</h2>
      </div>
      <img src={doadores} alt="Doadores" />
    </section>
  );
}

export default FirstSection;
