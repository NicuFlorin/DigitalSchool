import { Button, Typography } from "@mui/material";
import ArrowRightIcon from "@mui/icons-material/ArrowRight";
import ArrowDropDownIcon from "@mui/icons-material/ArrowDropDown";
import React, { useState } from "react";
import Users from "../../components/Administration/Users";
import { connect } from "react-redux";
import UserFilter from "../../components/Administration/UserFilter";
import { useHistory } from "react-router-dom";
const mapStateToProps = (state) => {
  return { filterUsers: state.filterUsers };
};
const UserList = (props) => {
  const [showNewFilters, setShowNewFilters] = useState(false);
  const [showActiveFilters, setShowActiveFilters] = useState(true);
  const { filter } = props.filterUsers;
  const history = useHistory();
  return (
    <div>
      lala
      <div style={{ display: "flex" }}>
        <Typography component="a" variant="h3">
          Filters
        </Typography>
        {showNewFilters ? <ArrowDropDownIcon /> : <ArrowRightIcon />}
        {showNewFilters && <UserFilter />}
      </div>
      <div style={{ display: "flex" }}>
        <Typography component="a" variant="h3">
          Active Filters
        </Typography>
      </div>
      <Users />
      <Button variant="contained" onClick={() => history.push("/add-user")}>
        Add new user
      </Button>
    </div>
  );
};

export default connect(mapStateToProps)(UserList);
