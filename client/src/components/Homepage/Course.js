import React from "react";
import GroupWorkIcon from "@mui/icons-material/GroupWork";
import { Link, Typography } from "@mui/material";
import { Box } from "@mui/material";
import { useHistory } from "react-router-dom";
const Course = (props) => {
  const history = useHistory();
  return (
    <Box
      sx={{
        padding: 3,
      }}
    >
      <div style={{ display: "flex" }}>
        <GroupWorkIcon sx={{ alignSelf: "center" }} />
        <Link
          variant="h4"
          onClick={() => {
            history.push(`/course/${props.course.id}`);
          }}
          component="a"
          style={{ textDecorationColor: "#ec7f13", color: "#ec7f13" }}
        >
          {props.course.name}
        </Link>
      </div>
      Teacher: {props.course.teacherFirstName} {props.course.teacherLastName}
    </Box>
  );
};

export default Course;
