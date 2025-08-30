import { useContext } from 'react';

import ThemeContext from '@context/theme/ThemeContext';

export function useTheme() {
  const context = useContext(ThemeContext);

  if (!context) throw new Error('Theme context is called outside of its provider');
  return context;
}
