<template>
  <div id="main">
    <InfoWindow
      v-if="!$store.getters.isLoggedIn"
      infoMessage="You are not logged in!"></InfoWindow>
    <div v-else>
      <h1>Do you want to log out?</h1>
      <div class="centered">
        <v-btn @click="logout">Yes, log out</v-btn>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import InfoWindow from "@/components/InfoWindow.vue";

export default Vue.extend({
  components: { InfoWindow },

  methods: {
    logout() {
      this.$store.dispatch("clearToken");
      this.$router.push(`/`);
    },
  },
});
</script>

<style scoped>
#main {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 50vh; /* Use 100% of the viewport height */
}

h1 {
  margin-bottom: 10px;
  text-align: center;
}

.centered {
  display: flex;
  justify-content: center;
}

.v-btn {
  margin-top: 20px;
}
</style>
