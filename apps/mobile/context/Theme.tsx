import Constants from 'expo-constants';
import { createContext, useContext, useEffect, useState } from 'react';
import { useColorScheme } from 'react-native';

type ThemeType = 'light' | 'dark';

// Context
const ThemeContext = createContext({ theme: 'light', toggle: () => {} });

// Provider
type Props = {
  children: React.ReactNode;
};
function ThemeProvider({ children }: Props) {
  const systemScheme = useColorScheme();
  const appTheme = Constants.expoConfig?.userInterfaceStyle ?? 'system';

  const [theme, setTheme] = useState<ThemeType>((): ThemeType => {
    if (appTheme === 'system') return (systemScheme ?? 'light') as ThemeType;
    return (appTheme ?? 'light') as ThemeType;
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

// Hook
export function useTheme() {
  return useContext(ThemeContext);
}

export default ThemeProvider;
