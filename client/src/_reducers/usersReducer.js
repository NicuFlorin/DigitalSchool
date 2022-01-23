import {
  AddUserFailed,
  AddUserPending,
  AddUserSuccess,
  GetUsersFailed,
  GetUsersPending,
  GetUsersSuccess,
} from "../constants";

const initialState = {
  users: [],
  isPending: false,
  error: "",
};

export const usersReducer = (state = initialState, action = {}) => {
  switch (action.type) {
    case GetUsersPending:
      return Object.assign({}, state, {
        isPending: true,
      });
    case GetUsersFailed:
      return Object.assign({}, state, {
        isPending: false,
        error: action.error,
      });
    case GetUsersSuccess:
      return Object.assign({}, state, {
        isPending: false,
        users: action.payload,
      });
    case AddUserPending:
      return Object.assign({}, state, {
        isPending: true,
      });

    case AddUserFailed:
      return Object.assign({}, state, {
        isPending: false,
        error: action.error,
      });

    case AddUserSuccess:
      let users = [...state.users];
      users.push(action.payload);
      return Object.assign({}, state, { isPending: false, users: users });

    default:
      return state;
  }
};
