import axios from "./Axios";
import { getRequestError } from "./Axios";

const getContexts = async (token) => {
  try {
    const res = await axios.get("/context/get-all", {
      headers: {
        Authorization: "Bearer " + token,
      },
    });
    return { ok: true, contexts: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};

const addContext = async (token, context) => {
  try {
    const res = await axios.post("/context", {
      headers: {
        Authorization: "Bearer " + token,
      },
      context,
    });
    return { ok: true, context: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};
const ContextReq = { getContexts, addContext };
export default ContextReq;
