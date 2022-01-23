import { Box } from "@mui/material";
import React, { useEffect } from "react";
import { connect } from "react-redux";
import { getUpload } from "../_actions/uploadActions";
import { Typography } from "@mui/material";
import { useSearchParams } from "react-router-dom";
import { downloadFile } from "../_actions/downloadActions";
import General from "../components/Activity/General"

const mapStateToProps = (state) => {
  return {
    upload: state.UploadReducer.upload,
    isPending: state.UploadReducer.isPending,
    error: state.UploadReducer.error,
    file: state.DownloadFileReducer.file,
  };
};
const mapDispatchToProps = (dispatch) => {
  return {
    GetUpload: (id_upload) => getUpload(dispatch, id_upload),
    Download: (id_file) => downloadFile(dispatch, id_file),
  };
};
const ActivityPage = (props) => {
  const upload = props.upload;
  const URLParams = new URLSearchParams(window.location.search);
  const c_id = URLParams.get("c_id");
  const r_type = URLParams.get("r_type");
  const id_upload = URLParams.get("id_upload");
 
  useEffect(() => {
    props.GetUpload(id_upload);
    if (props.file) {
    }
  }, []);
  return (
    <Box>
      {upload && (
        <div>
          <General upload={upload} />
        </div>
      )}
    </Box>
  );
};
export default connect(mapStateToProps, mapDispatchToProps)(ActivityPage);
