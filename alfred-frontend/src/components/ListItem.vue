<template>
    <div>
        <div class="card">
            <div class="card-body">
                <div class="d-flex flex-row">
                    <img src="" class="img-lg rounded" />
                    <div class="ml-3">
                        <h6>Thomas Edison</h6>
                        <p class="text-muted">thomas@gmail.com</p>
                        <p class="mt-2 text-success font-weight-bold">Developer</p>
                    </div>
                </div>
            </div>
        </div>

        <div class="list d-flex align-items-center pt-3">
            <img class="img-sm rounded-circle" src="" alt="">
            <div class="wrapper w-100 ml-3">
                <p class="mb-0"><b>Nateila </b>posted in Material</p>
                <div class="d-flex justify-content-between align-items-center">
                    <div class="d-flex align-items-center">
                        <i class="mdi mdi-clock text-muted mr-1"></i>
                        <p class="mb-0">That's awesome!</p>
                    </div>
                    <small class="text-muted ml-auto">1 hours ago</small>
                </div>
            </div>
        </div>
    </div>
    
</template>

<script>
    export default {
        name: 'ListItem',
        props: {
            item: Array,
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
