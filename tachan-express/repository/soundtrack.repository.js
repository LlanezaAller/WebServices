module.exports = (app) => {
    const rootUri = app.get('music-api-endpoint');
    const httpClient = new(require('node-rest-client').Client)();

    return {
        findSoundtrack(name) {
            return new Promise((resolve, reject) => {
                httpClient.get(`${rootUri}/findById`, (data, response) => {
                    console.log('[SoundTrack.Repository] Find By ID Data', data);
                    console.log('[SoundTrack.Repository] Find By ID Response', response);
                    resolve(data);
                });
            })
        }
    }
}