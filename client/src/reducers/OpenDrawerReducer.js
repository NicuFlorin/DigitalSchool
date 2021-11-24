import { CloseDrawer, OpenDrawer } from "../constants";

const initialState = {
  isOpen: true,
};
export const openDrawer = (state = initialState, action = {}) => {
  switch (action.type) {
    case OpenDrawer:
      return Object.assign({}, state, { isOpen: true });
    case CloseDrawer:
      return Object.assign({}, state, { isOpen: false });
    default:
      return state;
  }
};
