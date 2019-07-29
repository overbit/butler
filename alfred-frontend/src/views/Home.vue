<template>
    <div class="home">
        <h1>Alfred, at your service Master Bruce</h1>
        <div id="search-form container">
                <FacetCategory v-for="fc in facetCategoryList"
                               v-bind:facetCategory="fc"
                               v-bind:selectedFacets="selectedFacets"
                               v-bind:key="fc.id"
                               v-on:new-selection="updateFacetCategoryList" />
                <b-row>
                    <b-col></b-col>
                    <b-col cols="3">
                        <b-button block variant="outline-primary" v-on:click="search">Search</b-button>
                    </b-col>
                    <b-col></b-col>
                </b-row>
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
                //reqBody: {
                //    "TargetName": "",
                //    "Application": "",
                //    "Reactivity": "",
                //    "HostSpecies": "",
                //    "RequiredFacets": ["TargetName", "Application", "Reactivity", "HostSpecies"]
                //},
                facetCategoryList: [],
                msg: null,
                searchKeyword: null,
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
            search: function () {
                /* eslint-disable no-console */
                //console.log(this);
                /* eslint-enable no-console */
                let that = this;

                window.location.href ="http://dev.abcam.com/products?"
                + "keywords=" + that.selectedFacets["TargetName"]
                + "&selected.targetName=" +  that.selectedFacets["TargetName"] 
                + "&selected.application=" + that.selectedFacets["Application"] 
                + "&selected.hostSpecies=" + that.selectedFacets["HostSpecies"] 
                + "&selected.reactivity=" + that.selectedFacets["Reactivity"] ;

                // axios.post('/alfred/product', that.selectedFacets)
                //     .then(function (response) {
                //         this.msg = response.data;
                //     });
            },
            async updateFacetCategoryList(sel) {
                /* eslint-disable no-console */

                let that = this;
                let modCategory = that.facetCategoryList.filter(function (item) { return item.Name === sel.category })[0];
                let modIndex = that.facetCategoryList.indexOf(modCategory);

                that.selectedFacets[sel.category] = sel.id;

                let updatedList = await client.facets(that.selectedFacets);
                
                for (let i = modIndex + 1; i < that.facetCategoryList.length; i++) {
                    let item = that.facetCategoryList[i];
                    if (item.Name != modCategory.Name) {
                        let newVal = updatedList.filter(function (i) { return i.Name === item.Name })[0];
                        // Workaround due to limitations in JavaScript. https://vuejs.org/v2/guide/list.html#Caveats
                        that.facetCategoryList.splice(i, 1, newVal);
                        item = that.facetCategoryList[i];

                        that.mapFacetOptions(item);
                    }
                }
            },
            mapFacetOptions(fc) {
                console.log(fc);
                fc.FacetOptions = fc.Facets.map(function (item) {
                    let value = item.name + '   ' + item.count ;
                    return { id: item.name, name: value }
                })
            }
        },
        async created() {
            let that = this;

            that.facetCategoryList = await client.facets(that.selectedFacets);
            for (let i = 0; i < that.facetCategoryList.length; i++)
                that.mapFacetOptions(that.facetCategoryList[i])
        }
    }
</script>

<style>
    .home{
        max-width:1000px;
    }
    div{
        margin-top:0.5em;
    }
</style>