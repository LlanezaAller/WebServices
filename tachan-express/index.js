const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const app = express();
const mongoClient = require('mongodb').MongoClient;
const jwt = require('jsonwebtoken');

//Configuration
app.set('port', 8080);
app.set('music-api-endpoint', 'http://localhost:8081');
app.set('movies-api-endpoint', 'http://localhost:8082');
app.set('jwt-secret', '<s4f3tyI$Numb3r0n3Pr10r1ty>');

mongoClient.connect('mongodb://localhost:27017', (err, client) => {
    if (err) {
        console.error("Cannot connect to the database.")
        console.error(error);
    }
    console.log("Connected to db successfully.");
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