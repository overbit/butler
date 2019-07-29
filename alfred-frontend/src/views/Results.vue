<template>
    <div class="results">
        <h1>This is an about page</h1>

        <ListItem v-for="item in results"
                  v-bind:item="item"
                  v-bind:key="item.id" />
    </div>
</template>

<script>
    // @ is an alias to /src
    import client from '@/client.js';
    import ListItem from '@/components/ListItem.vue';
    import { Array } from 'core-js';

    export default {
        name: 'results',
        prop: {
            selectedFacets: Array,
            searchKeyword: String
        },
        data() {
            return {
                results : []
            }
        },
        components: {
            ListItem
        },
        methods: {
            async getResult() {
                this.results = await client.products(this.selectedFacets);
            }
        },
        created() { 
            let that = this;
            that.selectedFacets = that.$attrs.selectedFacets;
            that.searchKeyword = that.$attrs.searchKeyword;

            that.getResult();
            //window.location.href = "http://dev.abcam.com/products?"
            //+ "keywords=" + that.searchKeyword
            //+ "&selected.targetName=" +  that.selectedFacets["TargetName"] 
            //+ "&selected.application=" + that.selectedFacets["Application"] 
            //+ "&selected.hostSpecies=" + that.selectedFacets["HostSpecies"] 
            //+ "&selected.reactivity=" + that.selectedFacets["Reactivity"] ;
        }
    }
</script>