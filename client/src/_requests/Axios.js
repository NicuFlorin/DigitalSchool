import axios from "axios";

const axiosInstance = axios.create({
  withCredentials: true,

  baseURL: "https://localhost:5001/api",
});

axiosInstance.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (error.response) {
      if (
        error.response.status === 403 &&
        error.response.config.url !== "/login" &&
        window.location.pathname !== "/login"
      ) {
        let url = window.location.pathname;
        window.history.pushState({ previousUrl: url });
        window.location.reload();
      } else {
        console.log(error);
      }
    }
    return Promise.reject(error);
  }
);

const getRequestError = (err) => {
  if (!err.response) {
    return { ok: false, message: err.message };
  } else if (err.response.data.message) {
    return { ok: false, message: err.response.data.message };
  } else {
    return {
      ok: false,
      message: `Internal server error: ${err.response.status}`,
    };
  }
};

export default axiosInstance;
export { getRequestError };
