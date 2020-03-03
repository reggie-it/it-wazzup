import React from 'react';
import logo from './logo.png';
import { Icon } from '@infotrack/zenith-ui';

import './menu.styles.scss';

const Menu = () => {
  return (
    <div className="main-menu">
      <img src={logo}></img>
    </div>
  );
};

export default Menu;
