const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const app = express();

//Configuration
app.set('port', 8080);
app.set('music-api-endpoint', 'http://localhost:8081');
app.set('movies-api-endpoint', 'http://localhost:8082');

//Dependencies
app.use(cors());
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));

//Routes
require('./router/search.router')(app);

//App init
app.listen(app.get('port'), () => {
    console.log(`Tachan public API server started. Listening to port: ${app.get('port')}`);
})