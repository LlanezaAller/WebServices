module.exports = (app) => {
    const rootUri = app.get('movies-api-endpoint');
    const httpClient = new(require('node-rest-client').Client)();

    return {
        findById(id) {
            return new Promise((resolve, reject) => {
                console.log(`${rootUri}/movie/id/${id}`);
                httpClient.get(`${rootUri}/movie/id/${id}`, (data, response) => {
                    //console.log('[Movie.Repository] Find by ID Data', data);
                    resolve(data);
                });
            })
        },
        findByTitle(title) {
            return new Promise((resolve, reject) => {
                console.log(`${rootUri}/movie/name/${title}`);
                httpClient.get(`${rootUri}/movie/name/${title}`, (data, response) => {
                    //console.log('[Movie.Repository] Find By Name Data', data);
                    resolve(data);
                });
            });
        }
    }
}