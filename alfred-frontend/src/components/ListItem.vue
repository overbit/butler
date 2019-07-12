<template>
    <b-list-group-item>{{text}}</b-list-group-item>
</template>

<script>
    export default {
        name: 'ListItem',
        props: {
            list: Array,
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
