import api from '../base';
import { AxiosPromise } from 'axios';
import { CampaignModel } from './model';

export const loadCampaigns = (): AxiosPromise<CampaignModel> =>
  api.post('campaign');
