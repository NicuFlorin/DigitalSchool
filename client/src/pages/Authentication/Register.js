import {
  Container,
  CssBaseline,
  Box,
  Typography,
  TextField,
  Button,
  Link,
} from "@mui/material";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import { maxWidth } from "@mui/system";
import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { connect } from "react-redux";
import { register } from "../../actions/loginActions";

const theme = createTheme();
const mapStateToProps = (state) => {
  return {
    isPending: state.signInReducer.isPending,
    error: state.signInReducer.error,
  };
};
const mapDispatchToProps = (dispatch) => {
  return {
    onRegister: (user) => register(dispatch, user),
  };
};
const Register = (props) => {
  const history = useHistory();
  const [updateRoute, setUpdateRoute] = useState(false);
  const { isPending, error, onRegister } = props;
  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    
    const user = {
      username: data.get("email"),
      password: data.get("password"),
      firstName: data.get("firstName"),
      lastName: data.get("lastName"),
    };
    if (
      user.username.trim().length === 0 ||
      user.password.trim().length === 0 ||
      user.firstName.length === 0 ||
      user.lastName.length === 0 ||
      user.password.length < 6
    ) {
      alert("nu e bine");
    } else {
      props.onRegister(user);
      setUpdateRoute(true);
    }
  };
  useEffect(() => {
    if (!isPending && !error && updateRoute) {
      history.push("/login");
    }
  });
  return (
    <ThemeProvider theme={theme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Typography component="h2" variant="h5">
            Sign Up
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit}
            noValidate
            sx={{ mt: 1 }}
          >
            <TextField
              margin="normal"
              required
              label="First Name"
              name="firstName"
              autoFocus
              fullWidth
            />
            <TextField
              margin="normal"
              required
              label="Last Name"
              name="lastName"
              autoFocus
              fullWidth
            />

            <TextField
              margin="normal"
              required
              id="email"
              label="Email"
              name="email"
              autoComplete="email"
              autoFocus
              fullWidth
            />
            <TextField
              margin="normal"
              required
              id="password"
              label="Password"
              name="password"
              type="password"
              autoFocus
              fullWidth
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign Up
            </Button>
          </Box>
          <Link
            href="#"
            variant="body2"
            onClick={() => {
              history.push("/login");
            }}
          >
            Already have an account?(Login)
          </Link>
        </Box>
      </Container>
    </ThemeProvider>
  );
};

export default connect(mapStateToProps, mapDispatchToProps)(Register);
