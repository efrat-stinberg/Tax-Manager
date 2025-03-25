import { Link } from "react-router-dom";
import Login from "../components/Login";

const AuthPage = () => {

  return (
    <div>
      <Login />
      <p>Not registered in the system yet?</p>
      <Link to="/register"> Sign up</Link>
    </div>
  );
};

export default AuthPage;
