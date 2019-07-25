<template>
    <div class="home">
        <h1>Alfred, at your service Master Bruce</h1>
        <div id="Search">
            <FacetCategory v-for="fc in facetCategoryList"
                           v-bind:facetCategory="fc"
                           v-bind:selectedFacets="selectedFacets"
                           v-bind:key="fc.id" />
            <b-button variant="outline-primary" v-on:click="doStuff">Click me</b-button>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    import FacetCategory from '@/components/FacetCategory.vue';

    export default {
        name: 'home',
        components: {
            FacetCategory
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
                selectedFacets: {
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

                /* eslint-disable no-console */
                //console.log(this);
                /* eslint-enable no-console */

                let that = this;
                axios.post('/alfred/product', that.selectedFacets)
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

            axios.post('/alfred/facet', that.reqBody)
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
</style>

