import React, { useState, useEffect } from 'react';
import { fetchEnvironmentData, getEnvironmentData } from '../EnvironmentData';

export default function Navbar() {
  const [data, setData] = useState(null);

  useEffect(() => {
    const loadEnvironmentData = async () => {
      await fetchEnvironmentData(); 
      setData(getEnvironmentData()); 
    };

    loadEnvironmentData();
  }, []);

  const [menuOpen, setMenuOpen] = useState(false);

  const toggleMenu = () => {
    setMenuOpen(!menuOpen);
  };

  return (
    <nav className="bg-strong-green p-5 shadow-md">
      <div className="container mx-auto flex justify-between items-center">
        <div className="flex items-center space-x-6">
          <button className="text-gray-900">
            <svg className="h-5 w-5" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M4 6h16M4 12h8m-8 6h8"></path>
            </svg>
          </button>
          <h1 className="text-2xl font-semibold text-gray-900">
            {data?.name }
          </h1>
        </div>
      </div>
    </nav>
  );
}
