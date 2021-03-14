import axios from 'axios';

export interface Url {
  code: string;
  url: string;
  error: string;
}

export default {
  create: async (url: string): Promise<Url> => {
    const apiUrl = 'http://api.localhost:5000/url';
    console.log(apiUrl);
    const response = await axios.post(apiUrl, {
      url,
    });

    const result = {
      code: response.data.code,
      url: response.data.url,
      error: response.data.error,
    };

    return result;
  },
};
