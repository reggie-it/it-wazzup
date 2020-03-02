import React, { useState } from 'react';
import { useAsync } from 'react-use';
import * as constants from '../../constants/host';

import './home.styles.scss';
import Campaign from '../campaign/campaign.component';

const Home = () => {
  const [campaigns, setCampaigns] = useState([]);

  const loadCampaigns = () => {
    debugger;
    const url = constants.HOST + 'api/campaign';
    fetch(url)
      .then(function(response) {
        if (response.status !== 200) {
          console.log(
            'Looks like there was a problem. Status Code: ' + response.status
          );
          return;
        }

        response.json().then(function(data) {
          console.log(data);
          return data;
        });
      })
      .catch(function(err) {
        console.log('Fetch Error :-S', err);
      });
  };

  useAsync(async () => {
    const response = loadCampaigns();

    // if (response) {
    //   setCampaigns(response);
    // }
  }, []);

  return (
    <div>
      {campaigns.map(c => (
        <Campaign></Campaign>
      ))}
    </div>
  );
};

export default Home;
