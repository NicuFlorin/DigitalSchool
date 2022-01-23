import React, { useEffect, useState } from "react";
import { getUsers } from "../../_actions/userActions";
import { Box, Button, Checkbox, FormControlLabel } from "@mui/material";
import { connect } from "react-redux";
import {
  assignUsers,
  getAssignedUsers,
  removeUsers,
  getPotentialUsers,
} from "../../_actions/studentActions";
import { LteMobiledataOutlined } from "@mui/icons-material";
const mapStateToProps = (state) => {
  return {
    users: state.usersReducer.users,
    students: state.studentReducer.students,
    potential_users: state.studentReducer.potential_users,
  };
};
const mapDispatchToProps = (dispatch) => {
  return {
    GetPotentialUsers: (id_cohort) => getPotentialUsers(dispatch, id_cohort),
    GetStudents: (id_cohort) => getAssignedUsers(dispatch, id_cohort),
    AssignUsers: (users) => assignUsers(dispatch, users),
    RemoveUsers: (users) => removeUsers(dispatch, users),
  };
};
const AssignPage = (props) => {
  const potential_users = props.potential_users;
  const students = props.students;
  const [usersToAdd, setUsersToAdd] = useState([]);
  const [usersToRemove, setUsersToRemove] = useState([]);
  useEffect(() => {
    const token = JSON.parse(localStorage.getItem("user"))?.token;
    props.GetStudents(props.match.params.id_cohort);
    props.GetPotentialUsers(props.match.params.id_cohort);
  }, []);

  return (
    <div>
      <Box
        sx={{
          width: "95%",
          height: 500,
          backgroundColor: "#e1e8f2",
          position: "absolute",
          display: "flex",
        }}
      >
        <Box
          sx={{
            backgroundColor: "white",
            width: "40%",
            height: "80%",
            marginLeft: 5,
            marginTop: 10,
          }}
        >
          Current users
          <div style={{ dispay: "flex", flexDirection: "column" }}>
            {students.map((student, index) => {
              return (
                <div key={index}>
                  <FormControlLabel
                    control={
                      <Checkbox
                        id={student.memberDto.id}
                        onChange={(e) => {
                          if (e.target.checked) {
                            const users = [...usersToRemove];
                            users.push({
                              memberDto: { id: parseInt(e.target.id) },
                              cohortId: props.match.params.id_cohort,
                            });
                            setUsersToRemove(users);
                          } else {
                            let users = [...usersToRemove];
                            users = users.filter(
                              (u) => u.memberDto.id != e.target.id
                            );
                            setUsersToRemove(users);
                          }
                        }}
                      />
                    }
                    label={`${student.memberDto.firstName} ${student.memberDto.lastName} (${student.memberDto.username})`}
                  />
                </div>
              );
            })}
          </div>
        </Box>
        <div
          style={{ display: "flex", flexDirection: "column", marginLeft: 10 }}
        >
          <Button
            variant="contained"
            sx={{ backgroundColor: "#bebfc2", marginTop: 30 }}
            onClick={() => {
              props.AssignUsers(usersToAdd);
              console.log("afet");
            }}
          >
            Add
          </Button>
          <Button
            variant="contained"
            sx={{ backgroundColor: "#bebfc2", marginTop: 5 }}
            onClick={() => {
              props.RemoveUsers(usersToRemove, props.match.params.id_cohort);
              console.log("afet");
            }}
          >
            Remove
          </Button>
        </div>
        <Box
          sx={{
            backgroundColor: "white",
            width: "20%",
            height: "80%",
            marginLeft: 5,
            marginTop: 10,
            overflow: "scroll",
          }}
        >
          Potential users
          <div style={{ dispay: "flex", flexDirection: "column" }}>
            {potential_users.map((user, index) => {
              return (
                <div key={index}>
                  <FormControlLabel
                    control={
                      <Checkbox
                        id={user.id}
                        onChange={(e) => {
                          if (e.target.checked) {
                            let users = [...usersToAdd];
                            users.push({
                              memberDto: { id: parseInt(e.target.id) },
                              cohortId: props.match.params.id_cohort,
                            });
                            setUsersToAdd(users);
                          } else {
                            let users = [...usersToAdd];
                            users = users.filter(
                              (u) => u.memberDto.id != e.target.id
                            );
                            setUsersToAdd(users);
                          }
                        }}
                      />
                    }
                    label={`${user.firstName} ${user.lastName} (${user.username})`}
                  />
                </div>
              );
            })}
          </div>
        </Box>
      </Box>
    </div>
  );
};

export default connect(mapStateToProps, mapDispatchToProps)(AssignPage);
