import {
  ThemeProvider,
  ToastContainer,
  ToastProvider
} from '@infotrack/zenith-ui';

import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import { BrowserRouter } from 'react-router-dom';
import UserProvider from './shared/context/User/Provider';

ReactDOM.render(
  <BrowserRouter>
    <UserProvider>
      <ThemeProvider>
        <ToastProvider>
          <ToastContainer />
          <App />
        </ToastProvider>
      </ThemeProvider>
    </UserProvider>
  </BrowserRouter>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
