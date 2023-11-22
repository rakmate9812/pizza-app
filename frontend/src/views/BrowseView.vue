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
              <v-img :src="item.image" height="200" loading="lazy"></v-img>
              <v-card-title class="pizza-name">{{ item.name }}</v-card-title>
              <v-card-text class="pizza-description">{{
                item.description
              }}</v-card-text>
              <v-card-subtitle
                >Upload Date: {{ item.uploadDate }}</v-card-subtitle
              >
            </v-card>
          </template>
        </v-hover>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
export default {
  data() {
    return {
      items: [
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Delicious Margherita",
          description:
            "A classic Margherita pizza with fresh mozzarella, tomatoes, and basil. Perfectly baked to perfection.",
          uploadDate: "2022-05-15",
        },
        {
          image:
            "https://images.unsplash.com/photo-1588315029754-2dd089d39a1a?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Pepperoni Paradise",
          description:
            "Savory pepperoni slices on a bed of melted cheese, creating a mouthwatering experience with every bite.",
          uploadDate: "2022-06-20",
        },
        {
          image:
            "https://images.unsplash.com/photo-1541745537411-b8046dc6d66c?q=80&w=1888&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Vegetarian Delight",
          description:
            "An assortment of fresh vegetables including bell peppers, mushrooms, and olives, creating a colorful and tasty pizza masterpiece.",
          uploadDate: "2022-07-10",
        },
        {
          image:
            "https://images.unsplash.com/photo-1613564834361-9436948817d1?q=80&w=1943&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "BBQ Chicken Feast",
          description:
            "Tender chunks of barbecue chicken with red onions and a drizzle of barbecue sauce, delivering a sweet and savory flavor explosion.",
          uploadDate: "2022-08-05",
        },
        {
          image:
            "https://plus.unsplash.com/premium_photo-1680303989900-b4b002b520c5?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Supreme Delicacy",
          description:
            "The ultimate pizza experience with a combination of pepperoni, sausage, bell peppers, olives, and mushrooms. Every bite is a flavor journey.",
          uploadDate: "2022-09-18",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Hawaiian Bliss",
          description:
            "A tropical delight featuring ham, pineapple, and melted cheese. Close your eyes, take a bite, and imagine you're on a Hawaiian beach.",
          uploadDate: "2022-10-03",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Mushroom Medley",
          description:
            "A delightful combination of various mushrooms, sautéed to perfection and generously spread over a golden crust.",
          uploadDate: "2022-11-12",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Spinach and Feta Delight",
          description:
            "A healthy and flavorful option featuring fresh spinach, feta cheese, and a hint of garlic. It's a taste sensation.",
          uploadDate: "2022-12-01",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Meat Lovers' Paradise",
          description:
            "For those who can't get enough meat, this pizza features a hearty combination of sausage, bacon, pepperoni, and ground beef.",
          uploadDate: "2023-01-01",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Buffalo Chicken Kick",
          description:
            "Spicy buffalo chicken, blue cheese crumbles, and a drizzle of ranch dressing create a pizza with a kick. Are you up for the challenge?",
          uploadDate: "2023-02-14",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Truffle Indulgence",
          description:
            "Indulge in the rich and earthy flavors of truffle oil, paired with mushrooms and a blend of gourmet cheeses. A truly luxurious pizza experience.",
          uploadDate: "2023-03-20",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Caprese Perfection",
          description:
            "Fresh tomatoes, mozzarella, and basil come together in a delightful tribute to the classic Caprese salad, now in pizza form.",
          uploadDate: "2023-04-10",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Pesto Passion",
          description:
            "Experience the bold flavors of pesto sauce, sun-dried tomatoes, and pine nuts on a crispy pizza crust. It's a pesto lover's dream.",
          uploadDate: "2023-05-25",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sausage Sensation",
          description:
            "A pizza that celebrates the savory goodness of Italian sausage, complemented by roasted red peppers and melted cheese.",
          uploadDate: "2023-06-15",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
        {
          image:
            "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
          name: "Sweet and Savory Fig",
          description:
            "Indulge in the perfect balance of sweet and savory with figs, prosciutto, and gorgonzola cheese. A sophisticated pizza experience.",
          uploadDate: "2023-07-30",
        },
      ],
      itemsPerPage: 4,
      currentPage: 1,
    };
  },
  computed: {
    numPages(): number {
      return Math.ceil(this.items.length / this.itemsPerPage);
    },

    paginatedItems(): any /** TODO */ {
      const startIndex = (this.currentPage - 1) * this.itemsPerPage;
      const endIndex = startIndex + this.itemsPerPage;
      return this.items.slice(startIndex, endIndex);
    },
  },

  methods: {
    handleSearch() {
      console.log("search"); //TODO
    },

    handleItemClick(item: any /**TODO */) {
      console.log(item); //TODO
    },
  },
};
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
