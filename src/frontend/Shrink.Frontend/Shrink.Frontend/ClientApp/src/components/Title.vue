<template>
  <div>
    <a><router-link :to="'/'"><h1 class="header">Shrink.io</h1></router-link></a>
    <a class="description">A URL shortener who cares your privacy</a>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'Title',
});
</script>

<style lang="scss" scoped>
a {
  text-decoration: none;
}

h1 {
  text-decoration: none;
  color: white;
}

.header {
  font-size: 60px;
}

.description {
  font-size: 22px;
}
</style>
