import React from 'react';
import { Card } from '@infotrack/zenith-ui';

import './campaign.styles.scss';

const Campaign = (data: any) => {
  return (
    <Card
      borderRadiusSize="md"
      spacing="md"
      variant="shadow-md"
      className="campaign"
    >
      <h1>{data.campaign.name}</h1>
      <p>{data.campaign.description}</p>
    </Card>
  );
};

export default Campaign;
