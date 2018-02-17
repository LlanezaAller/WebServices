module.exports = (app) => {
    const util = require('./_router.util');
    const service = require('../business/tachan.service')(app);
    const rootPublic = '/search';

    const router = {
        search: (req, res) => {
            const query = req.query.q;
            console.log("Searching for films with parameters: ", req);
            if (query && `${query}`.trim().length > 0) {
                const queryResult = service.searchMovieSoundtrack;
                res
                    .status(200)
                    .send(queryResult)
            } else {
                util.sendError(res, 400, error("The 'q' parameter is mandatory.", 400));
            }
        }

    }

    console.log(`Search endpoint init successfully at [${rootPublic}]`)
    app.get(`${rootPublic}`, router.search);
}
