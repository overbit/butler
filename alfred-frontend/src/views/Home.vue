<template>
    <div class="home">
        <h1>Alfred, at your service Master Bruce</h1>
        <div id="search-form">
            <FacetCategory v-for="fc in facetCategoryList"
                           v-bind:facetCategory="fc"
                           v-bind:selectedFacets="selectedFacets"
                           v-bind:key="fc.id" 
                           v-on:facet-selected="" />
            <b-button variant="outline-primary" v-on:click="doStuff">Click me</b-button>
        </div>
        <div v-if="error && error.response && error.request"> 
            <p> <strong>Request</strong><br>
                Url: {{ error.request.url}}<br>
                Method: {{ error.request.method}}<br>
            </p>
            <p>
                <strong> Response: </strong><br>
                Status:  {{error.response.status}}     <br>  

                <!-- Status: {{error.response.status}}     <br>      
                Data: {{error.response.data}}           <br>
                Headers: {{error.response.headers}}       <br> -->
            </p>       
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    import client from '@/client.js';
    import FacetCategory from '@/components/FacetCategory.vue';

    export default {
        name: 'home',
        components: {
            FacetCategory
        },
        data() {
            return {
                error: null,
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
                /* eslint-disable no-console */
                //console.log(this);
                /* eslint-enable no-console */
                let that = this;

                window.location.href ="http://dev.abcam.com/products?"
                + "keywords=" + that.selectedFacets["TargetName"]
                // + "&selected.targetName=" +  that.selectedFacets["TargetName"] 
                + "&selected.targetName=" +  that.selectedFacets["TargetName"] 
                + "&selected.application=" + that.selectedFacets["Application"] 
                + "&selected.hostSpecies=" + that.selectedFacets["HostSpecies"] 
                + "&selected.reactivity=" + that.selectedFacets["Reactivity"] ;

                // axios.post('/alfred/product', that.selectedFacets)
                //     .then(function (response) {
                //         this.msg = response.data;
                //     });
            }
        },
        created() {
            let that = this;
            that.selectedFacets = that.reqBody;
            
            that.facetCategoryList = client.facets(that.reqBody, that.error);
        }
    }
</script>

<style>
</style>