import counterReducer from "./counter";
import { signInReducer } from "./loginReducer";
import { combineReducers } from "redux";
import { openDrawer } from "../reducers/OpenDrawerReducer";

const allReducers = combineReducers({
  signInReducer,
  openDrawer,
});

export default allReducers;
