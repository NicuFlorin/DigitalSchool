import { Box } from "@mui/system";
import React from "react";
import { useSearchParams } from "react-router-dom";
import EditResource from "../components/EditActivities/EditResource";
const EditActivityPage = (props) => {
  const id_course = props.match.params.id_course;
  const activity_type = props.match.params.activity_type;
  const sectionId = new URLSearchParams(window.location.search).get(
    "sectionId"
  );
  return (
    <Box sx={{ width: "100%" }}>
      {activity_type === "Assignment" && <div>Assignment</div>}
      {activity_type === "quiz" && <div>Quiz</div>}
      {activity_type === "attendance" && <div>Attendance</div>}
      {activity_type === "File" && (
        <EditResource {...props} id_course={id_course} sectionId={sectionId} />
      )}
    </Box>
  );
};

export default EditActivityPage;
