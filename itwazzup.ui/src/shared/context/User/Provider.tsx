import React, {
  FunctionComponent,
  ReactElement,
  PropsWithChildren,
  ReactNode
} from 'react';
import useLocalStorage from 'react-use/lib/useLocalStorage';
import UserContext, { UserSession, UserIdentity } from '.';
import { USER_SESSION, USER_IDENTITY } from './constants';

type Props = {} & PropsWithChildren<ReactNode>;

const UserProvider: FunctionComponent<Props> = (props: Props): ReactElement => {
  const [userSession, setUserSession] = useLocalStorage<
    UserSession | undefined
  >(USER_SESSION, undefined);

  const [userIdentity, setUserIdentity] = useLocalStorage<
    UserIdentity | undefined
  >(USER_IDENTITY, undefined);

  return (
    <UserContext.Provider
      value={{ userSession, setUserSession, userIdentity, setUserIdentity }}
    >
      {props.children}
    </UserContext.Provider>
  );
};
export default UserProvider;
