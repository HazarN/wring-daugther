import { useState } from 'react';

import AuthContext from '@context/auth/AuthContext';
import { Tokens } from '@models/Tokens';

type Props = { children: React.ReactNode };
function AuthProvider({ children }: Props) {
  const [accessToken, setAccessToken] = useState<string | null>(null);
  const [refreshToken, setRefreshToken] = useState<string | null>(null);

  const login = (tokens: Tokens) => {
    setAccessToken(tokens.accessToken);
    setAccessToken(tokens.refreshToken);
  };
  const logout = () => {
    setAccessToken(null);
    setRefreshToken(null);
  };

  return (
    <AuthContext.Provider value={{ accessToken, refreshToken, login, logout, setAccessToken }}>
      {children}
    </AuthContext.Provider>
  );
}

export default AuthProvider;
