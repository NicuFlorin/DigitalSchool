import {
  AddContextFailed,
  AddContextPending,
  AddContextSuccess,
  GetCohortsFailed,
  GetContextsPending,
  GetContextsSuccess,
} from "../constants";
import ContextReq from "../_requests/ContextReq";

export const getContexts = async (dispatch) => {
  dispatch({ type: GetContextsPending });
  const user = JSON.parse(localStorage.getItem("user"));

  const res = await ContextReq.getContexts(user.token);
  if (res.ok) {
    dispatch({ type: GetContextsSuccess, payload: res.contexts });
  } else dispatch({ type: GetCohortsFailed, error: res.message });
  if (!user) {
    dispatch({ type: GetCohortsFailed, error: "current user not found" });
    return;
  }
};

export const addContext = async (dispatch, context) => {
  dispatch({ type: AddContextPending });
  const user = JSON.parse(localStorage.getItem("user"));

  const res = await ContextReq.addContext(user.token, context);
  if (res.ok) {
    dispatch({ type: AddContextSuccess, payload: res.context });
  } else {
    dispatch({ type: AddContextFailed, error: res.message });
  }
};
