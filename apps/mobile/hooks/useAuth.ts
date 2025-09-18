import { useContext } from 'react';

import AuthContext from '@context/auth/AuthContext';

export function useAuth() {
  const context = useContext(AuthContext);

  if (!context) throw new Error('Auth context is called outside of its provider');
  return context;
}
