<template>
  <v-container class="home-container" ref="containerRef" @scroll="handleScroll">
    <div class="background-image"></div>
    <v-col cols="6"></v-col>
    <v-col cols="6">
      <v-row class="intro-1">
        <v-col>
          <h1 class="welcome fade-in">
            <span>Welcome to Pizza'ed</span> <br />
            Your Ultimate Pizza Adventure!
          </h1>
        </v-col>
      </v-row>
      <v-row class="intro">
        <v-col>
          <h2 class="fade-in">
            Craving the perfect slice? <br />
            You're in the right place! 🍕
          </h2>
          <p class="fade-in">
            The creator of Pizza'ed believes that the power of pizza brings joy
            and satisfaction to every human's taste buds. Whether you're a
            pizza-pro or just starting your pizza journey, the app is here to
            elevate your pizza experience.
          </p>
        </v-col>
      </v-row>

      <v-row class="intro">
        <v-col>
          <h2 class="fade-in">Discover Delightful Pizzas</h2>
          <p class="fade-in">
            Explore a world of flavors with the extensive collection of pizza
            reviews. From classic Margherita to bold and exotic creations,
            Pizza'ed is your passport to pizza paradise. Search by pizza name or
            ingredients to find the perfect slice for every mood.
          </p>
        </v-col>
      </v-row>

      <v-row class="intro">
        <v-col>
          <h2 class="fade-in">Share Your Pizza Passion with the World!</h2>
          <p class="fade-in">
            Every pizza lover has a unique story to tell, and the world wants to
            hear yours! Introducing a user-friendly upload feature that allows
            you to share your pizza adventures with the Pizza'ed community.
          </p>
        </v-col>
      </v-row>
    </v-col>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  data() {
    return {
      isBackgroundLoaded: false,
      threshold: 50,
    };
  },
  methods: {
    preloadImage() {
      const img = new Image();
      img.src = "@/img/background2-cropped.jpg";

      img.onload = () => {
        this.isBackgroundLoaded = true;
      };
    },

    handleScroll() {
      const container = this.$refs.containerRef as any;
      const sections = container.getElementsByClassName("fade-in");

      for (const section of sections) {
        const boundingBox = section.getBoundingClientRect();
        const isVisible = boundingBox.top < window.innerHeight - this.threshold;

        if (isVisible) {
          section.classList.add("visible");
        }
      }
    },

    resetScroll() {
      const container = this.$refs.containerRef as any;

      container.scrollTop = 0; // Reset the scroll position to the top

      // Remove the visible class from all sections
      const sections = container.getElementsByClassName("fade-in");
      for (const section of sections) {
        section.classList.remove("visible");
      }

      // Display the h1 first
      const h1 = container.querySelector(".welcome");
      h1.classList.add("visible");
    },
  },
  mounted() {
    this.preloadImage();
    console.log("imageloaded"); // this log appears first before the background picture

    this.resetScroll();

    window.addEventListener("scroll", this.handleScroll);
  },

  beforeDestroy() {
    // Remove scroll event listener
    window.removeEventListener("scroll", this.handleScroll);
  },
});
</script>

<style scoped>
* {
  font-size: 1.2rem;
}

h1 {
  font-size: 2rem;
  text-align: center;
  margin: 40% 0 60%;
}

h2 {
  font-size: 1.5rem;
  margin: 0 0 1rem;
}

.background-image {
  background-image: url("../img/background2.jpg");
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: -1;
}

.fade-in {
  opacity: 0;
  transform: translateY(10px);
  transition: opacity 1s, transform 1s;
}

.fade-in.visible {
  opacity: 1;
  transform: translateY(0);
}

@keyframes fadeIn {
  from {
    opacity: 0;
    transform: translateY(10px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

.home-container {
  display: flex;
  text-align: right;
}

.welcome span {
  font-size: 2.5rem;
}

.intro {
  margin-bottom: 10rem;
}
</style>
