import React, { ReactElement, FunctionComponent } from 'react';
import { RouteComponentProps, withRouter } from 'react-router-dom';
import Login from './components/login/login.component';
import Routes from './routes';
import useUser from './shared/context/User/useUser';
// import { setAuthorizationHeader } from './api-client/planit/base';

type Props = {} & RouteComponentProps;

const App: FunctionComponent<Props> = (props: Props): ReactElement => {
  const { userSession, userIdentity } = useUser();

  // if (!userSession || !userIdentity) return <Login />;
  if (userSession) {
    // setAuthorizationHeader(userSession.accessToken);
    console.log(userSession);
  }
  return (
    <div>
      <main>
        <Routes />
      </main>
    </div>
  );
};

export default withRouter(App);
