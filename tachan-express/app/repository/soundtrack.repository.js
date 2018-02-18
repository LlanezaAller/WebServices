module.exports = (app) => {
    const util = require('util')
    const music = () => app.get('music-client');
    return {
        findAlbum(name) {
            return music()
                .GetMusicFromAsync({search: name})
                .then(response => {
                    const items = response.GetMusicFromResult.albums.Items.Item;
                    if (!Array.isArray(items)) 
                        return [items];
                    return items;
                });
        }
    }
}