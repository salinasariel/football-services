import React from 'react';
import { useNavigate } from 'react-router-dom';

export const ServiceCard = ({ serviceName, serviceDesc, photo, serviceId }) => {
  const navigate = useNavigate(); // Hook para redirigir

  const decodePhoto = `data:image/jpg;base64,${photo}`;

  const handleReserve = () => {
    // Redirige a /servicereserve con serviceName como parámetro
    navigate(`/servicereserve?serviceId=${encodeURIComponent(serviceId)}`);
  };

  return (
    <div className="bg-light-brown p-4 w-30 border rounded-lg shadow-md scale-up-center transition transform hover:scale-105 duration-300 ease-in-out">
      <h1 className="text-xl font-bold">{serviceName}</h1>
      <p className="text-sm text-gray-700">{serviceDesc}</p>
      <img
        className="border rounded-lg mt-3 w-full h-48 object-cover"
        src={decodePhoto || 'https://via.placeholder.com/650'}
        alt={serviceName}
      />
      <div className="text-right mt-4">
        <button
          className="bg-light-green border p-2 rounded-lg hover:bg-strong-green"
          onClick={handleReserve} // Asocia el evento
        >
          Reservar
        </button>
      </div>
    </div>
  );
};

export default ServiceCard;
