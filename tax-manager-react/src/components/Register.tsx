import { useState } from "react";
import { useDispatch } from "react-redux";
import { TextField, Button, Container, Typography } from "@mui/material";
import { getUserByEmail, registerUser } from "../api/api"; // Assuming you have a registerUser API function
import { login } from "../store/slices/userSlice";
import { useNavigate } from "react-router-dom";

const Register = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [username, setUsername] = useState("");

  const handleSubmit = async (e: any) => {
    e.preventDefault();
    try {
      const token = await registerUser(username, email, password); // Register the user
      localStorage.setItem("token", token); // Store the token
      console.log("Login successful");
      const user = await getUserByEmail(email); // Get user details
      dispatch(login(user)); // Dispatch user details to Redux
      navigate("/"); // Dispatch user details to Redux
    } catch (error) {
      console.error("Registration failed:", error);
    }
  };

  return (
    <Container maxWidth="sm">
      <form onSubmit={handleSubmit}>
        <div>
          <Typography variant="body1">Username</Typography>
          <TextField
            type="text"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            required
            fullWidth
            margin="normal"
            variant="outlined"
          />
        </div>
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
          Register
        </Button>
      </form>
    </Container>
  );
};

export default Register;
