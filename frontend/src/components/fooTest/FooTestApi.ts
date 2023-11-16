import axios, { AxiosError } from "axios";

export default class FooTestApi {
  static async send(): Promise<void> {
    try {
      const response = await axios.get("https://localhost:7172/test/test");
      console.log(response.data.message);
    } catch (error) {
      console.error(error);
    }
  }
}
