import { useContext } from 'react';
import UserContext, { UserContextState } from '.';
const useUser = (): UserContextState => {
  const {
    userSession,
    setUserSession,
    userIdentity,
    setUserIdentity
  } = useContext(UserContext);
  return {
    userSession,
    setUserSession,
    userIdentity,
    setUserIdentity
  };
};

export default useUser;
