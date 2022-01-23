import {
  AddCohortFailed,
  AddCohortPending,
  AddCohortSuccess,
  GetCohortsFailed,
  GetCohortsPending,
  GetCohortsSuccess,
} from "../constants";
import CohortReq from "../_requests/CohortReq";


export const getCohorts = async (dispatch) => {

  dispatch({ type: GetCohortsPending });
  const user = JSON.parse(localStorage.getItem("user"));

  const res = await CohortReq.getCohorts(user.token);
  if (res.ok) {
    dispatch({ type: GetCohortsSuccess, payload: res.cohorts });
  } else {
    dispatch({ type: GetCohortsFailed, payload: res.message });
  }
};
export const addCohort = async (dispatch, cohort) => {
  dispatch({ type: AddCohortPending });
  const user = JSON.parse(localStorage.getItem("user"));

  const res = await CohortReq.addCohort(user.token, cohort);
  if (res.ok) {
    dispatch({ type: AddCohortSuccess, payload: res.cohorts });
  } else {
    dispatch({ type: AddCohortFailed, payload: res.message });
  }
};
