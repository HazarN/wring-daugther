import { View } from 'react-native';

import ThemedButton from '@ui/ThemedButton';
import ThemedText from '@ui/ThemedText';

function Home() {
  return (
    <View className='flex-1 justify-around items-center'>
      <View className='flex items-center'>
        <ThemedText className='text-3xl mb-2' bold>
          Wring Daugther
        </ThemedText>
        <ThemedText className='text-xl'>Nothing special here.</ThemedText>
      </View>

      <ThemedButton className='mb-10'>Check In</ThemedButton>
    </View>
  );
}

export default Home;
