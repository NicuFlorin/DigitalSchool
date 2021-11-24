import React from "react";
import { Paper, Typography } from "@mui/material";
import SettingsMenu from "./SettingsMenu";

export default function Header(props) {
  return (
    <Paper
      sx={{
        alignItems: "center",
        padding: "30px 0",
        display: "flex",
      }}
    >
      <Typography
        component="h2"
        variant="h4"
        sx={{ marginLeft: 5, flexGrow: 1 }}
      >
        Your school name
      </Typography>
      <SettingsMenu sx={{ paddingRight: 3 }} />
    </Paper>
  );
}
