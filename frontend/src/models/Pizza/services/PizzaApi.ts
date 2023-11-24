import axios, { AxiosRequestConfig, AxiosResponse } from "axios";
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
      const response: AxiosResponse<Pizza[]> = await axios.request(config);
      return response.data;
    } catch (error) {
      console.log(error);
      throw new Error("Something went wrong...");
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
    } catch (error) {
      console.log(error);
      throw new Error("Something went wrong...");
    }
  }

  public static async create(pizza: Pizza): Promise<Pizza> {
    const data = JSON.stringify(pizza);
    const config = {
      method: "post",
      maxBodyLength: Infinity,
      url: "https://localhost:7172/pizza/create",
      headers: {
        "Content-Type": "application/json",
        // Authorization:
        //   "Bearer tokenWillBeHere", //TODO
      },
      data: data,
    };

    try {
      const response: AxiosResponse<Pizza> = await axios.request(config);
      return response.data;
    } catch (error) {
      console.log(error);
      throw new Error("Something went wrong...");
    }
  }
}
