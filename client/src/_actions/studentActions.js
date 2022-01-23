import {
  AssignUsersFailed,
  AssignUsersPending,
  AssignUsersSuccess,
  GetPotentialUsersFailed,
  GetPotentialUsersPending,
  GetPotentialUsersSuccess,
  GetStudentsFailed,
  GetStudentsPending,
  GetStudentsSuccess,
  RemoveStudentsFailed,
  RemoveStudentsPending,
  RemoveStudentsSuccess,
} from "../constants";
import {
  assignUsersToCohort,
  getStudentsByCohort,
  removeStudentsFromCohort,
  getPotentialUsers as getUsers,
} from "../_requests/StudentReq";
export const getAssignedUsers = async (dispatch, id_cohort) => {
  dispatch({ type: GetStudentsPending });
  const token = JSON.parse(localStorage.getItem("user"))?.token;
  const res = await getStudentsByCohort(id_cohort, token);
  if (res.ok) {
    dispatch({ type: GetStudentsSuccess, payload: res.students });
  } else {
    dispatch({ type: GetStudentsFailed, payload: res.message });
  }
};

export const assignUsers = async (dispatch, users, id_cohort) => {
  dispatch({ type: AssignUsersPending });
  const token = JSON.parse(localStorage.getItem("user"))?.token;
  const res = await assignUsersToCohort(users, token);
  if (res.ok) {
    dispatch({ type: AssignUsersSuccess });
  } else {
    dispatch({ type: AssignUsersFailed, payload: res.message });
  }
};

export const getPotentialUsers = async (dispatch, id_cohort) => {
  dispatch({ type: GetPotentialUsersPending });
  const token = JSON.parse(localStorage.getItem("user"))?.token;
  const res = await getUsers(id_cohort, token);
  if (res.ok) {
    dispatch({ type: GetPotentialUsersSuccess, payload: res.potential_users });
  } else {
    dispatch({ type: GetPotentialUsersFailed, payload: res.message });
  }
};

export const removeUsers = async (dispatch, users) => {
  dispatch({ type: RemoveStudentsPending });
  const token = JSON.parse(localStorage.getItem("user"))?.token;
  const res = await removeStudentsFromCohort(users, token);
  if (res.ok) {
    dispatch({ type: RemoveStudentsSuccess });
  } else {
    dispatch({ type: RemoveStudentsFailed, payload: res.message });
  }
};
