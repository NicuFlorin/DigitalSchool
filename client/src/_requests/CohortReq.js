import axios from "./Axios";
import { getRequestError } from "./Axios";

const getCohorts = async (token) => {
  try {
    const res = await axios.get("/cohort", {
      headers: {
        Authorization: "Bearer " + token,
      },
    });
    return { ok: true, cohorts: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};

const addCohort = async (token, cohort) => {
  try {
    const res = await axios.post("/cohort/create", cohort, {
      headers: {
        Authorization: "Bearer " + token,
      },
    });
    return { ok: true, cohort: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};

const CohortReq = { getCohorts, addCohort };
export default CohortReq;
