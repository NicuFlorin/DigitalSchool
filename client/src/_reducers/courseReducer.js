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
const initialState = {
  courses: [],
  isPending: false,
  error: "",
  selected_course: null,
};

export const courseReducer = (state = initialState, action = {}) => {
  switch (action.type) {
    case AddCoursePending:
      return Object.assign({}, state, { isPending: true });
    case AddCourseSuccess:
      return Object.assign({}, state, { isPending: false });
    case AddCourseFailed:
      return Object.assign({}, state, {
        isPending: false,
        error: action.payload,
      });

    case GetCoursesPending:
      return Object.assign({}, state, {
        isPending: true,
      });
    case GetCoursesSuccess:
      return Object.assign({}, state, {
        isPending: false,
        courses: action.payload,
      });
    case GetCoursesFailed:
      return Object.assign({}, state, {
        isPending: false,
        error: action.payload,
      });

    case GetCourseByIDPending:
      return Object.assign({}, state, {
        isPending: true,
      });
    case GetCourseByIDSuccess:
      return Object.assign({}, state, {
        isPending: false,
        selected_course: action.payload,
      });
    case GetCourseByIDFailed:
      return Object.assign({}, state, {
        isPending: false,
        error: action.payload,
      });
    case AddResourcePending:
      return Object.assign({}, state, {
        isPending: true,
      });
    case AddResourceSuccess:
      return Object.assign({}, state, {
        isPending: false,
        courses: addResource(action.payload, state.courses),
      });
    case AddResourceFailes:
      return Object.assign({}, state, {
        isPending: false,
        error: action.payload,
      });
    default:
      return state;
  }
};

function addResource(upload, courses) {
  courses.map((c) => {
    if (c.id == upload.idCourse && upload.idSection == 0) {
      if (c.uploads) {
        c.uploads = [...c.uploads, upload];
      } else c.uploads = [upload];
    }
  });
  return courses;
}
