import MyFolder from "./Folder";

type User = {
  name: string;
  email: string;
  folders: MyFolder[];
};

export default User;