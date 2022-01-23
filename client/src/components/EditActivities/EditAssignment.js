import React, { useState } from "react";
import { Box } from "@mui/system";
import { useHistory } from "react-router-dom";
import { connect } from "react-redux";
import FileUpload from "../FileUpload/FileUpload";
import GeneralForm from "./GeneralForm";

const EditAssignment = (props) => {
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [files, setFiles] = useState([]);
  const history = useHistory();
  const formData = new FormData();

  const handleDescription = (html) => {
    setDescription(html);
  };

  const handleFiles = (file) => {
    setFiles([...files, file]);
  };
  return (
    <Box sx={{ width: "100%" }}>
      <GeneralForm
        HandleName={handleName}
        HandleDescription={handleDescription}
      />
      <div style={{ display: "flex", paddingTop: 10 }}>
        <Typography sx={{ paddingRight: 11 }}>Select files</Typography>
        <FileUpload HandleFiles={handleFiles} files={files} />
      </div>
      <div style={{ display: "flex", justifyContent: "center", paddingTop: 7 }}>
        <Button
          variant="contained"
          sx={{ marginRight: 3 }}
          onClick={uploadResource}
        >
          Save
        </Button>
        <Button
          variant="outlined"
          onClick={() => {
            history.goBack();
          }}
        >
          Cancel
        </Button>
      </div>
    </Box>
  );
};

export default EditAssignment;
