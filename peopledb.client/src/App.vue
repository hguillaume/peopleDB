<script setup lang="ts">
  import HelloWeatherForecast from './components/HelloWeatherForecast.vue'
  import TheWelcome from './components/TheWelcome.vue'
  import HelloUsers from './components/Users/Index.vue'

  //import globTests from './components/globTests.vue'

  //import Modal from './components/Modal.vue';

</script>

<template>
  <header>
    <img alt="Vue logo" class="logo" src="./assets/logo.svg" width="125" height="125" />

    <div class="wrapper">
      <!--<HelloWeatherForecast msg="You did it!" />-->
      <!--<HelloUsers />-->
      <!--<globTests />-->
    </div>
  </header>

  <main>
    <!--<TheWelcome />-->
    <router-view></router-view>
  </main>
</template>

<style scoped>
  header {
    line-height: 1.5;
  }

  .logo {
    display: block;
    margin: 0 auto 2rem;
  }

  @media (min-width: 1024px) {
    header {
      display: flex;
      place-items: center;
      padding-right: calc(var(--section-gap) / 2);
    }

    .logo {
      margin: 0 2rem 0 0;
    }

    header .wrapper {
      display: flex;
      place-items: flex-start;
      flex-wrap: wrap;
    }
  }
</style>
