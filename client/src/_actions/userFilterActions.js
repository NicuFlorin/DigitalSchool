import { Email, FullName, Role } from "../constants";
export const filterByName = (fullName) => {
  return {
    type: FullName,
    payload: fullName,
  };
};

export const filterByEmail = (email) => {
  return {
    type: Email,
    payload: email,
  };
};
export const filterByRole = (role) => {
  return {
    type: Role,
    payload: role,
  };
};
