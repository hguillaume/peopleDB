/// <reference types="vitest/config" />
/// <reference types="@vitest/browser/providers/webdriverio" />
/// <reference types="vitest-browser-vue" />
//import vue2 from 'eslint-plugin-vue';
import vue from "@vitejs/plugin-vue";
import { config } from 'process';
import { defineConfig } from 'vite'
export default defineConfig({
  test: {
    //setupFiles: ['vitest-browser-vue'],
    //ui: true,
    //reporters: ['html'],
    workspace:
      [{
        extends: true,
        test:
        {
          globals: true,
          environment: "jsdom"
        }
      }],
    browser: {
          enabled: false,
          provider: 'webdriverio',
          ui: true,
          //headless: false,
          instances: [
            {
              browser: 'edge',
              //setupFile: './chromium-setup.js',
            },
          ],
        },
      },
  plugins: [vue()],
});
