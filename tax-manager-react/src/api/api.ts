import axios from "axios";
import User from "../models/User";

const API_URL = "https://localhost:7042/api";


export const loginUser = async (
  email: string,
  password: string
): Promise<any> => {
    try {
        const response = await axios.post(`${API_URL}/Auth/login`, {
          email,
          password,
        });
        return response.data;
      } catch (error : any ) {
        console.error("Login failed:", error.response ? error.response.data : error.message);
        throw error;
      }
      
};


export const registerUser = async (
  username: string,
  email: string,
  password: string
): Promise<any> => {
    try {
        const response = await axios.post(`${API_URL}/Auth/register`, {
            username,
            email,
            password,
        });
        return response.data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            if (error.response?.status === 409) {
                throw new Error("Registration failed: User with this email already exists.");
            }
            throw new Error(`Registration failed: ${error.response?.data?.message || "Unknown error"}`);
        } else {
            throw new Error("Registration failed: Unknown error");
        }
    }
};

export const updateUser = async (updatedUser: User) => {
  try {
    const id = updatedUser.userId;
    console.log(updatedUser);

    const response = await axios.put(`${API_URL}/users/${id}`, updatedUser);
    return response.data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      throw new Error(error.response?.data?.message || "Error updating user");
    } else {
      throw new Error("Error updating user");
    }
  }
};

export const getUserByEmail = async (email: string) => {
  const response = await axios.get(`${API_URL}/users/${email}`);
  console.log(response.data);
  return response.data;
};
