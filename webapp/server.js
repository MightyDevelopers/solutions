var express = require('express');

var app = express();

app.set('views', '');
app.set('view engine', 'ejs');
// app.engine('html', 'ejs.renderFile');

app.get('/', function(req, res){
	res.render('index');
});

app.use(express.static('app'));

app.listen(3000);

console.log('Server running at http//localhost:3000');