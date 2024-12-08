import React from 'react';
import { useSearchParams } from 'react-router-dom';
import Navbar from '../components/NavBar';
import api from '../api';

const  ServiceReserve = () => {
  const [searchParams] = useSearchParams();
  const serviceName = searchParams.get('serviceId');

  return (
    <div>
      <Navbar/>
     
      <div className="bg-light-brown p-4 w-30 border  rounded-lg shadow-md scale-up-center transition transform hover:scale-105 duration-300 ease-in-out">
      <h1>Reservar servicio: {serviceName}</h1>
    </div>
    </div>
  );
};

export default ServiceReserve;
