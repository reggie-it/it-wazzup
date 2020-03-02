import api from '../base';
import { AxiosPromise } from 'axios';
import { LoginResponseModel, LoginRequestModel } from './models';

export const loginUser = (
  request: LoginRequestModel
): AxiosPromise<LoginResponseModel> => api.post('account', request);
