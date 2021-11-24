import React from "react";
import { Button, Paper, Typography } from "@mui/material";
import AddIcon from "@mui/icons-material/Add";
import { Box } from "@mui/system";
import { useHistory } from "react-router-dom";

const MainSection = (props) => {
  const history = useHistory();
  return (
    <Paper sx={{ paddingBottom: "10px" }}>
      <Box sx={{ display: "flex" }}>
        <Typography
          component="h2"
          variant="h4"
          sx={{ marginLeft: 5, flexGrow: 1 }}
        >
          Available courses
        </Typography>
        <Button startIcon={<AddIcon />} sx={{ color: "orange" }}>
          Add an activity or resource
        </Button>
      </Box>
      <Button
        variant="contained"
        sx={{ marginLeft: 5 }}
        onClick={() => {
          history.push("/newCourse");
        }}
      >
        Add a new course
      </Button>
    </Paper>
  );
};

export default MainSection;
