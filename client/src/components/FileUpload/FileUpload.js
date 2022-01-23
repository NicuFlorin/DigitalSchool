import React, { useRef, useState } from "react";
import { Box } from "@mui/system";
import InsertDriveFileIcon from "@mui/icons-material/InsertDriveFile";
import FileDownloadIcon from "@mui/icons-material/FileDownload";
import DeleteIcon from "@mui/icons-material/Delete";
import { DataGrid } from "@mui/x-data-grid";
const FileUpload = (props) => {
  const inputFile = useRef(null);

  const handleFileChange = (event) => {
    event.stopPropagation();
    event.preventDefault();

    props.HandleFiles(event.target.files[0]);
  };
  const convert = (size) => {
    if (size < 1000) return size + " B";
    if (size < 1000000) return parseFloat(size / 1000) + " KB";
    return parseFloat(size / 1000) + " MB";
  };
  const columns = [
    { field: "name", headerName: "Name", width: 300 },
    { field: "lastModified", headerName: "Last Modified", width: 180 },
    { field: "size", headerName: "Size", width: 90 },
    { field: "type", headerName: "Type", width: 200 },
  ];
  const rows = props.files.map((file, index) => {
    return {
      id: index,
      name: file.name,
      lastModified: file.lastModifiedDate,
      size: convert(file.size),
      type: file.type,
    };
  });
  const handleDeleteFile = () => {};
  return (
    <Box sx={{ border: "1px solid", width: "100%", height: 250 }}>
      <input
        type="file"
        id="file"
        onChange={handleFileChange}
        ref={inputFile}
        style={{ display: "none" }}
      />
      <div style={{ display: "flex" }}>
        <InsertDriveFileIcon
          onClick={() => {
            inputFile.current.click();
          }}
        />
        <FileDownloadIcon />
        <DeleteIcon onClick={handleDeleteFile} />
      </div>
      <div style={{ height: "95%", width: "100%", overflow: "scroll" }}>
        <DataGrid
          rows={rows}
          columns={columns}
          pageSize={5}
          rowsPerPageOptions={[5]}
          checkboxSelection
        />
      </div>
    </Box>
  );
};

export default FileUpload;
