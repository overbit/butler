<template>
    <b-col md-12>
    <b-card no-body class="overflow-hidden mb-4" >

        <b-card-img-lazy :src=url class="img-top card-img" v-show="url != ''"></b-card-img-lazy>
        <b-card-body :title=title>
            <ul class="list-group list-group-flush">
                <li class="list-group-item">
                    <div class="row"> 
                        <div class="col"><strong>Description</strong>: {{item.productDescriptionHtml}}
                    </div>
                        <div class="col-4"> 
                            <span :class=getStarRatings()></span>
                            <a class="text-nowrap" :href=datasheetUrl> Reviews ( <span v-html="item['reviewCount']"/> )</a>
                        </div>
                     
                    </div>
                </li>
                <li class="list-group-item">
                    <strong>Application</strong>: <span v-html="applications" style="font-size:larger;"/></li>
                <li class="list-group-item" v-show="item.conjugate">
                    <strong>Conjugation</strong>: {{item.conjugate}}</li>
                <li class="list-group-item" v-show="item.Reactivity">
                    <strong>Reactivity</strong>: {{item.Reactivity}}</li>
                <li class="list-group-item" v-show="item.SampleType">
                    <strong>SampleType</strong>: {{item.SampleType}}</li>
                <li class="list-group-item text-truncate" :title=item.AlternativeNames>
                    <strong>Alternative Names</strong>: {{item.AlternativeNames}}</li>
            
            <!-- <ItemProperty class="col-md-6 col-lg-4" v-for="item in items"
                  v-bind:item="item"
                  v-bind:key="item.productCode" 
                  v-show="items.length > 0"/> -->
            </ul>
        </b-card-body>
        <b-card-body>
            <b-button class="float-right" variant="success" v-on:click="gotoDatasheet">Datasheet</b-button>
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
                title: "",
                url: "",
                applications: "",
                datasheetUrl: "https://www.abcam.com/" + this.item["productCode"],
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
            },
            gotoDatasheet(){
                window.location.href = this.datasheetUrl;
            },
            getStarRatings(){
                if(this.item["starRating"])
                    return  "pws_ratings star_".concat(this.item["starRating"]);
                else
                    return "d-none"
            }
        },
        created() {
       
        },
        mounted() {
            /* eslint-disable no-console */
            let that = this;
            //Default
            this.url = "";
            console.log({"this.item" : that.item});
            if (that.item.productCode != undefined) {
                
                that.title = that.item.productNameHtml.concat(" [", that.item.productCode, "]");
                
                if (that.item.images.length > 0)
                    that.url =  "https://www.abcam.com" + that.item.images[0];

                that.applications = that.listToString(that.getApplications(that.item["application"]));

                that.item.Reactivity = that.listToString(that.item["reactivity"]);

                that.item.AlternativeNames = that.listToString(that.item["alternativeName"]);

                that.item.SampleType = that.listToString(that.item["sampleType"]);
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.card-img {
    width: unset;
    padding: 1rem;
    object-fit: scale-down;
}
@media (min-width: 991px) {
        
    .card-img {
    /* width: 100%; */
    height: 15vw; 
    padding: 1rem;
    object-fit: scale-down;
    }
}
</style>
