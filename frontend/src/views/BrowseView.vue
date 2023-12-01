<template>
  <div>
    <loading-spinner ref="loadingSpinner"></loading-spinner>
    <v-row class="search-row">
      <v-text-field
        ref="searchInput"
        v-model="searchText"
        class="search-bar"
        label="Find Your Favorite Pizza"
        solo
        append-icon="mdi-magnify"
        @click:append="loadData"
        @keyup.enter="loadData"></v-text-field>
    </v-row>

    <v-row v-if="message !== null" class="search-row">
      {{ message }}
    </v-row>

    <div v-else>
      <v-pagination
        v-model="currentPage"
        :length="numPages"
        total-visible="7"
        class="pagination"></v-pagination>

      <v-row>
        <v-col
          v-for="(item, index) in store.pageItems"
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
                <v-img
                  :src="item.imageData"
                  height="200"
                  loading="lazy"></v-img>
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
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import store from "@/models/Pizza/services/PizzaStore";
import LoadingSpinner from "@/components/LoadingSpinner.vue";
import Pizza from "@/models/Pizza/Pizza";
import dayjs from "dayjs";

export default Vue.extend({
  components: { LoadingSpinner },

  data() {
    return {
      store: store,
      searchText: null as string | null,
      itemsPerPage: 4,
      currentPage: 1,
      message: null as string | null,
    };
  },

  async mounted() {
    await this.loadData();
  },

  computed: {
    numPages(): number {
      return Math.ceil(this.store.totalNumOfPizzas / this.itemsPerPage);
    },
  },

  methods: {
    async loadData() {
      try {
        await this.store.loadPizzasBySearchTextPaginated(
          this.searchText,
          this.currentPage
        );
        this.message = null;
      } catch (error) {
        this.message = (error as any).message;
      } finally {
        (this.$refs.searchInput as any).blur();
      }
    },

    async searchAndPaginate() {
      this.currentPage = 1; // Just updating the current page; the watcher will handle the data loading
    },

    handleItemClick(item: Pizza) {
      this.$router.push(`${item.id}`);
    },

    convertDate(date: Date): string {
      return dayjs(date).format("YYYY-MM-DD");
    },
  },

  watch: {
    currentPage: "loadData", // Watch for changes in currentPage and load data accordingly
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
