/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './app/**/*.{js,jsx,ts,tsx}',
    './features/**/*.{js,jsx,ts,tsx}',
    './ui/**/*.{js,jsx,ts,tsx}',
  ],
  presets: [require('nativewind/preset')],
  darkMode: 'class',
  theme: {
    extend: {
      colors: {
        background: {
          light: '#f9f9f9',
          dark: '#121212',
        },
        surface: {
          light: '#ffffff',
          dark: '#1e1e1e',
        },
        text: {
          light: '#222222',
          dark: '#ffffff',
        },
        border: {
          light: '#444444',
          dark: '#bbbbbb',
        },
      },
      fontFamily: {
        dactilo: ['RobotoMono_400Regular'],
      },
    },
  },
  plugins: [],
};
