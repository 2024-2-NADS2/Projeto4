import React from 'react';
import bradesco from '../../../assets/Home/bradesco.svg';
import fecap from '../../../assets/Home/fecap.svg';
import nike from '../../../assets/Home/nike.svg';
import saraiva from '../../../assets/Home/saraiva.svg';
import renner from '../../../assets/Home/renner.svg';
import mcdonalds from '../../../assets/Home/mcdonalds.svg';
import './Third.css'
function ThirdSection() {
  return (
    <section id="third-container">
      <h1>Quem já <span id="faz">faz</span> parte?</h1>
      <div className="imgs-logo">
        <div className="img-logo"><img src={bradesco} alt="Bradesco" /></div>
        <div className="img-logo"><img src={fecap} alt="Fecap" /></div>
        <div className="img-logo"><img src={nike} alt="Nike" /></div>
        <div className="img-logo"><img src={saraiva} alt="Saraiva" /></div>
        <div className="img-logo"><img src={renner} alt="Renner" /></div>
        <div className="img-logo"><img src={mcdonalds} alt="McDonalds" /></div>
      </div>
    </section>
  );
}

export default ThirdSection;
