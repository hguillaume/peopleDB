<script setup lang="ts">
  import { minimatch } from 'minimatch'

  //const result = minimatch('peopledb.client/dist/index.html', '**/dist/**/*')
  //const result = minimatch('peopledb.client/dist/index.html', 'peopledb.client/dist/**/*')
  const result = minimatch('peopledb.client/dist/index.html', 'peopledb.client/dist/**/*')
  console.log(result);

</script>

<template>
  <div>
    <h1>globTests.vue</h1>
  </div>
</template>
