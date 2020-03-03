import React, { useState, useCallback } from 'react';
import { } from 'react-use';
import { Card } from '@infotrack/zenith-ui';
import './campaignItem.styles.scss';

const emptyStar = <svg xmlns="http://www.w3.org/2000/svg" height="24" viewBox="0 0 24 24" width="24">
    <path fill="#eeee14" d="M22 9.24l-7.19-.62L12 2 9.19 8.63 2 9.24l5.46 4.73L5.82 21 12 17.27 18.18 21l-1.63-7.03L22 9.24zM12 15.4l-3.76 2.27 1-4.28-3.32-2.88 4.38-.38L12 6.1l1.71 4.04 4.38.38-3.32 2.88 1 4.28L12 15.4z" />
    <path d="M0 0h24v24H0z" fill="none" />
</svg>;

const filledStar = <svg xmlns="http://www.w3.org/2000/svg" height="24" viewBox="0 0 24 24" width="24">
    <path d="M0 0h24v24H0z" fill="none" />
    <path fill="#eeee14" d="M12 17.27L18.18 21l-1.64-7.03L22 9.24l-7.19-.61L12 2 9.19 8.63 2 9.24l5.46 4.73L5.82 21z" />
    <path d="M0 0h24v24H0z" fill="none" />
</svg>;

const CampaignItem = (props: any) => {
    const [filledStars, setFilledStars] = useState(0);
    const starToggleClick = useCallback(() => {
        setFilledStars(filledStars + 1);
        if (filledStars >= props.maxStars) {
            setFilledStars(0);
        }
    }, [filledStars, props.maxStars]);

    let stars = [];
    for (var n = 0; n < props.maxStars; n++) {
        if (n < filledStars) {
            stars.push(<span className="star">
                {filledStar}
            </span>);
        }
        else {
            stars.push(<span className="star">
                {emptyStar}
            </span>);
        }

    }
    return <Card
        onClick={starToggleClick}
        borderRadiusSize="md"
        spacing="md"
        variant="basic"
        className="campaignItem"
    >
        <div className="compaignItemHeader">
            <h2>{props.name}</h2>
            <div className="stars">
                {stars}
            </div>
        </div>
        <div className="description">
            {props.description}
        </div>
    </Card>
};

export default CampaignItem;
