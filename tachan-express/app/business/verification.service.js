module.exports = (app) => {
    const repository = require('../repository/verification.repository')(app);
    const validateVerification = (verification) => new Promise((resolve, reject) => {
        if (!verification) {
            reject("The 'verification' object can't be null or undefined.");
        }
        if (!verification.movieId) {
            reject("The attribute 'movieId' can't be null or undefined.");
        }
        if (!verification.albumId) {
            reject("The attribute 'albumId' can't be null or undefined.");
        }
        resolve();
    });

    return {
        find(movieId) {
            return repository.find(movieId);
        },
        update(id, verification) {
            verification = {
                movieId: verification.movieId,
                albumId: verification.albumId
            };
            return validateVerification(verification).then(() => repository.update(id, verification));
        },
        save(verification) {
            verification = {
                movieId: verification.movieId,
                albumId: verification.albumId
            };
            return validateVerification(verification).then(() => repository.save(verification));
        },
        remove(objectId) {
            return repository.remove(objectId);
        }
    }
}