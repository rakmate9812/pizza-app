import Pizza, { defaultPizza } from "../Pizza";

class PizzaStore {
  items: Pizza[] = [];

  loadPizzas() {
    this.items = [
      {
        ...defaultPizza,
        name: "Delicious Margherita",
        description:
          "A classic Margherita pizza with fresh mozzarella, tomatoes, and basil. Perfectly baked to perfection.",
      },
      {
        ...defaultPizza,
        name: "Pepperoni Paradise",
        description:
          "Savory pepperoni slices on a bed of melted cheese, creating a mouthwatering experience with every bite.",
      },
      {
        ...defaultPizza,
        name: "Vegetarian Delight",
        description:
          "An assortment of fresh vegetables including bell peppers, mushrooms, and olives, creating a colorful and tasty pizza masterpiece.",
      },
      {
        ...defaultPizza,
        name: "BBQ Chicken Feast",
        description:
          "Tender chunks of barbecue chicken with red onions and a drizzle of barbecue sauce, delivering a sweet and savory flavor explosion.",
      },
      {
        ...defaultPizza,
        name: "Supreme Delicacy",
        description:
          "The ultimate pizza experience with a combination of pepperoni, sausage, bell peppers, olives, and mushrooms. Every bite is a flavor journey.",
      },
      {
        ...defaultPizza,
        name: "Hawaiian Bliss",
        description:
          "A tropical delight featuring ham, pineapple, and melted cheese. Close your eyes, take a bite, and imagine you're on a Hawaiian beach.",
      },
      {
        ...defaultPizza,
        name: "Mushroom Medley",
        description:
          "A delightful combination of various mushrooms, sautéed to perfection and generously spread over a golden crust.",
      },
    ];
  }
}

const store = new PizzaStore();
export default store;
