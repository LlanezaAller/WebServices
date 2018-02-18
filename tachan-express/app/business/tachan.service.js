module.exports = (app) => {
    const camelcaseKeys = require('camelcase-keys');
    const movieRepository = require('../repository/movie.repository')(app);
    const soundtrackRepository = require('../repository/soundtrack.repository')(app);
    const verificationRepository = require('../repository/verification.repository')(app);

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
                    return Promise.all([
                        soundtrackRepository.findAlbum(movie.title),
                        verificationRepository.find(movie.imdbId)
                    ]).then((response) => {
                        const albumsResponse = response[0];
                        const verifiedResponse = response[1];

                        movie.recommendedSoundtracks = camelcaseKeys(albumsResponse, {deep: true});
                        movie.verifiedSoundtracks = verifiedResponse.map((ver) => ver.albumId);
                        return movie;
                    })
                });
        }
    }
}