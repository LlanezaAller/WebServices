module.exports = (app) => {
    const rootUri = app.get('movies-api-endpoint');
    const httpClient = new(require('node-rest-client').Client)();

    return {
        findByID(id) {
            return new Promise((resolve, reject) => {
                httpClient.get(`${rootUri}/findById`, (data, response) => {
                    console.log('[Movie.Repository] Find by ID Data', data);
                    console.log('[Movie.Repository] Find by ID Response', response);
                    resolve(data);
                });
            })
        },
        searchByTitle(title) {
            return new Promise((resolve, reject) => {
                httpClient.get(`${rootUri}/findByName`, (data, response) => {
                    console.log('[Movie.Repository] Find By Name Data', data);
                    console.log('[Movie.Repository] Find By Name Response', response);
                    resolve(data);
                });
            });
        }
    }
}