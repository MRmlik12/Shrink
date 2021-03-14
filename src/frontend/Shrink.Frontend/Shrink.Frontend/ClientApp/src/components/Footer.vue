<template>
  <div>
    Github repository &bull;
    Terms of Service &bull;
    <router-link :to="'/report'"> malicious link </router-link>  &bull;
    <router-link :to="'/api'"> API </router-link>&bull;
    Contact
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'Footer',
});
</script>

<style lang="scss" scoped>
  a {
    text-decoration: none;
    color: white;
  }
</style>
