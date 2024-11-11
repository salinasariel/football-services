import React from 'react'
import ServiceCard from './ServiceCard'

export const ServiceCardsGrid = () => {
  return (
    <div className="grid gap-4 grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-3 xl:grid-cols-4 p-4">
      <ServiceCard />
      <ServiceCard />
      <ServiceCard />
      <ServiceCard />
      <ServiceCard />
    </div>
  )
}

export default ServiceCardsGrid;
