import UsersList from "./pages/Site Administration/UsersList";
export const adminRoutes = {
  dashboard: [
    {
      id: "Users",
      settings: [
        {
          id: "Accounts",
          list: [
            { label: "Browse list of users", path: "users-list" },
            { label: "Add a new user", path: "add-user" },
            { label: "Cohorts", path: "cohorts" },
            { label: "Upload users", path: "upload-users" },
          ],
        },
      ],
    },
    {
      id: "Courses",
      settings: [
        {
          id: "Courses",
          list: [
            { label: "Manage courses and categories", path: "course-manager" },
            { label: "Course custom fields", path: "/" },
            { label: "Add a category", path: "add-category" },
            { label: "Add a course", path: "add-course" },
            { label: "Restore course", path: "/" },
            { label: "Upload courses", path: "/" },
          ],
        },
      ],
    },
    {
      id: "Grades",
      settings: [
        {
          id: "Grades",
          list: [
            { label: "General settings", path: "/" },
            { label: "Grade category settings", path: "/" },
            { label: "Scales", path: "/" },
            { label: "Letters", path: "/" },
            { label: "Grade item settings", path: "/" },
          ],
        },
        {
          id: "Report",
          list: [
            { label: "Grader report", path: "/" },
            { label: "Grade history", path: "/" },
            { label: "User report", path: "/" },
          ],
        },
      ],
    },
  ],
  pages: [
    
  ],
};
