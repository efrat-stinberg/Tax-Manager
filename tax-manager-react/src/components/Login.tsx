import { useState } from "react";
import { login } from "../store/slices/userSlice";
import { useDispatch } from "react-redux";
import { TextField, Button, Container, Typography } from "@mui/material";
import { getUserByEmail, loginUser } from "../api/api";

const Login = () => {
  const dispatch = useDispatch();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = async (e: any) => {
    e.preventDefault();
    try {
      const token = await loginUser(email, password); 
      localStorage.setItem('token', token); // Store the token
      console.log("Login successful");
      const user = await getUserByEmail(email); // Get user details
      dispatch(login(user)); // Dispatch user details to Redux
    } catch (error) {
      console.error("Login failed:", error);
    }
  };
  

  return (
    <Container maxWidth="sm">
      <form onSubmit={handleSubmit}>
        <div>
          <Typography variant="body1">Email</Typography>
          <TextField
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
            fullWidth
            margin="normal"
            variant="outlined"
          />
        </div>
        <div>
          <Typography variant="body1">Password</Typography>
          <TextField
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
            fullWidth
            margin="normal"
            variant="outlined"
          />
        </div>
        <Button type="submit" variant="contained" color="primary">
          Login
        </Button>
      </form>
    </Container>
  );
};

export default Login;
