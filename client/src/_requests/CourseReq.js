import axios from "./Axios";
import { getRequestError } from "./Axios";

export const addCourse = async (course, token) => {
  try {
    await axios.post("/course", course, {
      headers: {
        Authorization: "Bearer " + token,
      },
    });

    return { ok: true };
  } catch (err) {
    return getRequestError(err);
  }
};

export const getCourses = async (id_category, token) => {
  try {
    const res = await axios.get("/course/" + id_category, {
      headers: {
        Authorization: "Bearer " + token,
      },
    });
    return { ok: true, courses: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};

export const getAll = async (token) => {
  try {
    const res = await axios.get("/course/get-all", {
      headers: {
        Authorization: "Bearer " + token,
      },
    });
    return { ok: true, courses: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};
export const getByID = async (token, id_course) => {
  try {
    const res = await axios.get("/course/get-by-id/" + id_course, {
      headers: {
        Authorization: "Bearer " + token,
      },
    });
    return { ok: true, course: res.data };
  } catch (err) {
    return getRequestError(err);
  }
};


