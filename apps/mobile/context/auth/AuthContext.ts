import { createContext } from 'react';

import AuthContextType from '@models/AuthContextType';

const AuthContext = createContext<AuthContextType | null>(null);
export default AuthContext;
