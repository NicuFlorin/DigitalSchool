import {
  GetUploadFailed,
  GetUploadPending,
  GetUploadSuccess,
} from "../constants";

const initialState = {
  upload: null,
  isPending: false,
  error: "",
};

export const UploadReducer = (state = initialState, action = {}) => {
  switch (action.type) {
    case GetUploadPending:
      return Object.assign({}, state, { isPending: true });
    case GetUploadSuccess:
      return Object.assign({}, state, {
        isPending: false,
        upload: action.payload,
      });
    case GetUploadFailed:
      return Object.assign({}, state, { isPending: false, error: "" });
    default:
      return state;
  }
};
