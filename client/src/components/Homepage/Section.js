import React from "react";
import { Box, Typography } from "@mui/material";
import AddIcon from "@mui/icons-material/Add";

const Section = (props) => {
  const section = props.section;
  return (
    <Box sx={{ width: "100%", padding: 3 }}>
      <Typography variant="h5" align="left">{section.title}</Typography>
      <div
        style={{
          display: "flex",
     
        }}
      >
        <AddIcon
          style={{ marginLeft: "auto", marginRight: 0, color: "#ec7f13" }}
        />
        <a style={{ color: "#ec7f13" }} href="#">
          Add an activity or a resource
        </a>
      </div>
    </Box>
  );
};
export default Section;
