import React from "react";
import { Route, Redirect } from "react-router-dom";
// import Navbar from "./Navbar";
import Main from "../components/Drawer/Main";
import { connect } from "react-redux";

import DrawerHeader from "./Drawer/DrawerHeader";
const mapStateToProps = (state) => {
  return {
    isOpen: state.openDrawer.isOpen,
  };
};
const PrivateRoute = (props) => {
  let { component: MyComponent, ...rest } = props;

  return (
    <Route
      {...rest}
      exact
      render={(props) =>
        rest.loggedIn ? (
          <div>
            {/* {rest.navbar && <Navbar path={rest.path} />} */}

            <Main open={rest.isOpen}>
              <DrawerHeader />
              <MyComponent {...props} />
            </Main>
          </div>
        ) : (
          <div>
            <Redirect
              to={{ pathname: "/login", state: { from: props.location } }}
            />
          </div>
        )
      }
    />
  );
};
export default connect(mapStateToProps)(PrivateRoute);
