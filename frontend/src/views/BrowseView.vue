<template>
  <v-container>
    <v-row class="search-row">
      <!-- v-model="searchTerm" -->
      <v-text-field
        class="search-bar"
        label="Find Your Favorite Pizza"
        solo
        append-icon="mdi-magnify"
        @click:append="handleSearch"
        @keyup.enter="handleSearch"></v-text-field>
    </v-row>
    <v-pagination
      v-model="currentPage"
      :length="numPages"
      total-visible="7"
      class="pagination"></v-pagination>
    <v-row>
      <v-col
        v-for="(item, index) in paginatedItems"
        :key="index"
        cols="12"
        md="6"
        lg="3">
        <v-hover>
          <template v-slot="{ hover }">
            <v-card
              @click="handleItemClick(item)"
              class="pizza-card"
              :class="{ 'card-hover': hover }">
              <!-- <v-img :src="TODO" height="200" loading="lazy"></v-img> -->
              <v-card-title class="pizza-name">{{ item.name }}</v-card-title>
              <v-card-text class="pizza-description">{{
                item.description
              }}</v-card-text>
              <v-card-subtitle
                >Upload Date: {{ item.timeCreated }}</v-card-subtitle
              >
            </v-card>
          </template>
        </v-hover>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import store from "@/models/Pizza/services/PizzaStore";
import Pizza from "@/models/Pizza/Pizza";

export default Vue.extend({
  data() {
    return {
      store: store,
      itemsPerPage: 4,
      currentPage: 1,
    };
  },

  beforeMount() {
    this.store.loadPizzas();
  },

  computed: {
    numPages(): number {
      return Math.ceil(this.store.items.length / this.itemsPerPage);
    },

    paginatedItems(): Pizza[] {
      const startIndex = (this.currentPage - 1) * this.itemsPerPage;
      const endIndex = startIndex + this.itemsPerPage;
      return this.store.items.slice(startIndex, endIndex);
    },
  },

  methods: {
    handleSearch() {
      console.log("search"); //TODO
    },

    handleItemClick(item: Pizza) {
      console.log(item); //TODO
    },
  },
});
</script>

<style scoped>
.search-row {
  display: flex;
  justify-content: center;
  margin: 25px;
}

.search-bar {
  max-width: 500px;
}

.pizza-card {
  max-height: 400;
}

.pizza-name {
  max-height: 50px;
  overflow: hidden;
  text-overflow: ellipsis;
}

.pizza-description {
  max-height: 45px;
  overflow: hidden;
  text-overflow: ellipsis;
}

.pagination {
  margin: 15px;
}

::v-deep .primary {
  color: red !important;
}

.card-hover {
  transform: scale(1.05);
  cursor: pointer;
  transition: transform 0.3s ease;
}
</style>
