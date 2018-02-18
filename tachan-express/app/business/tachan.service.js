module.exports = (app) => {
    const camelcaseKeys = require('camelcase-keys');
    const movieRepository = require('../repository/movie.repository')(app);
    const soundtrackRepository = require('../repository/soundtrack.repository')(app);

    return {
        searchMovies(title) {
            return movieRepository
                .findByTitle(title)
                .then((movies) => movies.Search
                    ? camelcaseKeys(movies.Search, {deep: true})
                    : []);
        },
        getMovie(movieId) {
            return movieRepository
                .findById(movieId)
                .then((movie) => {
                    if (movie.Error) {
                        return {}
                    }
                    movie = camelcaseKeys(movie, {deep: true});
                    return soundtrackRepository
                        .findAlbum(movie.title)
                        .then((albums) => {
                            movie.recommendedSoundtracks = camelcaseKeys(albums, {deep: true});
                            return movie;
                        })
                });
        }
    }
}