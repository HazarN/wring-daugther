import { Text, TextProps } from 'react-native';

import { useTheme } from '@hooks/useTheme';

type Props = {
  children: React.ReactNode;
  className?: TextProps['className'];
  bold?: boolean;
};
function ThemedText({ children, className, bold }: Props) {
  const { theme } = useTheme();

  return (
    <Text
      className={`p-1 
        ${bold ? 'font-boldtilo' : 'font-dactilo'} 
        ${theme === 'dark' ? 'text-text-dark' : 'text-text-light'} 
        ${className}`}
    >
      {children}
    </Text>
  );
}

export default ThemedText;
