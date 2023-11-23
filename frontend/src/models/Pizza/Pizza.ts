export default interface Pizza {
  id: number;
  name: string;
  description: string;
  imageData: string;
  recipeLink: string;
  timeCreated: Date;
  rating: number;
}

export const defaultPizza: Pizza = {
  id: 0,
  name: "",
  description: "",
  imageData: "",
  recipeLink: "",
  timeCreated: new Date(2000, 0, 1),
  rating: 3,
};
