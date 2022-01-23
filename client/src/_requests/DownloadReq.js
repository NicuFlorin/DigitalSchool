import axios from "./Axios";
import { getRequestError } from "./Axios";
export const getFile = async (id_file, token) => {
  try {
    const res = await axios("/upload/get-file/" + id_file, {
      responseType: "blob",
      headers: {
        Authorization: "Bearer " + token,
      },
    });

    return { ok: true, file: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};
