import React, { useState } from 'react';

export default function Navbar() {
  const [menuOpen, setMenuOpen] = useState(false);

  const toggleMenu = () => {
    setMenuOpen(!menuOpen);
  };

  return (
    <nav className="bg-strong-green p-5 shadow-md ">
      <div className="container mx-auto flex justify-between items-center">
        <div className="flex items-center space-x-6">
          <button className="text-gray-900">
            {/* Ícono de menú */}
            <svg className="h-5 w-5" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M4 6h16M4 12h8m-8 6h8"></path>
            </svg>
          </button>
          <h1 className="text-2xl font-semibold text-gray-900">establishment_name</h1>
        </div>

{/*        
        <div className="relative">
          <button
            onClick={toggleMenu}
            className="flex items-center focus:outline-none"
          >
            <span className="sr-only">Abrir menú de usuario</span>
            
            <svg className="h-8 w-8 text-gray-900" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
              <path fillRule="evenodd" d="M10 12a6 6 0 100-12 6 6 0 000 12zM2 18a8 8 0 0116 0H2z" clipRule="evenodd"></path>
            </svg>
          </button>

          
          {menuOpen && (
            <div className="absolute right-0 mt-2 w-48 bg-white border border-gray-200 rounded-md shadow-lg">
              <a href="#" className="block px-4 py-2 text-gray-700 hover:bg-gray-100">Perfil</a>
              <a href="#" className="block px-4 py-2 text-gray-700 hover:bg-gray-100">Configuración</a>
              <a href="#" className="block px-4 py-2 text-gray-700 hover:bg-gray-100">Cerrar sesión</a>
            </div>
          )}
        </div>
         */}
         
      </div>
    </nav>
  );
}