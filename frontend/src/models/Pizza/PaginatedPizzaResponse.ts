import Pizza from "./Pizza";

export default interface PaginatedPizzaResponse {
  items: Pizza[]; // The items are only from the current page
  total: number;
}
