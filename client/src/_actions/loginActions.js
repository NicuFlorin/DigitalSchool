import {
  SignIn,
  SignOut,
  Register,
  SignInUserPending,
  SignInUserSuccess,
  SignInUserFailed,
  GetCurrentUserFailed,
  GetCurrentUserPending,
  GetCurrentUserSuccess,
  RegisterUserPending,
  RegisterUserSuccess,
  RegisterUserFailed,
} from "../constants.js";
import UserLogin from "../interfaces/UserLogin";
import UserRegister from "../interfaces/UserRegister";
import AuthRequests from "../_requests/auth";

export const signIn = (dispatch, creds) => {
  dispatch({ type: SignInUserPending });
  AuthRequests.login(creds)
    .then((res) => {
      if (res.ok) {
        dispatch({ type: SignInUserSuccess, payload: res.user });
      } else {
        dispatch({ type: SignInUserFailed, error: res.message });
      }
    })
    .catch((err) => dispatch({ type: SignInUserFailed, error: err.message }));
};

export const register = (dispatch, user) => {
  dispatch({ type: RegisterUserPending });
  AuthRequests.register(user).then((res) => {
    if (res.ok) dispatch({ type: RegisterUserSuccess });
    else dispatch({ type: RegisterUserFailed, payload: res.message });
  });
};
export const signOut = () => {
  return {
    type: SignOut,
  };
};

export const getCurrentUser = (dispatch) => {
  dispatch({ type: GetCurrentUserPending });
  const user = JSON.parse(localStorage.getItem("user"));
  if (!user) {
    dispatch({ type: GetCurrentUserFailed, payload: "current user not found" });
    return;
  }
  AuthRequests.getCurrentUser(user.token, user.id)
    .then((res) => {
      if (res.ok) {
        dispatch({ type: GetCurrentUserSuccess, payload: res.user });
      } else dispatch({ type: GetCurrentUserFailed, payload: res.message });
    })
    .catch((err) =>
      dispatch({ type: GetCurrentUserFailed, payload: err.message })
    );
};
