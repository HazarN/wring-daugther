import { Pressable, PressableProps } from 'react-native';

import { useTheme } from '@hooks/useTheme';

import ThemedText from '@ui/ThemedText';

type Props = {
  children: React.ReactNode;
  className?: PressableProps['className'];
  full?: boolean;
  onPress?: () => {};
};
function ThemedButton({ children, className, full, onPress }: Props) {
  const { theme } = useTheme();

  return (
    <Pressable
      className={`rounded-2xl border py-12
        ${full ? 'w-full' : 'px-20'}
        ${
          theme === 'dark'
            ? 'bg-surface-dark border-border-dark active:bg-surface-dark-hover'
            : 'bg-surface-light border-border-light active:bg-surface-light-hover'
        }
        ${className}
      `}
      onPress={onPress}
    >
      <ThemedText className='text-center'>{children}</ThemedText>
    </Pressable>
  );
}

export default ThemedButton;
