module.exports = (app) => {
    const util = require('./_router.util');
    const service = require('../business/tachan.service')(app);
    const rootPublic = '/movie';

    const router = {
        search: (req, res) => {
            const titleQuery = req.query.title;
            const idQuery = req.query.id;
            if (titleQuery && `${titleQuery}`.trim().length > 0) {
                console.log("Searching for films with title: ", titleQuery);
                service
                    .searchMovies(titleQuery)
                    .then((response) => res.status(200).send(response))
                    .catch((err) => util.sendError(res, 500, err));
            } else if (idQuery && `${idQuery}`.trim().length > 0) {
                console.log("Searching for films with id: ", idQuery);
                service
                    .getMovie(idQuery)
                    .then((response) => res.status(200).send(response))
                    .catch((err) => util.sendError(res, 500, err));
            } else {
                util.sendError(res, 400, error("The 'q' parameter is mandatory.", 400));
            }
        }

    }

    console.log(`Search endpoint init successfully at [${rootPublic}]`)
    app.get(`${rootPublic}`, router.search);
}
