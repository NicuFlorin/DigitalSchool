import {
  AddCourseFailed,
  AddCoursePending,
  AddCourseSuccess,
  AddResourceFailes,
  AddResourcePending,
  AddResourceSuccess,
  GetCourseByIDFailed,
  GetCourseByIDPending,
  GetCourseByIDSuccess,
  GetCoursesFailed,
  GetCoursesPending,
  GetCoursesSuccess,
} from "../constants";
import {
  addCourse as add,
  getCourses as get,
  getAll,
  getByID,
} from "../_requests/CourseReq";
import { add as addResourceReq } from "../_requests/ResourceReq";

export const addCourse = async (dispatch, course) => {
  dispatch({ type: AddCoursePending });
  const token = JSON.parse(localStorage.getItem("user"))?.token;
  const res = await add(course, token);
  if (res.ok) {
    dispatch({ type: AddCourseSuccess });
  } else {
    dispatch({ type: AddCourseFailed, error: res.message });
  }
};

export const getCourses = async (dispatch, id_category) => {
  dispatch({ type: GetCoursesPending });
  const token = JSON.parse(localStorage.getItem("user"))?.token;
  const res = await get(id_category, token);
  if (res.ok) {
    dispatch({ type: GetCoursesSuccess, payload: res.courses });
  } else {
    dispatch({ type: GetCoursesFailed, error: res.message });
  }
};

export const getCourseByID = async (dispatch, id_course) => {
  dispatch({ type: GetCourseByIDPending });
  const token = JSON.parse(localStorage.getItem("user"))?.token;
  const res = await getByID(token, id_course);
  if (res.ok) {
    dispatch({ type: GetCourseByIDSuccess, payload: res.course });
  } else {
    dispatch({ type: GetCourseByIDFailed, error: res.message });
  }
};

export const getAllCourses = async (dispatch) => {
  dispatch({ type: GetCoursesPending });
  const token = JSON.parse(localStorage.getItem("user"))?.token;
  const res = await getAll(token);
  if (res.ok) {
    dispatch({ type: GetCoursesSuccess, payload: res.courses });
  } else {
    dispatch({ type: GetCoursesFailed, error: res.message });
  }
};

export const addResource = async (dispatch, resource) => {
  dispatch({ type: AddResourcePending });
  const token = JSON.parse(localStorage.getItem("user"))?.token;
  const res = await addResourceReq(token, resource);
  if (res.ok) {
    dispatch({ type: AddResourceSuccess, payload: res.resource });
  } else dispatch({ type: AddResourceFailes, payload: res.message });
};
