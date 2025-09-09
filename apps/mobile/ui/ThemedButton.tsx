import { useTheme } from '@hooks/useTheme';
import { Pressable, PressableProps } from 'react-native';

import ThemedText from '@ui/ThemedText';

type Props = {
  children: React.ReactNode;
  className?: PressableProps['className'];
  onPress?: () => {};
};
function ThemedButton({ children, className, onPress }: Props) {
  const { theme } = useTheme();

  return (
    <Pressable
      className={`px-20 py-6 rounded-2xl border
        ${
          theme === 'dark'
            ? 'bg-surface-dark border-border-dark active:bg-surface-dark-hover'
            : 'bg-surface-light border-border-light active:bg-surface-light-hover'
        }
        ${className}
    `}
    >
      <ThemedText>{children}</ThemedText>
    </Pressable>
  );
}

export default ThemedButton;
