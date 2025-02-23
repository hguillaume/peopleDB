<template>
  <div class="weather-component">
    <h1>Add/Edit</h1>
    <form @submit.prevent="submitForm()">
      <div>
        <label for="name" class="p-2">Name</label>
        <input type="text" id="name" required v-model="user.name" class="bg-zinc-500 rounded" />
      </div>
      <div>
        <label for="email"  class="p-2">Email</label>
        <input type="text" id="email" required v-model="user.email" class="bg-zinc-500 rounded" />
      </div>
      <div>
        <label for="password"  class="p-2">Password</label>
        <input type="password" id="password" required v-model="user.password" class="bg-zinc-500 rounded" />
      </div>
      <button class="text-blue-400" type="submit">{{ buttonText }}</button>
    </form>
  </div>
</template>

<script setup lang="ts">
  import { computed } from 'vue'
  const user = defineModel('user');
  const isShowUserForm = defineModel('isShowUserForm');
  const emit = defineEmits(['addTestUser', 'addUser', 'editUser']);

  //type User = {
  //  name: string,
  //  email: string,
  //  password: string,
  //};

  const props = defineProps({
    user: {
      type: Object,
      default: () => ({ name: '', email: '', password: '' })
    },
    isEditForm: {
      type: Boolean,
      default: false,
    },
  });

  const buttonText = computed(() => props.isEditForm ? 'Submit Edit' : 'Submit Add');

  function submitForm() {
    //console.log('submitForm', isEditForm, user);
    if (props.isEditForm) {
      //console.log('edit user', user.value);
      emit('editUser', user.value);
    } else {
      //console.log('add user', user.value);
      //emit('addTestUser');
      emit('addUser', user.value);
    }
    isShowUserForm.value = false;
  }
</script>
