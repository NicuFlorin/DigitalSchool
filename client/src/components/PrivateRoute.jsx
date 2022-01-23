import React from "react";
import { Route, Redirect } from "react-router-dom";
// import Navbar from "./Navbar";
import Main from "../components/Drawer/Main";
import { connect } from "react-redux";
import Drawer from "../components/Drawer/Drawer";

import DrawerHeader from "./Drawer/DrawerHeader";
import { Container } from "@mui/material";
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
      render={(props) =>
        rest.loggedIn ? (
          <Container sx={{ width: "80%" }}>
            {/* {rest.navbar && <Navbar path={rest.path} />} */}

            <Main open={rest.isOpen}>
              <DrawerHeader />
              <MyComponent {...props} />
            </Main>
          </Container>
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
