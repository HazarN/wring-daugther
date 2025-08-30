import { Stack } from 'expo-router';

import '@styles/globals.css';

function Layout() {
  return (
    <Stack>
      <Stack.Screen name='index' options={{ title: 'Home' }} />
    </Stack>
  );
}

export default Layout;
