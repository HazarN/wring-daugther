import { useTheme } from '@hooks/useTheme';
import { TextInput, TextInputProps } from 'react-native';

type Props = TextInputProps & {
  full?: boolean;
  secured?: boolean;
};
function ThemedInput({ className, placeholder, onChangeText, value, full, secured }: Props) {
  const { theme } = useTheme();
  const placeholderColors = {
    light: 'rgba(0, 0, 0, .4)',
    dark: 'rgba(255, 255, 255, .4)',
  };

  return (
    <TextInput
      className={`
        m-2 border px-4 h-14 text-lg text-left rounded-2xl
        ${
          theme === 'dark'
            ? 'bg-surface-dark text-text-dark border-border-dark active:bg-surface-dark-hover'
            : 'bg-surface-light text-text-light border-border-light active:bg-surface-light-hover'
        }
        ${className}
        ${full ? 'w-full' : 'px-20'}
      `}
      style={{
        lineHeight: 20,
      }}
      keyboardAppearance={theme === 'dark' ? 'dark' : 'light'}
      placeholderTextColor={theme === 'dark' ? placeholderColors.dark : placeholderColors.light}
      placeholder={placeholder}
      onChangeText={onChangeText}
      value={value}
      secureTextEntry={secured}
      textAlignVertical='center'
      defaultValue=''
    />
  );
}

export default ThemedInput;
