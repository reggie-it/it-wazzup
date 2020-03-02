import { createContext } from 'react';

export type UserSession = {
  accessToken: string;
  expiresIn: number;
  refreshToken: string;
};

export type UserIdentity = {
  clientId: number;
  clientName: string;
  email: string;
  firmId: string;
  isAdmin: boolean;
  loginId: number;
  name: string;
  roles: string[];
  username: string;
};

export type UserContextState = {
  userSession?: UserSession;
  setUserSession: (value: UserSession | undefined) => void;
  userIdentity?: UserIdentity;
  setUserIdentity: (value: UserIdentity | undefined) => void;
};

const defaultValue: UserContextState = {
  userSession: undefined,
  setUserSession: (): void => {},
  userIdentity: undefined,
  setUserIdentity: (): void => {}
};

const UserContext = createContext(defaultValue);
export default UserContext;
