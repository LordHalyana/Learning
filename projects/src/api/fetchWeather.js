import axios from 'axios';

const URL = 'https://api.openweathermap.org/data/2.5/weather';
const API_KEY = '1ffb0818381f17ec21b34b3dd26caa07';

export const fetchWeather = async (query) => {
    const { data } = await axios.get(URL, {
        params: {
            q: query,
            units: 'metric',
            APPID: API_KEY,
        }
    });

    return data;
}