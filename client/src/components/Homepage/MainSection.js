import React, { useEffect } from "react";
import { Button, Paper, Typography } from "@mui/material";
import AddIcon from "@mui/icons-material/Add";
import { Box } from "@mui/system";
import { useHistory } from "react-router-dom";
import { connect } from "react-redux";
import { getAllCourses } from "../../_actions/courseActions";
import Course from "../../components/Homepage/Course";
const mapStateToProps = (state) => {
  return {
    courses: state.courseReducer.courses,
    isPending: state.courseReducer.isPending,
    error: state.courseReducer.error,
  };
};
const mapDispatchToProps = (dispatch) => {
  return {
    GetAll: () => getAllCourses(dispatch),
  };
};
const MainSection = (props) => {
  const history = useHistory();
  useEffect(() => {
    props.GetAll();
  }, []);
  return (
    <Paper sx={{ paddingBottom: "10px" }}>
      <Box sx={{}}>
        <Typography
          component="h2"
          variant="h4"
          sx={{ marginLeft: 5, flexGrow: 1 }}
        >
          Available courses
        </Typography>
        {props.courses.map((course, index) => {
          return <Course key={index} course={course} index={index} />;
        })}
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

export default connect(mapStateToProps, mapDispatchToProps)(MainSection);
