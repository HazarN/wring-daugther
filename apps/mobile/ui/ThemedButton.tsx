import { Pressable, PressableProps, Text } from 'react-native';

import { useTheme } from '@hooks/useTheme';

type Props = {
  children: React.ReactNode;
  className?: PressableProps['className'];
  full?: boolean;
  inverted?: boolean;
  onPress?: () => {};
};
function ThemedButton({ children, className, full, inverted, onPress }: Props) {
  const { theme } = useTheme();

  return (
    <Pressable
      className={`rounded-2xl border py-4
        ${full ? 'w-full' : 'px-20'}
        ${
          inverted
            ? theme === 'dark'
              ? 'bg-surface-light border-border-light active:bg-surface-light-hover'
              : 'bg-surface-dark border-border-dark active:bg-surface-dark-hover'
            : theme === 'dark'
            ? 'bg-surface-dark border-border-dark active:bg-surface-dark-hover'
            : 'bg-surface-light border-border-light active:bg-surface-light-hover'
        }
        ${className}
      `}
      onPress={onPress}
    >
      <Text
        className={`font-dactilo text-center ${
          inverted
            ? theme === 'dark'
              ? 'text-text-light'
              : 'text-text-dark'
            : theme === 'dark'
            ? 'text-text-dark'
            : 'text-text-light'
        }`}
      >
        {children}
      </Text>
    </Pressable>
  );
}

export default ThemedButton;
