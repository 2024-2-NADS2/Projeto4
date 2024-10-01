import React from 'react';
import pessoa from '../../assets/Como-Funciona/person2.svg';
import '../../css/comofunciona.css';

function TriagemSection() {
  return (
    <section className="third-container">
      <img src={pessoa} className='img-pessoa2' alt="Pessoa se registrando" />
      <div className="text-container">
        <h1 className="text-third-container">Triagem</h1>
        <p className="text-third-container">
          O primeiro passo é cadastrar-se na plataforma. Doadores <br />
          podem listar produtos para doação, como roupas e livros, <br />
          enquanto ONGs acessam e selecionam itens disponíveis.
        </p>
      </div>
    </section>
  );
}

export default TriagemSection;
