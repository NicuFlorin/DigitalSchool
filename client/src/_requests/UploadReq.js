import axios from "./Axios";
import { getRequestError } from "./Axios";

export const getUpload = async (token, id_upload) => {
  try {
    const res = await axios.get("/upload/get-upload/" + id_upload, {
      headers: {
        Authorization: "Bearer " + token,
      },
    });
    return { ok: true, upload: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};
