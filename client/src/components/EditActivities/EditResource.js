import { Box } from "@mui/system";
import React, { useState } from "react";
import GeneralForm from "./GeneralForm";
import FileUpload from "../FileUpload/FileUpload";
import { Button, Typography } from "@mui/material";
import { useHistory } from "react-router-dom";
import { connect } from "react-redux";
import { addResource } from "../../_actions/courseActions";
const mapStateToProps = (state) => {
  return {
    error: state.courseReducer.error,
    isPending: state.courseReducer.isPending,
  };
};
const mapDispatchToProps = (dispatch) => {
  return {
    UploadResource: (resource) => {
      addResource(dispatch, resource);
    },
  };
};
const EditResource = (props) => {
  const formData = new FormData();
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [files, setFiles] = useState([]);
  const history = useHistory();
  const handleName = (name) => {
    console.log(name);
    setName(name);
  };
  const handleDescription = (html) => {
    setDescription(html);
  };

  const handleFiles = (file) => {
    setFiles([...files, file]);
  };

  const uploadResource = () => {
    formData.append("name", name);
    formData.append("description", description);
    for (let i = 0; i < files.length; i++) {
      formData.append("clientFiles", files[i]);
    }
    formData.append("courseId", props.id_course);
    if (props.sectionId != "0") formData.append("sectionId", props.sectionId);
    if (files.length > 0) {
      props.UploadResource(formData);
    }
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

export default connect(mapStateToProps, mapDispatchToProps)(EditResource);
