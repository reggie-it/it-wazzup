export type LoginRequestModel = {
  username: string;
  password: string;
};

export type LoginResponseModel = {
  accessToken: string;
  expiresIn: number;
  refreshToken: string;
};

export type CurrentUserResponseModel = {
  clientId: number;
  clientName: string;
  email: string;
  firmId: string;
  isAdmin: boolean;
  loginId: number;
  name: string;
  roles: string[];
  username: string;
};
