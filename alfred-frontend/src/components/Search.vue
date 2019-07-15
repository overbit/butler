<template>
    <div class="search">
        <h2>{{facetCategory.Name}}</h2>
        <!--<p>{{ facetCategory.text }}</p>-->

        <Dropdown :options=options
                  :name=categoryName
                  :maxItem=maxDropdownItems
                  v-on:selected="saveSelection"
                  placeholder="Please select an option">
        </Dropdown>
    </div>

</template>

<script>
    import Dropdown from 'vue-simple-search-dropdown';

    export default {
        name: 'Search',
        components: {
            Dropdown
        },
        props: {
            facetCategory: Object,
            selectedFacets: Object
            },
        data() {
            return {
                options: this.facetCategory.Facets.map(function (item) {
                    return { id: item.name, name: item.name }
                }),
                categoryName: this.facetCategory.Name,
                maxDropdownItems: this.facetCategory.Facets.length
            }
        },
        methods: {
            saveSelection(selection) {
                this.selectedFacets[this.categoryName] = selection.id;
                
                /* eslint-disable no-console */
                console.log({ selectedFacets: this.selectedFacets });
            }
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
</style>
