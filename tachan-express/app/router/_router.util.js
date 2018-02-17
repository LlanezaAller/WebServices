module.exports = {
    sendError(res, errorCode, msg) {
        return res
            .status(errorCode)
            .send({errorCode, msg});
    }
}