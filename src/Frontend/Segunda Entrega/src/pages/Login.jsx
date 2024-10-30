import React from 'react';
import '../css/login.css';
import personagem from '../assets/personagem.svg';


function Login() {
  return (
    <div className="login-page">
    <div className="login-card">
      <h2>Seja bem-vindo(a)!</h2>
      <p className="signup-link">
        Não tem conta? <a href="/cadastro">Cadastre-se</a>
      </p>
      <form>
        <label>
          Digite seu e-mail
          <input type="email" placeholder="E-mail" required />
        </label>
        <label>
          Digite sua senha
          <div className="password-input">
            <input type="password" placeholder="Senha" required />
            <span className="show-password">👁️</span> {/* Ícone para mostrar senha */}
          </div>
        </label>
        <a href="/esqueci-senha" className="forgot-password">
          Esqueceu a senha
        </a>
        <button type="submit" className="login-button">
          Entrar
        </button>
        <button type="button" className="google-login">
              Entrar com o Google
            </button>
      </form>
    </div>
  </div>
  );
}

export default Login;
