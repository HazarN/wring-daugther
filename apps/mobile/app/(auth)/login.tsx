import React, { useState } from 'react';
import { KeyboardAvoidingView, Platform, View } from 'react-native';

import ThemedInput from '@ui/ThemedInput';
import ThemedText from '@ui/ThemedText';
import { Link } from 'expo-router';

function Login() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

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

          <View>
            <Link href='/signup'>
              <ThemedText>Don't have an account?</ThemedText>
              <ThemedText className='text-blue-500'> Sign Up</ThemedText>
            </Link>
          </View>
        </View>
      </View>
    </KeyboardAvoidingView>
  );
}

export default Login;
