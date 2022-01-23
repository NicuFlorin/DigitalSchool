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

const initialState = {
  students: [],
  potential_users: [],
  error: "",
  isPending: false,
};

export const studentReducer = (state = initialState, action = {}) => {
  switch (action.type) {
    case GetStudentsPending:
      return Object.assign({}, state, { isPending: true });
    case GetStudentsSuccess:
      return Object.assign({}, state, {
        students: action.payload,
        isPending: false,
      });
    case GetStudentsFailed:
      return Object.assign({}, state, {
        error: action.payload,
        isPending: false,
      });
    case AssignUsersPending:
      return Object.assign({}, state, { isPending: true });
    case AssignUsersSuccess:
      return Object.assign([], state, { isPending: false });

    case AssignUsersFailed:
      return Object.assign({}, state, {
        error: action.payload,
        isPending: false,
      });

    case RemoveStudentsPending:
      return Object.assign({}, state, { isPending: true });
    case RemoveStudentsSuccess:
      return Object.assign({}, state, {
        isPending: false,
      });

    case RemoveStudentsFailed:
      return Object.assign({}, state, {
        error: action.payload,
        isPending: false,
      });
    case GetPotentialUsersPending:
      return Object.assign({}, state, { isPending: true });

    case GetPotentialUsersSuccess:
      return Object.assign({}, state, {
        potential_users: action.payload,
        isPending: false,
      });

    case GetPotentialUsersFailed:
      return Object.assign({}, state, {
        error: action.payload,
        isPending: false,
      });

    default:
      return state;
  }
};
