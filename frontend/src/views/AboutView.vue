<template>
  <v-container class="pa-5 text-center">
    <div class="background-image"></div>
    <v-col cols="3"></v-col>
    <v-col cols="9">
      <v-row class="about">
        <v-col>
          <h1>About Pizza'ed</h1>
          <p>
            Pizza'ed is a passion project and a showcase of my current
            full-stack web development skills. This application is a combination
            of various software development tools to deliver a nice browsing
            experience.
          </p>
        </v-col>
      </v-row>

      <v-col cols="11">
        <v-divider style="margin: 20px 0 10px"></v-divider>
      </v-col>

      <v-row class="components">
        <v-col cols="10">
          <h2>Project Components</h2>
          <p>The Pizza'ed app is comprised of three main components:</p>
          <ul>
            <li>
              <strong>Azure MS SQL Cloud Database:</strong> Storage of Pizza'ed
              reviews and users.
            </li>
            <li>
              <strong>ASP.NET 8 Web API:</strong> The communication layer
              between the UI and database.
            </li>
            <li>
              <strong>Vue 2:</strong> The visually appealing front-end UI.
            </li>
          </ul>
        </v-col>
      </v-row>

      <v-col cols="9">
        <v-divider style="margin: 20px 0 10px"></v-divider>
      </v-col>

      <v-row class="contact">
        <v-col cols="3">
          <h2>Contact</h2>
          <ul>
            <li>via <a href="https://github.com/rakmate9812">Github</a></li>

            <li>
              via
              <a href="https://www.linkedin.com/in/rakmate9812/">LinkedIn</a>
            </li>
          </ul>
        </v-col>
      </v-row>
    </v-col>
  </v-container>
</template>

<style scoped>
.background-image {
  background-image: url("../img/background3.jpg");
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

.components h2 {
  margin: 0 0 0.2rem;
}

.components p {
  margin: 0 0 0.2rem;
}
</style>
