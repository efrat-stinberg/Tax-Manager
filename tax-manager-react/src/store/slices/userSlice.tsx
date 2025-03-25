import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import User from "../../models/User"; // Adjusted import to remove .ts extension

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
      state.currentUser = {
        email: action.payload.email,
        name: action.payload.name,
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
