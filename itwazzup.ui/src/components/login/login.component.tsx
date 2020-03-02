import React, { FunctionComponent, ReactElement, useState } from 'react';
import {
  Formik,
  FormikProps,
  Form,
  FormikActions,
  Field,
  FieldProps
} from 'formik';
import { AxiosResponse } from 'axios';
import './login.styles.scss';
import { Button, TextInput } from '@infotrack/zenith-ui';
import { loginUser } from '../../shared/api-client/user';
import { LoginRequestModel } from '../../shared/api-client/user/models';
// import styles from './styles.module.scss';
// import loginLogo from './loginLogo.png';
// import validatonSchema from './validation-schema';

import { setAuthorizationHeader } from '../../shared/api-client/base';
import useUser from '../../shared/context/User/useUser';
import { UserSession, UserIdentity } from '../../shared/context/User';

const initialValues: LoginRequestModel = {
  username: '',
  password: ''
};

type Props = {};

const Login: FunctionComponent<Props> = (props: Props): ReactElement => {
  const [loginError, setLoginError] = useState('');
  const { setUserSession, setUserIdentity } = useUser();
  const handleSubmit = async (
    values: LoginRequestModel,
    actions: FormikActions<LoginRequestModel>
  ): Promise<void> => {
    try {
      const loginUserResponse = await loginUser(values);
      const userSessionData = loginUserResponse.data as UserSession;
      if (userSessionData) {
        setUserSession(userSessionData);
        setAuthorizationHeader(userSessionData.accessToken);
        // setUserIdentity(userIdentityData);
      }
    } catch (e) {
      // if (e.response) {
      //   const errorResponse = e.response as AxiosResponse;
      //   switch (errorResponse.status) {
      //     default:
      //       setLoginError(
      //         'Login failed. The username or password may be incorrect.'
      //       );
      //       break;

      //     case INTERNAL_SERVER_ERROR:
      //       setLoginError('Oops something went wrong. Please try again.');
      //       break;
      //   }
      // } else {
      //   setLoginError('Oops something went wrong. Please try again.');
      // }
      actions.resetForm(values);
    }
  };

  return (
    <div className="login-component">
      <Formik
        initialValues={initialValues}
        onSubmit={handleSubmit}
        render={({
          touched,
          errors,
          isSubmitting
        }: FormikProps<LoginRequestModel>): ReactElement => (
          <Form className="login-form">
            <h4>Login with your InfoTrack account</h4>
            <div className="">
              <Field
                name={'username'}
                autoFocus
                render={(fieldProps: FieldProps): ReactElement => (
                  <TextInput
                    fullWidth
                    {...fieldProps.field}
                    labelText="Username"
                    placeholder="Enter username"
                    disabled={isSubmitting}
                  />
                )}
              />
              <Field
                name={'password'}
                render={(fieldProps: FieldProps): ReactElement => (
                  <TextInput
                    fullWidth
                    {...fieldProps.field}
                    labelText="Password"
                    placeholder="Enter password"
                    type="password"
                  />
                )}
              />
            </div>
            <Button type="submit" disabled={isSubmitting} fullWidth>
              Login
            </Button>
          </Form>
        )}
      />
    </div>
  );
};
export default Login;
