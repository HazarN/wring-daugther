import { Tokens } from '@models/Tokens';

type AuthContextType = {
  accessToken: string | null;
  refreshToken: string | null;
  login: (tokens: Tokens) => void;
  logout: () => void;
  setAccessToken: (token: string) => void;
};

export default AuthContextType;
