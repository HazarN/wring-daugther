import { useTheme } from '@hooks/useTheme';

export function useThemedStack() {
  const { theme } = useTheme();

  return {
    headerStyle: {
      backgroundColor: theme === 'dark' ? '#121212' : '#f9f9f9',
    },
    headerTintColor: theme === 'dark' ? '#fff' : '#000',
    headerTitleStyle: {
      fontFamily: 'RobotoMono_400Regular',
    },
    contentStyle: {
      backgroundColor: theme === 'dark' ? '#121212' : '#f9f9f9',
    },
  };
}
