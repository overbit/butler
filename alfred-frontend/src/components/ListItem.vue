<template>
    <b-card no-body class="overflow-hidden" style="">
        <b-row no-gutters>
            <b-col md="1">
                <b-card-img :src=url class="rounded-0"></b-card-img>
            </b-col>
            <b-col md="6">
                <b-card-body :title="item">
                    <b-card-text>
                        This is a wider card with supporting text as a natural lead-in to additional content.
                        This content is a little bit longer.
                    </b-card-text>
                </b-card-body>
            </b-col>
        </b-row>
    </b-card>
</template>

<script>
    export default {
        name: 'ListItem',
        props: {
            item: Object,
        },
        data() {
            return {
                url: "https://placekitten.com/" + (Math.floor(Math.random() * 10) + 600)  + "/400/"
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
