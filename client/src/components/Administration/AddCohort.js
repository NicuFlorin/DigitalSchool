import {
  Button,
  FormControlLabel,
  MenuItem,
  Select,
  TextField,
  Typography,
} from "@mui/material";
import { Box } from "@mui/system";
import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import { getContexts } from "../../_actions/contextActions";
import { addCohort } from "../../_actions/cohortActions";

const mapStateToProps = (state) => {
  return {
    contexts: state.ContextReducer.contexts,
    isPending: state.ContextReducer.isPending,
    error: state.ContextReducer.error,
  };
};
const mapDispatchToProps = (dispatch) => {
  return {
    GetContexts: () => getContexts(dispatch),
    AddCohort: (cohort) => addCohort(dispatch, cohort),
  };
};

const AddCohort = (props) => {
  const [name, setName] = useState("");
  const [id, setId] = useState("");
  const [description, setDescription] = useState("");
  const [context, setContext] = useState(null);

  const flatten = (arr) =>
    arr.reduce((a, value) => {
      a.push({ id: value.id, name: value.name });
      if (value.subCategory instanceof Array && value.subCategory.length > 0) {
        a.push(...flatten(value.subCategory));
      }
      return a;
    }, []);
  const contexts = flatten(props.contexts);
  useEffect(async () => {
    props.GetContexts();
  }, []);

  const addCohort = () => {
    if (name !== "") {
      props.AddCohort({
        name,
        id: id !== "" ? id : 0,
        contextId: context,
        description,
      });
    }
  };
  return (
    <Box sx={{ display: "flex", flexDirection: "column" }}>
      <FormControlLabel
        control={
          <TextField
            size="medium"
            onChange={(e) => {
              setName(e.target.value);
            }}
          />
        }
        label="Name"
        labelPlacement="start"
      />
      <FormControlLabel
        control={
          <Select
            size="medium"
            defaultValue={"Global"}
            onChange={(e) => {
              setContext(e.target.value);
            }}
          >
            <MenuItem selected>Choose</MenuItem>
            {contexts?.map((context, index) => {
              return (
                <MenuItem value={context.id} key={index}>
                  {context.name}
                </MenuItem>
              );
            })}
          </Select>
        }
        label="Context"
        labelPlacement="start"
      />

      <FormControlLabel
        control={
          <TextField
            size="medium"
            onChange={(e) => {
              setId(e.target.value);
            }}
          />
        }
        label="Cohort ID"
        labelPlacement="start"
      />
      <FormControlLabel
        control={
          <TextField
            size="medium"
            multiline={4}
            onChange={(e) => {
              setDescription(e.target.value);
            }}
          />
        }
        label="Description"
        labelPlacement="start"
      />
      <Button variant="contained" size="small" onClick={() => addCohort()}>
        Add cohort
      </Button>
    </Box>
  );
};

export default connect(mapStateToProps, mapDispatchToProps)(AddCohort);
