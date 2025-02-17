// Extensions->Manage Extensions->Install marketplace extension for Tailwind CSS VS2022 Editor Support

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
