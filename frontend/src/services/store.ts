import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    token: localStorage.getItem("PIZZA_APP_JWT") || null,
  },
  mutations: {
    setToken: (state, token) => {
      state.token = token;
      localStorage.setItem("PIZZA_APP_JWT", token);
    },
    clearToken: (state) => {
      state.token = null;
      localStorage.removeItem("PIZZA_APP_JWT");
    },
  },
  actions: {
    setToken({ commit }, token) {
      commit("setToken", token);
    },
    clearToken({ commit }) {
      commit("clearToken");
    },
  },
  getters: {
    getToken: (state) => state.token,
    isLoggedIn: (state) => state.token !== null,
  },
});
