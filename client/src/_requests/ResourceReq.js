import axios from "./Axios";
import { getRequestError } from "./Axios";

export const add = async (token, resource) => {
  try {
    console.log(resource.getAll("files[]"));
    const res = await axios.post("/upload/upload-resource", resource, {
      headers: {
        Authorization: "Bearer " + token,
      },
    });
    return { ok: true, resource: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};
