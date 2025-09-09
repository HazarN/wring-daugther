import { View } from 'react-native';

import ThemedLink from '@ui/ThemedLink';
import ThemedText from '@ui/ThemedText';

function Home() {
  return (
    <View className='flex-1 justify-around items-center mx-4'>
      <View className='flex items-center'>
        <ThemedText className='text-4xl mb-2' bold>
          Wring Daugther
        </ThemedText>
        <ThemedText className='text-xl'>Nothing special here.</ThemedText>
      </View>

      <ThemedLink to='/signup' className='mb-10' full>
        <ThemedText>Check In</ThemedText>
      </ThemedLink>
    </View>
  );
}

export default Home;
