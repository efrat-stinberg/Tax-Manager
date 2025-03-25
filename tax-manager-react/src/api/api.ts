import axios from 'axios';

const API_URL = 'https://localhost:7042/api/Auth';


export const loginUser = async (email: string, password: string) => {
    const response = await axios.post(`${API_URL}/login`, { email, password });
    return response.data;
};

export const registerUser = async (email: string, password: string) => {
    const response = await axios.post(`${API_URL}/register`, { email, password });
    return response.data;
};

export const getUserByEmail = async (email: string) => {
    const response = await axios.get(`https://localhost:7042/api/users/${email}`); 
    console.log(response.data);
    return response.data;
}
