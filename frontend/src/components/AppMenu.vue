<template>
  <div>
    <v-app-bar app class="nav-gradient">
      <v-container>
        <v-row align="center" justify="space-between">
          <v-col class="horizontally-centered">
            <router-link to="/" class="title">
              <img src="@/img/pizza.png" alt="Pizza Icon" class="pizza-icon" />
              Pizza'ed
            </router-link>
          </v-col>
          <v-col class="horizontally-centered">
            <v-btn class="nav-button" text to="/review">Review</v-btn>
            <v-btn class="nav-button" text to="/browse">Browse</v-btn>
            <v-btn class="nav-button" text to="/login">Login</v-btn>
            <v-btn class="nav-button" text to="/about">About</v-btn>
          </v-col>
        </v-row>
      </v-container>
    </v-app-bar>
  </div>
</template>

<script>
export default {
  name: "AppMenu",
};
</script>

<style scoped>
.horizontally-centered {
  margin: auto;
}

.title {
  font-size: 24px;
  font-family: "Marhey";
  font-weight: 300;
  text-decoration: none;
  color: white;
  display: flex;
  align-items: center;
}

.pizza-icon {
  width: 28px;
  height: 28px;
  margin-right: 8px;
}

.nav-gradient {
  background: linear-gradient(to right, rgb(255, 166, 0), rgb(255, 182, 46));
}

.nav-button {
  margin: auto;
  margin: 0 0.7rem 0 0;
  color: white;
}
</style>
