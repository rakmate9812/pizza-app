export default interface User {
  id: number;
  username: string;
  password: string;
}

export const defaultUser: User = {
  id: 0,
  username: "",
  password: "",
};
