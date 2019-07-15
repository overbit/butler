<template>
    <div class="List">
        <h1>List</h1>
        <p>{{msg}}</p>
        <!--<b-list-group>
            <ListItem v-for="item in List"/>
        </b-list-group>-->
    </div>
</template>

<script>
    export default {
        name: 'List',
        props: {
            List: Array,
            msg: String
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
