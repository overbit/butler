<template>
    <div class="results">
        <h4>Search results</h4>
        <b-button variant="outline-primary"
                  v-on:click="gotoPWS"
                  v-show="items && items.length > 0"
                  style="margin-top:2em">Search on abcam.com</b-button>
        <ListItem v-for="item in items"
                  v-bind:item="item"
                  v-bind:key="item.productCode" />
        <b-row align-h="center">
            <b-button v-on:click="loadMore"
                      v-show="items && items.length > 0"
                      style="margin-top:2em">Load more</b-button>
        </b-row>
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
                items: Array,
                page: Number,
                size: 2
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
            },
            async loadMore() {
            /* eslint-disable no-console */
                console.log("page", this.page);
                this.page++;
                let newResults = await this.getResults(this.page);
                console.log("newResults", newResults);
                console.log("this.items", this.items);
                console.log("this.items.concat(newResults", this.items.concat(newResults));
                this.items = this.items.concat(newResults);
                console.log("this.items after", this.items);
            },
            async getResults(page = 1) {
            /* eslint-disable no-console */
                let that = this;
                let results = [];
                that.selectedFacets = that.$attrs.selectedFacets;
                that.searchKeyword = that.$attrs.searchKeyword;
                let prodReq = that.selectedFacets;
                prodReq.keyword = that.searchKeyword;

                let res = await client.products(prodReq, page, this.size);

                if (res && res["products"]) {
                    results = res["products"].map(function (item) {
                        return item.productIndexModel;
                    })
                }
                return results;
            }
        },
        async created() { 
            this.page = 1;
            this.items = await this.getResults();
        }
    }
</script>