<template>
  <div>
   <input placeholder="Paste URL here" class="url" v-model="url"/>
   <button v-on:click="onCreateClicked" class="create">Short me!</button>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Api from '../api/api';

export default Vue.extend({
  name: 'Create',
  data() {
    return {
      url: '',
    };
  },
  methods: {
    async onCreateClicked() {
      const isValid = this.checkVaildUrl(this.url);
      if (!isValid) {
        this.showError("This URL isn't vaild!");
      } else {
        const response = await Api.create(this.url);
        if (!response.error == null) {
          this.showError(response.error);
        } else {
          this.$store.state.url = `http://localhost:8080/${response.code}`;
          this.$store.state.isGenerated = true;
        }
      }
    },
    showError(error: string) {
      Vue.notify({
        group: 'url',
        type: 'error',
        title: 'Error',
        text: error,
      });
    },
    checkVaildUrl(url: string) {
      const regexPattern = "^(?:http(s)?:\\/\\/)?[\\w.-]+(?:\\.[\\w\\.-]+)+[\\w\\-\\._~:/?#[\\]@!\\$&'\\(\\)\\*\\+,;=.]+$";
      const regex = new RegExp(regexPattern);
      if (regex.exec(url)?.length === undefined) {
        return false;
      }
      return true;
    },
  },
});
</script>

<style lang="scss">
.url {
  font-size: 18px;
  color: #fff;
  border: 2px solid white;
  background-color: #121212;
  padding: 2px;
  text-decoration: none;
  width: 75%;
  height: 40px;
}

.create {
  margin-left: 10px;
  font-size: 18px;
  background-color: white;
  border: none;
  text-decoration: none;
  height: 40px;
}
</style>
