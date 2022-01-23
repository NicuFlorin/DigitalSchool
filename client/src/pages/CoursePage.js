import { Box } from "@mui/system";
import React, { useEffect, useState } from "react";
import { connect } from "react-redux";
import { getCourseByID } from "../_actions/courseActions";
import AddIcon from "@mui/icons-material/Add";
import Section from "../components/Homepage/Section";
import AddActivityModal from "../components/Homepage/AddActivityModal";
import { getFiles } from "../_requests/CourseReq";
import Resource from "../components/EditActivities/Resource";
const mapStateToProps = (state) => {
  return {
    selected_course: state.courseReducer.selected_course,
    isPending: state.courseReducer.isPending,
    error: state.courseReducer.error,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    GetCourseByID: (id_course) => getCourseByID(dispatch, id_course),
  };
};

const CoursePage = (props) => {
  const [open, setOpen] = useState(false);
  const [files, setFiles] = useState(null);
  const handleOpen = () => {
    setOpen(true);
  };
  const handleClose = () => {
    setOpen(false);
  };

  const downloadEmployeeData = () => {
    let url = window.URL.createObjectURL(
      new Blob([files], {
        type: "application/pdf",
      })
    );
    let a = document.createElement("a");
    a.href = url;

    a.click();
  };

  //window.location.href = response.url;

  useEffect(async () => {
    props.GetCourseByID(props.match.params.id_course);
  }, []);
  return (
    <Box sx={{ width: "100%" }}>
      {props.selected_course?.uploads.map((upload, index) => {
        return <Resource key={index} upload={upload} />;
      })}
      <div
        style={{
          display: "flex",
        }}
      >
        <div
          style={{
            marginLeft: "auto",
            marginRight: 0,
            display: "flex",
          }}
        ></div>
        <AddIcon style={{ right: 0, left: "auto", color: "#ec7f13" }} />
        <a style={{ color: "#ec7f13" }} onClick={handleOpen}>
          Add an activity or a resource
        </a>
      </div>
      {props.selected_course?.sections?.map((section, index) => {
        return <Section key={index} section={section}></Section>;
      })}
      <AddActivityModal open={open} handleClose={handleClose} {...props} />
      <button onClick={downloadEmployeeData}>Download</button>
    </Box>
  );
};
export default connect(mapStateToProps, mapDispatchToProps)(CoursePage);
