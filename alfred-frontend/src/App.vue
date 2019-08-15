<template>
    <div id="app" class="shards-landing-page--1">
        <!--<div id="nav">
            <router-link to="/">Search</router-link> |
            <router-link to="/results">Results</router-link>
        </div>-->
        <router-view />
    </div>
</template>

<style>
    #app {
        /*font-family: 'Avenir', Helvetica, Arial, sans-serif;*/
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        /*text-align: center;*/
        color: #2c3e50;
        padding: 20px;
    }

    #nav {
        padding: 30px;
    }

    #nav a {
        font-weight: bold;
        color: #2c3e50;
    }

    #nav a.router-link-exact-active {
        color: #42b983;
    }
    @import url(./assets/shards.min.css);
    @import url(./assets/shards-demo.min.css);
    @import url(./assets/shards-extras.min.css);
</style>
