const root = '/search';

const router = {
    search: (req, res) => {
        const query = req.query.q;
        console.log("Searching for films with parameters: ", req);
        if(query && `${query}`.trim().length > 0) {
            const queryResult = {};
            res.status(200).send(queryResult)
        } else {
            res.status(400).send(error("The 'q' parameter is mandatory.", 400))
        }
    }

}
function error(msg, errorCode) {
    return {
        msg,
        errorCode
    }
}

module.exports = (app) => {
    console.log(`Search endpoint init successfully at [${root}]`)
    app.get(`${root}`, router.search);
}

