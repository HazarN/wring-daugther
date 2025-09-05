import { RobotoMono_400Regular, useFonts } from '@expo-google-fonts/roboto-mono';
import { Stack } from 'expo-router';
import { StatusBar } from 'expo-status-bar';

import ThemeProvider from '@context/theme/ThemeProvider';

import '@styles/globals.css';

function Layout() {
  const fonts = useFonts({ RobotoMono_400Regular });
  if (!fonts) return null;

  return (
    <ThemeProvider>
      <StatusBar style='auto' />

      <Stack screenOptions={{ headerShown: false }}>
        <Stack.Screen name='index' options={{ title: 'Home' }} />
      </Stack>
    </ThemeProvider>
  );
}

export default Layout;
