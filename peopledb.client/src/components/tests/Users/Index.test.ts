import { mount } from '@vue/test-utils'
import { describe, it, expect } from 'vitest';
import Index from './../../Users/Index.vue'

import AxiosMockAdapter from "axios-mock-adapter";
//import { wrap } from 'module';

//import { render } from 'vitest-browser-vue'

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

describe('Users Component', () => {
  const wrapper = mount(Index);
  const instance = wrapper.vm;
  const axios = instance.axios;
  const axiosMock = new AxiosMockAdapter(axios);

  it('test getUsers() length', async () => {
    // Arrange
    axiosMock.onGet("/api/users").reply(200, {
      users: [{ id: 1, name: "John Smith", email: "abc@abc.com", password: "test123456" }],
    });

    // Act
    await instance.getUsers();
    const users = instance.users;
    //output(JSON.stringify(users, null, 2));
    const len = Object.keys(users).length;
    //output("Users Length: " + len);

    // Assert
    expect(len).toBeGreaterThan(0);
  }),
    it('test getUsers() HTML table tr built', async () => {
      // Arrange
      axiosMock.onGet("/api/users").reply(200, {
        users: [{ id: 1, name: "John Smith", email: "abc@abc.com", password: "test123456" }],
      });

      // Act
      await instance.getUsers();
      instance.$nextTick();
      const users = instance.users;
      //output(JSON.stringify(users, null, 2));
      const usersElement = wrapper.find('[data-test="users"]');
      //output("Element exists: " + usersElement.exists().toString());
      //output("Text Content: " + usersElement.element.textContent);
      //output("Child ELement count: " + usersElement.element.childElementCount);
      //output("Outer HTML:" + usersElement.element.outerHTML);
      //output("Inner HTML:" + usersElement.element.innerHTML);
      const len = usersElement.element.childElementCount;

      // Assert
      expect(len).toBeGreaterThan(0);
    }),
    it('test showUserForm() HTML form', async () => {
      // Arrange
      //const wrapper = mount(Index);
      //const instance = wrapper.vm;
      //const axios = instance.axios;
      //const axiosMock = new AxiosMockAdapter(axios);

      // Act
      await instance.showUserForm();
      instance.$nextTick();
      const addEditElement = wrapper.find('[data-test="addEdit"]');
      //output("Element exists: " + addEditElement.exists().toString());
      //output("Inner HTML:" + addEditElement.element.innerHTML);
      const nameElement = wrapper.find('#name');
      const emailElement = wrapper.find('#email');
      const passwordElement = wrapper.find('#password');
      //output("Element exists: " + nameElement.exists().toString());
      //output("Outer HTML:" + nameElement.element.outerHTML);
      //output("value:" + nameElement.element.textContent);

      // Assert
      expect(addEditElement.exists()).toBe(true);
      expect(nameElement.exists()).toBe(true);
      expect(emailElement.exists()).toBe(true);
      expect(passwordElement.exists()).toBe(true);

      expect(instance.user.name).toBe("");
      expect(instance.user.email).toBe("");
      expect(instance.user.password).toBe("");
    }),
    it('test editUserForm(user) vue variables', async () => {
      // Arrange
      const user = {
        id: 1, name: "test test", email: "abc@abc.com", password: "test123456"
      };

      // Act
      await instance.editUserForm(user);
      instance.$nextTick();
      const addEditElement = wrapper.find('[data-test="addEdit"]');
      //output("Element exists: " + addEditElement.exists().toString());
      //output("Inner HTML:" + addEditElement.element.innerHTML);
      const nameElement = wrapper.find('#name');
      const emailElement = wrapper.find('#email');
      const passwordElement = wrapper.find('#password');
      //output("Element exists: " + nameElement.exists().toString());
      //output("Outer HTML:" + nameElement.element.outerHTML);
      //output("value:" + nameElement.text());

      // Assert
      expect(addEditElement.exists()).toBe(true);
      expect(instance.user.name).toBe("test test");
      expect(instance.user.email).toBe("abc@abc.com");
      expect(instance.user.password).toBe("test123456");
    }),
    it('test editUser(user)', async () => {
      // Arrange
      const user = {
        id: 1, name: "test updated good", email: "abc@abc.com", password: "test123456"
      };
      axiosMock.onPut("/api/users").reply(200, {
        //user: { id: 1, name: "test updated", email: "abc@abc.com", password: "test123456" },
      });
      instance.editUser(user);
      instance.$nextTick();
      expect(axiosMock.history.put.length).toBeGreaterThan(0);
      //output(wrapper.text());
      //expect(wrapper.text()).toContain("test updated good");
    }),
    it('test addUser(user)', async () => {
      // Arrange
      const user = {
        id: 1, name: "test added good", email: "abc@abc.com", password: "test123456"
      };
      axiosMock.onPost("/api/users").reply(200, {
        //user: { id: 1, name: "test updated", email: "abc@abc.com", password: "test123456" },
      });
      instance.addUser(user);
      instance.$nextTick();
      expect(axiosMock.history.post.length).toBeGreaterThan(0);
    }),
    it('test deleteUser(id)', async () => {
      // Arrange
      //const user = {
      //  id: 1, name: "test added good", email: "abc@abc.com", password: "test123456"
      //};
      axiosMock.onDelete("/api/users").reply(200, {
        //user: { id: 1, name: "test updated", email: "abc@abc.com", password: "test123456" },
      });
      instance.deleteUser(1);
      instance.$nextTick();
      expect(axiosMock.history.delete.length).toBeGreaterThan(0);
    })
    //it('test render', async () => {
    //  const screen = render(Index);
    //});
});
