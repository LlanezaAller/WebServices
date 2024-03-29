module.exports = (app) => {
    const util = require('./_router.util');
    const service = require('../business/verification.service')(app);
    const rootPublic = '/verification';
    const rootSecured = `/secure${rootPublic}`;

    const router = {
        find: (req, res) => {
            const movieId = req.params.movieId
            service
                .find(movieId)
                .then((response) => res.send(response))
                .catch((err) => util.sendError(res, 400, err));

        },
        update: (req, res) => {
            const objectId = req.params.objectId;
            const verification = req.body;
            service
                .update(objectId, verification)
                .then(response => res.send(response))
                .catch((err) => util.sendError(res, 400, err));
        },
        save: (req, res) => {
            const verification = req.body;
            service
                .save(verification)
                .then(response => res.send(response))
                .catch((err) => util.sendError(res, 400, err));
        },
        remove: (req, res) => {
            const objectId = req.params.objectId;
            service
                .remove(objectId)
                .then(response => res.send(response))
                .catch((err) => util.sendError(res, 400, err));
        }
    }

    console.log(`Verification endpoint init successfully at [${rootPublic}, ${rootSecured}]`)
    app.get(`${rootPublic}/:movieId`, router.find);
    app.put(`${rootSecured}/:objectId`, router.update);
    app.post(`${rootSecured}`, router.save);
    app.delete(`${rootSecured}/:objectId`, router.remove);
}
