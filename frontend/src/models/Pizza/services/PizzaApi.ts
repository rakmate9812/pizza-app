import axios, { AxiosRequestConfig, AxiosResponse } from "axios";
import bus from "@/services/eventBus";
import Pizza from "../Pizza";

export default class PizzaApi {
  public static async getAll(): Promise<Pizza[]> {
    const config: AxiosRequestConfig = {
      method: "get",
      maxBodyLength: Infinity,
      url: "https://localhost:7172/pizza/all",
      headers: {},
    };

    try {
      bus.$emit("start-loading");
      const response: AxiosResponse<Pizza[]> = await axios.request(config);
      return response.data;
    } catch (error: any) {
      console.log(error);
      throw new Error("Something went wrong...");
    } finally {
      bus.$emit("stop-loading");
    }
  }

  public static async get(pizzaId: number): Promise<Pizza> {
    const config: AxiosRequestConfig = {
      method: "get",
      maxBodyLength: Infinity,
      url: `https://localhost:7172/pizza/${pizzaId}`,
      headers: {},
    };

    try {
      const response: AxiosResponse<Pizza> = await axios.request(config);
      return response.data;
    } catch (error: any) {
      console.log(error);
      throw new Error("Something went wrong...");
    }
  }

  public static async create(pizza: Pizza, token: string): Promise<Pizza> {
    const data = JSON.stringify(pizza);
    const config = {
      method: "post",
      maxBodyLength: Infinity,
      url: "https://localhost:7172/pizza/create",
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      },
      data: data,
    };

    try {
      bus.$emit("start-loading");
      const response: AxiosResponse<Pizza> = await axios.request(config);
      return response.data;
    } catch (error: any) {
      if (error.response.status === 401) {
        throw new Error("Unauthorized access!");
      }
      throw new Error("Something went wrong...");
    } finally {
      bus.$emit("stop-loading");
    }
  }
}
