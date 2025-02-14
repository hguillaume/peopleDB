<template>
    <div class="weather-component">
        <h1>Welcome Users</h1>

        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="post" class="content">
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Email</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="user in post">
                        <td>{{ user.name }}</td>
                        <td>{{ user.email }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    type Users = {
        name: string,
        email: string,
    }[];

    interface Data {
        loading: boolean,
        post: null | Users
    }

    export default defineComponent({
        data(): Data {
            return {
                loading: false,
                post: null
            };
        },
        async created() {
            // fetch the data when the view is created and the data is
            // already being observed
            await this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            async fetchData() {
                this.post = null;
                this.loading = true;

                var response = await fetch('/api/users');
                if (response.ok) {
                    this.post = await response.json();
                    this.loading = false;
                }
            }
        },
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
