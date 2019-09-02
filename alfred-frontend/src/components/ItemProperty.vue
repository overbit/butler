<template>
    <li class="list-group-item" v-if="property.name == 'Application'">
        <strong>{{property.name}}</strong>: <span v-html="applications" style="font-size:larger;"></span>
    </li>
    <li class="list-group-item" v-else>
        <strong>{{property.name}}</strong>: {{property.value}}
    </li>
</template>

<script>
    export default {
        name: 'ListItem',
        props: {
            property: Object,
        },
        data() {
            return {
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
                window.location.href = "https://www.abcam.com/" + this.item["productCode"];
            }
        },
        created() {
        },
        mounted() {
            this.applications = this.listToString(this.getApplications(this.property.value));
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
