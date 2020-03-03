import React, { useState, useEffect, useCallback } from 'react';
import axios from 'axios';
import CampaignItem from '../campaignItem/campaignItem.component';
import { Button } from '@infotrack/zenith-ui';
import './campaignItems.styles.scss';
import { HOST } from '../../../constants/host';
import { takeRight } from 'lodash';
import { withRouter } from 'react-router-dom';
const CampaignItems = (props: any) => {
  const [campaignItems, setCampaignItems] = useState([]);
  const [votes, setVotes] = useState<number[]>([]);

  useEffect(() => {
    axios.get(`${HOST}api/CampaignItem?CampaignId=1`).then(function(response) {
      setCampaignItems(response.data);
    });
  }, []);

  // let cards = [];
  // for (var i = 0; i < campaignItems.length; i++) {
  //   let name = campaignItems[i]['name'];
  //   let description = campaignItems[i]['description'];
  //   let maxStars = campaignItems[i]['maxStars'];

  //   cards.push(
  //     <CampaignItem name={name} maxStars={maxStars} description={description} />
  //   );
  // }

  let castVote = function(votes: number[]) {
    axios
      .post(`${HOST}api/CampaignItem`, {
        voterName: 'John Doe',
        campaignId: 1,
        campaignIdList: votes
      })
      .then(() => {
        props.history.push('/thanks');
      });
  };

  return (
    <div className="campaignItems">
      <div className="campaignName">
        <h1>Hackathon Y2020T3</h1>
      </div>
      {campaignItems.map(x => (
        <CampaignItem
          id={x['id']}
          name={x['name']}
          maxStars={x['maxStars']}
          description={x['description']}
          currentVotes={votes}
          setVotes={(vote: any) => {
            const updatedVotes = [...votes, vote];
            setVotes(takeRight(updatedVotes, x['maxStars']));
          }}
        />
      ))}
      <div className="submitVote">
        <Button
          buttonType="primary"
          fullWidth
          icon="emoji_events"
          iconPosition="left"
          onClick={() => castVote(votes)}
        >
          Submit
        </Button>
      </div>
    </div>
  );
};

export default withRouter(CampaignItems);
