import * as React from "react";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";
import Activity from "../Cards/Activity";
import AssignmentIcon from "@mui/icons-material/Assignment";
import assignment from "../../icons/assignment.png";
import quiz from "../../icons/quiz.png";
import attendance from "../../icons/attendance.png";
import file from "../../icons/file.png";
const style = {
  position: "absolute",
  top: "30%",
  left: "50%",
  transform: "translate(-50%, -30%)",
  width: 600,
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
};
const asmIcon = <img width={40} height={40} src={assignment}></img>;
const quizIcon = <img width={40} height={40} src={quiz}></img>;
const attendanceIcon = <img width={40} height={40} src={attendance}></img>;
const fileIcon = <img width={40} height={40} src={file}></img>;

export default function AddActivityModal(props) {
  return (
    <Modal
      open={props.open}
      onClose={props.handleClose}
      aria-labelledby="modal-modal-title"
      aria-describedby="modal-modal-description"
    >
      <Box sx={style}>
        <Typography id="modal-modal-title" variant="h7" component="h2">
          Add an activity or resource
        </Typography>
        <Box
          sx={{
            display: "flex",
            flexWrap: "wrap",
            width: "100%",
            justifyContent: "center",
          }}
        >
          <Activity title="Assignment" icon={asmIcon} {...props}/>
          <Activity title="Quiz" icon={quizIcon} {...props}/>
          <Activity title="Attendance" icon={attendanceIcon} {...props}/>
          <Activity title="File" icon={fileIcon} {...props}/>
        </Box>
      </Box>
    </Modal>
  );
}
