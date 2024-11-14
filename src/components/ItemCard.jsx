import React from 'react';

function ItemCard({ item }) {
  const statusColors = {
    'Recebido': 'green',
    'Em Trânsito': 'orange',
    'A Retirar': 'red',
  };

  return (
    <div className="item-card">
      <img src={`${item.title}.jpg`} alt={item.title} className="item-image" />
      <div className="item-info">
        <h4>{item.title}</h4>
        <p>{item.description}</p>
        {item.date && <p>Recebido em {item.date}</p>}
      </div>
      <span className={`status ${statusColors[item.status]}`}>{item.status}</span>
    </div>
  );
}

export default ItemCard;
