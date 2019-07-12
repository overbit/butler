<template>
    <div class="List">
        <h1>List</h1>
        <b-list-group>
            <ListItem v-for="item in List"/>
        </b-list-group>
    </div>
</template>

<script>
    export default {
        name: 'List',
        props: {
            List: Array,
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
