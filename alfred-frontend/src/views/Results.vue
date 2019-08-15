<template>
    <div class="section section-invert clearfix">
        <h2 class="section-title text-center m-5">Search results</h2>
        <div class="text-center m-5">
    
            <b-button variant="outline-primary"
                    v-on:click="gotoHome">
                    Start again
            </b-button>

            <b-button variant="outline-secondary" 
                    v-on:click="gotoPWS">
                    Search on abcam.com
            </b-button>
    
        </div>
        
        <div class="card-deck">
        <ListItem class="col-md-12 col-lg-4" v-for="item in items"
                  v-bind:item="item"
                  v-bind:key="item.productCode" 
                  v-show="items.length > 0"/>
        </div>  

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
                size: 3
            }
        },
        components: {
            ListItem
        },
        methods: {
            gotoPWS() {
                let that = this;
                window.location.href = "http://www.abcam.com/products?"
                + "keywords=" + that.searchKeyword
                + "&selected.targetName=" +  that.selectedFacets["TargetName"] 
                + "&selected.application=" + that.selectedFacets["Application"] 
                + "&selected.hostSpecies=" + that.selectedFacets["HostSpecies"] 
                + "&selected.reactivity=" + that.selectedFacets["Reactivity"] ;
            },
            gotoHome() {
                this.$router.push('/');
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

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.btn {
    margin-left: 2rem;
    margin-right: 2rem;
}

</style>