import { Ionicons } from '@expo/vector-icons';
import { useEffect, useRef } from 'react';
import { Animated, Easing, Pressable } from 'react-native';

import { useTheme } from '@hooks/useTheme';

function ThemeIcon() {
  const scale = useRef(new Animated.Value(1)).current;

  const { theme, toggle } = useTheme();

  useEffect(() => {
    // Scaling animation
    Animated.sequence([
      Animated.timing(scale, {
        toValue: 0.8,
        duration: 120,
        easing: Easing.ease,
        useNativeDriver: true,
      }),
      Animated.timing(scale, {
        toValue: 1,
        duration: 120,
        easing: Easing.out(Easing.ease),
        useNativeDriver: true,
      }),
    ]).start();
  }, [theme]);

  return (
    <Pressable onPress={toggle} className='mr-3'>
      <Animated.View style={{ transform: [{ scale }] }}>
        <Ionicons
          name={theme === 'dark' ? 'moon' : 'sunny'}
          size={22}
          color={theme === 'dark' ? '#fff' : '#000'}
        />
      </Animated.View>
    </Pressable>
  );
}

export default ThemeIcon;
