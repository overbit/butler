<template>
    <div>
        <nav class="navbar navbar-light navbar-expand-md navigation-clean-button" id="mainNav">
            <div class="container">
                <a class="navbar-brand pws-logo" href="/"></a>
                <button data-toggle="collapse" data-target="#navcol-1" class="navbar-toggler noborder">
                    <span class="navbar-text actions">Alfred</span>
                </button>
                <div class="collapse navbar-collapse" id="navcol-1">
                    <ul class="nav navbar-nav mr-auto"></ul>
                    <span class="navbar-text actions">Alfred here Sir, at your service</span>
                </div>
            </div>
        </nav>
                
        <router-view />
    </div>
</template>

<style>
    @import url(./assets/shards.min.css);
    @import url(./assets/shards-demo.min.css);
    @import url(./assets/shards-extras.min.css);
    @import url(./assets/styles.css);
    @import url(./assets/buttons.css);
    @import url(./assets/rating.css);
</style>
<style scoped>
.container {
    max-width: 100%;
}
</style>