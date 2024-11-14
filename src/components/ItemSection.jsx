import React from 'react';
import ItemCard from './ItemCard';

function ItemsSection() {
  const items = [
    { title: 'É assim que acaba', description: 'Livro semi-usado', status: 'Recebido' },
    { title: 'Boné', description: 'Boné novo', status: 'Em Trânsito', date: '21/10/2024' },
    { title: 'Harry Potter', description: 'Livro antigo', status: 'A Retirar' },
  ];

  return (
    <div className="items-section">
      <h3>Itens Arrecadados (3)</h3>
      {items.map((item, index) => (
        <ItemCard key={index} item={item} />
      ))}
    </div>
  );
}

export default ItemsSection;
