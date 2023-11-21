<template>
  <div>
    <h1>You were Pizza'ed</h1>
    <div class="form-container">
      <div>
        <v-form @submit.prevent="submitForm">
          <v-row>
            <v-col cols="12">
              <v-file-input label="Evidence (photo)"></v-file-input>
            </v-col>
          </v-row>

          <v-row>
            <v-col cols="12">
              <v-text-field label="Name of the Victim"></v-text-field>
            </v-col>
          </v-row>

          <v-row>
            <v-col cols="12">
              <v-textarea rows="1" label="Description"></v-textarea>
            </v-col>
          </v-row>

          <v-row>
            <v-col cols="12">
              <v-text-field label="Recipe link"></v-text-field>
            </v-col>
          </v-row>

          <v-row>
            <v-col cols="12">
              <v-label>How delicious was it?</v-label>
              <v-rating half-increments></v-rating>
            </v-col>
          </v-row>

          <v-row>
            <v-col cols="12">
              <v-btn type="submit">Submit</v-btn>
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
  methods: {
    submitForm() {
      console.log("form submit");
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
  padding: 0 20px 20px 20px;
  border: 1px solid #e0e0e0;
  border-radius: 4px;
  box-shadow: 0 0 10px rgba(225, 202, 202, 0.1);
}

button {
  margin-top: 20px;
}
</style>
