<script setup>
  import { defineProps, defineEmits } from 'vue'
  const user = defineModel('user');
  const emit = defineEmits(['addTestUser', 'addUser', 'editUser']);

  defineProps({
    user: {
      type: Object,
      default: () => ({ name: '', email: '' })
    },
    isEditForm: {
      type: Boolean,
      default: false,
    }
  });

  function submitForm(isEditForm) {
    //console.log('submitForm', isEditForm, user);
    if (isEditForm) {
      //console.log('edit user', user.value);
      emit('editUser', user.value);
    } else {
      //console.log('add user', user.value);
      //emit('addTestUser');
      emit('addUser', user.value);
    }
  }
</script>

<template>
  <div class="weather-component">
    <h1>Add/Edit</h1>
    <form @submit.prevent="submitForm(isEditForm)">
      <div>
        <label for="name">Name</label>
        <input type="text" id="name" v-model="user.name" />
      </div>
      <div>
        <label for="email">Email</label>
        <input type="text" id="email" v-model="user.email" />
      </div>
      <div>
        <label for="password">Password</label>
        <input type="password" id="password" v-model="user.password" />
      </div>
      <button type="submit">Submit</button>
    </form>
  </div>
</template>
