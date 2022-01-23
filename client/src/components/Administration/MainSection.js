import { Typography } from "@mui/material";
import React from "react";
import { adminRoutes } from "../../adminRoutes";
import {
  useRouteMatch,
  Link,
  useHistory,
  Route,
  useParams,
} from "react-router-dom";
import Button from "@mui/material/Button";
import ButtonGroup from "@mui/material/ButtonGroup";

const Option = (props) => {
  const param = useParams();
  const history = useHistory();
  const { url, path } = useRouteMatch();
  const option = props.options.find((option) => {
    return option.id === param.optionId;
  });
  return (
    <div>
      {option.settings.map((setting) => {
        return (
          <div key={setting.id} style={{ display: "flex", paddingTop: 20 }}>
            {setting.id}
            <br />
            <div
              style={{
                display: "flex",
                flexDirection: "column",
                paddingLeft: 40,
              }}
            >
              {setting.list.map((item, i) => (
                <a
                  href="#"
                  onClick={() => history.push(`../${item.path}`)}
                  key={i}
                >
                  {item.label}
                </a>
              ))}
            </div>
          </div>
        );
      })}
    </div>
  );
};

const MainSection = (props) => {
  const { path, url } = useRouteMatch();
  const history = useHistory();
  const adminOptions = adminRoutes.dashboard;

  return (
    <div>
      <Typography variant="h4" gutterBottom component="div">
        Site administration
      </Typography>
      <ButtonGroup
        variant="contained"
        aria-label="outlined primary button group"
      >
        {adminOptions.map((option) => {
          return (
            <Button
              id={option.id}
              onClick={() => {
                history.push(`${url}/${option.id}`);
              }}
            >
              {option.id}
            </Button>
          );
        })}
      </ButtonGroup>
      <Route path={`${path}/:optionId`}>
        <Option options={adminOptions} />
      </Route>
    </div>
  );
};
export default MainSection;
