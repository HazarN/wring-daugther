import Constants from 'expo-constants';
import { useEffect, useState } from 'react';
import { useColorScheme } from 'react-native';

import ThemeContext from '@context/theme/ThemeContext';

type ThemeType = 'light' | 'dark';
type Props = {
  children: React.ReactNode;
};
function ThemeProvider({ children }: Props) {
  const systemScheme = useColorScheme();
  const appTheme = Constants.expoConfig?.userInterfaceStyle ?? 'system';

  const [theme, setTheme] = useState<ThemeType>((): ThemeType => {
    if (appTheme === 'system') return (systemScheme ?? 'dark') as ThemeType;
    return (appTheme ?? 'dark') as ThemeType;
  });

  useEffect(() => {
    if (appTheme === 'system') {
      setTheme((systemScheme ?? 'light') as ThemeType);
    }
  }, [systemScheme]);

  return (
    <ThemeContext.Provider
      value={{
        theme,
        toggle: () => setTheme((t) => (t === 'light' ? 'dark' : 'light')),
      }}
    >
      {children}
    </ThemeContext.Provider>
  );
}

export default ThemeProvider;
