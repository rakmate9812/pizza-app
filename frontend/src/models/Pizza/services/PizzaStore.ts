import PizzaApi from "./PizzaApi";
import Pizza from "../Pizza";

class PizzaStore {
  items: Pizza[] = []; // Better practice to store the desired items here in a list, because the store will only initialized once until the user refreshes the page

  async loadPizzas() {
    this.items = await PizzaApi.getAll();
  }

  async loadPizza(pizzaId: number) {
    return await PizzaApi.get(pizzaId); // If we need 1 item, that should be handled within the component it's used by
  }

  async createPizza(pizza: Pizza) {
    return await PizzaApi.create(pizza); // Will return the newly created pizza object
  }
}

const store = new PizzaStore();
export default store;
