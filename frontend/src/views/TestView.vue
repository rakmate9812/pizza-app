<template>
  <div>
    <FooTest />
  </div>
</template>

<script lang="ts">
import FooTest from "@/components/fooTest/FooTest.vue";
import Vue from "vue";

export default Vue.extend({
  components: {
    FooTest,
  },
});
</script>
