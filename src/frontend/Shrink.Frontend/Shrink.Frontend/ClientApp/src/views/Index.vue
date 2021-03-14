<template>
  <div>
    <div id="create">
      <create></create>
      <generated :url="this.$store.state.url" v-if="this.$store.state.isGenerated">
      </generated>
    </div>
  </div>
</template>

<script type="ts">
import Vue from 'vue';
import Create from '../components/Create.vue';
import Generated from '../components/Generated.vue';

export default Vue.extend({
  name: 'Index',
  components: {
    Create,
    Generated,
  },
});
</script>

<style lang="scss">
  #create {
    font-family: 'Roboto-Light';
    width: 100%;
    height: 20%;
    text-align: center;
    margin-left: auto;
    margin-right: auto;
    align-items: center;
    position: absolute;
    left: 50%;
    top: 50%;
    -webkit-transform: translate(-50%, -50%);
    transform: translate(-50%, -50%);
  }
</style>
