import { RobotoMono_400Regular, useFonts } from '@expo-google-fonts/roboto-mono';
import { Stack } from 'expo-router';
import { StatusBar } from 'expo-status-bar';
import { View } from 'react-native';

import ThemeProvider from '@context/theme/ThemeProvider';
import { useTheme } from '@hooks/useTheme';
import { useThemedStack } from '@hooks/useThemedStack';
import '@styles/globals.css';
import ThemeIcon from '@ui/ThemeIcon';

export default function RootLayout() {
  const fontsLoaded = useFonts({ RobotoMono_400Regular });
  if (!fontsLoaded) throw new Error('Fonts cannot be applied to the app');

  return (
    <ThemeProvider>
      <AppContent />
    </ThemeProvider>
  );
}

function AppContent() {
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
        <Stack.Screen name='index' options={{ title: 'Home' }} />
      </Stack>
    </View>
  );
}
