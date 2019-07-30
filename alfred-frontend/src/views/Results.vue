<template>
    <div class="results">
        <h4>Search results</h4>
        <b-button block 
                  variant="outline-primary" 
                  v-on:click="gotoPWS"
                  v-show="results && results.length > 0"> Search</b-button>
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
                results: Array
            }
        },
        components: {
            ListItem
        },
        methods: {
            gotoPWS() {
                let that = this;
                window.location.href = "http://dev.abcam.com/products?"
                + "keywords=" + that.searchKeyword
                + "&selected.targetName=" +  that.selectedFacets["TargetName"] 
                + "&selected.application=" + that.selectedFacets["Application"] 
                + "&selected.hostSpecies=" + that.selectedFacets["HostSpecies"] 
                + "&selected.reactivity=" + that.selectedFacets["Reactivity"] ;
            }
        },
        async created() { 
            let that = this;
            that.selectedFacets = that.$attrs.selectedFacets;
            that.searchKeyword = that.$attrs.searchKeyword;
            
            /* eslint-disable no-console */
 
            let res = await client.products(this.selectedFacets);

            if (res && res["products"]) {
                that.results= res["products"].map(function (item) {
                    return item.productIndexModel;
                })
            }
            else
                that.results = [];

            console.log("that.results", that.results);
        }
    }
</script>