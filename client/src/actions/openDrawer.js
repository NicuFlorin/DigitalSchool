import { OpenDrawer, CloseDrawer} from "../constants";
export const openDrawer = () => {
  return {
    type: OpenDrawer,
  };
};

export const closeDrawer = () => {
  return {
    type: CloseDrawer,
  };
};
