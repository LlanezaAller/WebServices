module.exports = (jwtSecret) => {
    const util = require('../router/_router.util');
    const express = require('express');
    const jwt = require('jsonwebtoken');
    const tokenRouter = express.Router();
    tokenRouter.use((req, res, next) => {
        const token = req.headers.authorization;
        if (token) {
            jwt
                .verify(token, jwtSecret, function (err, tokenInfo) {
                    if (err) {
                        util.sendError(res, 401, "The token is not valid.");
                    } else {
                        next();
                    }
                });
        } else {
            util.sendError(res, 401, "You need to send the Authorization header with a valid token.");
        }
    });
    return tokenRouter;
}