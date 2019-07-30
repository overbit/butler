<template>
    <b-card no-body class="overflow-hidden" style="font-size: smaller;">
        <b-row no-gutters>
            <b-col md="2">
                <b-card-img-lazy :src=url class="rounded-0" style=""></b-card-img-lazy>
            </b-col> 
            <b-col md="6">
                <b-card-body :title=item.productNameHtml>
                    <b-card-text>
                        <p><strong>Description</strong>: {{item.productDescriptionHtml}}</p>
                        <p><strong>Application</strong>: <span v-html="applications" style="font-size:larger;"></span></p>
                        <p><strong>Reactivity</strong>: {{item.Reactivity}}</p>
                        <p v-show="item.conjugate"><strong>Conjugation</strong>: {{item.conjugate}}</p>
                        <p><strong>Alternative Names</strong>: {{item.AlternativeNames}}</p>
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
                product: Object,
                url: String,
                applications: String,
                applicationVariants: ["primary", "secondary", "success", "danger", "warning", "info", "light", "dark"]
            }
        },
        methods: {
            getApplications(list) {
                if (!list) {
                    return;
                }
                let res = [];
                for (let i = 0; i < list.length; i++) {
                    let curr = list[i];
                    let hash = this.getHashForString(curr);
                    let appVariant = this.applicationVariants[hash % 7];

                    res.push("<span class='badge badge-" + appVariant + "'>"+curr+"</span>")
                }
                return res;
            },
            getHashForString(s){
                  return s.split("").reduce(function(a,b){a=((a<<5)-a)+b.charCodeAt(0);return a&a},0);              
            },
            listToString(l) {
                if (!l) {
                    return;
                }
                let r = "";
                for (let i = 0; i < l.length; i++) {
                    r += l[i];
                    if (i !== l.length - 1)
                        r+="  "
                }
                return r;
            }
        },
        created() {
        /* eslint-disable no-console */
            //Default
            this.url = "https://placekitten.com/" + (Math.floor(Math.random() * 10) + 600) + "/400/";
            if (this.item) {
                if (this.item.images )
                    this.url =  "https://bau-ci.abcam.com"+this.item.images[0];

                this.applications = this.listToString(this.getApplications(this.item["application"]));

                this.item.Reactivity = this.listToString(this.item["reactivity"]);

                this.item.AlternativeNames = this.listToString(this.item["alternativeName"]);
                }

        },
        mounted() {

        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.card-img {
    width: 100%;
    height: 15vw;
    object-fit: cover;
}
</style>
