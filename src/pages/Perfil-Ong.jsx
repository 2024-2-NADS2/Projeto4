
import React from 'react';
import Navbar from './components/Navbar';
import ProfileCard from './components/ProfileCard';
import ItemsSection from './components/ItemsSection';
import InterestsSection from './components/InterestsSection';
import './App.css';

function PerfilOng() {
  return (
    <div className="app">
      <Header />
      <div className="main-content">
        <ProfileCard />
        <ItemsSection />
        <InterestsSection />
      </div>
    </div>
  );
}

export default PerfilOng;
