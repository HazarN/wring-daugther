import { useTheme } from '@hooks/useTheme';
import { Text, View } from 'react-native';

function Home() {
  const { theme } = useTheme();

  return (
    <View className='flex-1 justify-center items-center'>
      <Text
        className={`text-2xl font-dactilo ${
          theme === 'dark' ? 'text-text-dark' : 'text-text-light'
        }`}
      >
        Wring Daugther Mobile App
      </Text>
    </View>
  );
}

export default Home;
