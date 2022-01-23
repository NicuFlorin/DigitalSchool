import SignIn from "./pages/Authentication/SignIn";
import routes from "./routes";
import { connect } from "react-redux";
import { BrowserRouter as Router, Switch } from "react-router-dom";
import { useSelector } from "react-redux";
import { useState, useEffect } from "react";
import PrivateRoute from "./components/PrivateRoute";
import { getCurrentUser } from "./_actions/loginActions";
import { Box } from "@mui/system";
import { CssBaseline } from "@mui/material";
import Drawer from "./components/Drawer/Drawer";

import Navbar from "./components/Navbar";
const mapStateToProps = (state) => {
  return {
    loggedIn: state.signInReducer.loggedIn,
    currentUser: state.signInReducer.currentUser,
    isPending: state.signInReducer.isPending,
    error: state.signInReducer.error,
  };
};
const mapDispatchToProps = (dispatch) => {
  return {
    onRequestCurrentUser: () => getCurrentUser(dispatch),
  };
};

function App(props) {
  const { loggedIn } = props;

  useEffect(() => {
    props.onRequestCurrentUser();
  }, []);

  return (
    <Box sx={{ display: "flex" }}>
      <CssBaseline />

      <Router>
        {loggedIn && <Navbar />}
        {loggedIn && <Drawer />}
        <Switch>
          {routes.map((route, index) => {
            return (
              <PrivateRoute
                key={index}
                path={route.path}
                exact={route.exact}
                // navbar={route.navbar}
                component={route.component}
                loggedIn={route.private ? loggedIn : true}
              />
            );
          })}
        </Switch>
      </Router>
    </Box>
  );
}

export default connect(mapStateToProps, mapDispatchToProps)(App);
