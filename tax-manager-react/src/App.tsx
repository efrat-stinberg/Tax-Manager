import "./App.css";
import { Provider, useSelector } from "react-redux";
import store from "./store/store";
import Login from "./components/Login";
import UserAvatar from "./components/UserAvatar";
import FileUpload from "./components/FileUpload";
import FolderUpload from "./components/FolderUploud";

const headerStyle = {
  display: 'flex',
  justifyContent: 'flex-end', // מיקום האבטר בצד ימין
  alignItems: 'flex-start', // מיקום האבטר למעלה
  padding: '10px',
};


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
    <div style={headerStyle}>
      {isAuthenticated ? (
        <>
          <FolderUpload />
          <UserAvatar /> 
        </>
      ) : (
        <Login />
      )}
    </div>
  );
}

export default App;
