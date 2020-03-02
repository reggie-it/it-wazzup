import React from 'react';

import { Icon } from '@infotrack/zenith-ui';

import './menu.styles.scss';

const Menu = () => {
  return (
    <div className="main-menu">
      <Icon
        name="menu"
        size="large"
        variant="rounded"
        className="hamburger-menu"
      />
    </div>
  );
};

export default Menu;
