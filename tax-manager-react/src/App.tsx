import "./App.css";
import { Provider, useSelector } from "react-redux";
import { BrowserRouter as Router } from "react-router-dom";
import store from "./store/store";
import Login from "./components/Login";
import UserAvatar from "./components/UserAvatar";
import FolderUpload from "./components/FolderUploud";


const headerStyle = {
  display: 'flex',
  justifyContent: 'flex-end',
  alignItems: 'flex-start',
  padding: '10px',
};

function App() {
  return (
    <Provider store={store}>
      <Router>
        <Main />
      </Router>
    </Provider>
  );
}

function Main() {
  const isAuthenticated = useSelector(
    (state: any) => state.user.isAuthenticated
  );

  return (
    <div style={headerStyle}>
      {isAuthenticated ? (
        <>
          <FolderUpload /> {/* Render FolderUpload directly */}
          <UserAvatar /> {/* Render UserAvatar directly */}
        </>
      ) : (
        <Login />
      )}
    </div>
  );
}

export default App;
