<template>
  <div>
    <loading-spinner ref="loadingSpinner"></loading-spinner>

    <InfoWindow
      v-if="!$store.getters.isLoggedIn"
      infoMessage="You have to log in first!"></InfoWindow>
    <div v-else>
      <h1>You were Pizza'ed</h1>
      <div class="form-container">
        <div>
          <v-form ref="form" v-model="valid" @submit.prevent="submitForm">
            <v-row>
              <v-col cols="12">
                <v-row v-if="uploadedImgSrc != null" class="file-row">
                  <v-card>
                    <v-img :src="uploadedImgSrc" alt="a nice pizza"></v-img>
                  </v-card>
                </v-row>
                <v-row>
                  <v-file-input
                    id="inputImage"
                    label="Evidence (photo)"
                    @change="handleFileChange"
                    @click:clear="handleFileClear"
                    style="margin-top: 20px"
                    :rules="[
                      (v) => !!v || 'Upload an apetizing picture first!',
                    ]"
                    required></v-file-input>
                </v-row>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="12">
                <v-text-field
                  v-model="newPizza.name"
                  label="Name of the Victim"
                  :rules="[(v) => !!v || 'You must name your slice!']"
                  required></v-text-field>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="12">
                <v-textarea
                  v-model="newPizza.description"
                  rows="1"
                  label="Description"></v-textarea>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="12">
                <v-text-field
                  v-model="newPizza.recipeLink"
                  label="Recipe link"></v-text-field>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="12">
                <v-label>How delicious was it?</v-label>
                <v-rating v-model="newPizza.rating"></v-rating>
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
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import store from "@/models/Pizza/services/PizzaStore";
import Pizza, { defaultPizza } from "@/models/Pizza/Pizza";
import InfoWindow from "@/components/InfoWindow.vue";
import LoadingSpinner from "@/components/LoadingSpinner.vue";

export default Vue.extend({
  components: { InfoWindow, LoadingSpinner },

  data() {
    return {
      store: store,

      newPizza: { ...defaultPizza } as Pizza,
      uploadedImgSrc: null as string | null,

      valid: false as boolean,
    };
  },

  methods: {
    async submitForm() {
      this.valid = await (this.$refs.form as any)?.validate(); // Vuetify's built in validate funtion

      if (this.valid) {
        // console.log(this.newPizza);
        const ret = await this.store.createPizza(
          this.newPizza,
          this.$store.getters.getToken
        );
        this.$router.push(`${ret.id}`);
      }
    },

    handleFileChange() {
      const fileInput = document.getElementById(
        "inputImage"
      ) as HTMLInputElement;
      const file = fileInput.files?.[0];

      if (file !== undefined) {
        if (!file.type.startsWith("image/"))
          console.error("Invalid file type. Please upload an image."); // TODO - let the user know about this

        if (file) {
          const reader = new FileReader();
          reader.onloadend = () => {
            // console.log(reader.result);
            this.uploadedImgSrc = reader.result as string;
          };
          reader.readAsDataURL(file);
        }
      }
    },

    handleFileClear() {
      this.uploadedImgSrc = null;

      const fileInput = document.getElementById(
        "inputImage"
      ) as HTMLInputElement;

      if (fileInput) {
        fileInput.value = ""; // Clearing the input
        fileInput.blur(); // Losing focus
        this.resetFormValidation();
      }
    },

    resetForm() {
      this.handleFileClear();
      (this.$refs.form as any)?.reset(); // Vuetify built-in
    },

    resetFormValidation() {
      (this.$refs.form as any)?.resetValidation(); // Vuetify built-in
    },
  },

  watch: {
    uploadedImgSrc(newVal) {
      this.newPizza.imageData = newVal;
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
  background: white;
  min-width: 30rem;
  padding: 0 20px 20px 20px;
  border: 1px solid #e0e0e0;
  border-radius: 4px;
  box-shadow: 0 0 10px rgba(225, 202, 202, 0.1);
}

button {
  margin-top: 20px;
}

.file-row {
  display: flex;
  justify-content: center;
}

.file-row .v-card {
  margin: 2rem;
  max-width: 10rem;
}
</style>
