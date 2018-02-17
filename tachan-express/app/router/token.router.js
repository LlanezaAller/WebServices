module.exports = (app) => {
    const jwt = require('jsonwebtoken');
    const util = require('./_router.util');
    const service = require('../business/user.service')(app);
    const rootPublic = '/token';

    const router = {
        create: (req, res) => {
            const credentials = req.body;
            service
                .find(credentials)
                .then((user) => {
                    console.log(user);
                    const tokenContents = {
                        "email": user.email,
                        "timestamp": Date.now() / 1000
                    };
                    const response = {
                        token: jwt.sign(tokenContents, app.get('jwt-secret'))
                    }
                    res.send(response);
                })
                .catch((err) => util.sendError(res, 400, err));
        }
    }

    console.log(`Token endpoint init successfully at [${rootPublic}]`)
    app.post(`${rootPublic}`, router.create);
}
