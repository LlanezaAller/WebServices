module.exports = (app) => {
    const util = require('./_router.util');
    const service = require('../business/user.service')(app);
    const rootPublic = '/user';

    const router = {
        create: (req, res) => {
            const user = req.body;
            service
                .save(user)
                .then((response) => res.send(response))
                .catch((err) => util.sendError(res, 400, err));

        }
    }

    console.log(`User endpoint init successfully at [${rootPublic}]`)
    app.post(`${rootPublic}`, router.create);
}
