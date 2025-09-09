import { Link, LinkProps } from 'expo-router';

import { useTheme } from '@hooks/useTheme';

import ThemedText from '@ui/ThemedText';

type Props = {
  children: React.ReactNode;
  className?: LinkProps['className'];
  to: LinkProps['href'];
  full?: boolean;
};
function ThemedLink({ children, className, to, full }: Props) {
  const { theme } = useTheme();

  return (
    <Link
      href={to}
      className={`rounded-2xl border py-6
        ${full ? 'w-full' : 'px-20'}
        ${
          theme === 'dark'
            ? 'bg-surface-dark border-border-dark active:bg-surface-dark-hover'
            : 'bg-surface-light border-border-light active:bg-surface-light-hover'
        }
    ${className}`}
    >
      <ThemedText className='text-center hover:bg-inherit'>{children}</ThemedText>
    </Link>
  );
}

export default ThemedLink;
