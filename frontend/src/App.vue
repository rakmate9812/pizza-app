<template>
  <div id="app">
    <AppMenu />
    <router-view />
  </div>
</template>

<script lang="ts">
import AppMenu from "@/AppMenu.vue";
import Vue from "vue";

export default Vue.extend({
  components: { AppMenu },
});
</script>

<style lang="scss">
#app {
  font-family: Arial, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
