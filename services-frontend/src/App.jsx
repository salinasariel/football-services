import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from '../src/pages/home';
import ServiceReserve from '../src/pages/ServiceReserve';

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/servicereserve" element={<ServiceReserve />} />
      </Routes>
    </Router>
  );
};

export default App;
