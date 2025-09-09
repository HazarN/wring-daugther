import { KeyboardAvoidingView, Platform, View } from 'react-native';

import ThemedInput from '@ui/ThemedInput';
import ThemedText from '@ui/ThemedText';
import { useState } from 'react';

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
        </View>
      </View>
    </KeyboardAvoidingView>
  );
}

export default Signup;
