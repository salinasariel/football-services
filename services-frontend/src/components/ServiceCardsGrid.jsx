import React, { useState, useEffect } from 'react';
import ServiceCard from './ServiceCard';
import { fetchEnvironmentData, getTypeServicesData } from '../EnvironmentData';

export const ServiceCardsGrid = () => {
  const [data, setData] = useState([]); 

  useEffect(() => {
    const loadEnvironmentData = async () => {
      try {
        await fetchEnvironmentData(); 
        const servicesData = getTypeServicesData()?.$values || []; 
        setData(servicesData); 
      } catch (error) {
        console.error('Error al cargar datos:', error);
        setData([]); 
      }
    };

    loadEnvironmentData();
  }, []);

  return (
    <div className="grid gap-4 grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-3 xl:grid-cols-4 p-4">
  {data.map((service, index) => (
    <ServiceCard
      key={service.idTypeServices || index}
      serviceName={service.name}
      serviceDesc={service.description || 'Descripción no disponible'}
      photo={service.photo || ''}
      serviceId={service.idTypeServices || ''}
    />
  ))}
</div>

  );
};

export default ServiceCardsGrid;
