import PizzaApi from "./PizzaApi";
import Pizza from "../Pizza";

class PizzaStore {
  pageItems: Pizza[] = []; // Better practice to store the desired items here in a list, because the store will only initialized once until the user refreshes the page
  totalNumOfPizzas = 0;

  /**Loads all pizzas to the {items} list in the store  */
  async loadPizzas() {
    this.pageItems = await PizzaApi.getAll();
  }

  /**Gets only the pizzas which contains the searchtext as it's name or description, loads them into the {items} list in the store  */
  async loadPizzasBySearchTextPaginated(
    searchText: string | null,
    pageNum: number
  ) {
    const ret = await PizzaApi.getPaginatedWithSearchText(searchText, pageNum);
    this.pageItems = ret.items;
    this.totalNumOfPizzas = ret.total;
  }

  /**Returns a pizza by ID */
  async loadPizza(pizzaId: number) {
    return await PizzaApi.get(pizzaId); // If we need 1 item, that should be handled within the component it's used by
  }

  /**Creates and returns a pizza with the given parameters, auth needed */
  async createPizza(pizza: Pizza, token: string) {
    return await PizzaApi.create(pizza, token); // Will return the newly created pizza object
  }
}

const store = new PizzaStore();
export default store;
