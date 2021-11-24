import React from "react";
import { connect } from "react-redux";
import { signOut } from "../actions/loginActions";
import { useHistory } from "react-router-dom";
import { Container, Paper, Typography } from "@mui/material";
import { Box } from "@mui/system";
import Header from "../components/Homepage/Header";
import MainSection from "../components/Homepage/MainSection";
const mapStateToProps = (state) => {
  return {
    loggedIn: state.signInReducer.loggedIn,
  };
};

const mapDispatchToProps = (dispatch) => {
  return { onSignOut: () => dispatch(signOut()) };
};
const Homepage = (props) => {
  const history = useHistory();

  const { onSignOut } = props;
  const signOut = () => {
    if (localStorage.getItem("user")) {
      localStorage.removeItem("user");
    }
    onSignOut();
    history.push("/login");
  };
  return (
    <div style={{ marginTop: 10 }}>
      <Container component="main" maxWidth="lg">
        <Header />
        <div style={{ marginTop: 50 }}></div>
        <MainSection style={{ marginTop: "50px" }} />
      </Container>
    </div>
  );
};
export default connect(mapStateToProps, mapDispatchToProps)(Homepage);
