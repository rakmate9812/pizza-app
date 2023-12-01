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
    } catch (error) {
      console.log(error);
      if (axios.isAxiosError(error)) {
        throw new Error(error.response?.data);
      } else throw new Error("Something went wrong...");
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
    } catch (error) {
      console.log(error);
      if (axios.isAxiosError(error)) {
        throw new Error(error.response?.data);
      } else throw new Error("Something went wrong...");
    } finally {
      bus.$emit("stop-loading");
    }
  }
}
