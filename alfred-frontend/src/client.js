﻿import axios from 'axios';

export default {
    /*--------Ajax--------*/
    async api(url, req, params) {

        if (params)
            url += '?' + params;

        /* eslint-disable no-console */
        let urlLog = "alfred-request " + url;
        console.log(urlLog, req);

        return await axios.post(url, req)
            .catch(function (error) {
                if (error.response) {
                    // The request was made and the server responded with a status code
                    // that falls out of the range of 2xx
                    console.error({ data: error.response.data });
                    console.error({ status: error.response.status });
                    console.error({ headers: error.response.headers });
                } else if (error.request) {
                    // The request was made but no response was received
                    // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
                    // http.ClientRequest in node.js
                    console.log(error.request);
                } else {
                    // Something happened in setting up the request that triggered an Error
                    console.log('Error', error.message);
                }
                console.log(error.config); 
                alert("alfred-api not responding. Check console for more details");
            });

    },
    async facets(req) {
        let response = await this.api('/alfred/facet', req);
        let list = [];
        if (response) {
            console.log({ "alfred-response": response.data });
            response.data.forEach(function (el) {
                list.push(
                    {
                        Name: el.name,
                        Facets: el.facets
                    }
                );
            });
        }
        return list;
    },
    async products(req, page, size) {
        let params = "size=" + size + "&page=" + page;

        let response = await this.api('/alfred/product', req, params);
        if (response) {
            console.log({ "alfred-response": response.data });

            return response.data;
        }

    }
}