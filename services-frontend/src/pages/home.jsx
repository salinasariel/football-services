import React from 'react'
import NavBar from '../components/NavBar'
import { ServiceCard } from '../components/ServiceCard';
import { ServiceCardsGrid } from '../components/ServiceCardsGrid';

export const Home = () => {
  return (
    <div>
        <NavBar/>
        <ServiceCardsGrid/>
        
    </div>
  )
}
export default Home;