import { useState } from 'react';
import { KeyboardAvoidingView, Platform, View } from 'react-native';

import { useAxios } from '@hooks/useAxios';
import LinkText from '@ui/LinkText';
import ThemedButton from '@ui/ThemedButton';
import ThemedInput from '@ui/ThemedInput';
import ThemedText from '@ui/ThemedText';

function Login() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const axios = useAxios();
  const testAxios = () => axios.post('Auth/login', { username: 'HazarN', password: 'HazarN5.' });

  return (
    <KeyboardAvoidingView
      className='flex-1'
      behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
      keyboardVerticalOffset={Platform.OS === 'ios' ? 60 : 20}
    >
      <View className='flex-1 justify-around items-center'>
        <ThemedText className='text-4xl'>Login</ThemedText>

        <View className='w-5/6 flex items-center'>
          <ThemedInput full placeholder='Username' value={username} onChangeText={setUsername} />
          <ThemedInput
            full
            secured
            placeholder='Password'
            value={password}
            onChangeText={setPassword}
          />

          <View className='flex flex-row items-center'>
            <ThemedText>Don't have an account?</ThemedText>

            <LinkText to={'/signup'}>Sign Up</LinkText>
          </View>

          <ThemedButton full className='mt-2' inverted onPress={testAxios}>
            Login
          </ThemedButton>
        </View>
      </View>
    </KeyboardAvoidingView>
  );
}

export default Login;
