import User from "../User";
import UserApi from "./UserApi";

class UserStore {
  /**Returns the JWT token for the user */
  async loginUser(user: User): Promise<string> {
    return await UserApi.login(user); // JWT will be returned
  }

  /** Returns a message of the result of the creation process*/
  async registerUser(user: User): Promise<string> {
    return await UserApi.register(user);
  }
}

const store = new UserStore();
export default store;
