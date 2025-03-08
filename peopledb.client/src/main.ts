// Extensions->Manage Extensions->Install marketplace extension for Tailwind CSS VS2022 Editor Support

import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'

// Routing
import { createRouter, createWebHistory } from 'vue-router'
//import TheWelcome from './components/TheWelcome.vue';
import IndexUsers from './components/Users/Index.vue';
import View404 from './components/404.vue';
const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: '/', redirect: '/users' },
    { path: '/users', component: IndexUsers },
    {
      path: '/:catchAll(.*)',
      name: '404Name',
      component: View404
    }
  ]
});

const app = createApp(App);
app.use(router);
app.mount('#app');
// Set up the global error handler
app.config.errorHandler = (err, instance, info) => {
  console.error('Global error handler:', err);
  //console.error('Component instance:', instance);
  //console.error('Error info:', info);
};
