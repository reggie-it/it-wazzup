import axios, { AxiosInstance } from 'axios';

const api: AxiosInstance = axios.create({
  baseURL: `${process.env.REACT_APP_API_URL}/api`
});

export const setAuthorizationHeader = (token: string): void => {
  if (token) {
    api.defaults.headers.common['Authorization'] = `Bearer ${token}`;
  } else {
    delete api.defaults.headers.common['Authorization'];
  }
};

export default api;
