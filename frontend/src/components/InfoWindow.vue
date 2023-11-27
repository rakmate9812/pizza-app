<template>
  <div id="main">
    <h1>{{ infoMessage }}</h1>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  props: {
    infoMessage: { type: String, required: true },
  },
});
</script>

<style scoped>
#info {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 50vh; /* Use 50% of the viewport height - the vertical center */
}

h1 {
  margin-bottom: 10px;
  text-align: center;
}
</style>
