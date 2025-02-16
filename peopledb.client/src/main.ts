import "https://cdnjs.cloudflare.com/ajax/libs/axios/1.7.8/axios.min.js"
import "https://unpkg.com/@tailwindcss/browser@4"

import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'

const app = createApp(App)
app.mount('#app')
// Set up the global error handler
app.config.errorHandler = (err, instance, info) => {
  console.error('Global error handler:', err);
  //console.error('Component instance:', instance);
  //console.error('Error info:', info);
};
