<template>
  <div>
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
h1 {
  margin-bottom: 10px;
  text-align: center;
}
</style>
