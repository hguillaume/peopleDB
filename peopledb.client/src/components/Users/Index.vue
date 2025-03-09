<template>
  <div class="weather-component">
    <h1>Welcome Users</h1>

    <div v-if="loading" class="loading">
      Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
    </div>

    <button @click="addTestUser()" class="bg-sky-500 hover:bg-sky-700 rounded">Add Test Users</button>
    <button @click="showUserForm()" class="bg-sky-500 hover:bg-sky-700 rounded">Add Users Form</button>

    <AddEdit v-if="isShowUserForm" :key="isShowUserForm" data-test="addEdit"
             v-model:user="user"
             v-model:isShowUserForm="isShowUserForm"
             :isEditForm="isEditForm"
             @addTestUser="addTestUser"
             @addUser="addUser"
             @editUser="editUser" />

    <!--<div data-test="testme">Test Me<span></span><span></span></div>-->

    <div v-if="users" class="content">
      <table>
        <thead>
          <tr>
            <th>id</th>
            <th>Name</th>
            <th>Email</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody data-test="users">
          <tr v-for="user in users" :key="users">
            <td>{{ user.id }}</td>
            <td>{{ user.name }}</td>
            <td>{{ user.email }}</td>
            <td><button @click="editUserForm(user)" class=""><i class="pi pi-pen-to-square text-orange-300"></i></button></td>
            <td><button @click='deleteUser(user.id)' class=""><i class="pi pi-delete-left text-red-500 hover:text-red-700"></i></button></td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup lang="ts">
  import { ref, onMounted, reactive } from 'vue'
  import AddEdit from './AddEdit.vue'
  import axios2 from 'axios'

  const axios = axios2;

  //type User = {
  //  name: string,
  //  email: string,
  //  password: string,
  //};

  //type Users = User[];

  const loading = ref(false);
  const users = ref(null);
  const isShowUserForm = ref(false);
  const user = ref({});
  const isEditForm = ref(false);
  const isTest = false;

  async function getUsers() {
    users.value = null;
    loading.value = true;
    await axios.get('/api/users')
      .then(response => {
        users.value = response.data;
      })
      .catch(error => {
        console.error('There was an error!', error);
      })
      .finally(() => {
        loading.value = false;
      });
  }

  function showUserForm() {
    this.user = {};
    this.user.name = '';
    this.user.email = '';
    this.user.password = '';
    //this.isShowUserForm = ! this.isShowUserForm;
    isEditForm.value = false;
    this.isShowUserForm = true;
  }

  function editUserForm(user) {
    this.isShowUserForm = true;
    this.user = user;
    isEditForm.value = true;
    //console.log(user);
  }

  async function editUser(user) {
    await axios.put("/api/users/" + user.id, user)
    .then(response => {
      console.log('Put edited:', response.data);
    })
      .catch(error => {
        console.error('Error creating post:', error);
      });
    getUsers();
  }

  async function addUser(user) {
    await axios.post('/api/users', user)
    .then(response => {
      console.log('Post created:', response.data);
    })
      .catch(error => {
        console.error('Error creating post:', error);
      });
    getUsers();
  }

  async function addTestUser() {
    addUser({ name: 'test', email: 'test@test.com', password: 'test123456' });
  }

  async function deleteUser(id) {
    await axios.delete(`/api/users/${id}`, {
    }).then(response => {
      console.log('Delete deleted:', response.data);
    })
      .catch(error => {
        console.error('Error creating post:', error);
      });
    this.getUsers();
  }

  // lifecycle hooks
  onMounted(async () => {
    if(isTest == false)
      await getUsers();
  });
</script>

<style scoped>
th {
    font-weight: bold;
}

th, td {
    padding-left: .5rem;
    padding-right: .5rem;
}

.weather-component {
    text-align: center;
}

table {
    margin-left: auto;
    margin-right: auto;
}
</style>
