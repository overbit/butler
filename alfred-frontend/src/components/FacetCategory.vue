<template>
    <div class="facet-category row" v-if="facetCategory.FacetOptions.length > 0">
        <div class="col-sm-2">
            <h5>{{facetCategory.Name}}</h5>
        </div>
        <div class="col-sm-3">
            <Dropdown :options=facetCategory.FacetOptions
                        :name=categoryName
                        :maxItem=maxDropdownItems
                        v-on:selected="saveSelection"
                        placeholder="Please select an option">
            </Dropdown>
        </div>
        <div v-if="facetCategory.Name === 'TargetName'" class="col-sm-6"  >
            If you cannot find the target add it here:
            <input v-model="customOption" placeholder="p53" />
        </div>
        <!--<b-button v-on:click="confirmSelection">Confirm</b-button>-->
    </div>

</template>

<script>
    import Dropdown from 'vue-simple-search-dropdown';
    import { String } from 'core-js';

    export default {
        name: 'FacetCategory',
        components: {
            Dropdown
        },
        props: {
            facetCategory: Object,
            selectedFacets: Object
            },
        data() {
            return {
                //options: this.facetCategory.Facets.map(function (item) {
                //    let value = item.name + '   ' + item.count ;
                //    return { id: item.name, name: value }
                //}),
                customOption: null,
                categoryName: this.facetCategory.Name,
                maxDropdownItems: this.facetCategory.Facets.length,
                selectedFacet: String
            }
        },
        methods: {
            saveSelection(selection) {
                this.selectedFacet = {
                    category : this.categoryName,
                    id: selection.id,
                    customOption: this.customOption
                };

                this.$emit('new-selection', this.selectedFacet);
            },
            //confirmSelection() { 
            //    this.$emit('new-selection', this.selectedFacet);
            //}
        },
        //created() {
        //    console.log({ created: this });
        //},
        //mounted() {
        //    console.log({ mounted: this });
        //}
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    h5{
        margin: 0 1em 0 1em;
    }
</style>
