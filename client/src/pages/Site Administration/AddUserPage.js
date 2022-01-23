import React, { useState } from "react";
import {
  Checkbox,
  FormControlLabel,
  FormLabel,
  TextField,
  Typography,
} from "@mui/material";
import { Label } from "@mui/icons-material";
import { Button } from "@mui/material";
import { connect } from "react-redux";
import { addUser } from "../../_actions/userActions";

const mapStateToProps = (state) => {
  return {
    users: state.usersReducer.users,
    isPending: state.usersReducer.isPending,
    error: state.usersReducer.error,
  };
};
const mapDispatchToProps = (dispatch) => {
  return {
    AddUser: (user) => addUser(dispatch, user),
  };
};

const AddUserPage = (props) => {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [generatePass, setGeneratePass] = useState(true);
  const [password, setPassword] = useState("");

  const createUser = () => {
    if (firstName !== "" && lastName !== "" && email !== "") {
      const pass = "Parola_123";
      props.AddUser({ firstName, lastName, userName: email, password: pass });
    }
  };
  return (
    <div>
      <div
        style={{
          display: "flex",
          textAlign: "center",
          verticalAlign: "middle",
        }}
      >
        <Typography style={{ textAlign: "center", verticalAlign: "middle" }}>
          First Name
        </Typography>
        <TextField
          size="small"
          sx={{ marginLeft: 10 }}
          onChange={(e) => {
            setFirstName(e.target.value);
          }}
        />
      </div>
      <div
        style={{
          display: "flex",
          textAlign: "center",
          verticalAlign: "middle",
        }}
      >
        <Typography style={{ textAlign: "center", verticalAlign: "middle" }}>
          Last Name
        </Typography>
        <TextField
          size="small"
          sx={{ marginLeft: 10 }}
          onChange={(e) => {
            setLastName(e.target.value);
          }}
        />
      </div>
      <div
        style={{
          display: "flex",
          textAlign: "center",
          verticalAlign: "middle",
        }}
      >
        <Typography style={{ textAlign: "center", verticalAlign: "middle" }}>
          Email
        </Typography>
        <TextField
          size="small"
          sx={{ marginLeft: 10 }}
          type="email"
          onChange={(e) => {
            setEmail(e.target.value);
          }}
        />
      </div>
      <FormControlLabel
        control={
          <Checkbox
            defaultChecked
            onClick={(e) => {
              if (e.target.checked) {
                setGeneratePass(!generatePass);
              }
            }}
          />
        }
        label="Generate password and notify user"
      />
      <FormControlLabel
        control={
          <TextField
            disabled={generatePass}
            size="small"
            type="password"
            onChange={(e) => {
              setPassword(e.target.value);
            }}
          />
        }
        label="New password"
        labelPlacement="start"
      />
      <Button variant="contained" onClick={() => createUser()}>
        Create user
      </Button>
    </div>
  );
};

export default connect(mapStateToProps, mapDispatchToProps)(AddUserPage);
