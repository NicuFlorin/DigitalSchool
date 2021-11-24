import axios from "./Axios";
import { getRequestError } from "./Axios";

const login = async (creds) => {
  try {
    const res = await axios.post("/account/login", creds);
    return { ok: true, user: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};

const register = async (user) => {
  try {
    const res = await axios.post("/account/register", user);
    return { ok: true };
  } catch (err) {
    return getRequestError(err);
  }
};

const getCurrentUser = async (token, id) => {
  if (!token) {
    return { loggedIn: false };
  }
  try {
    const res = await axios.get(`/users/${id}`, {
      headers: { Authorization: "Bearer " + token },
    });
    return { ok: true, user: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};

const AuthRequests = { login, getCurrentUser, register };

export default AuthRequests;
