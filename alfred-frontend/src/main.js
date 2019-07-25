import Vue from 'vue';
import App from './App.vue';
import router from './router'
import store from './store'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import axios from 'axios'

Vue.use(BootstrapVue);
require('dotenv').config();

axios.defaults.baseURL = process.env.VUE_APP_ALFRED_API_BASEURL;

Vue.config.productionTip = true;
Vue.prototype.$http = axios;

new Vue({
    router,
    store,
    render: h => h(App)
}).$mount('#app');
