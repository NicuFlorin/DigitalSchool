import {
  DownloadFileFailed,
  DownloadFilePending,
  DownloadFileSuccess,
} from "../constants";
import { getFile } from "../_requests/DownloadReq";
export const downloadFile = async (dispatch, id_file) => {
  dispatch({ type: DownloadFilePending });
  const token = JSON.parse(localStorage.getItem("user"))?.token;
  const res = await getFile(id_file, token);
  if (res.ok) {
    dispatch({ type: DownloadFileSuccess, payload: res.fileRes });
  } else dispatch({ type: DownloadFileFailed, payload: res.message });
};
