import SignIn from "./pages/Authentication/SignIn";
import Register from "./pages/Authentication/Register.js";
import Homepage from "./pages/Homepage";
import AdministrationPage from "./pages/Site Administration/AdministrationPage";
import UsersList from "./pages/Site Administration/UsersList";
import AddUserPage from "./pages/Site Administration/AddUserPage";
import CohortPage from "./pages/Site Administration/CohortPage";
import AssignPage from "./pages/Site Administration/AssignPage";
import CourseManagerPage from "./pages/Site Administration/CourseManagerPage";
import AddCategoryPage from "./pages/Site Administration/AddCategoryPage";
import AddCoursePage from "./pages/Site Administration/AddCoursePage";
import CoursePage from "./pages/CoursePage";
import EditActivityPage from "./pages/EditActivityPage";
import ActivityPage from "./pages/ActivityPage";

var routes = [
  {
    path: "/login",
    component: SignIn,
    private: false,
    exact: true,
  },
  {
    path: "/register",
    component: Register,
    private: false,
    exact: true,
  },
  {
    path: "/",
    component: Homepage,
    private: true,
    exact: true,
  },
  {
    path: "/users-list",
    component: UsersList,
    exact: true,
    private: true,
  },
  {
    path: "/add-user",
    component: AddUserPage,
    exact: true,
    private: true,
  },
  {
    path: "/cohorts",
    component: CohortPage,
    exact: true,
    private: true,
  },
  {
    path: "/assign/:id_cohort",
    component: AssignPage,
    exact: true,
    private: true,
  },
  {
    path: "/course-manager",
    component: CourseManagerPage,
    exact: true,
    private: true,
  },
  {
    path: "/add-category",
    component: AddCategoryPage,
    exact: true,
    private: true,
  },
  {
    path: "/add-course",
    component: AddCoursePage,
    exact: true,
    private: true,
  },
  {
    path: "/course/activity-view",
    component: ActivityPage,
    exact: true,
    private: true,
  },
  {
    path: "/course/:id_course",
    component: CoursePage,
    exact: true,
    private: true,
  },

  {
    path: "/course/edit-activity/:id_course/:activity_type",
    component: EditActivityPage,
    exact: true,
    private: true,
  },

  {
    path: "/administration",
    component: AdministrationPage,
    exact: false,
    private: true,
  },
];
export default routes;
