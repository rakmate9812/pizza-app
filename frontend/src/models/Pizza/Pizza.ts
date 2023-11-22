export default interface Pizza {
  id: number;
  name: string;
  description: string | null;
  imageData: Uint8Array | null;
  recipeLink: string | null;
  timeCreated: Date;
  rating: number;
}

export const defaultPizza: Pizza = {
  id: 0,
  name: "",
  description: null,
  imageData: null,
  recipeLink: null,
  timeCreated: new Date(2000, 0, 1),
  rating: 0,
};
