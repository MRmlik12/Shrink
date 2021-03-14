<template>
  <a id="result">🎉 Your generated URL is: <a class="link" v-bind:href="url">{{ url }}</a> 🎉</a>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'Generated',
  props: {
    url: {
      type: String,
    },
  },
  mounted() {
    const result = document.getElementById('result');

    for (let i = 0; i < 100; i += 1) {
      result!!.style.height = `${i}px`;
    }
  },
});
</script>

<style lang="scss" scoped>
  a {
    font-family: 'Roboto-Black';
  }

  .link {
    font-family: 'Roboto-Black';
    color: white;
  }
</style>
