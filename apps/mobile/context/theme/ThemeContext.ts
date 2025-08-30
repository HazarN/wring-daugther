import { createContext } from 'react';

const ThemeContext = createContext({ theme: 'light', toggle: () => {} });
export default ThemeContext;
