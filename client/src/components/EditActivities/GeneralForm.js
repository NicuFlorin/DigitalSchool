import React from "react";
import { Box, Typography } from "@mui/material";
import { TextField } from "@material-ui/core";
import TextEditor from "../TextEditor";

const GeneralForm = (props) => {
  const GetDescription = (html) => {};
  return (
    <div>
      <div style={{ width: "50%", display: "flex" }}>
        <Typography sx={{ alignSelf: "center", paddingRight: 15 }}>
          Name
        </Typography>
        <div style={{ flexGrow: 1 }}></div>
        <TextField
          variant="outlined"
          onChange={(e) => {
            props.HandleName(e.target.value);
          }}
          size="small"
          fullWidth
          sx={{ marginStart: 10 }}
        />
      </div>
      <div style={{ display: "flex", paddingTop: 10 }}>
        <Typography sx={{ paddingRight: 10 }}>Description</Typography>
        <TextEditor GetHTML={props.HandleDescription} />
      </div>
    </div>
  );
};

export default GeneralForm;
