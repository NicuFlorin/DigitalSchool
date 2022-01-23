import {
  AddContextFailed,
  AddContextPending,
  AddContextSuccess,
  GetCohortsFailed,
  GetContextsFailed,
  GetContextsPending,
  GetContextsSuccess,
} from "../constants";

const initialState = {
  contexts: [],
  pending: false,
  error: "",
};

const ContextReducer = (state = initialState, action = {}) => {
  switch (action.type) {
    case GetContextsPending:
      return Object.assign({}, state, { isPending: true });
    case GetContextsSuccess:
      return Object.assign({}, state, {
        isPending: false,
        contexts: action.payload,
      });
    case GetContextsFailed:
      return Object.assign({}, state, {
        isPending: false,
        error: action.error,
      });
    case AddContextPending:
      return Object.assign({}, state, { isPending: true });
    case AddContextSuccess:
      let contexts = [...state.contexts];
      contexts.push(action.payload);
      return Object.assign({}, state, {
        isPending: false,
        contexts: contexts,
      });
    case AddContextFailed:
      return Object.assign({}, state, {
        isPending: false,
        error: action.error,
      });
    default:
      return state;
  }
};

export default ContextReducer;
