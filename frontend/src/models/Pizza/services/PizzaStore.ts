import PizzaApi from "./PizzaApi";
import Pizza from "../Pizza";

class PizzaStore {
  items: Pizza[] = [];

  async loadPizzas() {
    this.items = await PizzaApi.getAll();
  }

  async createPizza(pizza: Pizza) {
    return await PizzaApi.create(pizza);
  }
}

const store = new PizzaStore();
export default store;
