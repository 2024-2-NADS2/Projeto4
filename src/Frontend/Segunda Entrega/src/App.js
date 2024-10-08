import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './components/Navbar';
import Home from './pages/Home';
import About from './pages/About';
import ComoFunciona from './pages/Como-Funciona';
import Footer from './components/Footer';
import './App.css';


function App() {
  return (
    <Router>
      <div>
        <Navbar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />} />
          <Route path="/como-funciona" element={<ComoFunciona />} />
        </Routes>
        <Footer />
      </div>
    </Router>
  );
}

export default App;
