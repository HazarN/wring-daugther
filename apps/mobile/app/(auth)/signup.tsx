import { useState } from 'react';
import { KeyboardAvoidingView, Platform, View } from 'react-native';

import LinkText from '@ui/LinkText';
import ThemedButton from '@ui/ThemedButton';
import ThemedInput from '@ui/ThemedInput';
import ThemedText from '@ui/ThemedText';

function Signup() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [passwordRepeated, setPasswordRepeated] = useState('');

  return (
    <KeyboardAvoidingView
      className='flex-1'
      behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
      keyboardVerticalOffset={Platform.OS === 'ios' ? 60 : 20}
    >
      <View className='flex-1 justify-around items-center'>
        <ThemedText className='text-4xl'>Sign Up</ThemedText>

        <View className='w-5/6 flex items-center'>
          <ThemedInput full placeholder='Username' value={username} onChangeText={setUsername} />
          <ThemedInput
            full
            secured
            placeholder='Password'
            value={password}
            onChangeText={setPassword}
          />
          <ThemedInput
            full
            secured
            placeholder='Repeat the password'
            value={passwordRepeated}
            onChangeText={setPasswordRepeated}
          />

          <View className='flex flex-row items-center'>
            <ThemedText>Already have one?</ThemedText>

            <LinkText to={'/login'}>Sign Up</LinkText>
          </View>

          <ThemedButton full inverted className='mt-2'>
            Register
          </ThemedButton>
        </View>
      </View>
    </KeyboardAvoidingView>
  );
}

export default Signup;
