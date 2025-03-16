import React, { useState } from "react";
import {
  Container,
  Grid,
  Card,
  CardContent,
  Typography,
  Dialog,
  DialogActions,
  Button,
  Input,
  Box,
  Paper,
} from "@mui/material";

const FolderUpload = () => {
  const [open, setOpen] = useState(false);
  const [selectedFolder, setSelectedFolder] = useState("");
  const [file, setFile] = useState<File | null>(null); // מצב עבור הקובץ שנבחר

  const handleClickOpen = (folder: string) => {
    setSelectedFolder(folder);
    setOpen(true);
    setFile(null); // לאפס את הקובץ שנבחר כאשר פותחים דיאלוג חדש
  };

  const handleClose = () => {
    setOpen(false);
    setSelectedFolder("");
    setFile(null); // לאפס את הקובץ שנבחר כאשר סוגרים את הדיאלוג
  };

  const handleFileUpload = (
    event: React.ChangeEvent<HTMLInputElement>
  ): void => {
    const files = event.target.files;
    if (files && files.length > 0) {
      setFile(files[0]); // שמירת הקובץ שנבחר
    } else {
      setFile(null);
    }
  };

  const handleUpload = async () => {
    const formData = new FormData();
    if (file) {
      formData.append("file", file);
      // כאן תוכל להוסיף לוגיקה להעלאת הקובץ לשרת
      console.log(`Uploading file for ${selectedFolder}:`, file);
    } else {
      console.error("No file selected");
      return;
    }
    handleClose(); // סוגרים את הדיאלוג לאחר ההעלאה
  };

  return (
    <Container maxWidth="lg">
      <Box my={4}>
        <Typography variant="h4" align="center" gutterBottom>
          ניהול תיקיות
        </Typography>
        <Grid container spacing={2}>
          {["הוצאות", "הכנסות", "תיקיה 1", "תיקיה 2"].map((folder) => (
            <Grid item xs={3} key={folder}>
              <Card onClick={() => handleClickOpen(folder)}>
                <CardContent>
                  <Typography variant="h6">{folder}</Typography>
                </CardContent>
              </Card>
            </Grid>
          ))}
        </Grid>
      </Box>
      <Dialog open={open} onClose={handleClose} maxWidth="sm" fullWidth>
    <Paper style={{ padding: '20px' }}>
        <Typography variant="h6" gutterBottom align="center">
            העלאת קבצים לתיקיה: {selectedFolder}
        </Typography>
        <Box display="flex" flexDirection="column" alignItems="center">
            <label htmlFor="file-upload">
                <Button 
                    variant="outlined" 
                    component="span" 
                    sx={{ 
                        backgroundColor: '#f5f5f5', // צבע רקע
                        color: '#3f51b5', // צבע טקסט
                        height: '48px', // גובה הכפתור
                        borderRadius: '4px', // רדיוס פינות
                        marginBottom: '20px', // מרווח תחתון
                        '&:hover': {
                            backgroundColor: '#e0e0e0', // צבע רקע בהעברה
                        }
                    }}
                >
                    בחירת קבצים
                </Button>
            </label>
            <Input 
                id="file-upload" 
                type="file" 
                inputProps={{ multiple: true }} 
                onChange={handleFileUpload} 
                style={{ display: 'none' }} // מסתיר את הקלט המקורי
            />
        </Box>
        <DialogActions>
            <Button onClick={handleClose} color="primary">
                סגור
            </Button>
            <Button 
                variant="contained" 
                onClick={handleUpload} 
                disabled={!file} 
                sx={{ 
                    backgroundColor: '#3f51b5', // צבע רקע
                    color: '#fff', // צבע טקסט
                    height: '48px', // גובה הכפתור
                    borderRadius: '4px', // רדיוס פינות
                    '&:hover': {
                        backgroundColor: '#303f9f', // צבע רקע בהעברה
                    }
                }}
            >
                העלה
            </Button>
        </DialogActions>
    </Paper>
</Dialog>
    </Container>
  );
};

export default FolderUpload;
