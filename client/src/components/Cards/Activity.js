import * as React from "react";
import Box from "@mui/material/Box";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import StarBorderIcon from "@mui/icons-material/StarBorder";
import { useHistory } from "react-router-dom";

const bull = (
  <Box
    component="span"
    sx={{ display: "inline-block", mx: "2px", transform: "scale(0.8)" }}
  >
    •
  </Box>
);

const MyCard = (props) => {
  const { icon, title } = props;
  const history = useHistory();
  return (
    <React.Fragment>
      <CardContent sx={{ borderBottom: "1px outset" }}>
        <div
          style={{
            margin: "0 auto",
            justifyContent: "center",
            display: "flex",
          }}
          onClick={() => {
            history.push(
              `/course/edit-activity/${
                props.match.params.id_course
              }/${title}?sectionId=${props.sectionId ? props.sectionId : 0}`
            );
          }}
        >
          {icon}
        </div>
        <Typography
          variant="h6"
          component="div"
          sx={{ margin: "0 auto", textAlign: "center" }}
        >
          {title}
        </Typography>
      </CardContent>
      <CardActions>
        <StarBorderIcon sx={{ margin: "0 auto" }} />
      </CardActions>
    </React.Fragment>
  );
};

export default function Activity(props) {
  return (
    <Box sx={{ minWidth: 140, margin: 3 }}>
      <Card variant="outlined">
        <MyCard {...props} />
      </Card>
    </Box>
  );
}
