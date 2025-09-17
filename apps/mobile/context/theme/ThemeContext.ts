import { createContext } from 'react';

import ThemeContextType from '@models/ThemeContextType';

const ThemeContext = createContext<ThemeContextType>({ theme: 'dark', toggle: () => {} });
export default ThemeContext;
