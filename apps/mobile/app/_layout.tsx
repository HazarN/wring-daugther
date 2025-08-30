import { Merriweather_400Regular, useFonts } from '@expo-google-fonts/merriweather';
import { Stack } from 'expo-router';
import { StatusBar } from 'expo-status-bar';

import ThemeProvider from '@context/Theme';

import '@styles/globals.css';

function Layout() {
  const fonts = useFonts({ Merriweather_400Regular });
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
