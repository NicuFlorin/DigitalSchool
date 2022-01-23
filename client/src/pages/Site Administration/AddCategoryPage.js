import React, { useEffect, useState } from "react";
import { connect } from "react-redux";
import { getContexts, addContext } from "../../_actions/contextActions";
import {
  Button,
  FormControlLabel,
  MenuItem,
  Select,
  TextField,
  Typography,
} from "@mui/material";
import { Box } from "@mui/system";

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
    AddContext: (context) => addContext(dispatch, context),
  };
};
const AddCategory = (props) => {
  const [name, setName] = useState("");
  const [id, setId] = useState("");
  const [description, setDescription] = useState("");
  const [context, setContext] = useState(null);

  useEffect(() => {
    props.GetContexts();
  }, []);

  const flatten = (arr) =>
    arr.reduce((a, value) => {
      a.push({ id: value.id, name: value.name });
      if (value.subCategory instanceof Array && value.subCategory.length > 0) {
        a.push(...flatten(value.subCategory));
      }
      return a;
    }, []);
  const contexts = flatten(props.contexts);

  const addCategory = () => {
    props.AddCohort({
      name,
      id: id !== "" ? id : 0,
      parentId: context,
      description,
    });
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
        label="Category name"
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
        label="Parent category"
        labelPlacement="start"
      />

      <FormControlLabel
        control={
          <TextField
            size="medium"
            type="number"
            onChange={(e) => {
              setId(e.target.value);
            }}
          />
        }
        label="Category ID number"
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
      <Button variant="contained" size="small" onClick={() => addCategory()}>
        Create category
      </Button>
    </Box>
  );
};

export default connect(mapStateToProps, mapDispatchToProps)(AddCategory);
