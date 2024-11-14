import React from 'react';
import InterestCard from './InterestCard';

function InterestsSection() {
  const interests = [
    { title: 'Camiseta', description: 'Camisa nova', status: 'Em análise' },
  ];

  return (
    <div className="interests-section">
      <h3>Meus interesses(3)</h3>
      {interests.map((interest, index) => (
        <InterestCard key={index} interest={interest} />
      ))}
    </div>
  );
}

export default InterestsSection;
