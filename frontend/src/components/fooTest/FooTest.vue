<template>
  <div>
    <div class="test-class">
      <h2>This is a test component</h2>
      <label>This is a click counter: {{ counter }} </label>
      <button @click="increment">Increment</button>
    </div>
    <ul>
      <li v-for="item in items" :key="item">
        {{ item }}
      </li>
    </ul>
    <button @click="sendApi()">Send API</button>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import store from "@/components/fooTest/FooTestStore";

export default Vue.extend({
  data() {
    return {
      counter: 0 as number,
      store,
    };
  },

  methods: {
    increment() {
      this.counter++;
      if (this.counter % 10 === 0) {
        this.store.addSomeData(`You pushed the button ${this.counter} times!`);
      }
    },

    sendApi() {
      this.store.sendApi();
    },
  },

  computed: {
    items(): string[] {
      return this.store.someData;
    },
  },

  beforeDestroy() {
    this.store.clearData();
  },
});
</script>

<style scoped>
.test-class {
  padding: 1rem;
  outline: 1px solid rgba(0, 0, 0, 0.4);
}

ul li {
  list-style-type: none;
}
</style>
