import React, { useState, useEffect } from "react";
import { Box, MenuItem, TextField } from "@mui/material";
import { connect } from "react-redux";
import { Select } from "@material-ui/core";
import { getContexts } from "../../_actions/contextActions";
import DatePicker from "@mui/lab/DatePicker";
import LocalizationProvider from "@mui/lab/LocalizationProvider";
import AdapterDateFns from "@mui/lab/AdapterDateFns";

const mapStateToProps = (state) => {
  return {
    contexts: state.ContextReducer.contexts,
  };
};
const mapDispatchToProps = (dispatch) => {
  return {
    GetContexts: () => getContexts(dispatch),
  };
};

const flatten = (arr) =>
  arr.reduce((a, value) => {
    a.push({ id: value.id, name: value.name });
    if (value.subCategory instanceof Array && value.subCategory.length > 0) {
      a.push(...flatten(value.subCategory));
    }
    return a;
  }, []);

const AddCoursePage = (props) => {
  const contexts = flatten(props.contexts);
  useEffect(() => {
    props.GetContexts();
  }, []);

  return (
    <Box
      component="form"
      sx={{
        "& > :not(style)": { m: 1, width: "25ch" },
      }}
      noValidate
      autoComplete="off"
    >
      <TextField label="Course full name" size="medium" variant="outlined" />
      <TextField label="Course short name" size="medium" variant="outlined" />

      <div>
        <Select label="Course category">
          <MenuItem default disabled>
            Choose
          </MenuItem>
          {contexts.map((context, index) => {
            return <MenuItem id={context.id}>{context.name}</MenuItem>;
          })}
        </Select>
      </div>
      <div>
        <LocalizationProvider dateAdapter={AdapterDateFns}>
          <DatePicker
            disableFuture
            label="Course start date"
            openTo="year"
            views={["year", "month", "day"]}
            onChange={(newValue) => {}}
            renderInput={(params) => <TextField {...params} />}
          />
          <DatePicker
            disableFuture
            label="Course end date"
            openTo="year"
            views={["year", "month", "day"]}
            onChange={(newValue) => {}}
            renderInput={(params) => <TextField {...params} />}
          />
        </LocalizationProvider>
      </div>
      <div>
        <TextField label="Course ID number" />
      </div>
      <TextField multiline rows={10} label="Description"></TextField>
      <div>
        Course Format
        <Select>
          <MenuItem>Weekly</MenuItem>
          <MenuItem>Topics</MenuItem>
          <MenuItem>Social</MenuItem>
        </Select>
      </div>
    </Box>
  );
};

export default connect(mapStateToProps, mapDispatchToProps)(AddCoursePage);
