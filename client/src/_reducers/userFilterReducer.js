import { Email, FullName, Role } from "../constants";

const initialState = {
  fullName: "",
  email: "",
  role: "",
};

export const filterUsers = (state = initialState, action = {}) => {
  switch (action.type) {
    case FullName:
      return Object.assign({}, state, { fullName: action.payload });
    case Email:
      return Object.assign({}, state, { email: action.payload });
    case Role:
      return Object.assign({}, state, { role: action.payload });
    default:
      return state;
  }
};
