<template>
  <div id="report">
    <h1>Report</h1>
    <div class="description">
      <a>
        If you entered link who breaks Term of service, please send me details about website
        in form!
      </a><br>
      <form action="mailto:mrmlik12.contact@protonmail.com" method="POST" enctype="text/plain">
        <input placeholder="Your e-mail address" class="form-input formatter" v-model="url"
        required name="mail"/>
        <input placeholder="URL of shrinker " class="form-input formatter" v-model="url"
          required name="name"/>
        <textarea placeholder="Describe your problem" class="form-input formatter" v-model="url"
          required style="height: 250px" name="description" rows="5"/><br>
        <button class="form-button formatter" type="submit">Send!</button>
      </form>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'Report',
});
</script>

<style lang="scss" scoped>
.form-input {
  font-size: 18px;
  color: #fff;
  border: 2px solid white;
  background-color: #121212;
  padding: 2px;
  text-decoration: none;
  width: 65%;
  height: 40px;
}

.formatter {
  margin-top: 15px;

}

.form-button {
  margin-left: 10px;
  font-size: 18px;
  background-color: white;
  border: none;
  width: 120px;
  text-decoration: none;
  height: 40px;
}
</style>
