<template>
  <div id="app">
    <TheAppMenu />
    <v-container id="main">
      <router-view />
    </v-container>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import TheAppMenu from "./components/TheAppMenu.vue";

export default Vue.extend({
  components: { TheAppMenu },
});
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Marhey:wght@300;400;500;600;700&family=Playpen+Sans:wght@100;200;300;400;500;600;700;800&display=swap");

body {
  font-family: "Playpen Sans", cursive;
  background: rgb(238, 238, 242);
}

#main {
  padding-top: 5rem;
}
</style>
