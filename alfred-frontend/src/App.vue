<template>
    <div id="app">
        <Home msg="Hello world!" />
        <Search v-for="fc in facetCategoryList"
                v-bind:facetCategory="fc"
                v-bind:selectedFacets="selectedFacets"
                v-bind:key="fc.id" />
        <b-button variant="outline-primary" v-on:click="doStuff">Click me</b-button>
        <List v-if=""></List>
    </div>
</template>

<script>
    import Home from './components/Home.vue'; 
    import List from './components/List.vue'; 
    import Search from './components/Search.vue';
    import axios from 'axios'

    export default {
        name: 'app',
        components: {
            Home,
            Search,
            List
        },
        data() {
            return {
                reqBody: {
                    "TargetName": "",
                    "Application": "",
                    "Reactivity": "",
                    "HostSpecies": "",
                    "RequiredFacets": ["TargetName", "Application", "Reactivity", "HostSpecies"]
                }, 
                facetCategoryList: [],
                msg: null,
                selectedFacets:{
                    "TargetName": "",
                    "Application": "",
                    "Reactivity": "",
                    "HostSpecies": "",
                    "RequiredFacets": ["TargetName", "Application", "Reactivity", "HostSpecies"]
                }, 
                //facetCategory : { Name, Facets : { Name, Count, } }
            }
        },
        methods: {
            doStuff: function () {
                //window.location = "http://dev.abcam.com/products"
                
                let that = this;
                axios.post('https://localhost:44384/api/alfred/product', that.selectedFacets)
                .then(function (response) {
                    this.msg = response.data;
                });
            }
        },
        created() {
            this.selectedFacets = this.reqBody;

            let that = this;
            /* eslint-disable no-console */
            //console.log(this);
            /* eslint-enable no-console */

            axios.post('https://localhost:44384/api/alfred/facet', that.reqBody)
                .then(function (response) {
                    response.data.forEach(function (el) {

                        that.facetCategoryList.push(
                            {
                                Name: el.name,
                                Facets: el.facets
                            }
                        );
                    });
            });
        }
    };
</script>

<style>
    body{
        font-family:'Century Gothic';
    }
</style>
