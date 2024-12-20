import React, { useState, useEffect } from 'react';

import { fetchEnvironmentData, getEnvironmentData } from '../EnvironmentData';


/** @type {import('tailwindcss').Config} */
export default {

  content: [
    "./index.html",

    
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        'light-yellow': '#FEFAE0',
        'light-brown': '#FAEDCE',
        'light-green': '#E0E5B6',
        'strong-green': '#CCD5AE',
      },
    },
  },
  plugins: [],
}
