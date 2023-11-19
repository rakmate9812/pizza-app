<template>
  <div id="app">
    <AppMenu />
    <v-container id="main">
      <router-view />
    </v-container>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import AppMenu from "./AppMenu.vue";

export default Vue.extend({
  components: { AppMenu },
});
</script>

<style>
body {
  font-family: "Roboto", sans-serif;
}

#main {
  padding-top: 5rem;
}
</style>
