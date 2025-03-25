import "./App.css";
import { Provider, useSelector } from "react-redux";
import { BrowserRouter, Route, BrowserRouter as Router, Routes } from "react-router-dom";
import store from "./store/store";
import UserAvatar from "./components/UserAvatar";
import FolderUpload from "./components/FolderUploud";
import AuthPage from "./pages/AuthPage";
import Register from "./components/Register";


const headerStyle = {
  display: 'flex',
  justifyContent: 'flex-end',
  alignItems: 'flex-start',
  padding: '10px',
};

function App() {
  return (
    <Provider store={store}>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Main />} />
          <Route path="/register" element={<Register />} />
        </Routes>
      </BrowserRouter>
    </Provider>
  );
}

function Main() {
  const isAuthenticated = useSelector((state: any) => state.user.isAuthenticated);

  return (
    <div style={headerStyle}>
      {isAuthenticated ? (
        <>
          <FolderUpload /> 
          <UserAvatar /> 
        </>
      ) : (
        <>
          <AuthPage /> 
        </>
      )}
    </div>
  );
}


export default App;
