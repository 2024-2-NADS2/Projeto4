import React from 'react';
import pessoa from '../../assets/Como-Funciona/person2.svg';
import '../../css/comofunciona.css';

function RegistroSection() {
  return (
    <section className="first-container">
      <div className="text-container">
        <h1 className="text-first-container">Registro</h1>
        <p className="text-first-container">
          O primeiro passo é cadastrar-se na plataforma. Doadores <br />
          podem listar produtos para doação, como roupas e livros, <br />
          enquanto ONGs acessam e selecionam itens disponíveis.
        </p>
      </div>
      <img src={pessoa} className='img-pessoa2' alt="Pessoa se registrando" />
    </section>
  );
}

export default RegistroSection;
