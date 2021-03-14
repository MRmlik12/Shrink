<template>
  <div id="app">
    <div id="title">
      <Title></Title>
    </div>
    <router-view/>
    <notifications group="url" position="bottom right"/>
    <div id="footer">
      <Footer></Footer>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Title from './components/Title.vue';
import Footer from './components/Footer.vue';

export default Vue.extend({
  components: {
    Title,
    Footer,
  },
});
</script>

<style lang="scss">
@font-face {
  font-family: 'Roboto-Light';
  src: url('assets/fonts/Roboto-Light.ttf');
}

@font-face {
  font-family: 'Roboto-Black';
  src: url('assets/fonts/Roboto-Black.ttf');
}

body {
  background-color: #121212;
}

#app {
  font-family: 'Roboto-Black', 'Roboto-Light' sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #fff;
}

#footer {
  position: fixed;
  bottom: 0;
  left: 0;
  right: 0;
  text-align: center;
}
</style>
