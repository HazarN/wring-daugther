import React, { useState } from 'react';
import { KeyboardAvoidingView, Platform, View } from 'react-native';

import { useKeyboardDismiss } from '@hooks/useKeyboardDismiss';
import ThemedInput from '@ui/ThemedInput';
import ThemedLink from '@ui/ThemedLink';
import ThemedText from '@ui/ThemedText';

function Login() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const KeyboardDismissWrapper = useKeyboardDismiss();

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

          <ThemedText>
            Don't have an account?
            <ThemedLink to='/login'>
              <ThemedText className='text-blue-600'>Sign Up</ThemedText>
            </ThemedLink>
          </ThemedText>
        </View>
      </View>
    </KeyboardAvoidingView>
  );
}

export default Login;
