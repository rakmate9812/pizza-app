<template>
  <v-container>
    <v-row class="search-row">
      <v-text-field
        v-model="searchText"
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
              <v-img :src="item.imageData" height="200" loading="lazy"></v-img>
              <v-card-title class="pizza-name">{{ item.name }}</v-card-title>
              <v-card-text
                v-if="item.description.length > 0"
                class="pizza-description"
                >{{ item.description }}</v-card-text
              >
              <v-card-text v-else class="pizza-description">
                <i>No description</i>
                <br />
              </v-card-text>
              <v-card-subtitle
                >Upload Date:
                {{ convertDate(item.timeCreated) }}</v-card-subtitle
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
import dayjs from "dayjs";

export default Vue.extend({
  data() {
    return {
      store: store,
      searchText: null as string | null, // TODO
      itemsPerPage: 4,
      currentPage: 1,
    };
  },

  async beforeMount() {
    await this.store.loadPizzas();
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
      this.$router.push(`${item.id}`);
    },

    convertDate(date: Date): string {
      return dayjs(date).format("YYYY-MM-DD");
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
  max-width: 25rem;
}

.pizza-card {
  height: 22rem;
}

.pizza-name {
  max-height: 3rem;
  overflow: hidden;
  text-overflow: ellipsis;
}

.pizza-description {
  height: 3rem;
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
