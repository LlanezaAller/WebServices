module.exports = (app) => {
    const repository = require('../repository/user.repository')(app);
    const validateUser = (user) => new Promise((resolve, reject) => {
        if (!user.email || user.email.length < 1) {
            reject("The attribute 'email' can't be null or undefined.");
        }
        if (!user.password || user.password.length < 1) {
            reject("The attribute 'albumId' can't be null or undefined.");
        }
        resolve();
    });

    return {
        find(credentials) {
            return repository
                .find(credentials.email)
                .then((user) => {
                    if (user && user.password === credentials.password) {
                        return user;
                    }
                    throw "User credentials not found";
                })
        },

        save(user) {
            user = {
                email: user.email,
                password: user.password
            };
            return validateUser(user).then(() => repository.save(user));
        }
    }
}