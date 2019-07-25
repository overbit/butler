<template>
    <div class="results">
        <h1>This is an about page</h1>

        <ListItem v-for="item in itemList"
                  v-bind:item="item"
                  v-bind:key="item.id" />
    </div>
</template>

<script>
    // @ is an alias to /src
    import ListItem from '@/components/ListItem.vue';

    export default {
        name: 'results',
        prop: {
            itemList: Array
        },
        data() {
            return {
                itemList : {}
            }
        },
        components: {
            ListItem
        },
        created() {
            /* eslint-disable no-console */
            console.log({ "itemlist": itemList });
            /* eslint-enable no-console */
        }
    }
</script>