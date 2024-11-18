import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';  // Para redirecionar após login
import '../css/login.css';
import personagem from '../assets/personagem.svg'; 
import googleLogo from '../assets/logo-google.png';

function Login() {
  const [passwordVisible, setPasswordVisible] = useState(false);
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const [error, setError] = useState("");  // Para exibir mensagens de erro

  const navigate = useNavigate(); // Hook de navegação para redirecionamento

  // Função para alternar visibilidade da senha
  const togglePasswordVisibility = () => {
    setPasswordVisible(prevState => !prevState);
  };

  // Função para tratar o envio do formulário
  const handleSubmit = async (e) => {
    e.preventDefault();

    // Verifica se os campos estão preenchidos
    if (!email || !senha) {
      setError("Por favor, preencha todos os campos.");
      return;
    }

    try {
      // Faz a requisição de autenticação à API
      const response = await fetch(
        'https://appsyp-hta3f0a6grhugmff.brazilsouth-01.azurewebsites.net/api/Usuario/login', // Endpoint da API
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json", // Especifica o tipo de conteúdo
          },
          body: JSON.stringify({ email, senha }), // Corpo da requisição com as credenciais
        }
      );

      if (response.ok) {
        // Login bem-sucedido, redireciona para a página de perfil do usuário
        navigate("/user-profile");  // Redireciona para a página de perfil
      } else {
        // Se o login falhar, exibe a mensagem de erro
        setError("Email ou senha inválidos.");
      }
    } catch (error) {
      console.error("Erro ao tentar fazer login", error);
      setError("Houve um erro ao tentar fazer login.");
    }
  };

  return (
    <div className="login-page">
      <img src={personagem} alt="Personagem" className="character-image" />
      <div className="login-card">
        <h2>Seja bem-vindo(a)!</h2>
        <p className="signup-link">
          Não tem conta? <a href="/cadastro">Cadastre-se</a>
        </p>
        <form onSubmit={handleSubmit}>
          <label>
            Digite seu e-mail
            <input 
              type="email" 
              placeholder="E-mail" 
              required 
              value={email} 
              onChange={(e) => setEmail(e.target.value)} 
            />
          </label>
          <label>
            Digite sua senha
            <div className="password-input">
              <input
                type={passwordVisible ? "text" : "password"} // Alterna entre texto e senha
                placeholder="Senha"
                required
                value={senha}
                onChange={(e) => setSenha(e.target.value)}
              />
              <span className="show-password" onClick={togglePasswordVisibility}>
                {passwordVisible ? "🙈" : "👁️"}  {/* Ícone para mostrar/ocultar senha */}
              </span>
            </div>
          </label>
          <a href="/esqueci-senha" className="forgot-password">
            Esqueceu a senha?
          </a>
          {error && <p className="error-message">{error}</p>}  {/* Exibe a mensagem de erro */}
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
