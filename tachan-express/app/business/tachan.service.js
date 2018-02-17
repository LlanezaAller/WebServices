module.exports = (app) => {
    const movieRepository = require('../repository/movie.repository')(app);
    const soundtrackRepository = require('../repository/soundtrack.repository')(app);

    return {
        searchMovies(title) {
            return movieRepository.findByTitle(title);
        },
        getMovie(movieId, title) {
            return Promise.all(movieRepository.findById(movieId), soundtrackRepository.findSoundtrack(title)).then((responses) => {
                console.log('[TachanService] Responses: ', responses)
            });
        }
    }
}