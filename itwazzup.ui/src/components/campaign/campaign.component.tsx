import React from 'react';
import { Card } from '@infotrack/zenith-ui';

import './campaign.styles.scss';

const Campaign = () => {
  return (
    <Card
      borderRadiusSize="md"
      cardTitle="Basic card"
      spacing="md"
      variant="basic"
    >
      <p>Some random content</p>
    </Card>
  );
};

export default Campaign;
