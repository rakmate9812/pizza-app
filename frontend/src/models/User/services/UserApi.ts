import User from "../User";
import bus from "@/services/eventBus";
import axios, { AxiosResponse } from "axios";

export default class UserApi {
  public static async login(user: User): Promise<string> {
    const data = JSON.stringify(user);
    const config = {
      method: "post",
      maxBodyLength: Infinity,
      url: "https://localhost:7172/auth/login",
      headers: {
        "Content-Type": "application/json",
      },
      data: data,
    };

    try {
      bus.$emit("start-loading");
      const response: AxiosResponse<string> = await axios.request(config);
      return response.data; // Will return the user's JWT
    } catch (error: any) {
      console.log(error);
      if (error.response.status === 404) throw new Error("User not found");
      if (error.response.status === 400) throw new Error("Wrong password");
      throw new Error("Something went wrong");
    } finally {
      bus.$emit("stop-loading");
    }
  }

  public static async register(user: User): Promise<string> {
    const data = JSON.stringify(user);
    const config = {
      method: "post",
      maxBodyLength: Infinity,
      url: "https://localhost:7172/auth/register",
      headers: {
        "Content-Type": "application/json",
      },
      data: data,
    };

    try {
      bus.$emit("start-loading");
      await axios.request(config);
      return "User created succesfully";
    } catch (error: any) {
      console.log(error);
      if (error.response.status === 400)
        throw new Error("Username already exists");
      throw new Error("Something went wrong");
    } finally {
      bus.$emit("stop-loading");
    }
  }
}
