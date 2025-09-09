import {
  RobotoMono_400Regular,
  RobotoMono_500Medium,
  useFonts,
} from '@expo-google-fonts/roboto-mono';
import { Stack } from 'expo-router';
import { StatusBar } from 'expo-status-bar';
import { View } from 'react-native';

import ThemeProvider from '@context/theme/ThemeProvider';
import { useTheme } from '@hooks/useTheme';
import { useThemedStack } from '@hooks/useThemedStack';
import '@styles/globals.css';
import ThemeIcon from '@ui/ThemeIcon';

// Main layout is separated with an AppContent to be able to use theme provider
const AppContent = () => {
  const { theme } = useTheme();
  const options = useThemedStack();

  return (
    <View className={theme === 'dark' ? 'dark flex-1' : 'flex-1'}>
      <StatusBar style={theme === 'dark' ? 'light' : 'dark'} />

      <Stack
        screenOptions={{
          ...options,
          headerRight: () => <ThemeIcon />,
        }}
      >
        <Stack.Screen name='index' options={{ title: '' }} />
        <Stack.Screen name='(auth)/login' options={{ title: 'Login' }} />
        <Stack.Screen name='(auth)/signup' options={{ title: 'Sign Up' }} />
      </Stack>
    </View>
  );
};

export default function RootLayout() {
  const fontsLoaded = useFonts({ RobotoMono_400Regular, RobotoMono_500Medium });
  if (!fontsLoaded) throw new Error('Fonts cannot be applied to the app');

  return (
    <ThemeProvider>
      <AppContent />
    </ThemeProvider>
  );
}
