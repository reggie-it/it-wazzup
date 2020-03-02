export type CampaignModel = {
  Id: number;
  Name: string;
  Description: string;
  StartDate: Date;
  EndDate: Date;
  CreatedBy: string;
  MaxVotes: number;
  Closed: boolean;
};
