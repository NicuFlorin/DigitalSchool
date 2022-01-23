import { Typography } from "@mui/material";
import React from "react";
import { FileIcon, defaultStyles } from "react-file-icon";
import { getFile } from "../../_requests/DownloadReq";

const General = (props) => {
  const upload = props.upload;
  const downloadFile = async (id_file, fileName) => {
    const token = JSON.parse(localStorage.getItem("user"))?.token;

    const res = await getFile(id_file, token);
    if (res.ok) {
      let url = window.URL.createObjectURL(
        new Blob([res.file], {
          type: res.file["content-type"],
        })
      );
      let a = document.createElement("a");
      a.href = url;
      a.download = fileName;
      a.click();
    }
  };
  return (
    <div>
      <Typography variant="h4" component="h4">
        {upload.name && upload.name}
      </Typography>
      <div
        dangerouslySetInnerHTML={{
          __html:
            upload.description !== "null" ? upload.description : <div>as</div>,
        }}
      ></div>
      {upload.files &&
        upload.files.map((file, index) => {
          const splits = file.fileName.split(".");
          const ext = splits[splits.length - 1];
          return (
            <div
              key={index}
              onClick={() => {
                downloadFile(file.id, file.fileName);
              }}
              style={{
                display: "flex",
                marginTop: 20,
              }}
            >
              <div style={{ width: "30px", height: "30px", marginRight: 3 }}>
                <FileIcon extension={ext} {...defaultStyles[ext]} />
              </div>
              <div style={{ alignSelf: "center" }}>{file.fileName}</div>
            </div>
          );
        })}
    </div>
  );
};
export default General;
