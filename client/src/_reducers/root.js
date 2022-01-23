import counterReducer from "./counter";
import { signInReducer } from "./loginReducer";
import { combineReducers } from "redux";
import { filterUsers } from "./userFilterReducer";
import { openDrawer } from "./OpenDrawerReducer";
import { usersReducer } from "./usersReducer";
import CohortReducer from "./cohortReducer";
import ContextReducer from "./contextReducer";
import { studentReducer } from "./studentReducer";
import { courseReducer } from "./courseReducer";
import { UploadReducer } from "./uploadReducer";
import { DownloadFileReducer } from "./downloadFileReducer";
const allReducers = combineReducers({
  signInReducer,
  openDrawer,
  filterUsers,
  usersReducer,
  CohortReducer,
  ContextReducer,
  studentReducer,
  courseReducer,
  UploadReducer,
  DownloadFileReducer,
});

export default allReducers;
