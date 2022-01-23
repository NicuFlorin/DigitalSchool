import axios from "./Axios";
import { getRequestError } from "./Axios";

const getUsers = async (token) => {
  try {
    const res = await axios.get("/users", {
      headers: { Authorization: "Bearer " + token },
    });

    return { ok: true, users: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};

const addUser = async (user, token) => {
  try {
    const res = await axios.post("/users/add-user", user, {
      headers: {
        Authorization: "Bearer " + token,
      },
    });
    return { ok: true, user: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};
const UsersRequests = { getUsers, addUser };
export default UsersRequests;
