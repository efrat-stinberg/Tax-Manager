import React, { useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import Button from "@mui/material/Button";
import Popover from '@mui/material/Popover';
import { logout } from '../store/slices/userSlice'; 
import UserEditDialog from './UserEditDialog'; 
import './UserAvatar.css';
import { updateUser } from "../api/api";
import User from "../models/User";

const UserAvatar = () => {
  const currentUser = useSelector((state:any) => state.user.currentUser);
  const userName = currentUser.username;
  const userEmail = currentUser.email; // הנח שיש שדה מייל
  const dispatch = useDispatch(); 

  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const [openEditDialog, setOpenEditDialog] = useState(false); 
  const [email, setEmail] = useState(userEmail); // הוסף מצב למייל

  const firstLetter = userName ? userName.charAt(0).toUpperCase() : "";

  const handleClick = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const open = Boolean(anchorEl);

  const handleEdit = () => {
    setOpenEditDialog(true); 
    handleClose();
  };

  const handleLogout = () => {
    dispatch(logout()); 
    handleClose();
  };

  const handleSave = async (updatedUserData: { name: string; email: string }) => {
    const userToUpdate: User = {
      ...currentUser,
      username: updatedUserData.name,
      email: updatedUserData.email,
    };
    try {
      await updateUser(userToUpdate);
      dispatch(await updateUser(userToUpdate));
    } catch (error) {
      console.error("Error updating user:", error);
    }
    setOpenEditDialog(false); 
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
        user={{ name: userName || '', email: email }} // העבר את המייל
        onSave={handleSave} // העבר את הפונקציה ללא קריאה
      />
    </div>
  );
};

export default UserAvatar;
