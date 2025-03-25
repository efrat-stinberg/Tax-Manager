import React, { useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import Button from "@mui/material/Button";
import Popover from '@mui/material/Popover';
import { logout } from '../store/slices/userSlice'; 
import UserEditDialog from './UserEditDialog'; 
import './UserAvatar.css';

const UserAvatar = () => {

  const currentUser = useSelector((state:any) => state.user.currentUser);
  console.log("use",currentUser);
  
  const userName = currentUser.username;
  console.log("use name",userName);
  
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const [openEditDialog, setOpenEditDialog] = useState(false); // מצב לפתיחת דיאלוג העריכה
  const dispatch = useDispatch(); 

  const firstLetter = userName ? userName.charAt(0).toUpperCase() : "";

  const handleClick = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const open = Boolean(anchorEl);

  const handleEdit = () => {
    setOpenEditDialog(true); // פתח את דיאלוג העריכה
    handleClose();
  };

  const handleLogout = () => {
    dispatch(logout()); 
    handleClose();
  };

  const handleSave = () => {
    // הוסף כאן את הלוגיקה לשמירת השינויים (למשל, עדכון Redux)
    setOpenEditDialog(false); // סגור את דיאלוג העריכה
  };

  return (
    <div>
      <div className="avatar" onClick={handleClick} style={{ cursor: 'pointer' }}>
        {firstLetter ? (
          <div className="initial">{firstLetter}</div>
        ) : (
          <div className="initial"></div>
        )}
      </div>
      <Popover
        open={open}
        anchorEl={anchorEl}
        onClose={handleClose}
        anchorOrigin={{
          vertical: 'bottom',
          horizontal: 'center',
        }}
        transformOrigin={{
          vertical: 'top',
          horizontal: 'center',
        }}
      >
        <div style={{ padding: '10px' }}>
          <Button onClick={handleEdit} color="primary">ערוך נתוני משתמש</Button>
          <Button onClick={handleLogout} color="primary">יציאה</Button>
        </div>
      </Popover>
      <UserEditDialog 
        isOpen={openEditDialog} 
        onClose={() => setOpenEditDialog(false)} 
        onSave={handleSave} 
        user={{ name: userName || '', email: '' }} 
      />
    </div>
  );
};

export default UserAvatar;
