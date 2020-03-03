import React, { useState } from 'react';
import imtiaz from './imtiaz.png';
import './thanks.styles.scss';

const Thanks = () => {
  return (
    <div className="thanks">
      <img src={imtiaz}></img>
      <h1>Thanks for voting. We hope you win ;)</h1>
    </div>
  );
};

export default Thanks;
