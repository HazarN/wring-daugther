import { SafeAreaView, Text } from 'react-native';

function Home() {
  return (
    <SafeAreaView className='flex-1 justify-center items-center bg-background-light dark:bg-background-dark'>
      <Text className='text-2xl text-text-light dark:text-text-dark font-dactilo'>
        Wring Daugther Mobile App
      </Text>
    </SafeAreaView>
  );
}

export default Home;
