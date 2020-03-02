import React from 'react';

import './home.styles.scss';
import Campaign from '../campaign/campaign.component';

const Home = () => {
  return (
    <div>
      <Campaign />
      <Campaign />
      <Campaign />
    </div>
  );
};

export default Home;
