import React from 'react';
import user from '../../../assets/Home/User.png';
import truck from '../../../assets/Home/truck.png';
import search from '../../../assets/Home/search.png';
import './Second.css'
import hands from '../../../assets/Home/hands.png';

function SecondSection() {
  return (
    <section id="second-container">
      <h1>Como <span id="cor-funciona">funciona</span> o SYP?</h1>
      <div className="steps">
        <div className="step">
          <img src={user} alt="Registro" />
          <h3>Registro</h3>
          <p>Lorem ipsum dolor sit amet.</p>
        </div>
        <div className="step">
          <img src={truck} alt="Coleta" />
          <h3>Coleta</h3>
          <p>Lorem ipsum dolor sit amet.</p>
        </div>
        <div className="step">
          <img src={search} alt="Triagem" />
          <h3>Triagem</h3>
          <p>Lorem ipsum dolor sit amet.</p>
        </div>
        <div className="step">
          <img src={hands} alt="Entrega" />
          <h3>Entrega</h3>
          <p>Lorem ipsum dolor sit amet.</p>
        </div>
      </div>
    </section>
  );
}

export default SecondSection;
