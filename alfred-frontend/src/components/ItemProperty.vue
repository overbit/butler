<template>
    <li class="list-group-item" v-show="property.value && property.value != ''">
        <strong>{{property.name}}</strong>: <span v-html="property.value" v-bind:style="property.styles" /> 
    </li>
</template>

<script>
    export default {
        name: 'ItemProperty',
        props: {
            item: Object,
        },
        data() {
            return {
                property: Object,
                applicationVariants: ["primary", "secondary", "success", "danger", "warning", "info", "light", "dark"]
            }
        },
        methods: {
            getApplicationsBadged(list) {
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
            toHtml(list) {
                if (!list) {
                    return;
                }
                let r = "";
                for (let i = 0; i < list.length; i++) {
                    r += list[i];
                    if (i !== list.length - 1)
                        r+="  "
                }
                return r;
            }
        },
        created() {
        },
        mounted() {
            let that = this;
            that.property = that.item;

            if (Array.isArray(that.property.value)){
                switch (that.property.name){
                    case "Application":
                        that.property.value = that.getApplicationsBadged(that.item.value);
                        break;
                }
                that.property.value = that.toHtml(that.property.value);
            }

            if (that.property.colour){
                that.property.styles = { color: that.item.colour, 'font-weight' : 'bolder' };
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
