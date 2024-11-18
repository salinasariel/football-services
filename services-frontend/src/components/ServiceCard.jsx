import React from 'react';

export const ServiceCard = ({ serviceName , serviceDesc , photo }) => {
  return (
    <div className="bg-light-brown p-4 w-30 border rounded-lg shadow-md scale-up-center transition transform hover:scale-105 duration-300 ease-in-out">
      <h1 className="text-xl font-bold">{serviceName}</h1>
      <p className="text-sm text-gray-700">{serviceDesc}</p>
      <img
        className="border rounded-lg mt-3 w-full h-48 object-cover"
        src={photo || 'https://via.placeholder.com/650'} // Imagen predeterminada si no hay foto
        alt={serviceName}
      />
      <div className="text-right mt-4">
        <button className="bg-light-green border p-2 rounded-lg hover:bg-strong-green">
          Reservar
        </button>
      </div>
    </div>
  );
};

export default ServiceCard;
