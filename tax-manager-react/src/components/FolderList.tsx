// FolderList.tsx
import React from "react";
import { Grid, Card, CardContent, Typography } from "@mui/material";

interface FolderListProps {
  folders: string[];
  onFolderClick: (folder: string) => void;
}

const FolderList: React.FC<FolderListProps> = ({ folders, onFolderClick }) => {
  return (
    <Grid container spacing={2}>
      {folders.map((folder) => (
        <Grid item xs={6} key={folder}>
          <Card onClick={() => onFolderClick(folder)}>
            <CardContent>
              <Typography variant="h6">{folder}</Typography>
            </CardContent>
          </Card>
        </Grid>
      ))}
    </Grid>
  );
};

export default FolderList;
