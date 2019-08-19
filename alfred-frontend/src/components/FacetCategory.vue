<template>
    <b-row align-content="center" v-if="facetCategory.FacetOptions.length > 0">
        <div class="col">
            <h5>{{facetCategory.Name}}</h5>
        </div>
        <div class="col">
            <Dropdown :options=facetCategory.FacetOptions
                        :name=categoryName
                        :maxItem=maxDropdownItems
                        :disabled="disabled || facetCategory.disabled"
                        v-on:selected="saveSelection"
                        :placeholder="getPlaceholder()">
            </Dropdown>
        </div>
    </b-row>

</template>

<script>
    import Dropdown from '@/components/Dropdown.vue';
    import { String } from 'core-js';

    export default {
        name: 'FacetCategory',
        components: {
            Dropdown
        },
        props: {
            disabled: Boolean,
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
                selectedFacet: String,
                placeholder: String
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
            updatedCustomOption(){
                this.$emit('new-custom-option', this.customOption);
            }
            //confirmSelection() { 
            //    this.$emit('new-selection', this.selectedFacet);
            //}
            , getPlaceholder() {
                if (this.facetCategory.disabled)
                    return "No futher options available";
                else
                    return "Please select an option";
            }
        },
        //created() {

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
