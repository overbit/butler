<template>
    <div>
        <h2 class="section-title text-center m-5">Fill the following and I'll do the rest</h2>
        <b-container id="search-form">

            <FacetCategory v-for="fc in facetCategoryList"
                        v-bind:facetCategory="fc"
                        v-bind:selectedFacets="selectedFacets"
                        v-bind:disabled="buttonDisabled"
                        v-bind:key="fc.id"
                        v-on:new-selection="updateFacetCategoryList"
                        v-on:new-custom-option="updatedCustomOption" />            
            
            <b-row class="py-4" align-h="center">
                <b-col cols="4">
                    <b-button block variant="" v-on:click="resetSelection">Reset</b-button>
                </b-col>
                <b-col cols="4">
                    <b-button block variant="success" v-on:click="search" :disabled="!!buttonDisabled">Search</b-button>
                </b-col>
            </b-row>  
    
        </b-container>
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
                buttonDisabled: null,
                facetCategoryList: [],
                searchKeyword: "",
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
            resetSelection() {
                this.$router.go();
            },
            search() {
                /* eslint-disable no-console */
                
                let that = this;
                let params = { searchKeyword: that.searchKeyword, selectedFacets: that.selectedFacets };
                this.$router.push({ name: 'results', params: params });
            },
            updatedCustomOption(sel){
                this.searchKeyword = sel;
            },
            async updateFacetCategoryList(sel) {
                this.buttonDisabled = true;
                /* eslint-disable no-console */
                if (!sel.id && !sel.customOption) {
                    this.buttonDisabled = null;
                    return;
                }

                let that = this;
                
                that.selectedFacets[sel.category] = sel.id;

                let updatedList = await client.facets(that.selectedFacets);

                for (let i = 0; i < that.facetCategoryList.length; i++) {
                    let item = that.facetCategoryList[i];
                    
                    let newVal = updatedList.filter(function (i) { return i.Name === item.Name })[0];

                    if (newVal) {
                        // Workaround due to limitations in JavaScript. https://vuejs.org/v2/guide/list.html#Caveats
                        that.facetCategoryList.splice(i, 1, newVal);
                        item = that.facetCategoryList[i];
                        that.mapFacetOptions(item);
                    }
                    else {
                        newVal = item;
                        newVal.disabled = true;
                        that.facetCategoryList.splice(i, 1, newVal);
                    }
                }
                
                for (let i = that.facetCategoryList.length - 1; i >= 0; i--) {
                    if (that.facetCategoryList[i].remove)
                        that.facetCategoryList.pop();
                }

                this.buttonDisabled = null;
            },
            mapFacetOptions(fc) {
                fc.FacetOptions = fc.Facets.map(function (item) {
                    let value = item.name + ' (' + item.count +')';
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
#search-form{
    justify-content:flex-end;
    max-width : 600px
}
</style>