import {
  AddCohortFailed,
  AddCohortPending,
  AddCohortSuccess,
  GetCohortsFailed,
  GetCohortsPending,
  GetCohortsSuccess,
} from "../constants";

const initialState = {
  cohorts: [],
  pending: false,
  error: "",
};

const CohortReducer = (state = initialState, action = {}) => {
  switch (action.type) {
    case GetCohortsPending:
      return Object.assign({}, state, { isPending: true });
    case GetCohortsSuccess:
      return Object.assign({}, state, {
        isPending: false,
        cohorts: action.payload,
      });
    case GetCohortsFailed:
      return Object.assign({}, state, {
        isPending: false,
        error: action.error,
      });
    case AddCohortPending:
      return Object.assign({}, state, { isPending: true });
    case AddCohortSuccess:
      let cohorts = [...state.cohorts];
      cohorts.push(action.payload);
      return Object.assign({}, state, {
        isPending: false,
        cohorts: cohorts,
      });
    case AddCohortFailed:
      return Object.assign({}, state, {
        isPending: false,
        error: action.error,
      });
    default:
      return state;
  }
};

export default CohortReducer;
