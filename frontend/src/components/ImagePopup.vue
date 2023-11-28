<template>
  <v-dialog v-model="dialog" :max-width="maxWidth">
    <div class="dialog">
      <v-img :src="selectedImage" max-height="100vh" contain></v-img>
      <!-- <v-btn icon @click="downloadImage">
        <v-icon>mdi-download</v-icon>
      </v-btn>
      <v-btn icon @click="closeDialog">
        <v-icon>mdi-close</v-icon>
      </v-btn> -->
    </div>
  </v-dialog>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  data() {
    return {
      dialog: false,
      selectedImage: null as null | string,
      maxWidth: 0 as number,
    };
  },

  methods: {
    openDialog(imageSrc: string) {
      this.selectedImage = imageSrc;
      this.dialog = true;
    },

    closeDialog() {
      this.dialog = false;
      this.selectedImage = null;
    },

    downloadImage() {
      //TODO
    },

    calculateWidth(originalWidth: number, originalHeight: number, height: number): number {
      const aspectRatio = originalWidth / originalHeight;
      const width = aspectRatio * height;
      return width;
    },
  },

  watch: {
    selectedImage(newVal) {
      const img = new Image();

      img.src = newVal;

      const imgWidth = img.naturalWidth;
      const imgHeight = img.naturalHeight;

      //   console.log("imgWidth: ", imgWidth);
      //   console.log("imgHeight: ", imgHeight);

      this.maxWidth = this.calculateWidth(imgWidth, imgHeight, window.innerWidth * 0.4);
    },
  },
});
</script>

<style scoped>
/* .dialog {
    TODO
} */
</style>
