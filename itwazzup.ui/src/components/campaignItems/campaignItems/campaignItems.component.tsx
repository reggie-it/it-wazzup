import React, { useState, useEffect } from 'react';
import axios from 'axios';
import CampaignItem from '../campaignItem/campaignItem.component';
import { Button } from '@infotrack/zenith-ui';
import './campaignItems.styles.scss';

const CampaignItems = () => {
  const [campaignItems, setCampaignItems] = useState([]);

  // Similar to componentDidMount and componentDidUpdate:
  useEffect(() => {
    axios.get('http://localhost:5000/api/CampaignItem?CampaignId=1').then(function (response) {
      setCampaignItems(response.data);
    })
  }, []);

  let cards = [];
  for (var i = 0; i < campaignItems.length; i++) {
    let name = campaignItems[i]["name"];
    let description = campaignItems[i]["description"];
    let maxStars = campaignItems[i]["maxStars"];
    cards.push(<CampaignItem
      name={name}
      maxStars={maxStars}
      description={description}
    />);
  }

  return (<div className="campaignItems">
    <div className="campaignName">
      <h1>
        Hackathon Y2020T3
      </h1>
    </div>
    {cards}
    <div className="submitVote">
      <Button
        buttonType="primary"
        fullWidth
        icon="emoji_events"
        iconPosition="left"
        onClick={function noRefCheck() { }}
        size={undefined}
      >
        Submit
      </Button>
    </div>
  </div>);
};

export default CampaignItems;
