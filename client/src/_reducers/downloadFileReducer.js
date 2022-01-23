import {
  DownloadFileFailed,
  DownloadFilePending,
  DownloadFileSuccess,
} from "../constants";

const initialState = {
  file: null,
  isPending: false,
  error: "",
};

export const DownloadFileReducer = (state = initialState, action = {}) => {
  switch (action.type) {
    case DownloadFilePending:
      return Object.assign({}, state, { isPending: true, file: null });
    case DownloadFileSuccess:
      return Object.assign({}, state, {
        file: action.payload,
        isPending: false,
      });
    case DownloadFileFailed:
      return Object.assign({}, state, { isPending: false, file: null });
    default:
      return state;
  }
};
