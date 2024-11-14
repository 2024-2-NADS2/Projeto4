import book from '../../../assets/Home/book.svg';
import clothes from '../../../assets/Home/clothes.svg';
import people from '../../../assets/Home/people.svg';
import React, { useEffect } from 'react';
import './Fourth.css'
function FourthSection() {
    useEffect(() => {
      const counters = document.querySelectorAll('.counter');
      let hasAnimated = false;
  
      // Função para animar os contadores
      const animateCounters = () => {
        counters.forEach(counter => {
          const target = +counter.getAttribute('data-target');
          let count = 0;
          const velocidadeContador = target / 100; // Velocidade do contador
          const formatNumber = num => num.toLocaleString('pt-BR');
  
          const updateCount = () => {
            count = Math.min(count + velocidadeContador, target);
            counter.innerText = `+${formatNumber(Math.floor(count))}`;
            if (count < target) {
              setTimeout(updateCount, 10);
            } else {
              counter.innerText = `+${formatNumber(target)}`;
            }
          };
  
          updateCount();
        });
      };
  
      // Configuração do IntersectionObserver
      const observer = new IntersectionObserver(entries => {
        entries.forEach(entry => {
          if (entry.isIntersecting && !hasAnimated) {
            // Inicia a animação apenas quando a seção entra na viewport
            animateCounters();
            hasAnimated = true; // Marca a animação como já realizada
            observer.disconnect(); // Desconecta o observer após a animação iniciar
          }
        });
      }, {
        threshold: 0.5 // A seção deve estar pelo menos 50% visível para iniciar a animação
      });
  
      observer.observe(document.querySelector('#fourth-container'));
  
      return () => {
        if (observer) observer.disconnect(); // Limpa o observer quando o componente desmontar
      };
    }, []);
  
    return (
      <section id="fourth-container">
        <h1>Nossos números</h1>
        <div className="imgs-logo">
          <div className="img-logo">
            <img src={book} alt="Livros" />
            <h3 className="counter" data-target="1000000">+0</h3>
            <p>de livros doados.</p>
          </div>
          <div className="img-logo">
            <img src={clothes} alt="Roupas" />
            <h3 className="counter" data-target="1000000">+0</h3>
            <p>de roupas doadas.</p>
          </div>
          <div className="img-logo">
            <img src={people} alt="Pessoas" />
            <h3 className="counter" data-target="1000000">+0</h3>
            <p>de doadores.</p>
          </div>
        </div>
      </section>
    );
  }
  
  export default FourthSection;