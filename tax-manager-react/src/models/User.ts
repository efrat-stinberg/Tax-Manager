import MyFolder from "./Folder";

type User = {
  userId: number;
  username: string;
  email: string;
  folders: MyFolder[];
};

export default User;