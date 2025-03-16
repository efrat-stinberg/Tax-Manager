import { useState } from "react";
import { login } from "../store/slices/userSlice";
import { useDispatch } from "react-redux";
import { TextField, Button, Container, Typography } from '@mui/material';


const Login = () => {
  const dispatch = useDispatch();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e: any) => {
    e.preventDefault();
    dispatch(login({ email, password }));
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
