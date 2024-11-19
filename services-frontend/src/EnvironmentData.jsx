import api from './api'; 

let environmentData = null;
let typeServicesData = null; 

let establishmentId = 9;

export async function fetchEnvironmentData() {

  environmentData = null;
  typeServicesData = null;

  try {

    const response = await api.get(`establishment/GetEstablishmetbyId?id=${establishmentId}`);
    const data = response?.data;


    environmentData = data;
    console.log('Datos de establecimiento:', environmentData);
  } catch (error) {
    console.error('Error al obtener datos de la API (Establishment):', error);
    environmentData = { name: 'Error al cargar el establecimiento' };
  }

  try {

    const responseType = await api.get(`Services/GetActiveAllTypeServicesByEstablishment?EstablishmentID=${establishmentId}`);
    const data = responseType?.data;

    typeServicesData = data;
    console.log('Datos de tipos de servicios:', typeServicesData);
  } catch (error) {
    console.error('Error al obtener datos de la API (Type Services):', error);
    typeServicesData = []; 
  }
}


export function getEnvironmentData() {
  return environmentData;
}

export function getTypeServicesData() {
  return typeServicesData;
}
