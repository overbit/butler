<template>
    <b-col md-12>
    <b-card no-body class="overflow-hidden mb-4" >

        <b-card-img-lazy :src=url 
                        class="img-top card-img"
                        @error.native="setFallbackImageUrl"/>
        <b-card-body :title=title>
            <ul class="list-group list-group-flush">
                <li class="list-group-item">
                    <div class="row"> 
                        <div class="col"><strong>Description</strong>: {{item.productDescriptionHtml}}
                    </div>
                    <div class="col-4"> 
                        <span :class=getStarRatings()></span>
                        <a class="text-nowrap" :href=datasheetUrl>Reviews <span class="badge badge-secondary"  v-html="item['reviewCount']"/></a>
                    </div>
                     
                    </div>
                </li>        
            <ItemProperty  v-for="p in properties"
                  v-bind:item="p"
                  v-bind:key="p.name" 
                  v-show="properties.length > 0"/>
            </ul>
        </b-card-body>
        <b-card-body>
            <b-button class="float-right" variant="success" v-on:click="gotoDatasheet">Datasheet</b-button>
        </b-card-body>

    </b-card>
    </b-col>
</template>

<script>/* eslint-disable */
    import ItemProperty from '@/components/ItemProperty.vue';

    export default {
        name: 'Card',
        props: {
            item: Object,
        },
        components: {
            ItemProperty,
        },
        data() {
            return {
                product: Object,
                properties: Array,
                title: "",
                url: "",
                applications: "",
                datasheetUrl: this.$abcamDomain + "/" + this.item.productCode,
                applicationVariants: ["primary", "secondary", "success", "danger", "warning", "info", "light", "dark"]
            }
        },
        methods: {
            gotoDatasheet(){
                window.location.href = this.datasheetUrl;
            },
            getStarRatings(){
                if(this.item["starRating"])
                    return  "pws_ratings star_".concat(this.item["starRating"]);
                else
                    return "d-none";
            },
            getProperties(prop){
                let that = this;
                let visibleProperties = [];
   
                for (let i = 0; i < prop.visibleProperties.length; i++){
                    let tmpProperty = {};
                    tmpProperty.name = prop.visibleProperties[i].propertyName;
                    tmpProperty.value =  that.getParameterCaseInsensitive(prop, tmpProperty.name);
                    
                    if(tmpProperty.name == "ProductDescription"){
                        continue;
                    }
                    else if(tmpProperty.name == "Conjugate"){
                        tmpProperty.colour = that.getParameterCaseInsensitive(prop, "ConjugateColor");
                    }

                    visibleProperties.push(tmpProperty);
                }
                return visibleProperties;
            },
            getParameterCaseInsensitive(object, key) {
                return object[Object.keys(object)
                    .find(k => k.toLowerCase() === key.toLowerCase())
                ];
            },
            setFallbackImageUrl(event){
                event.target.src = 'https://a.static-abcam.com/CmsMedia/Media/lvoimage984x492px.jpg';
            }
        },
        created() {
        },
        mounted() {
            let that = this;
            //Default
            if (that.item.productCode != undefined) {
                that.properties = that.getProperties(that.item);

                that.title = that.item.productNameHtml.concat(" [", that.item.productCode, "]");
                if (that.item.images.length > 0)
                    that.url =  this.$abcamDomain + that.item.images[0];
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


.card{
    background-color:#fff;
    border:none;
    border-radius:.625rem;
    box-shadow:0 .46875rem 2.1875rem rgba(90,97,105,.1),0 .9375rem 1.40625rem rgba(90,97,105,.1),0 .25rem .53125rem rgba(90,97,105,.12),0 .125rem .1875rem rgba(90,97,105,.1)
}
.card>.list-group:first-child .list-group-item:first-child{
    border-top-left-radius:.625rem;
    border-top-right-radius:.625rem
}
.card>.list-group:last-child .list-group-item:last-child{
    border-bottom-right-radius:.625rem;
    border-bottom-left-radius:.625rem
}
.card .list-group-item{
    padding:.8125rem 1.875rem
}
.card .card-text{
    margin-bottom:1.5625rem
}
.card a:hover{
    text-decoration:none
}
.card-small{
    box-shadow:0 2px 0 rgba(90,97,105,.11),0 4px 8px rgba(90,97,105,.12),0 10px 10px rgba(90,97,105,.06),0 7px 70px rgba(90,97,105,.1)
}
.card-small .card-body,.card-small .card-footer,.card-small .card-header{
    padding:1rem 1rem
}
.card-body{
    padding:1.875rem
}
.card-body>p:last-child{
    margin-bottom:0
}
.card-title{
    font-weight:500;
    margin-bottom:.75rem
}
.card-subtitle{
    margin-top:-1.09375rem
}
.card-link{
    font-family:Poppins,-apple-system,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif
}
.card-link+.card-link{
    margin-left:1.875rem
}
.card-header{
    padding:1.09375rem 1.875rem;
    background-color:rgba(90,97,105,.06);
    border-bottom:none
}
.card-header:first-child{
    border-radius:.625rem .625rem 0 0
}
.card-footer{
    padding:1.09375rem 1.875rem;
    background-color:rgba(90,97,105,.06);
    border-top:none
}
.card-footer:last-child{
    border-radius:0 0 .625rem .625rem
}
.card-header-tabs{
    margin-bottom:-1rem;
    border-bottom:0
}
.card-header-tabs .nav-link,.card-header-tabs .nav-link:hover{
    border-bottom:transparent
}
.card-header-pills{
    margin-right:-.9375rem;
    margin-left:-.9375rem
}
.card-header-pills:hover{
    background:0 0
}
.card-img-overlay{
    padding:1.875rem 2.1875rem;
    background:rgba(90,97,105,.5);
    border-radius:.625rem
}
.card-img-overlay .card-title{
    color:#fff
}
.card-img{
    border-radius:.625rem
}
.card-img-top{
    border-top-left-radius:.625rem;
    border-top-right-radius:.625rem
}
.card-img-bottom{
    border-bottom-right-radius:.625rem;
    border-bottom-left-radius:.625rem
}
.card-deck .card{
    margin-bottom:.9375rem
}
@media (min-width:576px){
    .card-deck{
        margin-right:-.9375rem;
        margin-left:-.9375rem
    }
    .card-deck .card{
        margin-right:.9375rem;
        margin-left:.9375rem
    }
}
.card-group>.card{
    box-shadow:0 .46875rem 2.1875rem rgba(90,97,105,.1),0 .9375rem 1.40625rem rgba(90,97,105,.1),0 .25rem .53125rem rgba(90,97,105,.12),0 .125rem .1875rem rgba(90,97,105,.1)
}
.card-group>.card:last-child .card-body,.card-group>.card:last-child .card-footer{
    border-right:none
}
.card-group .card-body,.card-group .card-footer{
    border-right:1px solid #e7e9ea
}
@media (min-width:576px){
    .card-group{
        box-shadow:0 .46875rem 2.1875rem rgba(90,97,105,.1),0 .9375rem 1.40625rem rgba(90,97,105,.1),0 .25rem .53125rem rgba(90,97,105,.12),0 .125rem .1875rem rgba(90,97,105,.1);
        border-radius:.625rem
    }
    .card-group>.card{
        box-shadow:none
    }
    .card-group>.card:first-child{
        border-top-right-radius:0;
        border-bottom-right-radius:0
    }
    .card-group>.card:last-child{
        border-top-left-radius:0;
        border-bottom-left-radius:0
    }
    .card-group>.card:only-child{
        border-radius:.625rem
    }
    .card-group>.card:only-child .card-header,.card-group>.card:only-child .card-img-top{
        border-top-left-radius:.625rem;
        border-top-right-radius:.625rem
    }
    .card-group>.card:only-child .card-footer,.card-group>.card:only-child .card-img-bottom{
        border-bottom-right-radius:.625rem;
        border-bottom-left-radius:.625rem
    }
    .card-group>.card:not(:first-child):not(:last-child):not(:only-child){
        border-radius:0
    }
    .card-group>.card:not(:first-child):not(:last-child):not(:only-child) .card-footer,.card-group>.card:not(:first-child):not(:last-child):not(:only-child) .card-header,.card-group>.card:not(:first-child):not(:last-child):not(:only-child) .card-img-bottom,.card-group>.card:not(:first-child):not(:last-child):not(:only-child) .card-img-top{
        border-radius:0
    }
}
.card-columns .card{
    margin-bottom:2.1875rem
}
@media (min-width:576px){
    .card-columns{
        -webkit-column-count:3;
        column-count:3;
        -webkit-column-gap:1.25rem;
        column-gap:1.25rem
    }
}
</style>
