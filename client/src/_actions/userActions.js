import {
  AddUserFailed,
  AddUserPending,
  AddUserSuccess,
  GetUsersFailed,
  GetUsersPending,
  GetUsersSuccess,
} from "../constants";
import Users from "../_requests/Users";
export const getUsers = (dispatch, token) => {
  dispatch({ type: GetUsersPending });

  Users.getUsers(token).then((res) => {
    if (res.ok) {
      dispatch({ type: GetUsersSuccess, payload: res.users });
    } else {
      dispatch({ type: GetUsersFailed, error: res.message });
    }
  });
};

export const addUser = (dispatch, user) => {
  dispatch({ type: AddUserPending });
  const token = JSON.parse(localStorage.getItem("user"))?.token;

  Users.addUser(user, token).then((res) => {
    if (res.ok) {
      dispatch({ type: AddUserSuccess, payload: res.user });
    } else {
      dispatch({ type: AddUserFailed, error: res.message });
    }
  });
};
