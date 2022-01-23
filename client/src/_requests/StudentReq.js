import axios from "./Axios";
import { getRequestError } from "./Axios";

export const getStudentsByCohort = async (id_cohort, token) => {
  try {
    const res = await axios.get("/student/" + id_cohort, {
      headers: { Authorization: "Bearer " + token },
    });
    return { ok: true, students: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};

export const getPotentialUsers = async (id_cohort, token) => {
  try {
    const res = await axios.get("/student/potential-users/" + id_cohort, {
      headers: { Authorization: "Bearer " + token },
    });
    return { ok: true, potential_users: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};

export const assignUsersToCohort = async (users, token) => {
  try {
    const res = await axios.post("/student/assign/", users, {
      headers: { Authorization: "Bearer " + token },
    });
    window.location.reload();
    return { ok: true };
  } catch (err) {
    return getRequestError(err);
  }
};
export const removeStudentsFromCohort = async (users, token) => {
  try {
    const res = await axios.post("/student/remove", users, {
      headers: { Authorization: "Bearer " + token },
    });
    window.location.reload();
    return { ok: true, students: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};
