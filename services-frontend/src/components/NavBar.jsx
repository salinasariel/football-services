import React, { useState, useEffect } from 'react';
import { fetchEnvironmentData, getEnvironmentData } from '../EnvironmentData';

export default function Navbar() {
  const [data, setData] = useState(null);
  const [menuOpen, setMenuOpen] = useState(false);

  useEffect(() => {
    const loadEnvironmentData = async () => {
      await fetchEnvironmentData();
      setData(getEnvironmentData());
    };

    loadEnvironmentData();
  }, []);

  const toggleMenu = () => {
    setMenuOpen(!menuOpen);
  };

  return (
    <>
      <nav className="bg-strong-green p-5 shadow-md">
        <div className="container mx-auto flex justify-between items-center">
     
          <div className="flex items-center space-x-6">
            <button
              className="text-gray-900"
              onClick={toggleMenu} 
            >
              <svg
                className="h-6 w-6"
                fill="none"
                stroke="currentColor"
                viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth="2"
                  d="M4 6h16M4 12h8m-8 6h8"
                ></path>
              </svg>
            </button>
            <h1 className="text-2xl font-semibold text-gray-900">
              {data?.name }
            </h1>
          </div>
        </div>
      </nav>

      <div
        className={`fixed top-0 left-0 h-full w-64 bg-white shadow-lg transform transition-transform duration-300 z-50 ${
          menuOpen ? 'translate-x-0' : '-translate-x-full'
        }`}
      >
        <button
          className="absolute top-5 right-5 text-gray-900"
          onClick={toggleMenu}
        >
          <svg
            className="h-6 w-6"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
            xmlns="http://www.w3.org/2000/svg"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              strokeWidth="2"
              d="M6 18L18 6M6 6l12 12"
            ></path>
          </svg>
        </button>
        <ul className="mt-16 px-4">
          <li className="py-2 border-b border-gray-200">{data?.name }</li>
          <li className="py-2 border-b border-gray-200">Politica de cancelacion</li>
          <li className="py-8">Crea tu Timely.ar</li>
        </ul>
      </div>
      {menuOpen && (
        <div
          className="fixed inset-0 backdrop-blur-sm bg-black bg-opacity-40 z-40"
          onClick={toggleMenu} 
        ></div>
      )}
    </>
  );
}
