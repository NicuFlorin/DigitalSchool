import {
  SignIn,
  Register,
  SignOut,
  GetCurrentUserPending,
  GetCurrentUserSuccess,
  GetCurrentUserFailed,
  SignInUserPending,
  SignInUserSuccess,
  SignInUserFailed,
  RegisterUserPending,
  RegisterUserSuccess,
  RegisterUserFailed,
} from "../constants.js";
const initialState = {
  loggedIn: false,
  isPending: false,
  error: "",
  currentUser: null,
};
export const signInReducer = (state = initialState, action = {}) => {
  switch (action.type) {
    case SignInUserPending:
      return Object.assign({}, state, {
        isPending: true,
      });
    case SignInUserSuccess:
      return Object.assign({}, state, {
        loggedIn: true,
        isPending: false,
        currentUser: action.payload,
      });
    case SignInUserFailed:
      return Object.assign({}, state, {
        loggedIn: false,
        isPending: false,
        currentUser: null,
      });
    case GetCurrentUserPending:
      return Object.assign({}, state, { isPending: true });
    case GetCurrentUserSuccess:
      return Object.assign({}, state, {
        isPending: false,
        loggedIn: true,
        currentUser: JSON.parse(localStorage.getItem("user")),
      });
    case GetCurrentUserFailed:
      return Object.assign({}, state, {
        currentUser: null,
        isPending: false,
        error: action.payload,
        loggedIn: false,
      });
    case RegisterUserPending:
      return Object.assign({}, state, { isPending: true });
    case RegisterUserSuccess:
      return Object.assign({}, state, { isPending: false, error: null });
    case RegisterUserFailed:
      return Object.assign({}, state, {
        isPending: false,
        error: action.payload,
      });
    case SignOut:
      return Object.assign({}, state, {
        loggedIn: false,
        currentUser: null,
        isPending: false,
      });
    default:
      return state;
  }
};
