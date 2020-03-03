import React, { useState } from 'react';
import { useAsync } from 'react-use';
import * as constants from '../../constants/host';

import './home.styles.scss';
import Campaign from '../campaign/campaign.component';

var renderCount = 0;

const Home = () => {
  const [campaigns, setCampaigns] = useState([]);

  const loadCampaigns = () => {
    fetch(constants.HOST + 'api/campaign')
      .then(result => {
        return result.json();
      })
      .then(data => {
        setCampaigns(data);
      });
  };

  renderCount++;
  console.log("RENDER COUNT IS: " + renderCount);
  useAsync(async () => {
    loadCampaigns();
  }, []);

  const handleOnCampaignClick = (campaign: any) => {
    console.log('clicked');
  };

  return (
    <div className="campaigns">
      {campaigns.map(c => (
        <Campaign
          campaign={c}
          onClick={() => handleOnCampaignClick(c)}
        ></Campaign>
      ))}
    </div>
  );
};

export default Home;
