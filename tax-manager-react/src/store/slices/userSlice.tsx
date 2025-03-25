import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import User from "../../models/User"; // Adjusted import to remove .ts extension
import { Link } from "react-router-dom";

interface UserState {
  currentUser: User | null;
  isAuthenticated: boolean;
}

const initialState: UserState = {
  currentUser: null,
  isAuthenticated: false,
};

const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    login: (state, action: PayloadAction<User>) => {
      console.log("login first", action.payload);
      state.currentUser = {
        userId: action.payload.userId, 
        email: action.payload.email,        
        username: action.payload.username,
        folders: action.payload.folders.map((folder) => ({
          ...folder,
          documents: folder.documents.map((document) => ({
            documentName: document.documentName, 
            filePath: document.filePath,
            uploadDate: document.uploadDate,
            folderId: document.folderId,
          })),
        })),
      };      
      console.log("login secens", state.currentUser);
      state.isAuthenticated = true;
    },
    logout: (state) => {
      state.currentUser = null;
      state.isAuthenticated = false;
    },
  },
});

export const { login, logout } = userSlice.actions;
export default userSlice.reducer;
