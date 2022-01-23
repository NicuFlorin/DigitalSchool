import React, { useState } from "react";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import {
  filterByName,
  filterByEmail,
  filterByRole,
} from "../../_actions/userFilterActions";
import { connect } from "react-redux";
import {
  InputLabel,
  FormHelperText,
  Select,
  MenuItem,
  Button,
} from "@mui/material";

const mapDispatchToProps = (dispatch) => {
  return {
    onFilterByName: (name) => dispatch(filterByName(name)),
    onFilterByEmail: (email) => dispatch(filterByEmail(email)),
    onFilterByName: (role) => dispatch(filterByName(role)),
  };
};

const UserFilter = (props) => {
  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");
  const [role, setRole] = useState("");
  return (
    <Box
      component="form"
      sx={{
        "& .MuiTextField-root": { m: 1, width: "25ch" },
      }}
      noValidate
      autoComplete="off"
    >
      <div>
        <TextField
          onChange={(e) => {
            setFullName(e.target.value);
          }}
          label="User name contains"
        ></TextField>
        <TextField
          label="Email adress"
          onChange={(e) => setEmail(e.target.value)}
        />
        <InputLabel id="demo-simple-select-helper-label"></InputLabel>
        <FormHelperText>Course role</FormHelperText>
        <Select
          labelId="demo-simple-select-helper-label"
          id="demo-simple-select-helper"
          label="Age"
          onChange={(e) => {
            setRole(e.targer.value);
          }}
        >
          <MenuItem value="any role" selected></MenuItem>
          <MenuItem value="Teacher">Teacher</MenuItem>
          <MenuItem value="Student">Student</MenuItem>
          <MenuItem value="Parent">Parent</MenuItem>
        </Select>
        <Select labelId="demo-simple-select-helper-label" label="">
          <MenuItem value="any category" selected></MenuItem>
        </Select>

        <Select
          labelId="demo-simple-select-helper-label"
          id="demo-simple-select-helper"
          label="Enrolled in any course"
        >
          <MenuItem value="any value" selected></MenuItem>
          <MenuItem value="Yes" selected></MenuItem>
          <MenuItem value="No" selected></MenuItem>
        </Select>
        <Button
          onClick={() => {
            if (fullName !== "") {
              props.onFilterByName(fullName);
            }
            if (email !== "") {
              props.onFilterByEmail(email);
            }
            if (role !== "") {
              props.onFilterByRole(role);
            }
          }}
        >
          Add Filter
        </Button>
      </div>
    </Box>
  );
};

export default connect(null, mapDispatchToProps)(UserFilter);
