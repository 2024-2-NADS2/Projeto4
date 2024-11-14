import React, { useState } from 'react';
import '../css/login.css';
import personagem from '../assets/personagem.svg'; // Certifique-se de que o caminho esteja correto
import googleLogo from '../assets/login/logo-google.png';

function Login() {
  const [passwordVisible, setPasswordVisible] = useState(false);

  const togglePasswordVisibility = () => {
    setPasswordVisible(prevState => !prevState);
  };

  return (
    <div className="login-page">
    <img src={personagem} alt="Personagem" className="character-image" /> {/* Adicionando a imagem do personagem */}
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
              <input
                type={passwordVisible ? "text" : "password"}
                placeholder="Senha"
                required
              />
              <span className="show-password" onClick={togglePasswordVisibility}>
                {passwordVisible ? "🙈" : "👁️"}
              </span>
            </div>
          </label>
          <a href="/esqueci-senha" className="forgot-password">
            Esqueceu a senha
          </a>
          <button type="submit" className="login-button">
            Entrar
          </button>
          <button type="button" className="google-login">
            <img src={googleLogo} alt="Google Logo" className="google-icon" />
            Entrar com o Google
          </button>
        </form>
      </div>
    </div>
  );
}

export default Login;
