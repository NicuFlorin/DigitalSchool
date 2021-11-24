import SignIn from "./pages/Authentication/SignIn";
import Register from "./pages/Authentication/Register.js"
import Homepage from "./pages/Homepage";

var routes = [
  {
    path: "/login",
    component: SignIn,
    private: false,
  },
  {
    path: "/register",
    component: Register,
    private: false,
  },
  {
    path: "/",
    component: Homepage,
    private: true,
  },
];
export default routes;
