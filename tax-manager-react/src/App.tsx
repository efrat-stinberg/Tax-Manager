import "./App.css";
import { Provider, useSelector } from "react-redux";
import store from "./store/store";
import Login from "./components/Login";
import UserAvatar from "./components/UserAvatar";

function App() {
  return (
    <Provider store={store}>
      <Main />
    </Provider>
  );
}

function Main() {
  const isAuthenticated = useSelector(
    (state: any) => state.user.isAuthenticated
  );  

  return (
    <>
      {isAuthenticated ? <UserAvatar /> : <Login />}
    </>
  );
}

export default App;
