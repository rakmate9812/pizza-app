<template>
  <div>
    <loading-spinner ref="loadingSpinner"></loading-spinner>
    <InfoWindow
      v-if="$store.getters.isLoggedIn"
      infoMessage="You are logged in!"></InfoWindow>
    <div v-else>
      <h1>{{ loginTitle }}</h1>
      <div class="form-container">
        <div>
          <v-form ref="form" @submit.prevent="submitForm">
            <v-row>
              <v-col cols="12">
                <v-text-field
                  v-model="loginUser.username"
                  label="Username"
                  :rules="[(v) => !!v || 'You must choose a username!']"
                  required></v-text-field>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="12">
                <v-text-field
                  v-model="loginUser.password"
                  type="password"
                  label="Password"
                  :rules="[(v) => !!v || 'You must enter a password!']"
                  required>
                </v-text-field>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="12" class="login-section">
                <v-btn type="submit">Login</v-btn>
                <p v-if="loginErrorMessage">{{ loginErrorMessage }}</p>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="12" class="register-section">
                <label @click="register"
                  >Register with the given credentials</label
                >
                <p class="registerErrorMessage" v-if="registerErrorMessage">
                  {{ registerErrorMessage }}
                </p>
                <p class="registerSuccessMessage" v-if="registerSuccessMessage">
                  {{ registerSuccessMessage }}
                </p>
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
import User, { defaultUser } from "@/models/User/User";
import store from "@/models/User/services/UserStore";
import InfoWindow from "@/components/InfoWindow.vue";
import LoadingSpinner from "@/components/LoadingSpinner.vue";

export default Vue.extend({
  components: { InfoWindow, LoadingSpinner },

  data() {
    return {
      store: store,

      loginUser: defaultUser as User,
      loginTitleList: [
        "Slice into Your Account",
        "Unlock the Flavor Vault",
        "Cheesy Login Goodness",
        "Crust in Time: Login",
        "Your Slice, Your Space: Log In",
        "Login for a Tasty Experience",
        "Bite into Your Account",
      ] as string[],

      valid: false as boolean,
      loginErrorMessage: "" as string,
      registerErrorMessage: "" as string,
      registerSuccessMessage: "" as string,
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
    async submitForm() {
      this.resetMessages();
      this.valid = await (this.$refs.form as any)?.validate(); // Vuetify's built in validate funtion

      if (this.valid) {
        try {
          const token = await this.store.loginUser(this.loginUser);
          this.$router.push(`/browse`);
          this.$store.dispatch("setToken", token);
          console.log(this.$store.getters.getToken);
        } catch (error: any) {
          this.loginErrorMessage = error.message;
        }
      }
    },

    async register() {
      this.resetMessages();
      this.valid = await (this.$refs.form as any)?.validate();

      if (this.valid) {
        try {
          const result = await this.store.registerUser(this.loginUser);
          this.registerSuccessMessage = result;
        } catch (error: any) {
          this.registerErrorMessage = error.message;
        }
      }
    },

    resetMessages() {
      this.loginErrorMessage = "";
      this.registerErrorMessage = "";
      this.registerSuccessMessage = "";
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
  background: white;
}

.login-section {
  display: flex;
  align-items: center;
}

.login-section p {
  color: red;
  padding-left: 1rem;
}

.register-section {
  display: flex;
  align-items: center;
}

.register-section label {
  cursor: pointer;
  color: grey;
}

.register-section label:hover {
  color: black;
}

.register-section {
  display: flex;
  align-items: center;
}

.registerErrorMessage {
  color: red;
  padding-left: 1rem;
}

.registerSuccessMessage {
  color: green;
  padding-left: 1rem;
}
</style>
