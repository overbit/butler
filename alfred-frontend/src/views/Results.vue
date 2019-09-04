<template>
    <div class="section">
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
            
        <ListItem class="col-md-6 col-lg-4" v-for="item in items" 
                  v-bind:item="item"
                  v-bind:key="item.productCode" 
                  v-show="items.length > 0"/>
        </div>  

        <b-row align-h="center">
            <b-button v-on:click="loadMore"
                      v-show="items && items.length > 0 && showMoreButton()"
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
            selection: Object,
        },
        data() {
            return {
                items: Array,
                page: Number,
                size: 3,
                totalItems: 0
            }
        },
        components: {
            ListItem
        },
        methods: {
            gotoPWS() {
                let that = this;
                window.location.href = this.$abcamDomain +  "/products?"
                + "keywords=" + that.selection.Keyword
                + "&selected.targetName="   +  that.selection.Facets.TargetName 
                + "&selected.application="  + that.selection.Facets.Application 
                + "&selected.hostSpecies="  + that.selection.Facets.HostSpecies 
                + "&selected.reactivity="   + that.selection.Facets.Reactivity ;
            },
            gotoHome() {
                this.$router.push('/');
            },
            async loadMore() {
                this.page++;
                let newResults = await this.getResults(this.page);
                this.items = this.items.concat(newResults);
            },
            async getResults(page = 1) {
                let that = this;
                let results = [];
                let searchRequest = that.$attrs.selection;
                let res = await client.products(searchRequest, page, this.size);

                if (res && res["products"]) {
                    results = res["products"].map(function (item) {
                        let tmp = new Object;
                        tmp = item.productIndexModel;
                        tmp.visibleProperties = item.visibleProperties;
                       
                        return item.productIndexModel;
                    })
                }

                this.totalItems = res["totalItems"];
                return results;
            },
            showMoreButton(){
                let currResultsDisplayed = this.page * this.size;
                if(currResultsDisplayed >= this.totalItems){
                    return false;
                }
                return true;
            }   
        },
        async mounted() { 
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
.section{
    padding: 0 20px 20px 20px;
}
</style>