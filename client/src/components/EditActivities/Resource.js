import React from "react";
import folder from "../../icons/folder.png";
import { Link } from "react-router-dom";
const Resource = (props) => {
  return (
    <div style={{ display: "flex" }}>
      {props.upload.discriminator == "Resource" && (
        <img
          src={folder}
          style={{ width: "20px", height: "20px", marginRight: 5 }}
        ></img>
      )}
      <Link
        to={`/course/activity-view?r_type=${props.upload.discriminator}&id_upload=${props.upload.id}&c_id=${props.upload.courseId}`}
      >
        {props.upload.name}
      </Link>
    </div>
  );
};
export default Resource;
