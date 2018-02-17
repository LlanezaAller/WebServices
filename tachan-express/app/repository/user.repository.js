module.exports = (app) => {
    const collection = () => app
        .get('db')
        .collection('users');

    return {
        find(email) {
            return collection().findOne({}, {email});
        },

        save(user) {
            return collection()
                .insertOne(user)
                .then(() => user);
        }
    }
}