import { Link, LinkProps } from 'expo-router';
import { Pressable, Text } from 'react-native';

import { useTheme } from '@hooks/useTheme';

type Props = {
  children: React.ReactNode;
  to: LinkProps['href'];
};
function LinkText({ children, to }: Props) {
  const { theme } = useTheme();

  return (
    <Link href={to} asChild replace>
      <Pressable
        className={` ${
          theme === 'dark' ? 'hover:bg-background-dark' : 'hover:bg-background-light'
        }`}
      >
        <Text className='text-blue-500'>{children}</Text>
      </Pressable>
    </Link>
  );
}

export default LinkText;
