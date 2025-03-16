// FolderUpload.tsx
import React, { useState, useEffect } from "react";
import { Container, Typography, Box } from "@mui/material";
import { useParams, useNavigate } from "react-router-dom";
import FolderList from "./FolderList";
import UploadDialog from "./UploadDialog";

const FolderUpload = () => {
  const { folderName } = useParams();
  const navigate = useNavigate();
  const [open, setOpen] = useState(false);
  const [selectedFolder, setSelectedFolder] = useState(folderName || "");
  const [file, setFile] = useState<File | null>(null);
  const [documents, setDocuments] = useState<string[]>([]);

  useEffect(() => {
    if (selectedFolder) {
      fetchDocuments(selectedFolder);
    }
  }, [selectedFolder]);

  const handleClickOpen = (folder: string) => {
    setSelectedFolder(folder);
    navigate(`/upload/${folder}`);
    setOpen(true);
    setFile(null);
  };

  const fetchDocuments = async (folder: string) => {
    const response = await fetch(`/api/documents?folder=${folder}`);
    const data = await response.json();
    setDocuments(data.documents);
  };

  const handleClose = () => {
    setOpen(false);
    setSelectedFolder("");
    setFile(null);
    setDocuments([]);
    navigate('/'); 
  };

  const handleFileUpload = (file: File | null) => {
    setFile(file);
  };

  const handleUpload = async () => {
    const formData = new FormData();
    if (file) {
      formData.append("file", file);
      console.log(`Uploading file for ${selectedFolder}:`, file);
    } else {
      console.error("No file selected");
      return;
    }
    handleClose();
  };

  return (
    <Container maxWidth="lg">
      <Box my={4}>
        <Typography variant="h4" align="center" gutterBottom>
          ניהול תיקיות
        </Typography>
        <FolderList folders={["הוצאות", "הכנסות"]} onFolderClick={handleClickOpen} />
      </Box>
      <UploadDialog
        open={open}
        selectedFolder={selectedFolder}
        documents={documents}
        onClose={handleClose}
        onFileUpload={handleFileUpload}
      />
    </Container>
  );
};

export default FolderUpload;
