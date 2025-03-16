import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import  User from "../../models/User.ts";

interface UserState {
  currentUser: User| null;
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
    login: (state, action: PayloadAction<{ email: string, password: string }>) => {
      if (!state.currentUser) {
        state.currentUser= { email: action.payload.email, id: '', name: '' };
      } else {
        state.currentUser.email = action.payload.email;         
      }
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
