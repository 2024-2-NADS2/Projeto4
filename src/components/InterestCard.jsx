import React from 'react';

function InterestCard({ interest }) {
  return (
    <div className="interest-card">
      <img src={`${interest.title}.jpg`} alt={interest.title} className="interest-image" />
      <div className="interest-info">
        <h4>{interest.title}</h4>
        <p>{interest.description}</p>
      </div>
      <span className="status orange">{interest.status}</span>
    </div>
  );
}

export default InterestCard;
