<template>
  <div>
    <h1>{{ loginTitle }}</h1>
    <div class="form-container">
      <div>
        <v-form @submit.prevent="submitForm">
          <v-row>
            <v-col cols="12">
              <v-text-field label="Username"></v-text-field>
            </v-col>
          </v-row>

          <v-row>
            <v-col cols="12">
              <v-text-field type="password" label="Password"> </v-text-field>
            </v-col>
          </v-row>

          <v-row>
            <v-col cols="12">
              <v-btn type="submit">Login</v-btn>
            </v-col>
          </v-row>
        </v-form>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  data() {
    return {
      loginTitleList: [
        "Slice into Your Account",
        "Unlock the Flavor Vault",
        "Cheesy Login Goodness",
        "Crust in Time: Login",
        "Your Slice, Your Space: Log In",
        "Login for a Tasty Experience",
        "Bite into Your Account",
      ] as string[],
    };
  },

  computed: {
    loginTitle(): string {
      return this.loginTitleList[
        Math.floor(Math.random() * this.loginTitleList.length)
      ];
    },
  },

  methods: {
    submitForm() {
      console.log("form submit"); // TODO
    },
  },
});
</script>

<style scoped>
h1 {
  margin-bottom: 10px;
  text-align: center;
}

.form-container {
  display: flex;
  justify-content: center;
}

form {
  min-width: 600px;
  padding: 20px;
  border: 1px solid #e0e0e0;
  border-radius: 4px;
  box-shadow: 0 0 10px rgba(225, 202, 202, 0.1);
}

button {
  margin-top: 20px;
}
</style>
