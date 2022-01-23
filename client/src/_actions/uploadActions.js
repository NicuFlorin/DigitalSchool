import {
  GetUploadFailed,
  GetUploadPending,
  GetUploadSuccess,
} from "../constants";
import { getUpload as get } from "../_requests/UploadReq";
export const getUpload = async (dispatch, id_upload) => {
  dispatch({ type: GetUploadPending });
  const token = JSON.parse(localStorage.getItem("user"))?.token;
  const res = await get(token, id_upload);
  if (res.ok) {
    dispatch({ type: GetUploadSuccess, payload: res.upload });
  } else {
    dispatch({ type: GetUploadFailed, payload: res.message });
  }
};
