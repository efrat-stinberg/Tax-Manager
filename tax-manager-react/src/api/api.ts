import axios from "axios";

const API_URL = "https://localhost:7042/api/Auth";


export const loginUser = async (email: string, password: string): Promise<any> => {
  const response = await axios.post(`${API_URL}/login`, { email, password });
  return response.data;
};

export const registerUser = async (username: string, email: string, password: string): Promise<any> => {
  try {
    const response = await axios.post(`${API_URL}/register`, { username, email, password });
    return response.data; 
  } catch (error) {
    if (axios.isAxiosError(error)) {
      throw new Error(`Registration failed: ${error.response?.data?.message || 'Unknown error'}`);
    } else {
      throw new Error('Registration failed: Unknown error');
    }
  }
};

export const getUserByEmail = async (email: string) => {
  const response = await axios.get(`https://localhost:7042/api/users/${email}`);
  console.log(response.data);
  return response.data;
};
