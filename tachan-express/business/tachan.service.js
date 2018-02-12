module.exports = (app) => {
    const movieRepository = require('../repository/movie.repository')(app);
    const soundtrackRepository = require('../repository/soundtrack.repository')(app);

    return {
        searchMovieSoundtrack(title) {
            return movieRepository.searchByTitle(title)
        },
        findMovieSoundtrack(title) {
            return Promise.all(movieRepository.searchByTitle(title), soundtrackRepository.findSoundtrack(title)).then((responses) => {
                console.log('[TachanService] Responses: ', responses)
            });
        }
    }
}