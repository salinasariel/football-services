import React from 'react'

export const ServiceCard = () => {
  return (
    <div className='bg-light-brown p-4 w-30 border rounded-lg shadow-md scale-up-center transition transform hover:scale-105 duration-300 ease-in-out'>
        <h1 className=''>card.tittle</h1>
        <h1 className=''>card.subtittle</h1>
        <img 
        className='border rounded-lg'
          src='https://media.istockphoto.com/id/1400697245/es/vector/vector-de-campo-de-f%C3%BAtbol-de-c%C3%A9sped-rayado-con-estrategias-de-juego.jpg?s=612x612&w=is&k=20&c=i-15oopMQgFRda_wTp5xhFZe1fpZ62ZmvvmekvUZU44=' 
          alt='Campo de fútbol' 
        />
        <div className='text-right'>
        <button className='bg-light-green border p-2 m-3 rounded-lg'>Reservar</button>
        </div>
    </div>
  )
}

export default ServiceCard; 