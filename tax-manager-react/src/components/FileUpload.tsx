import React, { useState } from "react";
import axios from "axios";
import { Button } from "@mui/material";

const FileUpload = () => {
  const [file, setFile] = useState<File | null>(null);

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.files && event.target.files.length > 0) {
      setFile(event.target.files[0]);
      console.log(event.target.files[0]);
    }
  };

  async function handleUpload() {
    const formData = new FormData();
    if (file) {
      formData.append("file", file);
    } else {
      console.error("No file selected");
      return;
    }

    try {
      const response = await axios.post(
        "YOUR_RENDER_SERVER_URL/upload",
        formData,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      );
      console.log(response.data);
    } catch (error) {
      console.error("Error uploading file:", error);
    }
  }

  return (
    <div>
      <input
        type="file"
        onChange={handleFileChange}
        style={{ display: "none" }} // להסתיר את ה-input
        id="file-upload"
      />
      <label htmlFor="file-upload">
        <Button variant="contained" component="span">
          בחירת קובץ
        </Button>
      </label>
      <Button variant="contained" onClick={handleUpload} disabled={!file}>
        Upload
      </Button>
    </div>
  );
};

export default FileUpload;
