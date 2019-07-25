import axios from 'axios';

export default {
    /*--------Ajax--------*/
    facets(req) {
        let list = [];
        /* eslint-disable no-console */
        axios.post('/alfred/facet', req)
            .then(response => {
                response.data.forEach(function (el) {
                    list.push(
                        {
                            Name: el.name,
                            Facets: el.facets
                        }
                    );
                });
            })
            .catch(function (error) {
                if (error.response) {
                    // The request was made and the server responded with a status code
                    // that falls out of the range of 2xx
                    console.log(error.response.data);
                    console.log(error.response.status);
                    console.log(error.response.headers);
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
        /* eslint-enable no-console */

        return list;
    }
}