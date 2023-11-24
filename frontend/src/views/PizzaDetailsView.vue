<template>
  <div class="pizza-details-container">
    <h1>Pizza Details</h1>
    <v-card class="pizza-card">
      <v-img class="pizza-image" :src="pizza.imageData" alt="a nice pizza">
        <v-icon class="zoom-icon" @click="openImage">mdi-magnify</v-icon></v-img
      >
      <v-card-text class="pizza-card-text">
        <h2>{{ pizza.name }}</h2>
        <p v-if="pizza.description.length > 0">{{ pizza.description }}</p>
        <p v-else><i>No description</i></p>
        <p>
          <strong>Recipe Link:</strong>
          <br />
          <a v-if="pizza.recipeLink.length > 0" :href="pizza.recipeLink">{{
            pizza.recipeLink
          }}</a>
          <span v-else><i>No link provided</i></span>
        </p>
        <p><strong>Rating:</strong> {{ pizza.rating }}/5</p>
      </v-card-text>
    </v-card>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Pizza, { defaultPizza } from "@/models/Pizza/Pizza";
import store from "@/models/Pizza/services/PizzaStore";

export default Vue.extend({
  data() {
    return {
      store: store,
      pizza: { ...defaultPizza } as Pizza,
    };
  },

  async beforeMount() {
    this.pizza = await this.store.loadPizza(+this.$route.params.pizzaId);
  },

  methods: {
    openImage() {
      const imgWindow = window.open("");
      if (imgWindow) {
        imgWindow.document.write(
          `<iframe width='100%' height='100%' src='${this.pizza.imageData}'></iframe>`
        );
      }
    },
  },
});
</script>

<style scoped>
h1 {
  margin-bottom: 20px;
  text-align: center;
}

.pizza-details-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  max-height: 100vh;
}

.pizza-card {
  display: flex;
  max-width: 50%;
}

.pizza-image {
  max-width: 50%;
}

.pizza-card-text {
  min-width: 50%;
  padding: 0 20px;
}

.pizza-card-text * {
  margin-bottom: 15px;
}

.pizza-card-text h2 {
  margin-top: 10px;
}

.zoom-icon {
  position: absolute;
  bottom: 10px;
  right: 10px;
  cursor: pointer;
  color: white;
}
</style>
