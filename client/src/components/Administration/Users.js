import React, { useEffect } from "react";
import { connect } from "react-redux";
import { getUsers } from "../../_actions/userActions";
import { styled } from "@mui/material/styles";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import { Pagination } from "@mui/material";

const mapStateToProps = (state) => {
  return {
    users: state.usersReducer.users,
    isPending: state.usersReducer.isPending,
    error: state.usersReducer.error,
  };
};
const mapDispatchToProps = (dispatch) => {
  return {
    GetUsers: (token) => getUsers(dispatch, token),
  };
};
const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  "&:nth-of-type(odd)": {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}));

const Users = (props) => {
  const { users, GetUsers } = props;
  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("user"));
    
    GetUsers(user.token);
  }, []);

  return (
    <div>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 700 }} aria-label="customized table">
          <TableHead>
            <TableRow>
              <StyledTableCell>First name</StyledTableCell>
              <StyledTableCell align="center">Last name</StyledTableCell>
              <StyledTableCell align="center">Email adress</StyledTableCell>
              <StyledTableCell align="center">Last Access</StyledTableCell>
              <StyledTableCell align="center" colSpan={2}>
                Edit
              </StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {users &&
              users.map((user, index) => (
                <StyledTableRow key={index}>
                  <StyledTableCell component="th" scope="row">
                    {user.firstName}
                  </StyledTableCell>
                  <StyledTableCell align="right">
                    {user.lastName}
                  </StyledTableCell>
                  <StyledTableCell align="right">
                    {user.username}
                  </StyledTableCell>
                  <StyledTableCell align="right">{"Never"}</StyledTableCell>
                  <StyledTableCell align="right">
                    <EditIcon />
                  </StyledTableCell>
                  <StyledTableCell align="right">
                    <DeleteIcon />
                  </StyledTableCell>
                </StyledTableRow>
              ))}
          </TableBody>
        </Table>
      </TableContainer>
      <Pagination count={10}/>
    </div>
  );
};

export default connect(mapStateToProps, mapDispatchToProps)(Users);
