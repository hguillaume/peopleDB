//import vue from '@vitejs/plugin-vue'
import { mount } from '@vue/test-utils'
import { describe, it, expect } from 'vitest';
import Index from './../../Users/Index.vue'
//import {getUsers} from './../../Users/Index.vue'

import AxiosMockAdapter from "axios-mock-adapter";
//const AxiosMockAdapter = require("axios-mock-adapter");

function output(text: string) {
  console.log(text);
  try {
    process.stdout.write(text + "\n");
  }
  catch (e) {
  }
}

var d = new Date();
var datestring = d.getFullYear() + "-" + (d.getMonth() + 1).toString().padStart(2, '0') + "-" + d.getDate().toString().padStart(2, '0') + " " + d.getHours().toString().padStart(2, '0') + ":" + d.getMinutes().toString().padStart(2, '0') + ":" + d.getSeconds().toString().padStart(2, '0');
output(datestring);

describe('test template', () => {
  const wrapper = mount(Index);
  const instance = wrapper.vm;
  const axios = instance.axios;
  const axiosMock = new AxiosMockAdapter(axios);
  it('test nothing', async () => {
    
  })
});
