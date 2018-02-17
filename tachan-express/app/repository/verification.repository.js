module.exports = (app) => {
    const ObjectId = require('mongodb').ObjectId;
    const collection = () => app
        .get('db')
        .collection('movieSoundtrackVerifications');

    return {
        find(movieId) {
            return collection().find({}, {movieId}).toArray();
        },
        update(id, verification) {
            if (!ObjectId.isValid(id)) 
                return;
            
            const query = {
                _id: ObjectId(id)
            };
            const update = {
                $set: verification
            }
            return collection()
                .findOneAndUpdate(query, update, {returnOriginal: false})
                .then((res) => res.value);
        },
        save(verification) {
            return collection()
                .insertOne(verification)
                .then(() => verification);
        },
        remove(objectId) {
            return collection()
                .findOneAndDelete({_id: ObjectId(objectId)})
                .then((res) => res.value);
        }
    }
}