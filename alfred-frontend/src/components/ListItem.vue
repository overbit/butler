<template>
    <b-col md-12>
    <b-card no-body class="overflow-hidden mb-4" border-variant="success" >

        <b-card-img-lazy :src=url class="img-top card-img" v-show="url != ''"></b-card-img-lazy>
        <b-card-body :title=item.productNameHtml>
            <p><strong>Description</strong>: {{item.productDescriptionHtml}}</p>
            <b-card-text>
              
                        <p><strong>Application</strong>: <span v-html="applications" style="font-size:larger;"></span></p>
                        <p><strong>Reactivity</strong>: {{item.Reactivity}}</p>
                        <p v-show="item.conjugate"><strong>Conjugation</strong>: {{item.conjugate}}</p>
                        <p v-show="item.SampleType"><strong>SampleType</strong>: {{item.SampleType}}</p>
                        <p><strong>Alternative Names</strong>: {{item.AlternativeNames}}</p>
                   
            </b-card-text>
        </b-card-body>

    </b-card>
    </b-col>
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
                    let appVariant = this.applicationVariants[Math.abs(hash) % 7]; 

                    res.push("<span class='badge badge-" + appVariant + "'>"+curr+"</span>")
                }
                return res;
            },
            getHashForString(s){
                var hash = 0, i, chr;
                if (s.length === 0) return hash;
                    for (i = 0; i < s.length; i++) {
                        chr   = s.charCodeAt(i);
                        hash  = ((hash << 5) - hash) + chr;
                        hash |= 0; // Convert to 32bit integer
                    }
                return hash;    
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
            this.url = "";
            console.log(this.item);
            if (this.item) {
                if (this.item.images)
                    this.url =  "https://p2-ci.abcam.com" + this.item.images[0];

                this.applications = this.listToString(this.getApplications(this.item["application"]));

                this.item.Reactivity = this.listToString(this.item["reactivity"]);

                this.item.AlternativeNames = this.listToString(this.item["alternativeName"]);

                this.item.SampleType = this.listToString(this.item["SampleType"]);
            }
        },
        mounted() {

        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.card-img {
    /* width: 100%; */
    height: 15vw; 
    padding: 1rem;
    object-fit: scale-down;
}
.card-body{
    padding-top: 0;
    padding-bottom: 0;
}
</style>
