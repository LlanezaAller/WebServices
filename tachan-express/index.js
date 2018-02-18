const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const app = express();
const mongoClient = require('mongodb').MongoClient;
const soap = require('soap');
const jwt = require('jsonwebtoken');

//Configuration
app.set('port', 8080);
app.set('music-api-endpoint', 'http://localhost:8001/services/MusicRS.svc?wsdl');
app.set('movies-api-endpoint', 'http://localhost:8002');
app.set('jwt-secret', '<s4f3tyI$Numb3r0n3Pr10r1ty>');

soap
    .createClientAsync(app.get('music-api-endpoint'))
    .then((client) => {
        console.log("Connected to the music api client successfully.");
        app.set('music-client', client);
    })
    .catch((err) => {
        console.error("Cannot connect to the music api.")
        console.error(error);
        return;
    });
mongoClient.connect('mongodb://localhost:27017', (err, client) => {
    if (err) {
        console.error("Cannot connect to the database.")
        console.error(error);
        return;
    }
    console.log("Connected to the db successfully.");
    app.set('db', client.db('tachan-db'));
});

//Dependencies
app.use(cors());
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));
app.use('/secure', require('./app/middleware/secure.middleware')(app.get('jwt-secret')));

//Routes
require('./app/router/search.router')(app);
require('./app/router/verification.router')(app);
require('./app/router/user.router')(app);
require('./app/router/token.router')(app);

//App init
app.listen(app.get('port'), () => {
    console.log(`Tachan public API server started. Listening to port: ${app.get('port')}`);
})