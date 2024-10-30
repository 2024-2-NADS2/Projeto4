import React from 'react';
// import coleta from '../../assets/Como-Funciona/coleta.svg';
import '../css/contato.css';

function Contato() {
  return (
    <div className="contact-container">
        <div className="contact-card">
            <h1>Formulário de Contato</h1>
            <form>
                <label htmlFor="name">Nome Completo</label>
                <input type="text" id="name" name="name" />

                <label htmlFor="email">E-mail</label>
                <input type="email" id="email" name="email" />

                <label htmlFor="subject">Assunto</label>
                <input type="text" id="subject" name="subject" />

                <label htmlFor="message">Mensagem</label>
                <textarea id="message" name="message" rows="4"></textarea>

                <p className="response-time">Nossa equipe retornará em até 48h</p>
                <button type="submit" className="submit-button">Enviar Mensagem</button>
            </form>
        </div>
    </div>
);
}


export default Contato;
