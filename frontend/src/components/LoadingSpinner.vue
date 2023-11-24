<!-- LoadingSpinner.vue -->

<template>
  <v-overlay :value="loading">
    <v-progress-circular indeterminate color="primary"></v-progress-circular>
  </v-overlay>
</template>

<script>
import bus from "@/services/eventBus";

export default {
  data() {
    return {
      loading: false,
    };
  },
  created() {
    // Listen for 'start-loading' and 'stop-loading' events
    bus.$on("start-loading", this.startLoading);
    bus.$on("stop-loading", this.stopLoading);
  },
  beforeDestroy() {
    // Cleanup: remove event listeners
    bus.$off("start-loading", this.startLoading);
    bus.$off("stop-loading", this.stopLoading);
  },
  methods: {
    startLoading() {
      this.loading = true;
    },
    stopLoading() {
      this.loading = false;
    },
  },
};
</script>

<style scoped>
/* You can add styles for the overlay here if needed */
</style>
